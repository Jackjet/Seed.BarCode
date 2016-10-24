using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seed.BarCodeCore.Interface;
using ListBox = System.Web.UI.WebControls.ListBox;

namespace Seed.BarCodeCore.Models
{
    public class Scan:IScan
    {
        public ListBox SmlCodeList;
        public RichTextBox Info;
        public int Count { get; set; }
        private int _bigCodeLen=10;
        private int _smlCodeLen=12;
        private int _specification = 30;
        private string _codeType = "1";
        private string _soundType = "0";
        private readonly SoundPlayer _player = new SoundPlayer();

        public Scan(ListBox list,int productCount,int bigCodeLen,int smlCodeLen,int specification,string codeType,RichTextBox info,string soundType)
        {
            SmlCodeList = list;
            Count = productCount;
            _bigCodeLen = bigCodeLen;
            _smlCodeLen = smlCodeLen;
            _specification = specification;
            _codeType = codeType;
            Info = info;
            _soundType = soundType;
        }
        public void ScanBarCode(string code)
        {
            if (SmlCodeList != null && IsBagFull(SmlCodeList.Items.Count, _specification))
            {
                if (IsBigCode(code, _bigCodeLen))
                {
                    if (!IsAnyBigCode(code))
                    {
                        Count++;
                        InsertCode(code);
                        Play("zy");
                        SmlCodeList.Items.Clear();
                    }
                    else
                    {
                        Log("数据库中已经有相同的条码");
                    }
                }
                else
                {
                    Log("条码错误，请输入大码");
                }
            }
            else
            {
                if (_codeType == "2")
                {
                    code = ReadQrCode(code);
                }
                if (IsAnySmlCodeInList(code))
                {
                    Log("本包装中已经扫描过相同的条码");
                }
                else
                {
                    if (IsAnySmlCode(code))
                    {
                        Log("数据库中存在相同的条码");
                    }
                    else
                    {
                        if ((code.Length == _smlCodeLen))
                        {
                            SmlCodeList.Items.Add(code);
                            Play(SmlCodeList.Items.Count.ToString());
                        }
                        else
                        {
                            Log("小条码长度与配置不符");
                        }
                    }
                }
            }
        }

        //当条码信息为二维码则需要获取第三行数据的条码
        //条码信息格式如下

        //北京XX种业公司
        //岳优9113
        //042710121001
        //http://code.xxxx.com

        //2016-10-13
        //条码枪会自动提出换行，所以修改直接获取第三行数据是错误的
        //逻辑修改为获取http字符前的n位数字，n=小条码长度
        private string ReadQrCode(string code)
        {
            if (code.IndexOf("http", StringComparison.Ordinal) < _smlCodeLen)
            {
                Log("二维码不符合标准！");
                return "";
            }
            return code.Substring(code.IndexOf("http", StringComparison.Ordinal) - _smlCodeLen, _smlCodeLen);
        }

        public void Log(string str)
        {
            if (Info.GetLineFromCharIndex(Info.Text.Length) > 8)
                Info.Text = "";
            Info.AppendText(DateTime.Now + " " + str + "\r\n");
        }

        public bool IsBigCode(string code, int len)
        {
            if (code.Length == len)
                return true;
            else
                return false;
        }
        public bool IsBagFull(int countNow, int countDefault)
        {
            if (countDefault == countNow)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="nb"></param>
        private void Play(string nb)
        {
            //如果为0，即没有声音，1为声音1，2为声音2，3为声音3
            if (_soundType != "0")
            {
                string soundSel;
                if (_soundType == "2")
                {
                    soundSel = "mid1";
                }
                else if (_soundType == "3")
                {
                    soundSel = "mid2";
                }
                else
                {
                    soundSel = "mid0";
                }
                var tempUrl = AppDomain.CurrentDomain.BaseDirectory + soundSel + "\\" + nb + ".wav";
                _player.SoundLocation = tempUrl;
                _player.Play();
            }
        }

        /// <summary>
        /// 当前件已扫描的条码是否跟当前条码重复
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool IsAnySmlCode(string code)
        {
            //if (_storeType == "1")
            //{
            //    LongkeCodeResposities res = new LongkeCodeResposities();
            //    return res.IsAnySmlCode(code);
            //}
            //else
            //{
            //    LongkeCodesResposities res = new LongkeCodesResposities();
            //    return res.IsAnySmlCode(code);
            //}
            return true;
        }

        public bool IsAnySmlCodeInList(string code)
        {
            return SmlCodeList.Items.Cast<string>().Any(str => code == str);
        }

        /// <summary>
        /// 查询是否已有大条码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool IsAnyBigCode(string code)
        {
            //if (_storeType == "1")
            //{
            //    LongkeCodeResposities res = new LongkeCodeResposities();
            //    return res.IsAnyBigCode(code);
            //}
            //else
            //{
            //    LongkeCodesResposities res = new LongkeCodesResposities();
            //    return res.IsAnyBigCode(code);
            //}
            return true;
        }


        /// <summary>
        /// 插入条码
        /// </summary>
        /// <param name="code"></param>
        private void InsertCode(string code)
        {
            //if (_storeType == "1")
            //{
            //    NcHandCode longke = new NcHandCode();
            //    longke.BoxNubs = Nubs.Text;
            //    longke.Patch = Patch.Text;
            //    longke.ProductName = TProductName.Text;
            //    longke.ProductLine = _productLine;
            //    LongkeCodeResposities res = new LongkeCodeResposities();
            //    res.InsertCodes(code, SmlCodeList, longke, _productNubs);
            //}
            //else
            //{
            //    NcHandCodes longke = new NcHandCodes();
            //    longke.BoxNubs = Nubs.Text;
            //    longke.Patch = Patch.Text;
            //    longke.ProductName = TProductName.Text;
            //    longke.ProductLine = _productLine;
            //    LongkeCodesResposities res = new LongkeCodesResposities();
            //    res.InsertCodes(code, SmlCodeList, longke);
            //}
        }
    }
}

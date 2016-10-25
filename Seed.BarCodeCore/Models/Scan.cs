using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seed.BarCodeCore.Interface;
using Seed.BarCodeCore.Resposity;
using ListBox = System.Web.UI.WebControls.ListBox;

namespace Seed.BarCodeCore.Models
{
    public class Scan:IScan
    {
        public ListBox SmlCodeList;
        public RichTextBox Info;
        public int Count { get; set; }
        private readonly int _bigCodeLen=10;
        private readonly int _smlCodeLen=12;
        private readonly int _specification = 30;
        private readonly string _codeType = "1";
        private readonly string _soundType = "0";
        private readonly SoundPlayer _player = new SoundPlayer();
        public IResposity Resposity;
        private readonly Product _curProduct;
        private readonly SystemConfig _curConfig;

        public Scan(ListBox list,int productCount,RichTextBox info,Product product,SystemConfig config)
        {
            SmlCodeList = list;
            Count = productCount;
            _bigCodeLen = config.BigCodeLen;
            _smlCodeLen = config.SmlCodeLen;
            _specification = Convert.ToInt32(product.Specification);
            _codeType = config.CodeType;
            Info = info;
            _soundType = config.SoundType;
            _curProduct = product;
            _curConfig = config;
            if (config.StoreType == "1")
            {
                Resposity = new SqliteResposity();            
            }
            else
            {
                Resposity = new SqlResposity();
            }
        }
        public void ScanBarCode(string code)
        {
            if (SmlCodeList != null && IsBagFull(SmlCodeList.Items.Count, _specification))
            {
                if (IsBigCode(code, _bigCodeLen))
                {
                    if (!Resposity.IsAnyBigCode(code))
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
                    if (Resposity.IsAnySmlCode(code))
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
        private bool IsBigCode(string code, int len)
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
        private bool IsAnySmlCodeInList(string code)
        {
            return SmlCodeList.Items.Cast<string>().Any(str => code == str);
        }
        /// <summary>
        /// 插入条码
        /// </summary>
        /// <param name="code"></param>
        private void InsertCode(string code)
        {
            if (_curConfig.StoreType== "1")
            {              ;
                Resposity.InsertList(BarCodeTist<Product>(code));
            }
            else
            {
                Resposity.InsertList(BarCodeTist<Products>(code));
            }
        }

        private List<T> BarCodeTist<T>(string code) where T : Product, new()
        {
            List<T> list = new List<T>();
            foreach (string str in SmlCodeList.Items)
            {
                T p = new T {Batch = _curProduct.Batch, BigCode = code};
                p.ProductLine = p.ProductLine;
                p.ProductName = p.ProductName;
                p.SmlCode = str;
                p.Specification = p.Specification;
                list.Add(p);
            }
            return list;
        }
    }
}

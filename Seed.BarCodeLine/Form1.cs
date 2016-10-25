using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seed.BarCodeCore.Models;
using Seed.BarCodeCore.Resposity;

namespace Seed.BarCodeLine
{
    public partial class Main : Form
    {
        private Scan _scan;
        private readonly string _soundType = System.Configuration.ConfigurationManager.AppSettings["MusicType"];
        private readonly string _bigCodeLen = System.Configuration.ConfigurationManager.AppSettings["BigCodeLen"];
        private readonly string _smlCodeLen = System.Configuration.ConfigurationManager.AppSettings["SmlCodeLen"];
        private readonly string _codeType = System.Configuration.ConfigurationManager.AppSettings["SmlCodeType"];
        private readonly string _productLine = System.Configuration.ConfigurationManager.AppSettings["ProductLine"];
        private readonly string _storeType = System.Configuration.ConfigurationManager.AppSettings["StoreType"];
        private readonly Product _product = new Product();
        private readonly SystemConfig _config=new SystemConfig();
        private int _count;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (_storeType == "1")
            {
                SqliteResposity resposity = new SqliteResposity();
                _count = resposity.TodayBigCodeCount(_productLine);
            }
            else
            {
                SqlResposity resposity = new SqlResposity();
                _count = resposity.TodayBigCodeCount(_productLine);
            }
            _product.Batch = TBatch.Text;
            _product.ProductLine = _productLine;
            _product.ProductName = TProductName.Text;
            _product.Specification =TNubs.Text;
            _config.BigCodeLen = Convert.ToInt32(_bigCodeLen);
            _config.SmlCodeLen = Convert.ToInt32(_smlCodeLen);
            _config.CodeType = _codeType;
            _config.SoundType = _soundType;
            _config.StoreType = _storeType;
            _scan = new Scan(listCode, _count, info, _product, _config);
        }

        private void Tcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                _scan.ScanBarCode(Tcode.Text.Trim());
                if (listCode.Items.Count == 0)
                    _scan.Log("今天已经包装" + _scan.Count + "件");
                Tcode.Text = "";
            }
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            BtUpdate.Enabled = false;
            Thread thread = new Thread(new ThreadStart(LoadData));
            thread.IsBackground = true;
            thread.Start();
        }

        private void LoadData()
        {
            DateTime beforDt = DateTime.Now;
            SqlResposity res = new SqlResposity();
            int maxId = res.LastUpdateInfo(_productLine);
            SqliteResposity re = new SqliteResposity();
            List<Products> list = re.CodeUpdate(maxId);
            res.InsertList(list);

            this.BeginInvoke(new MethodInvoker(delegate()
            {
                BtUpdate.Enabled = true;
                DateTime afterDt = DateTime.Now;
                TimeSpan ts = afterDt.Subtract(beforDt);
                _scan.Log("上传数据花费：" + ts.TotalSeconds + ".s");
            }));
        }
       
    }
}

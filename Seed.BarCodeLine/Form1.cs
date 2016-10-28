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
        public  Product _product = new Product();
        public SystemConfig _config=new SystemConfig();
        private int _count=0;
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
                    Product p = resposity.LastProduct<Product>();
                    if (p != null)
                    {
                        TNubs.Text = p.Specification;
                        TProductName.Text = p.ProductName;
                        TBatch.Text = p.Batch;
                    }
                }
                else
                {
                    SqlResposity resposity = new SqlResposity();
                    _count = resposity.TodayBigCodeCount(_productLine);
                    Products p = resposity.LastProduct<Products>();
                    if (p != null)
                    {
                        TNubs.Text = p.Specification;
                        TProductName.Text = p.ProductName;
                        TBatch.Text = p.Batch;
                    }
                }
                _config.ProductLine = _productLine;
                _config.BigCodeLen = Convert.ToInt32(_bigCodeLen);
                _config.SmlCodeLen = Convert.ToInt32(_smlCodeLen);
                _config.CodeType = _codeType;
                _config.SoundType = _soundType;
                _config.StoreType = _storeType;
                _scan = new Scan(listCode, _count, info, _product, _config);
            Tcode.Focus();
            _scan.Log("今天已包装" + _count + "件");
        }

        private void Tcode_KeyDown(object sender, KeyEventArgs e)
        {         
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                _scan._curProduct.ProductName = TProductName.Text;
                _scan._curProduct.Batch = TBatch.Text;
                _scan._curProduct.Specification = TNubs.Text;
                _scan.ScanBarCode(Tcode.Text.Trim());
                if (listCode.Items.Count == 0)
                    _scan.Log("今天已经包装" + _scan.Count + "件");
                Tcode.Text = "";
            }
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            BtUpdate.Enabled = false;
            Thread thread = new Thread(new ThreadStart(LoadData)) {IsBackground = true};
            thread.Start();
        }

        private void LoadData()
        {
            DateTime beforDt = DateTime.Now;
            SqlResposity res = new SqlResposity();
           // int maxId = res.LastUpdateInfo(_productLine);
            int maxId = res.LastUpdateId<Products>(_productLine);
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

 
        private void TNubs_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
                _scan.Log("请输入数字");               
            }
  
        }

   
       
    }
}

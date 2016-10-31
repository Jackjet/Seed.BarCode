using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Seed.BarCodeCore.Models;
using Seed.BarCodeCore.Resposity;


namespace Seed.BarCodeStore
{
    public partial class Main : Form
    {
        private readonly string _fileUrl = System.Configuration.ConfigurationManager.AppSettings["FileUrl"];
        readonly string _productLine = System.Configuration.ConfigurationManager.AppSettings["ProductLine"];
        public Main()
        {
            InitializeComponent();
        }

        private void Bt930_Click(object sender, EventArgs e)
        {
            //if (openFile.ShowDialog(this) == DialogResult.OK)
            //{
            //    CodeHelp code = new CodeHelp();
            //    code.ReadDt930(openFile.FileName, _fileUrl);
            //}
        }

        private void BT850_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                CodeScanHelp code = new CodeScanHelp();
                List<Store> list =code.ReadPt850(openFile.FileName, _fileUrl,_productLine);
                info.Text = "";
                foreach (var store in list)
                {
                    info.AppendText("单号："+store.OrderInfo +",物流码："+ store.BigCode+"\r\n");
                }
            }
        }

        private void BtStockUp_Click(object sender, EventArgs e)
        {
            BtStockUp.Enabled = false;
            Thread thread = new Thread(new ThreadStart(LoadStoreData)) {IsBackground = true};
            thread.Start();
        }

        public void LoadStoreData()
        {         
            DateTime beforDt = DateTime.Now;
            SqlResposity res = new SqlResposity();
            int maxId = res.LastUpdateId<Stores>(_productLine);
            SqliteResposity re = new SqliteResposity();
            List<Stores> list = re.StoreUpdate(maxId);
            res.InsertList(list);

            this.BeginInvoke(new MethodInvoker(delegate()
            {
                BtStockUp.Enabled = true;
                DateTime afterDt = DateTime.Now;
                TimeSpan ts = afterDt.Subtract(beforDt);
                info.AppendText("上传数据" + list.Count + "条.\r\n");
                info.AppendText("上传数据花费：" + ts.TotalSeconds + ".s\r\n");
            }));
        }

        private void BtSaleBaseUp_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                ExcelHelper eh = new ExcelHelper(openFile.FileName);
                List<Sale> list = eh.XlsToSales(_productLine);
                SqliteResposity res = new SqliteResposity();
                info.Text = "";
                foreach (var store in list)
                {
                    info.AppendText("单号：" + store.OrderInfo + ",客户信息：" + store.SaleInfo + "\r\n");
                }
                res.InsertList(list);
            }
        }

        private void SaleUpService_Click(object sender, EventArgs e)
        {
            SaleUpService.Enabled = false;
            Thread thread = new Thread(new ThreadStart(LoadSalesData)) { IsBackground = true };
            thread.Start();
        }

        public void LoadSalesData()
        {
            DateTime beforDt = DateTime.Now;
            SqlResposity res = new SqlResposity();
            int maxId = res.LastUpdateId<Sales>(_productLine);
            SqliteResposity re = new SqliteResposity();
            List<Sales> list = re.SaleUpdate(maxId);
            res.InsertList(list);

            this.BeginInvoke(new MethodInvoker(delegate()
            {
                SaleUpService.Enabled = true;
                DateTime afterDt = DateTime.Now;
                TimeSpan ts = afterDt.Subtract(beforDt);
                info.AppendText("上传数据" + list.Count + "条.\r\n");
                info.AppendText("上传数据花费：" + ts.TotalSeconds + ".s\r\n");
            }));
        }
    }
}

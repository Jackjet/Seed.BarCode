using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Seed.BarCodeCore.Models;
using Seed.BarCodeCore.Resposity;


namespace Seed.BarCodeStore
{
    public partial class Main : Form
    {
        private readonly string _fileUrl = System.Configuration.ConfigurationManager.AppSettings["FileUrl"];
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
                code.ReadPt850(openFile.FileName, _fileUrl);
            }
        }

        private void BtStockUp_Click(object sender, EventArgs e)
        {
            BtStockUp.Enabled = false;
            Thread thread = new Thread(new ThreadStart(LoadStockData)) {IsBackground = true};
            thread.Start();
        }

        public void LoadStockData()
        {
            string productLine = System.Configuration.ConfigurationManager.AppSettings["ProductLine"];
            DateTime beforDt = DateTime.Now;
            SqlResposity res = new SqlResposity();
            int maxId = res.LastUpdateId<Stores>(productLine);
            SqliteResposity re = new SqliteResposity();
            List<Stores> list = re.StoreUpdate(maxId);
            res.InsertList(list);

            this.BeginInvoke(new MethodInvoker(delegate()
            {
                BtStockUp.Enabled = true;
                DateTime afterDt = DateTime.Now;
                TimeSpan ts = afterDt.Subtract(beforDt);
                MessageBox.Show("上传数据花费：" + ts.TotalSeconds + ".s");
            }));
        }

        private void BtSaleBaseUp_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                ExcelHelper eh = new ExcelHelper(openFile.FileName);
                List<Sale> list = eh.XlsToSales();
                SqliteResposity res = new SqliteResposity();
                res.InsertList(list);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;
using Seed.StockOutScan.Models;
using Seed.BarCodeStore.Public;
using Seed.BarCodeStore.Reposities;

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
                CodeHelp code = new CodeHelp();
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
            DateTime beforDt = DateTime.Now;
            NcSaleInfoResposities res = new NcSaleInfoResposities();
            int maxId = res.LastUpdateInfo();
            NcHandSaleInfoResposities re = new NcHandSaleInfoResposities();
            List<NcSaleInfo> list = re.Update(maxId);
            res.InsertCodes(list);

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
                List<NcSaleBase> list = eh.XlsToSales();
                NcSaleInfoResposities res = new NcSaleInfoResposities();
                res.InsertCodes(list);
            }
        }
    }
}

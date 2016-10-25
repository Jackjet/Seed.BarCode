using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seed.BarCodeCore.Models;

namespace Seed.BarCodeLine
{
    public partial class Main : Form
    {
        private Scan Scan;
        private readonly string _soundType = System.Configuration.ConfigurationManager.AppSettings["MusicType"];
        private readonly string _bigCodeLen = System.Configuration.ConfigurationManager.AppSettings["BigCodeLen"];
        private readonly string _smlCodeLen = System.Configuration.ConfigurationManager.AppSettings["SmlCodeLen"];
        private readonly string _codeType = System.Configuration.ConfigurationManager.AppSettings["SmlCodeType"];
        private readonly string _productLine = System.Configuration.ConfigurationManager.AppSettings["ProductLine"];
        private readonly string _storeType = System.Configuration.ConfigurationManager.AppSettings["StoreType"];
        private Product product = new Product();
        private int Count;
        private SystemConfig config=new SystemConfig();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            product.Batch = TBatch.Text;
            product.ProductLine = _productLine;
            product.ProductName = TProductName.Text;
            product.Specification =TNubs.Text;
            config.BigCodeLen = Convert.ToInt32(_bigCodeLen);
            config.SmlCodeLen = Convert.ToInt32(_smlCodeLen);
            config.CodeType = _codeType;
            config.SoundType = _soundType;
            config.StoreType = _soundType;
            Scan = new Scan(listCode, Count, info, product, config);
        }

        private void Tcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Scan.ScanBarCode(Tcode.Text.Trim());
                if (listCode.Items.Count == 0)
                    Scan.Log("今天已经包装" + Count + "件");
                Tcode.Text = "";
            }
        }

       
    }
}

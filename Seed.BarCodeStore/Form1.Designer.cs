namespace Seed.BarCodeStore
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.BT850 = new System.Windows.Forms.Button();
            this.BtStockUp = new System.Windows.Forms.Button();
            this.BtSaleBaseUp = new System.Windows.Forms.Button();
            this.SaleUpService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // BT850
            // 
            this.BT850.Location = new System.Drawing.Point(12, 12);
            this.BT850.Name = "BT850";
            this.BT850.Size = new System.Drawing.Size(175, 41);
            this.BT850.TabIndex = 1;
            this.BT850.Text = "导入PT800";
            this.BT850.UseVisualStyleBackColor = true;
            this.BT850.Click += new System.EventHandler(this.BT850_Click);
            // 
            // BtStockUp
            // 
            this.BtStockUp.Location = new System.Drawing.Point(12, 231);
            this.BtStockUp.Name = "BtStockUp";
            this.BtStockUp.Size = new System.Drawing.Size(175, 41);
            this.BtStockUp.TabIndex = 2;
            this.BtStockUp.Text = "出库信息上传";
            this.BtStockUp.UseVisualStyleBackColor = true;
            this.BtStockUp.Click += new System.EventHandler(this.BtStockUp_Click);
            // 
            // BtSaleBaseUp
            // 
            this.BtSaleBaseUp.Location = new System.Drawing.Point(12, 83);
            this.BtSaleBaseUp.Name = "BtSaleBaseUp";
            this.BtSaleBaseUp.Size = new System.Drawing.Size(175, 41);
            this.BtSaleBaseUp.TabIndex = 3;
            this.BtSaleBaseUp.Text = "销售信息导入";
            this.BtSaleBaseUp.UseVisualStyleBackColor = true;
            this.BtSaleBaseUp.Click += new System.EventHandler(this.BtSaleBaseUp_Click);
            // 
            // SaleUpService
            // 
            this.SaleUpService.Location = new System.Drawing.Point(12, 304);
            this.SaleUpService.Name = "SaleUpService";
            this.SaleUpService.Size = new System.Drawing.Size(175, 41);
            this.SaleUpService.TabIndex = 4;
            this.SaleUpService.Text = "销售信息上传";
            this.SaleUpService.UseVisualStyleBackColor = true;
            this.SaleUpService.Click += new System.EventHandler(this.SaleUpService_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.SaleUpService);
            this.Controls.Add(this.BtSaleBaseUp);
            this.Controls.Add(this.BtStockUp);
            this.Controls.Add(this.BT850);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出库信息";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button BT850;
        private System.Windows.Forms.Button BtStockUp;
        private System.Windows.Forms.Button BtSaleBaseUp;
        private System.Windows.Forms.Button SaleUpService;
    }
}


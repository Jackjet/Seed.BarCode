namespace Seed.BarCodeLine
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
            this.listCode = new System.Windows.Forms.ListBox();
            this.Tcode = new System.Windows.Forms.TextBox();
            this.info = new System.Windows.Forms.RichTextBox();
            this.TBatch = new System.Windows.Forms.TextBox();
            this.TNubs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LName = new System.Windows.Forms.Label();
            this.TProductName = new System.Windows.Forms.TextBox();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listCode
            // 
            this.listCode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listCode.FormattingEnabled = true;
            this.listCode.ItemHeight = 20;
            this.listCode.Location = new System.Drawing.Point(12, 51);
            this.listCode.Name = "listCode";
            this.listCode.Size = new System.Drawing.Size(166, 344);
            this.listCode.TabIndex = 0;
            // 
            // Tcode
            // 
            this.Tcode.Location = new System.Drawing.Point(13, 13);
            this.Tcode.Name = "Tcode";
            this.Tcode.Size = new System.Drawing.Size(165, 34);
            this.Tcode.TabIndex = 1;
            this.Tcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tcode_KeyDown);
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(476, 16);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(222, 379);
            this.info.TabIndex = 2;
            this.info.Text = "";
            // 
            // TBatch
            // 
            this.TBatch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBatch.Location = new System.Drawing.Point(270, 151);
            this.TBatch.Margin = new System.Windows.Forms.Padding(4);
            this.TBatch.Name = "TBatch";
            this.TBatch.Size = new System.Drawing.Size(195, 29);
            this.TBatch.TabIndex = 12;
            this.TBatch.Text = "16101301";
            // 
            // TNubs
            // 
            this.TNubs.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TNubs.Location = new System.Drawing.Point(270, 16);
            this.TNubs.Margin = new System.Windows.Forms.Padding(4);
            this.TNubs.MaxLength = 3;
            this.TNubs.Name = "TNubs";
            this.TNubs.Size = new System.Drawing.Size(195, 29);
            this.TNubs.TabIndex = 10;
            this.TNubs.Text = "30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(194, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "规格：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(192, 156);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "批次：";
            // 
            // LName
            // 
            this.LName.AutoSize = true;
            this.LName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LName.Location = new System.Drawing.Point(193, 85);
            this.LName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LName.Name = "LName";
            this.LName.Size = new System.Drawing.Size(58, 21);
            this.LName.TabIndex = 14;
            this.LName.Text = "品种：";
            // 
            // TProductName
            // 
            this.TProductName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TProductName.Location = new System.Drawing.Point(270, 84);
            this.TProductName.Margin = new System.Windows.Forms.Padding(4);
            this.TProductName.Name = "TProductName";
            this.TProductName.Size = new System.Drawing.Size(195, 29);
            this.TProductName.TabIndex = 11;
            this.TProductName.Text = "天优华占";
            // 
            // BtUpdate
            // 
            this.BtUpdate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtUpdate.Location = new System.Drawing.Point(196, 352);
            this.BtUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(259, 42);
            this.BtUpdate.TabIndex = 16;
            this.BtUpdate.Text = "上传服务器";
            this.BtUpdate.UseVisualStyleBackColor = true;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 407);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.TBatch);
            this.Controls.Add(this.TNubs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LName);
            this.Controls.Add(this.TProductName);
            this.Controls.Add(this.info);
            this.Controls.Add(this.Tcode);
            this.Controls.Add(this.listCode);
            this.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Main";
            this.Text = "通用扫描";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listCode;
        private System.Windows.Forms.TextBox Tcode;
        private System.Windows.Forms.RichTextBox info;
        private System.Windows.Forms.TextBox TBatch;
        private System.Windows.Forms.TextBox TNubs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LName;
        private System.Windows.Forms.TextBox TProductName;
        private System.Windows.Forms.Button BtUpdate;
    }
}


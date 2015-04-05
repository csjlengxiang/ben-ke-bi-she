namespace 列控培训平台操控系统.查询
{
    partial class 查询界面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_查询车站 = new System.Windows.Forms.ComboBox();
            this.cb_车站设备 = new System.Windows.Forms.ComboBox();
            this.dgv_查询数据 = new System.Windows.Forms.DataGridView();
            this.lb_车站名 = new System.Windows.Forms.Label();
            this.lb_信号设备 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_查询数据)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_查询车站
            // 
            this.cb_查询车站.FormattingEnabled = true;
            this.cb_查询车站.Location = new System.Drawing.Point(219, 25);
            this.cb_查询车站.Name = "cb_查询车站";
            this.cb_查询车站.Size = new System.Drawing.Size(121, 20);
            this.cb_查询车站.TabIndex = 0;
            // 
            // cb_车站设备
            // 
            this.cb_车站设备.FormattingEnabled = true;
            this.cb_车站设备.Items.AddRange(new object[] {
            "信号机",
            "股道",
            "道岔"});
            this.cb_车站设备.Location = new System.Drawing.Point(428, 25);
            this.cb_车站设备.Name = "cb_车站设备";
            this.cb_车站设备.Size = new System.Drawing.Size(121, 20);
            this.cb_车站设备.TabIndex = 1;
            this.cb_车站设备.SelectedIndexChanged += new System.EventHandler(this.cb_车站设备_SelectedIndexChanged);
            // 
            // dgv_查询数据
            // 
            this.dgv_查询数据.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_查询数据.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_查询数据.Location = new System.Drawing.Point(-4, 62);
            this.dgv_查询数据.Name = "dgv_查询数据";
            this.dgv_查询数据.RowTemplate.Height = 23;
            this.dgv_查询数据.Size = new System.Drawing.Size(773, 502);
            this.dgv_查询数据.TabIndex = 2;
            // 
            // lb_车站名
            // 
            this.lb_车站名.AutoSize = true;
            this.lb_车站名.Location = new System.Drawing.Point(182, 28);
            this.lb_车站名.Name = "lb_车站名";
            this.lb_车站名.Size = new System.Drawing.Size(41, 12);
            this.lb_车站名.TabIndex = 3;
            this.lb_车站名.Text = "车站：";
            // 
            // lb_信号设备
            // 
            this.lb_信号设备.AutoSize = true;
            this.lb_信号设备.Location = new System.Drawing.Point(367, 28);
            this.lb_信号设备.Name = "lb_信号设备";
            this.lb_信号设备.Size = new System.Drawing.Size(65, 12);
            this.lb_信号设备.TabIndex = 4;
            this.lb_信号设备.Text = "信号设备：";
            // 
            // 查询界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 562);
            this.Controls.Add(this.lb_信号设备);
            this.Controls.Add(this.lb_车站名);
            this.Controls.Add(this.dgv_查询数据);
            this.Controls.Add(this.cb_车站设备);
            this.Controls.Add(this.cb_查询车站);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "查询界面";
            this.Text = "查询界面";
            this.Load += new System.EventHandler(this.查询界面_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_查询数据)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_查询车站;
        private System.Windows.Forms.ComboBox cb_车站设备;
        private System.Windows.Forms.DataGridView dgv_查询数据;
        private System.Windows.Forms.Label lb_车站名;
        private System.Windows.Forms.Label lb_信号设备;
    }
}
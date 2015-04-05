namespace 列控培训平台操控系统.列车初始化
{
    partial class 列车初始化界面
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
            this.label_车次号 = new System.Windows.Forms.Label();
            this.tb_车次号 = new System.Windows.Forms.TextBox();
            this.panel_站内区间选择 = new System.Windows.Forms.Panel();
            this.rb_区间 = new System.Windows.Forms.RadioButton();
            this.rb_站内 = new System.Windows.Forms.RadioButton();
            this.panel_区段 = new System.Windows.Forms.Panel();
            this.rb_区段反向 = new System.Windows.Forms.RadioButton();
            this.rb_区段正向 = new System.Windows.Forms.RadioButton();
            this.cb_区段 = new System.Windows.Forms.ComboBox();
            this.label_区段 = new System.Windows.Forms.Label();
            this.panel_站内 = new System.Windows.Forms.Panel();
            this.label_选择股道 = new System.Windows.Forms.Label();
            this.label_选择车站 = new System.Windows.Forms.Label();
            this.rb_反向 = new System.Windows.Forms.RadioButton();
            this.rb_正向 = new System.Windows.Forms.RadioButton();
            this.tb_反向 = new System.Windows.Forms.TextBox();
            this.tb_正向 = new System.Windows.Forms.TextBox();
            this.cb_选择股道 = new System.Windows.Forms.ComboBox();
            this.cb_选择站名 = new System.Windows.Forms.ComboBox();
            this.btn_确定 = new System.Windows.Forms.Button();
            this.btn_取消 = new System.Windows.Forms.Button();
            this.lb_车长 = new System.Windows.Forms.Label();
            this.tb_车长 = new System.Windows.Forms.TextBox();
            this.panel_站内区间选择.SuspendLayout();
            this.panel_区段.SuspendLayout();
            this.panel_站内.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_车次号
            // 
            this.label_车次号.AutoSize = true;
            this.label_车次号.Location = new System.Drawing.Point(41, 28);
            this.label_车次号.Name = "label_车次号";
            this.label_车次号.Size = new System.Drawing.Size(53, 12);
            this.label_车次号.TabIndex = 0;
            this.label_车次号.Text = "车次号：";
            // 
            // tb_车次号
            // 
            this.tb_车次号.Location = new System.Drawing.Point(100, 25);
            this.tb_车次号.Name = "tb_车次号";
            this.tb_车次号.Size = new System.Drawing.Size(100, 21);
            this.tb_车次号.TabIndex = 1;
            // 
            // panel_站内区间选择
            // 
            this.panel_站内区间选择.Controls.Add(this.rb_区间);
            this.panel_站内区间选择.Controls.Add(this.rb_站内);
            this.panel_站内区间选择.Location = new System.Drawing.Point(235, 28);
            this.panel_站内区间选择.Name = "panel_站内区间选择";
            this.panel_站内区间选择.Size = new System.Drawing.Size(213, 46);
            this.panel_站内区间选择.TabIndex = 2;
            // 
            // rb_区间
            // 
            this.rb_区间.AutoSize = true;
            this.rb_区间.Location = new System.Drawing.Point(115, 16);
            this.rb_区间.Name = "rb_区间";
            this.rb_区间.Size = new System.Drawing.Size(83, 16);
            this.rb_区间.TabIndex = 1;
            this.rb_区间.Text = "列车在区间";
            this.rb_区间.UseVisualStyleBackColor = true;
            this.rb_区间.Click += new System.EventHandler(this.rb_区间_Click);
            // 
            // rb_站内
            // 
            this.rb_站内.AutoSize = true;
            this.rb_站内.Checked = true;
            this.rb_站内.Location = new System.Drawing.Point(24, 15);
            this.rb_站内.Name = "rb_站内";
            this.rb_站内.Size = new System.Drawing.Size(83, 16);
            this.rb_站内.TabIndex = 0;
            this.rb_站内.TabStop = true;
            this.rb_站内.Text = "列车在站内";
            this.rb_站内.UseVisualStyleBackColor = true;
            this.rb_站内.Click += new System.EventHandler(this.rb_站内_Click);
            // 
            // panel_区段
            // 
            this.panel_区段.Controls.Add(this.rb_区段反向);
            this.panel_区段.Controls.Add(this.rb_区段正向);
            this.panel_区段.Controls.Add(this.cb_区段);
            this.panel_区段.Controls.Add(this.label_区段);
            this.panel_区段.Location = new System.Drawing.Point(79, 120);
            this.panel_区段.Name = "panel_区段";
            this.panel_区段.Size = new System.Drawing.Size(334, 183);
            this.panel_区段.TabIndex = 3;
            this.panel_区段.Visible = false;
            // 
            // rb_区段反向
            // 
            this.rb_区段反向.AutoSize = true;
            this.rb_区段反向.Location = new System.Drawing.Point(75, 138);
            this.rb_区段反向.Name = "rb_区段反向";
            this.rb_区段反向.Size = new System.Drawing.Size(71, 16);
            this.rb_区段反向.TabIndex = 3;
            this.rb_区段反向.TabStop = true;
            this.rb_区段反向.Text = "上行方向";
            this.rb_区段反向.UseVisualStyleBackColor = true;
            // 
            // rb_区段正向
            // 
            this.rb_区段正向.AutoSize = true;
            this.rb_区段正向.Location = new System.Drawing.Point(75, 106);
            this.rb_区段正向.Name = "rb_区段正向";
            this.rb_区段正向.Size = new System.Drawing.Size(71, 16);
            this.rb_区段正向.TabIndex = 2;
            this.rb_区段正向.TabStop = true;
            this.rb_区段正向.Text = "下行方向";
            this.rb_区段正向.UseVisualStyleBackColor = true;
            // 
            // cb_区段
            // 
            this.cb_区段.FormattingEnabled = true;
            this.cb_区段.Location = new System.Drawing.Point(145, 55);
            this.cb_区段.Name = "cb_区段";
            this.cb_区段.Size = new System.Drawing.Size(107, 20);
            this.cb_区段.TabIndex = 1;
            // 
            // label_区段
            // 
            this.label_区段.AutoSize = true;
            this.label_区段.Location = new System.Drawing.Point(73, 58);
            this.label_区段.Name = "label_区段";
            this.label_区段.Size = new System.Drawing.Size(53, 12);
            this.label_区段.TabIndex = 0;
            this.label_区段.Text = "区段名：";
            // 
            // panel_站内
            // 
            this.panel_站内.Controls.Add(this.label_选择股道);
            this.panel_站内.Controls.Add(this.label_选择车站);
            this.panel_站内.Controls.Add(this.rb_反向);
            this.panel_站内.Controls.Add(this.rb_正向);
            this.panel_站内.Controls.Add(this.tb_反向);
            this.panel_站内.Controls.Add(this.tb_正向);
            this.panel_站内.Controls.Add(this.cb_选择股道);
            this.panel_站内.Controls.Add(this.cb_选择站名);
            this.panel_站内.Location = new System.Drawing.Point(100, 135);
            this.panel_站内.Name = "panel_站内";
            this.panel_站内.Size = new System.Drawing.Size(281, 156);
            this.panel_站内.TabIndex = 8;
            // 
            // label_选择股道
            // 
            this.label_选择股道.AutoSize = true;
            this.label_选择股道.Location = new System.Drawing.Point(149, 13);
            this.label_选择股道.Name = "label_选择股道";
            this.label_选择股道.Size = new System.Drawing.Size(77, 12);
            this.label_选择股道.TabIndex = 16;
            this.label_选择股道.Text = "选择车站股道";
            // 
            // label_选择车站
            // 
            this.label_选择车站.AutoSize = true;
            this.label_选择车站.Location = new System.Drawing.Point(17, 13);
            this.label_选择车站.Name = "label_选择车站";
            this.label_选择车站.Size = new System.Drawing.Size(53, 12);
            this.label_选择车站.TabIndex = 15;
            this.label_选择车站.Text = "选择车站";
            // 
            // rb_反向
            // 
            this.rb_反向.AutoSize = true;
            this.rb_反向.Location = new System.Drawing.Point(17, 123);
            this.rb_反向.Name = "rb_反向";
            this.rb_反向.Size = new System.Drawing.Size(155, 16);
            this.rb_反向.TabIndex = 14;
            this.rb_反向.TabStop = true;
            this.rb_反向.Text = "距离反向出站信号机距离";
            this.rb_反向.UseVisualStyleBackColor = true;
            this.rb_反向.CheckedChanged += new System.EventHandler(this.rb_反向_CheckedChanged);
            // 
            // rb_正向
            // 
            this.rb_正向.AutoSize = true;
            this.rb_正向.Location = new System.Drawing.Point(17, 91);
            this.rb_正向.Name = "rb_正向";
            this.rb_正向.Size = new System.Drawing.Size(155, 16);
            this.rb_正向.TabIndex = 13;
            this.rb_正向.TabStop = true;
            this.rb_正向.Text = "距离正向出站信号机距离";
            this.rb_正向.UseVisualStyleBackColor = true;
            this.rb_正向.CheckedChanged += new System.EventHandler(this.rb_正向_CheckedChanged);
            // 
            // tb_反向
            // 
            this.tb_反向.Location = new System.Drawing.Point(175, 123);
            this.tb_反向.Name = "tb_反向";
            this.tb_反向.Size = new System.Drawing.Size(90, 21);
            this.tb_反向.TabIndex = 12;
            // 
            // tb_正向
            // 
            this.tb_正向.Location = new System.Drawing.Point(175, 91);
            this.tb_正向.Name = "tb_正向";
            this.tb_正向.Size = new System.Drawing.Size(90, 21);
            this.tb_正向.TabIndex = 9;
            // 
            // cb_选择股道
            // 
            this.cb_选择股道.FormattingEnabled = true;
            this.cb_选择股道.Location = new System.Drawing.Point(151, 31);
            this.cb_选择股道.Name = "cb_选择股道";
            this.cb_选择股道.Size = new System.Drawing.Size(114, 20);
            this.cb_选择股道.TabIndex = 1;
            // 
            // cb_选择站名
            // 
            this.cb_选择站名.FormattingEnabled = true;
            this.cb_选择站名.Location = new System.Drawing.Point(17, 31);
            this.cb_选择站名.Name = "cb_选择站名";
            this.cb_选择站名.Size = new System.Drawing.Size(112, 20);
            this.cb_选择站名.TabIndex = 0;
            this.cb_选择站名.SelectedIndexChanged += new System.EventHandler(this.cb_选择站名_SelectedIndexChanged);
            // 
            // btn_确定
            // 
            this.btn_确定.Location = new System.Drawing.Point(117, 338);
            this.btn_确定.Name = "btn_确定";
            this.btn_确定.Size = new System.Drawing.Size(100, 41);
            this.btn_确定.TabIndex = 9;
            this.btn_确定.Text = "确定";
            this.btn_确定.UseVisualStyleBackColor = true;
            this.btn_确定.Click += new System.EventHandler(this.btn_确定_Click);
            // 
            // btn_取消
            // 
            this.btn_取消.Location = new System.Drawing.Point(265, 338);
            this.btn_取消.Name = "btn_取消";
            this.btn_取消.Size = new System.Drawing.Size(100, 41);
            this.btn_取消.TabIndex = 10;
            this.btn_取消.Text = "取消";
            this.btn_取消.UseVisualStyleBackColor = true;
            this.btn_取消.Click += new System.EventHandler(this.btn_取消_Click);
            // 
            // lb_车长
            // 
            this.lb_车长.AutoSize = true;
            this.lb_车长.Location = new System.Drawing.Point(41, 61);
            this.lb_车长.Name = "lb_车长";
            this.lb_车长.Size = new System.Drawing.Size(41, 12);
            this.lb_车长.TabIndex = 11;
            this.lb_车长.Text = "车长：";
            // 
            // tb_车长
            // 
            this.tb_车长.Location = new System.Drawing.Point(100, 58);
            this.tb_车长.Name = "tb_车长";
            this.tb_车长.Size = new System.Drawing.Size(100, 21);
            this.tb_车长.TabIndex = 12;
            // 
            // 列车初始化界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 440);
            this.Controls.Add(this.tb_车长);
            this.Controls.Add(this.lb_车长);
            this.Controls.Add(this.btn_取消);
            this.Controls.Add(this.panel_区段);
            this.Controls.Add(this.panel_站内);
            this.Controls.Add(this.btn_确定);
            this.Controls.Add(this.panel_站内区间选择);
            this.Controls.Add(this.tb_车次号);
            this.Controls.Add(this.label_车次号);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "列车初始化界面";
            this.Text = "列车初始化界面";
            this.Load += new System.EventHandler(this.列车初始化界面_Load);
            this.panel_站内区间选择.ResumeLayout(false);
            this.panel_站内区间选择.PerformLayout();
            this.panel_区段.ResumeLayout(false);
            this.panel_区段.PerformLayout();
            this.panel_站内.ResumeLayout(false);
            this.panel_站内.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_车次号;
        private System.Windows.Forms.TextBox tb_车次号;
        private System.Windows.Forms.Panel panel_站内区间选择;
        private System.Windows.Forms.RadioButton rb_区间;
        private System.Windows.Forms.RadioButton rb_站内;
        private System.Windows.Forms.Panel panel_区段;
        private System.Windows.Forms.ComboBox cb_区段;
        private System.Windows.Forms.Label label_区段;
        public System.Windows.Forms.Panel panel_站内;
        private System.Windows.Forms.Label label_选择股道;
        private System.Windows.Forms.Label label_选择车站;
        private System.Windows.Forms.RadioButton rb_反向;
        private System.Windows.Forms.RadioButton rb_正向;
        public System.Windows.Forms.TextBox tb_反向;
        public System.Windows.Forms.TextBox tb_正向;
        public System.Windows.Forms.ComboBox cb_选择股道;
        public System.Windows.Forms.ComboBox cb_选择站名;
        private System.Windows.Forms.Button btn_确定;
        private System.Windows.Forms.Button btn_取消;
        private System.Windows.Forms.RadioButton rb_区段反向;
        private System.Windows.Forms.RadioButton rb_区段正向;
        private System.Windows.Forms.Label lb_车长;
        private System.Windows.Forms.TextBox tb_车长;
    }
}
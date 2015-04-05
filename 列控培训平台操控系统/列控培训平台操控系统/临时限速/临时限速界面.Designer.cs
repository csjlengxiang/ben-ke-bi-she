namespace 列控培训平台操控系统.临时限速
{
    partial class 临时限速界面
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
            this.gb_基本项 = new System.Windows.Forms.GroupBox();
            this.lb_m2 = new System.Windows.Forms.Label();
            this.lb_km2 = new System.Windows.Forms.Label();
            this.lb_线路 = new System.Windows.Forms.Label();
            this.cb_线路 = new System.Windows.Forms.ComboBox();
            this.lb_车站 = new System.Windows.Forms.Label();
            this.cb_限速值 = new System.Windows.Forms.ComboBox();
            this.cb_车站 = new System.Windows.Forms.ComboBox();
            this.tb_endkm = new System.Windows.Forms.TextBox();
            this.tb_startm = new System.Windows.Forms.TextBox();
            this.tb_endm = new System.Windows.Forms.TextBox();
            this.tb_startkm = new System.Windows.Forms.TextBox();
            this.lb_m1 = new System.Windows.Forms.Label();
            this.lb_结束公里标 = new System.Windows.Forms.Label();
            this.lb_限速值 = new System.Windows.Forms.Label();
            this.lb_km1 = new System.Windows.Forms.Label();
            this.lb_开始公里标 = new System.Windows.Forms.Label();
            this.cb_命令类型 = new System.Windows.Forms.ComboBox();
            this.lb_命令类型 = new System.Windows.Forms.Label();
            this.cb_限速原因 = new System.Windows.Forms.ComboBox();
            this.lb_限速原因 = new System.Windows.Forms.Label();
            this.gb_开始时间 = new System.Windows.Forms.GroupBox();
            this.rb_立即执行 = new System.Windows.Forms.RadioButton();
            this.rb_定时开始 = new System.Windows.Forms.RadioButton();
            this.gb_结束时间 = new System.Windows.Forms.GroupBox();
            this.rb_持久有效 = new System.Windows.Forms.RadioButton();
            this.rb_定时结束 = new System.Windows.Forms.RadioButton();
            this.btn_确定 = new System.Windows.Forms.Button();
            this.btn_取消 = new System.Windows.Forms.Button();
            this.cb_定时开始 = new System.Windows.Forms.ComboBox();
            this.cb_定时结束 = new System.Windows.Forms.ComboBox();
            this.gb_基本项.SuspendLayout();
            this.gb_开始时间.SuspendLayout();
            this.gb_结束时间.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_基本项
            // 
            this.gb_基本项.Controls.Add(this.lb_m2);
            this.gb_基本项.Controls.Add(this.lb_km2);
            this.gb_基本项.Controls.Add(this.lb_线路);
            this.gb_基本项.Controls.Add(this.cb_线路);
            this.gb_基本项.Controls.Add(this.lb_车站);
            this.gb_基本项.Controls.Add(this.cb_限速值);
            this.gb_基本项.Controls.Add(this.cb_车站);
            this.gb_基本项.Controls.Add(this.tb_endkm);
            this.gb_基本项.Controls.Add(this.tb_startm);
            this.gb_基本项.Controls.Add(this.tb_endm);
            this.gb_基本项.Controls.Add(this.tb_startkm);
            this.gb_基本项.Controls.Add(this.lb_m1);
            this.gb_基本项.Controls.Add(this.lb_结束公里标);
            this.gb_基本项.Controls.Add(this.lb_限速值);
            this.gb_基本项.Controls.Add(this.lb_km1);
            this.gb_基本项.Controls.Add(this.lb_开始公里标);
            this.gb_基本项.Controls.Add(this.cb_命令类型);
            this.gb_基本项.Controls.Add(this.lb_命令类型);
            this.gb_基本项.Controls.Add(this.cb_限速原因);
            this.gb_基本项.Controls.Add(this.lb_限速原因);
            this.gb_基本项.Location = new System.Drawing.Point(26, 28);
            this.gb_基本项.Name = "gb_基本项";
            this.gb_基本项.Size = new System.Drawing.Size(331, 237);
            this.gb_基本项.TabIndex = 0;
            this.gb_基本项.TabStop = false;
            this.gb_基本项.Text = "基本项";
            // 
            // lb_m2
            // 
            this.lb_m2.AutoSize = true;
            this.lb_m2.Location = new System.Drawing.Point(291, 178);
            this.lb_m2.Name = "lb_m2";
            this.lb_m2.Size = new System.Drawing.Size(11, 12);
            this.lb_m2.TabIndex = 19;
            this.lb_m2.Text = "m";
            // 
            // lb_km2
            // 
            this.lb_km2.AutoSize = true;
            this.lb_km2.Location = new System.Drawing.Point(179, 178);
            this.lb_km2.Name = "lb_km2";
            this.lb_km2.Size = new System.Drawing.Size(23, 12);
            this.lb_km2.TabIndex = 18;
            this.lb_km2.Text = "km+";
            // 
            // lb_线路
            // 
            this.lb_线路.AutoSize = true;
            this.lb_线路.Location = new System.Drawing.Point(42, 109);
            this.lb_线路.Name = "lb_线路";
            this.lb_线路.Size = new System.Drawing.Size(29, 12);
            this.lb_线路.TabIndex = 17;
            this.lb_线路.Text = "线路";
            // 
            // cb_线路
            // 
            this.cb_线路.FormattingEnabled = true;
            this.cb_线路.Items.AddRange(new object[] {
            "武广线下行线路",
            "武广线上行线路"});
            this.cb_线路.Location = new System.Drawing.Point(86, 106);
            this.cb_线路.Name = "cb_线路";
            this.cb_线路.Size = new System.Drawing.Size(216, 20);
            this.cb_线路.TabIndex = 6;
            // 
            // lb_车站
            // 
            this.lb_车站.AutoSize = true;
            this.lb_车站.Location = new System.Drawing.Point(188, 70);
            this.lb_车站.Name = "lb_车站";
            this.lb_车站.Size = new System.Drawing.Size(29, 12);
            this.lb_车站.TabIndex = 16;
            this.lb_车站.Text = "车站";
            // 
            // cb_限速值
            // 
            this.cb_限速值.FormattingEnabled = true;
            this.cb_限速值.Items.AddRange(new object[] {
            "20",
            "40",
            "80",
            "120",
            "160",
            "200",
            "250",
            "300"});
            this.cb_限速值.Location = new System.Drawing.Point(86, 207);
            this.cb_限速值.Name = "cb_限速值";
            this.cb_限速值.Size = new System.Drawing.Size(116, 20);
            this.cb_限速值.TabIndex = 4;
            // 
            // cb_车站
            // 
            this.cb_车站.FormattingEnabled = true;
            this.cb_车站.Location = new System.Drawing.Point(225, 67);
            this.cb_车站.Name = "cb_车站";
            this.cb_车站.Size = new System.Drawing.Size(77, 20);
            this.cb_车站.TabIndex = 5;
            // 
            // tb_endkm
            // 
            this.tb_endkm.Location = new System.Drawing.Point(86, 172);
            this.tb_endkm.Name = "tb_endkm";
            this.tb_endkm.Size = new System.Drawing.Size(87, 21);
            this.tb_endkm.TabIndex = 15;
            // 
            // tb_startm
            // 
            this.tb_startm.Location = new System.Drawing.Point(208, 138);
            this.tb_startm.Name = "tb_startm";
            this.tb_startm.Size = new System.Drawing.Size(77, 21);
            this.tb_startm.TabIndex = 14;
            // 
            // tb_endm
            // 
            this.tb_endm.Location = new System.Drawing.Point(208, 172);
            this.tb_endm.Name = "tb_endm";
            this.tb_endm.Size = new System.Drawing.Size(77, 21);
            this.tb_endm.TabIndex = 13;
            // 
            // tb_startkm
            // 
            this.tb_startkm.Location = new System.Drawing.Point(86, 138);
            this.tb_startkm.Name = "tb_startkm";
            this.tb_startkm.Size = new System.Drawing.Size(87, 21);
            this.tb_startkm.TabIndex = 12;
            // 
            // lb_m1
            // 
            this.lb_m1.AutoSize = true;
            this.lb_m1.Location = new System.Drawing.Point(291, 138);
            this.lb_m1.Name = "lb_m1";
            this.lb_m1.Size = new System.Drawing.Size(11, 12);
            this.lb_m1.TabIndex = 9;
            this.lb_m1.Text = "m";
            // 
            // lb_结束公里标
            // 
            this.lb_结束公里标.AutoSize = true;
            this.lb_结束公里标.Location = new System.Drawing.Point(18, 175);
            this.lb_结束公里标.Name = "lb_结束公里标";
            this.lb_结束公里标.Size = new System.Drawing.Size(65, 12);
            this.lb_结束公里标.TabIndex = 8;
            this.lb_结束公里标.Text = "结束公里标";
            // 
            // lb_限速值
            // 
            this.lb_限速值.AutoSize = true;
            this.lb_限速值.Location = new System.Drawing.Point(15, 210);
            this.lb_限速值.Name = "lb_限速值";
            this.lb_限速值.Size = new System.Drawing.Size(65, 12);
            this.lb_限速值.TabIndex = 7;
            this.lb_限速值.Text = "限速值km/h";
            // 
            // lb_km1
            // 
            this.lb_km1.AutoSize = true;
            this.lb_km1.Location = new System.Drawing.Point(179, 147);
            this.lb_km1.Name = "lb_km1";
            this.lb_km1.Size = new System.Drawing.Size(23, 12);
            this.lb_km1.TabIndex = 5;
            this.lb_km1.Text = "km+";
            // 
            // lb_开始公里标
            // 
            this.lb_开始公里标.AutoSize = true;
            this.lb_开始公里标.Location = new System.Drawing.Point(18, 141);
            this.lb_开始公里标.Name = "lb_开始公里标";
            this.lb_开始公里标.Size = new System.Drawing.Size(65, 12);
            this.lb_开始公里标.TabIndex = 4;
            this.lb_开始公里标.Text = "开始公里标";
            // 
            // cb_命令类型
            // 
            this.cb_命令类型.FormattingEnabled = true;
            this.cb_命令类型.Items.AddRange(new object[] {
            "正线限速",
            "车站限速"});
            this.cb_命令类型.Location = new System.Drawing.Point(86, 67);
            this.cb_命令类型.Name = "cb_命令类型";
            this.cb_命令类型.Size = new System.Drawing.Size(88, 20);
            this.cb_命令类型.TabIndex = 3;
            this.cb_命令类型.SelectedIndexChanged += new System.EventHandler(this.cb_命令类型_SelectedIndexChanged);
            // 
            // lb_命令类型
            // 
            this.lb_命令类型.AutoSize = true;
            this.lb_命令类型.Location = new System.Drawing.Point(18, 70);
            this.lb_命令类型.Name = "lb_命令类型";
            this.lb_命令类型.Size = new System.Drawing.Size(53, 12);
            this.lb_命令类型.TabIndex = 2;
            this.lb_命令类型.Text = "命令类型";
            // 
            // cb_限速原因
            // 
            this.cb_限速原因.FormattingEnabled = true;
            this.cb_限速原因.Items.AddRange(new object[] {
            "施工",
            "现场试验"});
            this.cb_限速原因.Location = new System.Drawing.Point(86, 30);
            this.cb_限速原因.Name = "cb_限速原因";
            this.cb_限速原因.Size = new System.Drawing.Size(88, 20);
            this.cb_限速原因.TabIndex = 1;
            // 
            // lb_限速原因
            // 
            this.lb_限速原因.AutoSize = true;
            this.lb_限速原因.Location = new System.Drawing.Point(18, 33);
            this.lb_限速原因.Name = "lb_限速原因";
            this.lb_限速原因.Size = new System.Drawing.Size(53, 12);
            this.lb_限速原因.TabIndex = 0;
            this.lb_限速原因.Text = "限速原因";
            // 
            // gb_开始时间
            // 
            this.gb_开始时间.Controls.Add(this.cb_定时开始);
            this.gb_开始时间.Controls.Add(this.rb_立即执行);
            this.gb_开始时间.Controls.Add(this.rb_定时开始);
            this.gb_开始时间.Location = new System.Drawing.Point(26, 292);
            this.gb_开始时间.Name = "gb_开始时间";
            this.gb_开始时间.Size = new System.Drawing.Size(160, 100);
            this.gb_开始时间.TabIndex = 1;
            this.gb_开始时间.TabStop = false;
            this.gb_开始时间.Text = "开始时间";
            // 
            // rb_立即执行
            // 
            this.rb_立即执行.AutoSize = true;
            this.rb_立即执行.Location = new System.Drawing.Point(20, 78);
            this.rb_立即执行.Name = "rb_立即执行";
            this.rb_立即执行.Size = new System.Drawing.Size(71, 16);
            this.rb_立即执行.TabIndex = 1;
            this.rb_立即执行.TabStop = true;
            this.rb_立即执行.Text = "立即执行";
            this.rb_立即执行.UseVisualStyleBackColor = true;
            // 
            // rb_定时开始
            // 
            this.rb_定时开始.AutoSize = true;
            this.rb_定时开始.Location = new System.Drawing.Point(20, 20);
            this.rb_定时开始.Name = "rb_定时开始";
            this.rb_定时开始.Size = new System.Drawing.Size(71, 16);
            this.rb_定时开始.TabIndex = 0;
            this.rb_定时开始.TabStop = true;
            this.rb_定时开始.Text = "定时开始";
            this.rb_定时开始.UseVisualStyleBackColor = true;
            // 
            // gb_结束时间
            // 
            this.gb_结束时间.Controls.Add(this.cb_定时结束);
            this.gb_结束时间.Controls.Add(this.rb_持久有效);
            this.gb_结束时间.Controls.Add(this.rb_定时结束);
            this.gb_结束时间.Location = new System.Drawing.Point(196, 292);
            this.gb_结束时间.Name = "gb_结束时间";
            this.gb_结束时间.Size = new System.Drawing.Size(160, 100);
            this.gb_结束时间.TabIndex = 2;
            this.gb_结束时间.TabStop = false;
            this.gb_结束时间.Text = "结束时间";
            // 
            // rb_持久有效
            // 
            this.rb_持久有效.AutoSize = true;
            this.rb_持久有效.Location = new System.Drawing.Point(20, 78);
            this.rb_持久有效.Name = "rb_持久有效";
            this.rb_持久有效.Size = new System.Drawing.Size(71, 16);
            this.rb_持久有效.TabIndex = 2;
            this.rb_持久有效.TabStop = true;
            this.rb_持久有效.Text = "持久有效";
            this.rb_持久有效.UseVisualStyleBackColor = true;
            // 
            // rb_定时结束
            // 
            this.rb_定时结束.AutoSize = true;
            this.rb_定时结束.Location = new System.Drawing.Point(20, 20);
            this.rb_定时结束.Name = "rb_定时结束";
            this.rb_定时结束.Size = new System.Drawing.Size(71, 16);
            this.rb_定时结束.TabIndex = 1;
            this.rb_定时结束.TabStop = true;
            this.rb_定时结束.Text = "定时结束";
            this.rb_定时结束.UseVisualStyleBackColor = true;
            // 
            // btn_确定
            // 
            this.btn_确定.Location = new System.Drawing.Point(377, 113);
            this.btn_确定.Name = "btn_确定";
            this.btn_确定.Size = new System.Drawing.Size(80, 41);
            this.btn_确定.TabIndex = 3;
            this.btn_确定.Text = "确定";
            this.btn_确定.UseVisualStyleBackColor = true;
            this.btn_确定.Click += new System.EventHandler(this.btn_确定_Click);
            // 
            // btn_取消
            // 
            this.btn_取消.Location = new System.Drawing.Point(377, 255);
            this.btn_取消.Name = "btn_取消";
            this.btn_取消.Size = new System.Drawing.Size(80, 41);
            this.btn_取消.TabIndex = 4;
            this.btn_取消.Text = "取消";
            this.btn_取消.UseVisualStyleBackColor = true;
            this.btn_取消.Click += new System.EventHandler(this.btn_取消_Click);
            // 
            // cb_定时开始
            // 
            this.cb_定时开始.FormattingEnabled = true;
            this.cb_定时开始.Location = new System.Drawing.Point(20, 42);
            this.cb_定时开始.Name = "cb_定时开始";
            this.cb_定时开始.Size = new System.Drawing.Size(71, 20);
            this.cb_定时开始.TabIndex = 20;
            // 
            // cb_定时结束
            // 
            this.cb_定时结束.FormattingEnabled = true;
            this.cb_定时结束.Location = new System.Drawing.Point(20, 42);
            this.cb_定时结束.Name = "cb_定时结束";
            this.cb_定时结束.Size = new System.Drawing.Size(71, 20);
            this.cb_定时结束.TabIndex = 21;
            // 
            // 临时限速界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 429);
            this.Controls.Add(this.btn_取消);
            this.Controls.Add(this.btn_确定);
            this.Controls.Add(this.gb_结束时间);
            this.Controls.Add(this.gb_开始时间);
            this.Controls.Add(this.gb_基本项);
            this.Name = "临时限速界面";
            this.Text = "临时限速界面";
            this.Load += new System.EventHandler(this.临时限速界面_Load);
            this.gb_基本项.ResumeLayout(false);
            this.gb_基本项.PerformLayout();
            this.gb_开始时间.ResumeLayout(false);
            this.gb_开始时间.PerformLayout();
            this.gb_结束时间.ResumeLayout(false);
            this.gb_结束时间.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_基本项;
        private System.Windows.Forms.ComboBox cb_限速原因;
        private System.Windows.Forms.Label lb_限速原因;
        private System.Windows.Forms.Label lb_m2;
        private System.Windows.Forms.Label lb_km2;
        private System.Windows.Forms.Label lb_线路;
        private System.Windows.Forms.ComboBox cb_线路;
        private System.Windows.Forms.Label lb_车站;
        private System.Windows.Forms.ComboBox cb_限速值;
        private System.Windows.Forms.ComboBox cb_车站;
        private System.Windows.Forms.TextBox tb_endkm;
        private System.Windows.Forms.TextBox tb_startm;
        private System.Windows.Forms.TextBox tb_endm;
        private System.Windows.Forms.TextBox tb_startkm;
        private System.Windows.Forms.Label lb_m1;
        private System.Windows.Forms.Label lb_结束公里标;
        private System.Windows.Forms.Label lb_限速值;
        private System.Windows.Forms.Label lb_km1;
        private System.Windows.Forms.Label lb_开始公里标;
        private System.Windows.Forms.ComboBox cb_命令类型;
        private System.Windows.Forms.Label lb_命令类型;
        private System.Windows.Forms.GroupBox gb_开始时间;
        private System.Windows.Forms.RadioButton rb_立即执行;
        private System.Windows.Forms.RadioButton rb_定时开始;
        private System.Windows.Forms.GroupBox gb_结束时间;
        private System.Windows.Forms.RadioButton rb_持久有效;
        private System.Windows.Forms.RadioButton rb_定时结束;
        private System.Windows.Forms.Button btn_确定;
        private System.Windows.Forms.Button btn_取消;
        private System.Windows.Forms.ComboBox cb_定时开始;
        private System.Windows.Forms.ComboBox cb_定时结束;
    }
}
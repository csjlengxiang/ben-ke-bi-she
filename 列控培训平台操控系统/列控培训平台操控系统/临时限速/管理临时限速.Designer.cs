namespace 列控培训平台操控系统.临时限速
{
    partial class 管理临时限速
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
            this.dgv_限速管理 = new System.Windows.Forms.DataGridView();
            this.lb_命令号 = new System.Windows.Forms.Label();
            this.btn_删除 = new System.Windows.Forms.Button();
            this.btn_关闭 = new System.Windows.Forms.Button();
            this.cb_命令号 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_限速管理)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_限速管理
            // 
            this.dgv_限速管理.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_限速管理.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_限速管理.Location = new System.Drawing.Point(1, 1);
            this.dgv_限速管理.Name = "dgv_限速管理";
            this.dgv_限速管理.RowTemplate.Height = 23;
            this.dgv_限速管理.Size = new System.Drawing.Size(897, 495);
            this.dgv_限速管理.TabIndex = 3;
            // 
            // lb_命令号
            // 
            this.lb_命令号.AutoSize = true;
            this.lb_命令号.Location = new System.Drawing.Point(192, 518);
            this.lb_命令号.Name = "lb_命令号";
            this.lb_命令号.Size = new System.Drawing.Size(77, 12);
            this.lb_命令号.TabIndex = 5;
            this.lb_命令号.Text = "限速命令号：";
            // 
            // btn_删除
            // 
            this.btn_删除.Location = new System.Drawing.Point(409, 513);
            this.btn_删除.Name = "btn_删除";
            this.btn_删除.Size = new System.Drawing.Size(75, 23);
            this.btn_删除.TabIndex = 6;
            this.btn_删除.Text = "删除";
            this.btn_删除.UseVisualStyleBackColor = true;
            this.btn_删除.Click += new System.EventHandler(this.btn_删除_Click);
            // 
            // btn_关闭
            // 
            this.btn_关闭.Location = new System.Drawing.Point(520, 513);
            this.btn_关闭.Name = "btn_关闭";
            this.btn_关闭.Size = new System.Drawing.Size(75, 23);
            this.btn_关闭.TabIndex = 7;
            this.btn_关闭.Text = "关闭";
            this.btn_关闭.UseVisualStyleBackColor = true;
            this.btn_关闭.Click += new System.EventHandler(this.btn_关闭_Click);
            // 
            // cb_命令号
            // 
            this.cb_命令号.FormattingEnabled = true;
            this.cb_命令号.Location = new System.Drawing.Point(276, 515);
            this.cb_命令号.Name = "cb_命令号";
            this.cb_命令号.Size = new System.Drawing.Size(96, 20);
            this.cb_命令号.TabIndex = 8;
            // 
            // 管理临时限速
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 561);
            this.Controls.Add(this.cb_命令号);
            this.Controls.Add(this.btn_关闭);
            this.Controls.Add(this.btn_删除);
            this.Controls.Add(this.lb_命令号);
            this.Controls.Add(this.dgv_限速管理);
            this.Name = "管理临时限速";
            this.Text = "管理临时限速";
            this.Load += new System.EventHandler(this.管理临时限速_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_限速管理)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_限速管理;
        private System.Windows.Forms.Label lb_命令号;
        private System.Windows.Forms.Button btn_删除;
        private System.Windows.Forms.Button btn_关闭;
        private System.Windows.Forms.ComboBox cb_命令号;
    }
}
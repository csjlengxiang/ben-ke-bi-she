namespace 列控培训平台操控系统.列车初始化
{
    partial class 管理列车
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_列车管理 = new System.Windows.Forms.DataGridView();
            this.lb_车次号 = new System.Windows.Forms.Label();
            this.cb_车次 = new System.Windows.Forms.ComboBox();
            this.btn_删除 = new System.Windows.Forms.Button();
            this.btn_关闭 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_列车管理)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_列车管理
            // 
            this.dgv_列车管理.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_列车管理.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_列车管理.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_列车管理.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_列车管理.Location = new System.Drawing.Point(-2, 2);
            this.dgv_列车管理.Name = "dgv_列车管理";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_列车管理.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_列车管理.RowTemplate.Height = 23;
            this.dgv_列车管理.Size = new System.Drawing.Size(749, 482);
            this.dgv_列车管理.TabIndex = 4;
            // 
            // lb_车次号
            // 
            this.lb_车次号.AutoSize = true;
            this.lb_车次号.Location = new System.Drawing.Point(130, 500);
            this.lb_车次号.Name = "lb_车次号";
            this.lb_车次号.Size = new System.Drawing.Size(53, 12);
            this.lb_车次号.TabIndex = 5;
            this.lb_车次号.Text = "车次号：";
            // 
            // cb_车次
            // 
            this.cb_车次.FormattingEnabled = true;
            this.cb_车次.Location = new System.Drawing.Point(189, 497);
            this.cb_车次.Name = "cb_车次";
            this.cb_车次.Size = new System.Drawing.Size(121, 20);
            this.cb_车次.TabIndex = 6;
            // 
            // btn_删除
            // 
            this.btn_删除.Location = new System.Drawing.Point(346, 497);
            this.btn_删除.Name = "btn_删除";
            this.btn_删除.Size = new System.Drawing.Size(75, 23);
            this.btn_删除.TabIndex = 7;
            this.btn_删除.Text = "删除";
            this.btn_删除.UseVisualStyleBackColor = true;
            this.btn_删除.Click += new System.EventHandler(this.btn_删除_Click);
            // 
            // btn_关闭
            // 
            this.btn_关闭.Location = new System.Drawing.Point(462, 497);
            this.btn_关闭.Name = "btn_关闭";
            this.btn_关闭.Size = new System.Drawing.Size(75, 23);
            this.btn_关闭.TabIndex = 8;
            this.btn_关闭.Text = "关闭";
            this.btn_关闭.UseVisualStyleBackColor = true;
            this.btn_关闭.Click += new System.EventHandler(this.btn_关闭_Click);
            // 
            // 管理列车
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 530);
            this.Controls.Add(this.btn_关闭);
            this.Controls.Add(this.btn_删除);
            this.Controls.Add(this.cb_车次);
            this.Controls.Add(this.lb_车次号);
            this.Controls.Add(this.dgv_列车管理);
            this.Name = "管理列车";
            this.Text = "管理列车";
            this.Load += new System.EventHandler(this.管理列车_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_列车管理)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_列车管理;
        private System.Windows.Forms.Label lb_车次号;
        private System.Windows.Forms.ComboBox cb_车次;
        private System.Windows.Forms.Button btn_删除;
        private System.Windows.Forms.Button btn_关闭;
    }
}
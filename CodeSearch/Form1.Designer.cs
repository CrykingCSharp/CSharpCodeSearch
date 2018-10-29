namespace CodeSearch
{
    partial class Form1
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
            this.lb_codefile = new System.Windows.Forms.ListBox();
            this.lab1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_codefile
            // 
            this.lb_codefile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_codefile.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lb_codefile.FormattingEnabled = true;
            this.lb_codefile.ItemHeight = 12;
            this.lb_codefile.Location = new System.Drawing.Point(35, 43);
            this.lb_codefile.Name = "lb_codefile";
            this.lb_codefile.Size = new System.Drawing.Size(203, 292);
            this.lb_codefile.TabIndex = 0;
            this.lb_codefile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Lb_codefile_MouseClick);
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Location = new System.Drawing.Point(33, 29);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(53, 12);
            this.lab1.TabIndex = 1;
            this.lab1.Text = "文件列表";
            // 
            // tb1
            // 
            this.tb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb1.Location = new System.Drawing.Point(255, 43);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(229, 21);
            this.tb1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(490, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "搜索代码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb2
            // 
            this.tb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb2.ForeColor = System.Drawing.Color.Red;
            this.tb2.Location = new System.Drawing.Point(0, 0);
            this.tb2.Multiline = true;
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb2.Size = new System.Drawing.Size(343, 263);
            this.tb2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.tb2);
            this.panel1.Location = new System.Drawing.Point(245, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 263);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 344);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.lb_codefile);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "源码搜索";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_codefile;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Panel panel1;
    }
}


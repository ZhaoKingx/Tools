namespace LRCMatch
{
    partial class Form_Main
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
            this.gb_Top = new System.Windows.Forms.GroupBox();
            this.btn_Dir = new System.Windows.Forms.Button();
            this.lbl_Dir = new System.Windows.Forms.Label();
            this.txt_Dir = new System.Windows.Forms.TextBox();
            this.gb_Bottom = new System.Windows.Forms.GroupBox();
            this.gb_Log_Fail = new System.Windows.Forms.GroupBox();
            this.lb_LogInfo_Fail = new System.Windows.Forms.ListBox();
            this.gb_Right_Suc = new System.Windows.Forms.GroupBox();
            this.lb_LogInfo_Suc = new System.Windows.Forms.ListBox();
            this.ll_Download = new System.Windows.Forms.LinkLabel();
            this.gb_Top.SuspendLayout();
            this.gb_Bottom.SuspendLayout();
            this.gb_Log_Fail.SuspendLayout();
            this.gb_Right_Suc.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Top
            // 
            this.gb_Top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Top.Controls.Add(this.btn_Dir);
            this.gb_Top.Controls.Add(this.lbl_Dir);
            this.gb_Top.Controls.Add(this.txt_Dir);
            this.gb_Top.Location = new System.Drawing.Point(12, 12);
            this.gb_Top.Name = "gb_Top";
            this.gb_Top.Size = new System.Drawing.Size(548, 44);
            this.gb_Top.TabIndex = 0;
            this.gb_Top.TabStop = false;
            this.gb_Top.Enter += new System.EventHandler(this.gb_Top_Enter);
            // 
            // btn_Dir
            // 
            this.btn_Dir.Location = new System.Drawing.Point(462, 13);
            this.btn_Dir.Name = "btn_Dir";
            this.btn_Dir.Size = new System.Drawing.Size(75, 23);
            this.btn_Dir.TabIndex = 2;
            this.btn_Dir.Text = "选择目录";
            this.btn_Dir.UseVisualStyleBackColor = true;
            this.btn_Dir.Click += new System.EventHandler(this.btn_Dir_Click);
            // 
            // lbl_Dir
            // 
            this.lbl_Dir.AutoSize = true;
            this.lbl_Dir.Location = new System.Drawing.Point(14, 18);
            this.lbl_Dir.Name = "lbl_Dir";
            this.lbl_Dir.Size = new System.Drawing.Size(53, 12);
            this.lbl_Dir.TabIndex = 1;
            this.lbl_Dir.Text = "歌曲目录";
            this.lbl_Dir.Click += new System.EventHandler(this.lbl_Dir_Click);
            // 
            // txt_Dir
            // 
            this.txt_Dir.Location = new System.Drawing.Point(76, 15);
            this.txt_Dir.Name = "txt_Dir";
            this.txt_Dir.Size = new System.Drawing.Size(372, 21);
            this.txt_Dir.TabIndex = 0;
            this.txt_Dir.TextChanged += new System.EventHandler(this.txt_Dir_TextChanged);
            // 
            // gb_Bottom
            // 
            this.gb_Bottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Bottom.Controls.Add(this.gb_Log_Fail);
            this.gb_Bottom.Controls.Add(this.gb_Right_Suc);
            this.gb_Bottom.Location = new System.Drawing.Point(12, 56);
            this.gb_Bottom.Name = "gb_Bottom";
            this.gb_Bottom.Size = new System.Drawing.Size(548, 306);
            this.gb_Bottom.TabIndex = 1;
            this.gb_Bottom.TabStop = false;
            this.gb_Bottom.Enter += new System.EventHandler(this.gb_Bottom_Enter);
            // 
            // gb_Log_Fail
            // 
            this.gb_Log_Fail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Log_Fail.Controls.Add(this.lb_LogInfo_Fail);
            this.gb_Log_Fail.Location = new System.Drawing.Point(261, 9);
            this.gb_Log_Fail.Name = "gb_Log_Fail";
            this.gb_Log_Fail.Size = new System.Drawing.Size(276, 291);
            this.gb_Log_Fail.TabIndex = 2;
            this.gb_Log_Fail.TabStop = false;
            this.gb_Log_Fail.Text = "失败日志";
            this.gb_Log_Fail.Enter += new System.EventHandler(this.gb_Log_Fail_Enter);
            // 
            // lb_LogInfo_Fail
            // 
            this.lb_LogInfo_Fail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_LogInfo_Fail.FormattingEnabled = true;
            this.lb_LogInfo_Fail.ItemHeight = 12;
            this.lb_LogInfo_Fail.Location = new System.Drawing.Point(3, 17);
            this.lb_LogInfo_Fail.Name = "lb_LogInfo_Fail";
            this.lb_LogInfo_Fail.Size = new System.Drawing.Size(270, 271);
            this.lb_LogInfo_Fail.TabIndex = 3;
            this.lb_LogInfo_Fail.SelectedIndexChanged += new System.EventHandler(this.lb_LogInfo_SelectedIndexChanged);
            // 
            // gb_Right_Suc
            // 
            this.gb_Right_Suc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_Right_Suc.Controls.Add(this.lb_LogInfo_Suc);
            this.gb_Right_Suc.Controls.Add(this.ll_Download);
            this.gb_Right_Suc.Location = new System.Drawing.Point(6, 9);
            this.gb_Right_Suc.Name = "gb_Right_Suc";
            this.gb_Right_Suc.Size = new System.Drawing.Size(249, 291);
            this.gb_Right_Suc.TabIndex = 1;
            this.gb_Right_Suc.TabStop = false;
            this.gb_Right_Suc.Text = "成功日志";
            this.gb_Right_Suc.Enter += new System.EventHandler(this.gb_Right_Suc_Enter);
            // 
            // lb_LogInfo_Suc
            // 
            this.lb_LogInfo_Suc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_LogInfo_Suc.FormattingEnabled = true;
            this.lb_LogInfo_Suc.ItemHeight = 12;
            this.lb_LogInfo_Suc.Location = new System.Drawing.Point(3, 17);
            this.lb_LogInfo_Suc.Name = "lb_LogInfo_Suc";
            this.lb_LogInfo_Suc.Size = new System.Drawing.Size(243, 271);
            this.lb_LogInfo_Suc.TabIndex = 2;
            this.lb_LogInfo_Suc.SelectedIndexChanged += new System.EventHandler(this.lb_LogInfo_Suc_SelectedIndexChanged);
            // 
            // ll_Download
            // 
            this.ll_Download.AutoSize = true;
            this.ll_Download.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.ll_Download.Location = new System.Drawing.Point(178, 2);
            this.ll_Download.Name = "ll_Download";
            this.ll_Download.Size = new System.Drawing.Size(53, 12);
            this.ll_Download.TabIndex = 1;
            this.ll_Download.TabStop = true;
            this.ll_Download.Text = "下载歌词";
            this.ll_Download.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_Download_LinkClicked);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 374);
            this.Controls.Add(this.gb_Bottom);
            this.Controls.Add(this.gb_Top);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "歌词自动匹配下载";
            this.gb_Top.ResumeLayout(false);
            this.gb_Top.PerformLayout();
            this.gb_Bottom.ResumeLayout(false);
            this.gb_Log_Fail.ResumeLayout(false);
            this.gb_Right_Suc.ResumeLayout(false);
            this.gb_Right_Suc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Top;
        private System.Windows.Forms.GroupBox gb_Bottom;
        private System.Windows.Forms.GroupBox gb_Right_Suc;
        private System.Windows.Forms.Label lbl_Dir;
        private System.Windows.Forms.TextBox txt_Dir;
        private System.Windows.Forms.Button btn_Dir;
        private System.Windows.Forms.LinkLabel ll_Download;
        private System.Windows.Forms.GroupBox gb_Log_Fail;
        private System.Windows.Forms.ListBox lb_LogInfo_Fail;
        private System.Windows.Forms.ListBox lb_LogInfo_Suc;
    }
}


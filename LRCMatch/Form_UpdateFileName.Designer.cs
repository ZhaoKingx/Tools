namespace LRCMatch
{
    partial class Form_ModifyFileName
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
            this.gb_Top = new System.Windows.Forms.GroupBox();
            this.btn_Dir = new System.Windows.Forms.Button();
            this.lbl_Dir = new System.Windows.Forms.Label();
            this.txt_Dir = new System.Windows.Forms.TextBox();
            this.gb_Bottom = new System.Windows.Forms.GroupBox();
            this.gb_Log_lafter = new System.Windows.Forms.GroupBox();
            this.lb_LogInfo_after = new System.Windows.Forms.ListBox();
            this.gb_Right_Befour = new System.Windows.Forms.GroupBox();
            this.lb_LogInfo_before = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_startnum = new System.Windows.Forms.TextBox();
            this.gb_Top.SuspendLayout();
            this.gb_Bottom.SuspendLayout();
            this.gb_Log_lafter.SuspendLayout();
            this.gb_Right_Befour.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Top
            // 
            this.gb_Top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Top.Controls.Add(this.label1);
            this.gb_Top.Controls.Add(this.txt_startnum);
            this.gb_Top.Controls.Add(this.btn_Dir);
            this.gb_Top.Controls.Add(this.lbl_Dir);
            this.gb_Top.Controls.Add(this.txt_Dir);
            this.gb_Top.Location = new System.Drawing.Point(12, 12);
            this.gb_Top.Name = "gb_Top";
            this.gb_Top.Size = new System.Drawing.Size(548, 44);
            this.gb_Top.TabIndex = 2;
            this.gb_Top.TabStop = false;
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
            this.lbl_Dir.Location = new System.Drawing.Point(155, 18);
            this.lbl_Dir.Name = "lbl_Dir";
            this.lbl_Dir.Size = new System.Drawing.Size(53, 12);
            this.lbl_Dir.TabIndex = 1;
            this.lbl_Dir.Text = "目录地址";
            // 
            // txt_Dir
            // 
            this.txt_Dir.Location = new System.Drawing.Point(214, 15);
            this.txt_Dir.Name = "txt_Dir";
            this.txt_Dir.Size = new System.Drawing.Size(234, 21);
            this.txt_Dir.TabIndex = 0;
            // 
            // gb_Bottom
            // 
            this.gb_Bottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Bottom.Controls.Add(this.gb_Log_lafter);
            this.gb_Bottom.Controls.Add(this.gb_Right_Befour);
            this.gb_Bottom.Location = new System.Drawing.Point(12, 56);
            this.gb_Bottom.Name = "gb_Bottom";
            this.gb_Bottom.Size = new System.Drawing.Size(548, 306);
            this.gb_Bottom.TabIndex = 3;
            this.gb_Bottom.TabStop = false;
            // 
            // gb_Log_lafter
            // 
            this.gb_Log_lafter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Log_lafter.Controls.Add(this.lb_LogInfo_after);
            this.gb_Log_lafter.Location = new System.Drawing.Point(261, 9);
            this.gb_Log_lafter.Name = "gb_Log_lafter";
            this.gb_Log_lafter.Size = new System.Drawing.Size(276, 291);
            this.gb_Log_lafter.TabIndex = 2;
            this.gb_Log_lafter.TabStop = false;
            this.gb_Log_lafter.Text = "修改后名称";
            // 
            // lb_LogInfo_after
            // 
            this.lb_LogInfo_after.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_LogInfo_after.FormattingEnabled = true;
            this.lb_LogInfo_after.ItemHeight = 12;
            this.lb_LogInfo_after.Location = new System.Drawing.Point(3, 17);
            this.lb_LogInfo_after.Name = "lb_LogInfo_after";
            this.lb_LogInfo_after.Size = new System.Drawing.Size(270, 271);
            this.lb_LogInfo_after.TabIndex = 3;
            // 
            // gb_Right_Befour
            // 
            this.gb_Right_Befour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_Right_Befour.Controls.Add(this.lb_LogInfo_before);
            this.gb_Right_Befour.Location = new System.Drawing.Point(6, 9);
            this.gb_Right_Befour.Name = "gb_Right_Befour";
            this.gb_Right_Befour.Size = new System.Drawing.Size(249, 291);
            this.gb_Right_Befour.TabIndex = 1;
            this.gb_Right_Befour.TabStop = false;
            this.gb_Right_Befour.Text = "原始名称";
            // 
            // lb_LogInfo_before
            // 
            this.lb_LogInfo_before.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_LogInfo_before.FormattingEnabled = true;
            this.lb_LogInfo_before.ItemHeight = 12;
            this.lb_LogInfo_before.Location = new System.Drawing.Point(3, 17);
            this.lb_LogInfo_before.Name = "lb_LogInfo_before";
            this.lb_LogInfo_before.Size = new System.Drawing.Size(243, 271);
            this.lb_LogInfo_before.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "起始序号";
            // 
            // txt_startnum
            // 
            this.txt_startnum.Location = new System.Drawing.Point(66, 14);
            this.txt_startnum.Name = "txt_startnum";
            this.txt_startnum.Size = new System.Drawing.Size(68, 21);
            this.txt_startnum.TabIndex = 3;
            this.txt_startnum.Text = "820";
            // 
            // Form_ModifyFileName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 374);
            this.Controls.Add(this.gb_Top);
            this.Controls.Add(this.gb_Bottom);
            this.Name = "Form_ModifyFileName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改文件名称";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ModifyFileName_FormClosing);
            this.gb_Top.ResumeLayout(false);
            this.gb_Top.PerformLayout();
            this.gb_Bottom.ResumeLayout(false);
            this.gb_Log_lafter.ResumeLayout(false);
            this.gb_Right_Befour.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Top;
        private System.Windows.Forms.Button btn_Dir;
        private System.Windows.Forms.Label lbl_Dir;
        private System.Windows.Forms.TextBox txt_Dir;
        private System.Windows.Forms.GroupBox gb_Bottom;
        private System.Windows.Forms.GroupBox gb_Log_lafter;
        private System.Windows.Forms.ListBox lb_LogInfo_after;
        private System.Windows.Forms.GroupBox gb_Right_Befour;
        private System.Windows.Forms.ListBox lb_LogInfo_before;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_startnum;
    }
}
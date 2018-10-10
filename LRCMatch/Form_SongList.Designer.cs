namespace LRCMatch
{
    partial class Form_SongList
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
            this.gb_Bottom = new System.Windows.Forms.GroupBox();
            this.dgv_Songs = new System.Windows.Forms.DataGridView();
            this.lbl_Singer = new System.Windows.Forms.Label();
            this.txt_Singer = new System.Windows.Forms.TextBox();
            this.txt_Song = new System.Windows.Forms.TextBox();
            this.lbl_Song = new System.Windows.Forms.Label();
            this.btn_Query = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LrcUri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_Top.SuspendLayout();
            this.gb_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Songs)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Top
            // 
            this.gb_Top.Controls.Add(this.btn_Query);
            this.gb_Top.Controls.Add(this.txt_Song);
            this.gb_Top.Controls.Add(this.lbl_Song);
            this.gb_Top.Controls.Add(this.txt_Singer);
            this.gb_Top.Controls.Add(this.lbl_Singer);
            this.gb_Top.Location = new System.Drawing.Point(12, 0);
            this.gb_Top.Name = "gb_Top";
            this.gb_Top.Size = new System.Drawing.Size(557, 47);
            this.gb_Top.TabIndex = 0;
            this.gb_Top.TabStop = false;
            this.gb_Top.Text = "歌曲信息";
            // 
            // gb_Bottom
            // 
            this.gb_Bottom.Controls.Add(this.dgv_Songs);
            this.gb_Bottom.Location = new System.Drawing.Point(12, 53);
            this.gb_Bottom.Name = "gb_Bottom";
            this.gb_Bottom.Size = new System.Drawing.Size(557, 309);
            this.gb_Bottom.TabIndex = 1;
            this.gb_Bottom.TabStop = false;
            this.gb_Bottom.Text = "歌词列表";
            // 
            // dgv_Songs
            // 
            this.dgv_Songs.AllowUserToAddRows = false;
            this.dgv_Songs.AllowUserToDeleteRows = false;
            this.dgv_Songs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Songs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.Artist,
            this.LrcUri});
            this.dgv_Songs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Songs.Location = new System.Drawing.Point(3, 17);
            this.dgv_Songs.Name = "dgv_Songs";
            this.dgv_Songs.ReadOnly = true;
            this.dgv_Songs.RowHeadersVisible = false;
            this.dgv_Songs.RowTemplate.Height = 23;
            this.dgv_Songs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Songs.Size = new System.Drawing.Size(551, 289);
            this.dgv_Songs.TabIndex = 0;
            this.dgv_Songs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Songs_CellDoubleClick);
            // 
            // lbl_Singer
            // 
            this.lbl_Singer.AutoSize = true;
            this.lbl_Singer.Location = new System.Drawing.Point(20, 21);
            this.lbl_Singer.Name = "lbl_Singer";
            this.lbl_Singer.Size = new System.Drawing.Size(53, 12);
            this.lbl_Singer.TabIndex = 0;
            this.lbl_Singer.Text = "歌手名称";
            // 
            // txt_Singer
            // 
            this.txt_Singer.Location = new System.Drawing.Point(79, 18);
            this.txt_Singer.Name = "txt_Singer";
            this.txt_Singer.Size = new System.Drawing.Size(100, 21);
            this.txt_Singer.TabIndex = 1;
            // 
            // txt_Song
            // 
            this.txt_Song.Location = new System.Drawing.Point(246, 16);
            this.txt_Song.Name = "txt_Song";
            this.txt_Song.Size = new System.Drawing.Size(100, 21);
            this.txt_Song.TabIndex = 3;
            // 
            // lbl_Song
            // 
            this.lbl_Song.AutoSize = true;
            this.lbl_Song.Location = new System.Drawing.Point(187, 21);
            this.lbl_Song.Name = "lbl_Song";
            this.lbl_Song.Size = new System.Drawing.Size(53, 12);
            this.lbl_Song.TabIndex = 2;
            this.lbl_Song.Text = "歌曲名称";
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(379, 16);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 4;
            this.btn_Query.Text = "搜索";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Artist
            // 
            this.Artist.DataPropertyName = "Artist";
            this.Artist.HeaderText = "Artist";
            this.Artist.Name = "Artist";
            this.Artist.ReadOnly = true;
            // 
            // LrcUri
            // 
            this.LrcUri.DataPropertyName = "LrcUri";
            this.LrcUri.HeaderText = "LrcUri";
            this.LrcUri.Name = "LrcUri";
            this.LrcUri.ReadOnly = true;
            this.LrcUri.Width = 200;
            // 
            // Form_SongList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AcceptButton = this.btn_Query;
            this.ClientSize = new System.Drawing.Size(581, 365);
            this.Controls.Add(this.gb_Bottom);
            this.Controls.Add(this.gb_Top);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(597, 403);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(597, 403);
            this.Name = "Form_SongList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "歌词列表";
            this.gb_Top.ResumeLayout(false);
            this.gb_Top.PerformLayout();
            this.gb_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Songs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Top;
        private System.Windows.Forms.GroupBox gb_Bottom;
        private System.Windows.Forms.DataGridView dgv_Songs;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.TextBox txt_Song;
        private System.Windows.Forms.Label lbl_Song;
        private System.Windows.Forms.TextBox txt_Singer;
        private System.Windows.Forms.Label lbl_Singer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artist;
        private System.Windows.Forms.DataGridViewTextBoxColumn LrcUri;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LRCMatch
{
    public partial class Form_SongList : Form
    {
        string m_fname = "";
        public Form_SongList(string fname)
        {
            InitializeComponent();
            m_fname = fname;
            if (m_fname.Contains("_-_"))
            {
                this.txt_Singer.Text = Path.GetFileNameWithoutExtension(m_fname).Split(new string[] { "_-_" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                this.txt_Song.Text = Path.GetFileNameWithoutExtension(m_fname).Split(new string[] { "_-_" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            LrcInfo[] infos = LyricsHelper.GetLrcList(this.txt_Singer.Text.Trim(), this.txt_Song.Text.Trim(), m_fname);
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Artist");
            dt.Columns.Add("Title");
            dt.Columns.Add("LrcUri");
            foreach (LrcInfo li in infos)
            {
                DataRow row = dt.NewRow();
                row[0] = li.Id;
                row[1] = li.Artist;
                row[2] = li.Title;
                row[3] = li.LrcUri;
                dt.Rows.Add(row);
            }

            dgv_Songs.DataSource = dt;
        }

        private void dgv_Songs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)//防止 Index 出错
            {
                if (LyricsHelper.DownloadLrc(dgv_Songs.Rows[e.RowIndex].Cells[3].Value.ToString(), m_fname))
                {
                    MessageBox.Show("下载歌词成功!");
                }
                else
                {
                    MessageBox.Show("下载歌词失败!");
                }

            }
        }
    }
}
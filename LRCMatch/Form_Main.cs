using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace LRCMatch
{
    public partial class Form_Main : Form
    {
        ArrayList arr = new ArrayList();
        public Form_Main()
        {
            InitializeComponent();
        }

        private void btn_Dir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"F:\车载音乐";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (fbd.SelectedPath != "")
                {
                    arr.Clear();
                    this.txt_Dir.Text = fbd.SelectedPath;
                    string[] files = Directory.GetFiles(this.txt_Dir.Text);
                    foreach (string fname in files)
                    {
                        if (!fname.Contains(".lrc"))
                        {
                            //if (!File.Exists(fname.Replace(".mp3", ".lrc").Replace(".wav", ".lrc")))//不存在lrc
                            arr.Add(fname);
                        }
                    }
                    foreach (string fpath in Directory.GetDirectories(this.txt_Dir.Text))
                    {
                        if (fpath.Contains("\\."))
                            continue;
                        files = Directory.GetFiles(fpath);
                        foreach (string fname in files)
                        {
                            if (!fname.Contains(".lrc"))
                            {
                                //if (!File.Exists(fname.Replace(".mp3", ".lrc").Replace(".wav", ".lrc")))//不存在lrc
                                arr.Add(fname);
                            }
                        }
                    }
                }
            }
        }
        bool m_Download = false;
        object m_LockDownload = new object();
        System.Threading.Thread th;
        private void ll_Download_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (arr.Count <= 0)
                return;
            if (!m_Download)
            {
                m_Download = true;
                th = new System.Threading.Thread(WorkForKuWo);
                th.Start();
            }
            else
            {
                m_Download = false;
            }
        }
        /// <summary>
        /// 从千千静听服务器下载
        /// </summary>
        void Work()
        {
            if (this.txt_Dir.Text != "")
            {
                arr.Clear();
                string[] files = Directory.GetFiles(this.txt_Dir.Text);
                foreach (string fname in files)
                {
                    if (!fname.Contains(".lrc"))
                    {
                        //if (!File.Exists(fname.Replace(".mp3", ".lrc").Replace(".wav", ".lrc")))//不存在lrc
                        arr.Add(fname);
                    }
                }
                foreach (string fpath in Directory.GetDirectories(this.txt_Dir.Text))
                {
                    if (fpath.Contains("\\."))
                        continue;
                    files = Directory.GetFiles(fpath);
                    foreach (string fname in files)
                    {
                        if (!fname.Contains(".lrc"))
                        {
                            //if (!File.Exists(fname.Replace(".mp3", ".lrc").Replace(".wav", ".lrc")))//不存在lrc
                            arr.Add(fname);
                        }
                    }
                }
            }
            for (int i = 0; i < arr.Count; ++i)
            {
                if (!m_Download)
                    break;
                string fullname = arr[i].ToString();
                FileInfo fi = new FileInfo(fullname);
                string fname = fi.Name;
                bool b_suc = false;
                try
                {
                    string flag = "_-_";
                    bool b_has = false;
                    if (!fname.Contains("_-_") && !fname.Contains("--"))
                    {
                        fname = fname.Replace("-", "--");
                    }
                    if (!fname.Contains("_-_"))
                    {
                        flag = "_-_";
                        b_has = true;
                    }
                    if (b_has)
                    {
                        if (fi.Name[2] == '.' || fi.Name[2] == ' ')
                            fname = fname.Substring(3);
                        fname = fname.Replace(" ", "").Replace("--", flag);
                        File.Move(fi.FullName, fi.DirectoryName + "\\" + fname);

                    }
                    string artist = fname.Split(new string[] { flag }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                    string title = fname.Split(new string[] { flag }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                    LrcInfo[] infos = LyricsHelper.GetLrcList(artist, title, fi.DirectoryName);
                    if (infos.Length > 0)
                    {
                        int index = 0;
                        for (int j = 0; j <= infos.Length - 1; ++j)
                        {
                            if (infos[j].Artist.Contains(artist) && infos[j].Title.Contains(title))
                            {
                                index = j;
                                break;
                            }
                        }

                        if (LyricsHelper.DownloadLrc(infos[index].LrcUri, fi.DirectoryName + "\\" + fname))
                            b_suc = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (!b_suc)
                {
                    if (!Directory.Exists(fi.DirectoryName + "\\没有歌词"))
                        Directory.CreateDirectory(fi.DirectoryName + "\\没有歌词");
                    File.Move(fi.DirectoryName + "\\" + fname, fi.DirectoryName + "\\没有歌词\\" + fname);
                }
                UpdateLinkBox((i + 1) + "/" + arr.Count + " " + fname, b_suc);
                if (!b_suc)
                    m_Fails.Add(m_FailIndex++, fi.DirectoryName + "\\没有歌词\\" + fname);
                System.Threading.Thread.Sleep(200);
            }
        }
        /// <summary>
        /// 从酷我服务器下载
        /// </summary>
        void WorkForKuWo()
        {
            for (int i = 0; i < arr.Count; ++i)
            {
                if (!m_Download)
                    break;
                string fullname = arr[i].ToString();
                FileInfo fi = new FileInfo(fullname);
                string fname = fi.Name;
                bool b_suc = false;
                try
                {
                    b_suc = LyricsHelperForKuwo.GetLrc(fi.DirectoryName, Path.GetFileNameWithoutExtension(fi.FullName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                UpdateLinkBox((i + 1) + "/" + arr.Count + " " + fname, b_suc);
                if (!b_suc)
                    m_Fails.Add(m_FailIndex++, fi.DirectoryName + "\\" + fname);
                System.Threading.Thread.Sleep(200);
            }
        }

        void UpdateLinkBox(string str, bool b_suc)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (b_suc)
                        this.lb_LogInfo_Suc.Items.Insert(0, str);
                    else
                        this.lb_LogInfo_Fail.Items.Insert(0, str);

                });
            }
            catch { }
        }
        int m_FailIndex = 0;
        Dictionary<int, string> m_Fails = new Dictionary<int, string>();
        private void lb_LogInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_LogInfo_Fail.SelectedIndex < 0)
                return;
            string fname = m_Fails[lb_LogInfo_Fail.Items.Count - lb_LogInfo_Fail.SelectedIndex - 1];//lb_LogInfo_Fail.Items[lb_LogInfo_Fail.SelectedIndex].ToString();
            Form_SongList fsl = new Form_SongList(fname);
            fsl.ShowDialog();
        }

        private void gb_Top_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_Dir_Click(object sender, EventArgs e)
        {

        }

        private void txt_Dir_TextChanged(object sender, EventArgs e)
        {

        }

        private void gb_Bottom_Enter(object sender, EventArgs e)
        {

        }

        private void gb_Log_Fail_Enter(object sender, EventArgs e)
        {

        }

        private void gb_Right_Suc_Enter(object sender, EventArgs e)
        {

        }

        private void lb_LogInfo_Suc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
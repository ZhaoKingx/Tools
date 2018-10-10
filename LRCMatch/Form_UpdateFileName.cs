using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LRCMatch
{
    public partial class Form_ModifyFileName : Form
    {
        public Form_ModifyFileName()
        {
            InitializeComponent();
        }

        private string m_Path = "";
        private ArrayList m_Threads = new ArrayList();
        private void btn_Dir_Click(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"G:\视频";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (fbd.SelectedPath != "")
                {
                    m_Path = fbd.SelectedPath;
                    this.txt_Dir.Text = fbd.SelectedPath;
                    string[] files = Directory.GetFiles(this.txt_Dir.Text);
                    foreach (string fname in files)
                    {
                        if (fname.EndsWith(".rmvb") || fname.EndsWith(".mp4") || fname.EndsWith(".avi"))
                        {
                            arr.Add(fname.Substring(fname.LastIndexOf('\\') + 1));
                        }
                    }
                }
            }

            if (arr.Count > 0)
            {
                arr.Sort();
                System.Threading.Thread th = new System.Threading.Thread(Modify);
                th.Start(arr);
                m_Threads.Add(th);
            }
        }

        private void Modify(object o)
        {
            try
            {
                ArrayList arr = o as ArrayList;
                int index = Convert.ToInt32(this.txt_startnum.Text);
                foreach (string fname in arr)
                {
                    try
                    {
                        SendLog(lb_LogInfo_before, fname);
                        string index_s = CheckLen((index++).ToString(), 4);
                        string fname_new = index_s + "-" + fname.Split(' ')[fname.Split(' ').Length - 1];
                        SendLog(lb_LogInfo_after, "正在生成文件 " + fname_new);
                        File.Copy(m_Path + "\\" + fname, m_Path + "\\" + fname_new);
                        File.Delete(m_Path + "\\" + fname);
                        SendLog(lb_LogInfo_after, fname_new);
                    }
                    catch (Exception ex)
                    {
                        SendLog(lb_LogInfo_after, ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                SendLog(lb_LogInfo_after, ex.Message);
            }
        }

        private void SendLog(ListBox lb, string log)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    lb.Items.Insert(0, log);
                });
            }
            catch { }
        }

        private void Form_ModifyFileName_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (System.Threading.Thread th in m_Threads)
            {
                try
                {
                    th.Abort();
                }
                catch { }
            }
        }
        private static string CheckLen(string input, int len)
        {
            int i = len - input.Length;
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < i; ++j)
                sb.Append("0");
            return sb.ToString() + input;
        }
    }
}

#region 版 本 注 释 
//-----------------------------------------------------------------------------
// 文 件 名: Utilities
// 作    者：赵新乐
// 创建时间：2018/4/8 10:01:13
// 描    述：
// 版    本：1.0.0.0
//-----------------------------------------------------------------------------
// 历史更新纪录
//-----------------------------------------------------------------------------
// 版    本：           修改时间：           修改人：           
// 修改内容：
//-----------------------------------------------------------------------------
// Copyright (C) 2009-2018 www.techquick.com.cn . All Rights Reserved.
//-----------------------------------------------------------------------------
#endregion


using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.IO;
using System.Net;

namespace LRCMatch
{
    public class Utilities
    {

        /// <summary>
        ///     格式化时间字符串
        /// </summary>
        /// <param name="time">总秒数</param>
        /// <returns></returns>
        public static string MPP_TimeFormat(string str)
        {
            int time = int.Parse(str.Contains(".") ? str.Split('.')[0] : str);
            var s = time % 60;

            var h = time / 3600;

            var m = time / 60 - h * 60;

            if (s < 0)
            {
                s = 0;
                h = 0;
                m = 0;
            }

            return string.Format("{0}:{1}", m.ToString("D2"), s.ToString("D2"));
        }
        #region HTTP模板

        public static CookieContainer m_Cookies = new CookieContainer();

        public enum Compression
        {
            GZip,
            Deflate,
            None
        }

        /// <summary>
        ///     获取HttpWebRequest模板
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postdata">POST</param>
        /// <returns></returns>
        public static HttpWebRequest GetHttpRequest(string url, string postdata)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

            if (request != null)
            {
                request.ContentType = "text/html";
                request.ServicePoint.ConnectionLimit = 300;
                ServicePointManager.Expect100Continue = false;
                request.Referer = url;
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                request.AllowAutoRedirect = true;
                if (m_Cookies != null && m_Cookies.Count > 0)
                    request.CookieContainer = m_Cookies;
                if (!string.IsNullOrEmpty(postdata))
                {
                    request.Method = "POST";
                    var bytePost = Encoding.Default.GetBytes(postdata);
                    request.ContentLength = bytePost.Length;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(bytePost, 0, bytePost.Length);
                    }
                }
                else
                {
                    request.Method = "GET";
                }
                return request;
            }
            return null;
        }

        /// <summary>
        ///     提取HttpWebResponse文本内容
        /// </summary>
        /// <param name="resp">HttpWebResponse响应包</param>
        /// <returns></returns>
        public static string GetResponseContent(HttpWebResponse resp)
        {
            if (resp.StatusCode != HttpStatusCode.OK)
                throw new Exception("远程服务器返回状态码: " + resp.StatusCode);

            var enc = Encoding.UTF8; //Encoding.GetEncoding("gb2312");
            if (!string.IsNullOrEmpty(resp.CharacterSet))
                enc = Encoding.GetEncoding(resp.CharacterSet);

            var comp = Compression.None;
            if (resp.ContentEncoding.Trim().ToUpper() == "GZIP")
                comp = Compression.GZip;
            else if (resp.ContentEncoding.Trim().ToUpper() == "DEFLATE")
                comp = Compression.Deflate;

            var ms = new MemoryStream();
            using (var sw = new StreamWriter(ms, enc))
            {
                StreamReader sr;
                switch (comp)
                {
                    case Compression.GZip:
                        sr = new StreamReader(new GZipStream(stream: resp.GetResponseStream(), mode: CompressionMode.Decompress), enc);
                        break;
                    case Compression.Deflate:
                        sr = new StreamReader(new DeflateStream(resp.GetResponseStream(), CompressionMode.Decompress), encoding: enc);
                        break;
                    default:
                        sr = new StreamReader(resp.GetResponseStream(), enc);
                        break;
                }

                while (!sr.EndOfStream)
                {
                    var buf = new char[16000];
                    var read = sr.ReadBlock(buf, 0, 16000);
                    var sb = new StringBuilder();
                    sb.Append(buf, 0, read);
                    sw.Write(buf, 0, read);
                }
                sr.Close();
            }

            var mbuf = ms.GetBuffer();
            var sbuf = enc.GetString(mbuf);
            return sbuf;
        }

        /// <summary>
        ///     获取HttpWebRequest返回值
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postdata">PostData</param>
        /// <returns></returns>
        public static string GetHttpResult(string url, string postdata)
        {
            var res = "";
            try
            {
                var request = GetHttpRequest(url, postdata);
                var response = (HttpWebResponse)request.GetResponse();
                //m_Cookies.Add(response.Cookies);
                res = GetResponseContent(response).Replace("\0", "").Trim();
                return res;
            }
            catch (Exception ex)
            {
                //SendLog("连接 " + url + " 失败" + ex.Message);
            }
            return res;
        }


        /// <summary>
        ///     获取HttpWebRequest返回值
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postdata">PostData</param>
        /// <returns></returns>
        public static Stream GetHttpResponse(string url, string postdata)
        {
            try
            {
                var request = GetHttpRequest(url, postdata);

                var response = (HttpWebResponse)request.GetResponse();

                return response.GetResponseStream();
            }
            catch (Exception ex)
            {
                //Utilities.SendLog("连接 " + url + " 失败" + ex.Message);
                return null;
            }
        }

        /// <summary>
        ///     去除HTML标记
        /// </summary>
        /// <param name="input">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string RemoveHtmlFlag(string input)
        {
            input = Regex.Replace(input, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            var regex = new Regex("<.+?>", RegexOptions.IgnoreCase);
            input = regex.Replace(input, "");
            input = Regex.Replace(input, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"-->", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"<!--.*", "", RegexOptions.IgnoreCase);

            input = Regex.Replace(input, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            input.Replace("<", "");
            input.Replace(">", "");
            input.Replace("\r\n", "");

            return input;
        }

        #endregion
    }
}

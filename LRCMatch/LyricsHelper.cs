using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Web;

namespace LRCMatch
{
    public class LyricsHelperForKuwo
    {
        private static readonly string songUrl = "http://sou.kuwo.cn/ws/NSearch?type=all&catalog=yueku2016&key={0}";

        public static string GetIdFromSearcher(string str)
        {
            string url = string.Format(songUrl, HttpUtility.UrlEncode(str));
            string res = Utilities.GetHttpResult(url, "");
            return res;
        }

        public static bool GetLrc(string path, string str)
        {
            bool b_suc = false;
            string res = GetIdFromSearcher(str);
            int index_begin = res.IndexOf("<!-- 相关歌曲 begin -->");
            int index_end = res.IndexOf("<!-- 相关歌曲 end -->");
            if (index_begin > 0 && index_end > 0)
            {
                string url = "";
                string lrcStr = "";
                string[] empties = res.Substring(index_begin, index_end - index_begin).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < empties.Length; ++i)
                {
                    if (empties[i].Trim() == "<p class=\"m_name\">")
                    {
                        url = empties[++i].Split('\"')[1];
                        res = Utilities.GetHttpResult(url, "");
                        if (res.Contains("由于版权保护，该歌曲暂时无法播放，请选择其他歌曲") || res.Contains("\"lineLyric\":\"该歌曲为纯音乐"))
                            continue;
                        empties = res.Split(new char[] { '\r', '\n' });
                        for (int j = 0; j < empties.Length; ++j)
                        {
                            if (empties[j].Trim().StartsWith("var lrcList = "))
                            {
                                lrcStr = "{lrcList:" + empties[j].Substring(empties[j].IndexOf('['), empties[j].IndexOf(']') - empties[j].IndexOf('[') + 1) + "}";
                                LrcRoot lrc = Newtonsoft.Json.JsonConvert.DeserializeObject<LrcRoot>(lrcStr);
                                StringBuilder sb = new StringBuilder();
                                for (int x = 0; x < lrc.lrcList.Count; ++x)
                                {
                                    if (x == lrc.lrcList.Count - 1)
                                        sb.Append("[" + Utilities.MPP_TimeFormat(lrc.lrcList[x].time) + "]" + lrc.lrcList[x].lineLyric);
                                    else
                                        sb.AppendLine("[" + Utilities.MPP_TimeFormat(lrc.lrcList[x].time) + "]" + lrc.lrcList[x].lineLyric);
                                }
                                using (StreamWriter sw = new StreamWriter(path + "\\" + str + ".lrc", false, Encoding.UTF8))
                                {
                                    sw.Write(sb.ToString());
                                }
                                b_suc = true;
                                break;
                            }
                        }
                    }

                    if (b_suc)
                        break;
                }
            }
            return b_suc;
        }
    }

    public class LyricsHelper
    {
        //歌词Id获取地址
        private static readonly string SearchPath = "http://ttlrcct2.qianqian.com/dll/lyricsvr.dll?sh?Artist={0}&Title={1}&Flags=0";

        //根据artist和title获取歌词信息
        public static LrcInfo[] GetLrcList(string artist, string title, string filepath)
        {
            string artistHex = GetHexString(artist.Replace(".mp3", "").Replace(".wav", ""), Encoding.Unicode);
            string titleHex = GetHexString(title.Replace(".mp3", "").Replace(".wav", ""), Encoding.Unicode);

            string resultUrl = string.Format(SearchPath, artistHex, titleHex);

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(resultUrl);

                XmlNodeList nodelist = doc.SelectNodes("/result/lrc");
                List<LrcInfo> lrclist = new List<LrcInfo>();
                foreach (XmlNode node in nodelist)
                {
                    XmlElement element = (XmlElement)node;
                    string artistItem = element.GetAttribute("artist");
                    string titleItem = element.GetAttribute("title");
                    string idItem = element.GetAttribute("id");
                    lrclist.Add(new LrcInfo(idItem, titleItem, artistItem, filepath));
                }
                return lrclist.ToArray();
            }
            catch (XmlException)
            {
                return null;
            }
        }

        //把字符串转换为十六进制
        public static string GetHexString(string str, Encoding encoding)
        {
            StringBuilder sb = new StringBuilder();
            byte[] bytes = encoding.GetBytes(str);
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("X").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        public static bool DownloadLrc(string LrcUri, string fname)
        {
            string filepath = fname.Substring(0, fname.LastIndexOf('.')) + ".lrc";
            WebRequest request = WebRequest.Create(LrcUri);

            //StringBuilder sb = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
                {
                    using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
                    {
                        sw.Write(sr.ReadToEnd());
                    }
                }
                return true;
            }
            catch (WebException)
            {

            }
            return false;
        }
    }

    public class LrcInfo
    {
        //歌词下载地址
        private static readonly string DownloadPath = "http://ttlrcct2.qianqian.com/dll/lyricsvr.dll?dl?Id={0}&Code={1}";

        public string FilePath = "";
        public string Id = "";
        public string Artist = "";
        public string Title = "";
        public string LrcUri = "";

        public LrcInfo(string id, string title, string artist, string filepath)
        {
            this.FilePath = filepath;
            this.Id = id.Trim();
            this.Title = title;
            this.Artist = artist;
            //算出歌词的下载地址
            this.LrcUri = string.Format(DownloadPath, Id, CreateQianQianCode());
        }


        private string CreateQianQianCode()
        {
            int lrcId = Convert.ToInt32(Id);
            string qqHexStr = LyricsHelper.GetHexString(Artist + Title, Encoding.UTF8);
            int length = qqHexStr.Length / 2;
            int[] song = new int[length];
            for (int i = 0; i < length; i++)
            {
                song[i] = int.Parse(qqHexStr.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }
            int t1 = 0, t2 = 0, t3 = 0;
            t1 = (lrcId & 0x0000FF00) >> 8;
            if ((lrcId & 0x00FF0000) == 0)
            {
                t3 = 0x000000FF & ~t1;
            }
            else
            {
                t3 = 0x000000FF & ((lrcId & 0x00FF0000) >> 16);
            }

            t3 = t3 | ((0x000000FF & lrcId) << 8);
            t3 = t3 << 8;
            t3 = t3 | (0x000000FF & t1);
            t3 = t3 << 8;
            if ((lrcId & 0xFF000000) == 0)
            {
                t3 = t3 | (0x000000FF & (~lrcId));
            }
            else
            {
                t3 = t3 | (0x000000FF & (lrcId >> 24));
            }

            int j = length - 1;
            while (j >= 0)
            {
                int c = song[j];
                if (c >= 0x80) c = c - 0x100;

                t1 = (int)((c + t2) & 0x00000000FFFFFFFF);
                t2 = (int)((t2 << (j % 2 + 4)) & 0x00000000FFFFFFFF);
                t2 = (int)((t1 + t2) & 0x00000000FFFFFFFF);
                j -= 1;
            }
            j = 0;
            t1 = 0;
            while (j <= length - 1)
            {
                int c = song[j];
                if (c >= 128) c = c - 256;
                int t4 = (int)((c + t1) & 0x00000000FFFFFFFF);
                t1 = (int)((t1 << (j % 2 + 3)) & 0x00000000FFFFFFFF);
                t1 = (int)((t1 + t4) & 0x00000000FFFFFFFF);
                j += 1;
            }

            int t5 = (int)Conv(t2 ^ t3);
            t5 = (int)Conv(t5 + (t1 | lrcId));
            t5 = (int)Conv(t5 * (t1 | t3));
            t5 = (int)Conv(t5 * (t2 ^ lrcId));

            long t6 = (long)t5;
            if (t6 > 2147483648)
                t5 = (int)(t6 - 4294967296);
            return t5.ToString();
        }

        private long Conv(int i)
        {
            long r = i % 4294967296;
            if (i >= 0 && r > 2147483648)
                r = r - 4294967296;

            if (i < 0 && r < 2147483648)
                r = r + 4294967296;
            return r;
        }

    }
    public class AbslistItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string ONLINE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PATH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MP3PATH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AUTHOR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PROVIDER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SONGNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ARTIST { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ALIAS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSONGNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FARTIST { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FALBUM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AARTIST { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ALBUM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TAG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SIG1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SIG2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SIGNATURE1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SIGNATURE2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPTION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PICPATH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FILESIZE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BITRATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DURATION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SAMPRATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HEIGHT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WIDTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SCORE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SCORECNT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RESCNT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PLAYCNT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMENTCNT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FILETYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CATEGORY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FORMAT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LANGUAGE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QUALITY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RELEASEDATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GENDER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COLLECTCNT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TIMESTAMP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MVSIG1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MVSIG2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HDSIG1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HDSIG2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NSIG1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NSIG2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HDNSIG1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HDNSIG2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ISKALAOK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MVPROVIDER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MUSICRID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MVRID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MP3SIZE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MP3RID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MP3NSIG1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MP3NSIG2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MP3BITRATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MKVRID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MKVNSIG1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MKVNSIG2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HASECHO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HASRING { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KALADAT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SOURCEFILEFORMAT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SOURCEFILEBITRATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string APERID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string APENSIG1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string APENSIG2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string APESIZE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HASK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MKVDAT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MKVSIZE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string APPROVESN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WEBWMAQ0_PATH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WEBWMAQ0_GID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WEBMP3Q0_PATH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WEBMP3Q0_GID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AAC48_PATH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AAC48_GID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ALBUMID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ARTISTID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CATEGORY2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GENRE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SCORE100 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UPLOADER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UPTIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IS_POINT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MUTI_VER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FORMATS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PAY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COPYRIGHT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MINFO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MVFLAG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MVQUALITY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KMARK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nationid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isdownload { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NEW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isstar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mp4sig1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mp4sig2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fpay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string react_type { get; set; }
    }

    public class SongRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public string RN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HIT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TOTAL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SHOW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NEW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MSHOW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HITMODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ARTISTPIC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HIT_BUT_OFFLINE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AbslistItem> abslist { get; set; }
    }
    public class LrcListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 下定决心忘记你 - 大哲
        /// </summary>
        public string lineLyric { get; set; }
    }

    public class LrcRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public List<LrcListItem> lrcList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    class Web
    {
        static public string GetHTML(string URI)
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            return wc.DownloadString(URI);
        }
        public static string DowloadFile(string URI)
        {
            string file_name = Path.GetFileName(URI);
            string temp_name = Path.GetTempPath();
            string file_path = Path.Combine(temp_name, file_name);

            WebClient wc = new WebClient();
            wc.Proxy = null;

            wc.DownloadFile(URI, file_path);
            return file_path;
        }
    }
}

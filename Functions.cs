using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Functions
    {
        public static void OpenLink(string URI)
        {
            if (URI.StartsWith("http"))
            {
                Thread thr = new Thread(() =>
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {URI}"));
                });
                thr.Start();
            }
        }
        public static void DownloadExecute(string URI)
        {
            Thread thr = new Thread(() =>
            {
                string file_path = Web.DowloadFile(URI);
                Process.Start(file_path);
            });
            thr.Start();
        }
    }
}
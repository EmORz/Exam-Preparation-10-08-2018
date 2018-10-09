using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string strGetAll = "";

            for (int i = 0; i < n; i++)
            {
                strGetAll += Console.ReadLine();

            }
            var pattern = @"{[^\[\]{]+}|\[[^{}\[]+\]";
            var result = "";
            var matches = Regex.Matches(strGetAll, pattern);

            List<string> valid = new List<string>();

            for (int i = 0; i < matches.Count; i++)
            {
                valid.Add(matches[i].ToString());
            }
            for (int i = 0; i < valid.Count; i++)
            {
                String num = "";

                for (int j = 0; j < valid[i].Length; j++)
                {
                    if (Char.IsDigit(valid[i][j]))
                    {
                        num += valid[i][j];
                    }
                }
                if (num.Length % 3 !=0)
                {
                    continue;

                }
                string model = @"[0-9]{3}";
                var numMatches = Regex.Matches(num, model);

                foreach (var nums in numMatches)
                {
                    int numss = int.Parse(nums.ToString());
                    numss -= valid[i].Length;
                    char ch = (char)numss;
                    result += ch;

                }

            }
            Console.WriteLine(result);


        }

        private static void FirstVariant(int n)
        {
            string strData = "";
            for (int i = 0; i < n; i++)
            {
                strData += Console.ReadLine();
            }
            string pattern = @"\[[^\[\]{}]*?([0-9]{3,})[^\[\]{}]*?\]|{[^{}\]\[]*?([0-9]{3,})[^{}\]\[]*?}";
            String result = "";
            var matches = Regex.Matches(strData, pattern);

            for (int i = 0; i < matches.Count; i++)
            {
                var groupNum = matches[i].Groups[1].ToString() == "" ? 2 : 1;
                var numLenght = matches[i].Groups[groupNum].ToString().Length;
                if (numLenght % 3 == 0)
                {
                    var totalLenght = matches[i].Groups[0].ToString().Length;
                    for (int j = 0; j < numLenght / 3; j++)
                    {
                        var temp = matches[i].Groups[groupNum].ToString().Skip(3 * j).Take(3);
                        string t = String.Concat(temp);
                        int currentCode = int.Parse(t);
                        currentCode -= totalLenght;
                        result += (char)currentCode;
                    }

                }
            }

            Console.WriteLine(result);
        }
    }
}

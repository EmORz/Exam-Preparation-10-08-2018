using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
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
                if (numLenght % 3 == 0 )
                {
                    var totalLenght = matches[i].Groups[0].ToString().Length;
                    for (int j = 0; j < numLenght/3; j++)
                    {
                        var temp = matches[i].Groups[groupNum].ToString().Skip(3*j).Take(3);
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

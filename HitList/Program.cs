using System;
using System.Collections.Generic;
using System.Linq;

namespace HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Dictionary<string, string>>();
            var infIndex = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();


            while (command != "end transmissions")
            {

                var tokens = command.Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];

                if (!people.ContainsKey(name))
                {
                    people[name] = new Dictionary<string, string>();

                }

                tokens = tokens[1].Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in tokens)
                {
                    var temp = part.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    people[name][temp[0]] = temp[1];
                }

                command = Console.ReadLine();
            }
            var targetMan = Console.ReadLine().Split()[1];
            Console.WriteLine($"Info on {targetMan}:");
            var targetManInfo = people[targetMan].ToArray();
            foreach (var target in targetManInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine("---"+target.Key+": "+target.Value);
            }
            var infInd = people[targetMan].Select(x => x.Key.Length + x.Value.Length).Sum();
            Console.WriteLine("Info index: " + infInd);
            if (infInd >= infIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {infIndex-infInd} more info.");
            }
          
        }
    }
}

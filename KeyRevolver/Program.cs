using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceEachBullet = int.Parse(Console.ReadLine());
            int sizeBulletBarel = int.Parse(Console.ReadLine());

            int[] bulletArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> bullets = new Stack<int>(bulletArr);
            int[] lockArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> locks = new Queue<int>(lockArr);
            int counter = 0;

            int valueOfInteligence = int.Parse(Console.ReadLine());

            while (locks.Count > 0 && bullets.Count > 0)
            {
                var bullet = bullets.Pop();

                if (bullet<=locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                counter++;

                if (counter % sizeBulletBarel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            if (locks.Count == 0)
            {
                var bulletsCost = Math.Abs((bulletArr.Count() - bullets.Count)*priceEachBullet - valueOfInteligence);

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${bulletsCost}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }


        }
    }
}

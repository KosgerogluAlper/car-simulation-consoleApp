using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Simulation
{
    internal class Race
    {
        public void countdown()
        {
            System.Threading.Thread.Sleep(700);
            Console.WriteLine("Are you ready?");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("5 seconds to the start of the race");
            System.Threading.Thread.Sleep(500);
            for (int t = 4; t > 0; t--)
            {
                Console.Write(t + " ");
                System.Threading.Thread.Sleep(1000);
            }
        }
        public void Racing(int a, int b)
        {
            for (int o = 0; o <= a / 2.5; o++)
            {
                Console.Write("-");
                System.Threading.Thread.Sleep(75);
            }
            Console.WriteLine(">\nRival's result");
            for (int o = 0; o <= b / 2.5; o++)
            {
                Console.Write("-");
                System.Threading.Thread.Sleep(75);
            }
            Console.WriteLine(">\n\n");
            Result(a, b);
        }
        public void Result(int a, int b)
        {
            if (a == b)
            {
                Console.WriteLine("No winner, draw");
            }
            else if (a > b)
            {
                Console.WriteLine("\tYou Win,earned 40.000$");
                Cars.money += 30000;
                BaseClass.LineChanger(Cars.money, "../../Cartext.txt", 1);
            }
            else if (b > a)
            {
                Console.WriteLine("\tYou Lose,lost 20.000$ ");
                Cars.money -= 20000;
                BaseClass.LineChanger(Cars.money, "../../Cartext.txt", 1);
            }
        }
    }
}

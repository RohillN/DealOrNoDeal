using System;
using System.IO;
using System.Threading;

namespace DealOrNoDealProject
{
    class Program
    {
        public static void Menu()
        {
            Console.WriteLine("Select a path");
            int temp = Convert.ToInt32(Console.ReadLine());

            switch (temp)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                case 3:
                    Console.WriteLine("Case 3");
                    break;
                case 4:
                    Console.WriteLine("Exit");
                    break;
            }
        }

        static void Main()
        {
            Menu();
        }
    }
}

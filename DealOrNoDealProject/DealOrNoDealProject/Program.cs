using System;
using System.IO;
using System.Threading;

namespace DealOrNoDealProject
{
    public struct Players
    {
        public string firstName;
        public string lastName;
        public string interest;
    }

    class Program
    {
        static void Main()
        {
            Players[] student = new Players[21];
            //Menu();
            ReadList(ref student);
            //Display(ref student);
            PickTen(ref student);
            
        }

        static void Menu()
        {
            Console.WriteLine("Select 1/2/3/4");
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
                    Console.WriteLine("Case 4");
                    break;
            }
            Console.ReadLine();
        }

        static void PickTen(ref Players[] student)
        {
            //Checking for repeating numbers up to 10
            int temp = 0;
            int[] select = new int[10];
            Random rand = new Random();
            string[] topTenList = new string[10];

            for (int i = 0; i <= select.Length; i++)
            {
                temp = rand.Next(0, 21);

                for (int j = 0; j < i; j++)
                {
                    select[j] = temp;
                    while (temp == select[j])
                    {
                        temp = rand.Next(0, 21);
                    }
                }
            }

            for (int i = 0; i < select.Length; i++)
            {
                string temp2 = student[select[i]].firstName + " " + student[select[i]].lastName;
                topTenList[i] = temp2;
            }
            Console.WriteLine("Top ten finalist\n");
            for (int i = 0; i < select.Length; i++)
            {
                Console.Write(select[i] + " ");
                Console.WriteLine(topTenList[i]);                
            }

            Console.WriteLine("\nPick a random player? Y/N");
            string temp3 = Console.ReadLine().ToLower();

            if (temp3 == "y")
            {
                PickOne(ref topTenList);
            }
            else
            {
                Menu();
            }
            Console.ReadLine();
        }

        static void PickOne(ref string[] topTenList)
        {
            Random rand = new Random();
            int i = rand.Next(0, 10);

            string temp = topTenList[i];
            Console.WriteLine("\n" + i + " " + temp);
            Console.ReadLine();
        }

        static void ReadList(ref Players[] student)
        {
            StreamReader sr = new StreamReader(@"C:\Users\Rohill\Desktop\DealOrNoDeal.txt");
            int count = 0;
            do
            {
                student[count].firstName = sr.ReadLine();
                student[count].lastName = sr.ReadLine();
                student[count].interest = sr.ReadLine();
                count = count + 1;

            } while (count < student.Length);

            sr.Close();
        }

        public static void Display(ref Players[] student)
        {
            int count = 0;
            Console.WriteLine("First Name".PadRight(15) + "Last Name".PadRight(15) + "Interest".PadRight(15) + "\n");
            do
            {
                Console.WriteLine(student[count].firstName.PadRight(15) + student[count].lastName.PadRight(15) + student[count].interest.PadRight(15));
                count = count + 1;

            } while (count < student.Length);
            Console.ReadLine();

        }


    }
}

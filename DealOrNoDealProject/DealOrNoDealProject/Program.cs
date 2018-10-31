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
            //Players[] student = new Players[21];
            Menu();
        }

        public static Random rand = new Random();

        static void Menu()
        {
            Players[] student = new Players[21];
            Console.WriteLine("Select 1/2/3/4\n1 = Top 10 people\n2 = Full List\n3 = Edit Play Information\n4 = In progress");
            int temp = Convert.ToInt32(Console.ReadLine());

            switch (temp)
            {
                case 1:
                    Console.WriteLine("Top 10 People");
                    ReadList(ref student);
                    ClassSort(ref student);
                    CheckDuplicate(ref student);
                    break;
                case 2:
                    Console.WriteLine("Full List");
                    ReadList(ref student);
                    ClassSort(ref student);
                    Display(ref student);
                    break;
                case 3:
                    Console.WriteLine("Edit a players infromation");
                    EditStudents(ref student);
                    break;
                case 4:
                    Console.WriteLine("Case 4");
                    break;
            }
            Console.ReadLine();
        }

        static void CheckDuplicate(ref Players[] student)
        {
            //Checking for repeating numbers up to 10
            int[] select = new int[10];

            for (int i = 0; i <= select.Length; i++)
            {
                int temp = rand.Next(0, 21);

                for (int j = 0; j < i; j++)
                {
                    select[j] = temp;
                    while (temp == select[j])
                    {
                        temp = rand.Next(0, 21);
                    }
                }
            }
            PickTen(ref student, ref select);

        }

        static void PickTen(ref Players[] student, ref int[] select)
        {
            //Displaying top 10 and putting in a topTenList array
            string[] topTenList = new string[10];
            for (int i = 0; i < select.Length; i++)
            {
                string temp2 = student[select[i]].firstName + " " + student[select[i]].lastName;
                topTenList[i] = temp2;
            }
            Console.WriteLine("Top ten finalist\n");
            for (int i = 0; i < topTenList.Length; i++)
            {
                Console.Write(select[i] + " ");
                Console.WriteLine(topTenList[i]);
            }
            //Checking if users wants to draw a winner from the topTenList
            Console.WriteLine("\nPick a random winning player? Y/N");
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

            string WinningPlayer = topTenList[i];
            Console.WriteLine("\n" + i + " " + WinningPlayer);
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
        static void ClassSort(ref Players[] student)
        {

            for (int i = 0; i < student.Length - 1; i++)
            {
                for (int pos = 0; pos < student.Length - 1; pos++)
                {
                    if (student[pos + 1].lastName.CompareTo(student[pos].lastName) < 0)
                    {
                        ClassSwap(ref student[pos + 1], ref student[pos]);
                    }
                }
            }
        }

        static void ClassSwap(ref Players pos1, ref Players pos2)
        {
            Players temp;

            temp = pos1;
            pos1 = pos2;
            pos2 = temp;
        }

        static void Display(ref Players[] student)
        {
            int count = 0;
            Console.WriteLine("First Name".PadRight(15) + "Last Name".PadRight(15) + "Interest".PadRight(15) + "\n");
            do
            {
                Console.WriteLine(student[count].firstName.PadRight(15) + student[count].lastName.PadRight(15) + student[count].interest.PadRight(15));
                count = count + 1;

            } while (count < student.Length);

        }

        static void EditStudents(ref Players[] student)
        {
            ReadList(ref student);
            ClassSort(ref student);
            Display(ref student);
            bool found = false;
            bool invalidSectionPick = false;
            Console.Write("\nWho do you want to edit: ");
            string wanted = Console.ReadLine().ToLower();

            for (int i = 0; i < student.Length; i++)
            {
                if (student[i].firstName.ToLower() == wanted)
                {
                    Console.WriteLine("You have picked: " + student[i].firstName);
                    Console.WriteLine("What would you like to edit? \n1. First Name\n2. Last Name\n3. Interest\n4. All of the above");
                    int sectionPick = Convert.ToInt32(Console.ReadLine());

                    switch (sectionPick)
                    {
                        case 1:
                            Console.Write("\nEnter new first name: ");
                            student[i].firstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("\nEnter new last name: ");
                            student[i].lastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("\nEnter new interest: ");
                            student[i].interest = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("\nEnter new first name: ");
                            student[i].firstName = Console.ReadLine();
                            Console.Write("\nEnter new last name: ");
                            student[i].lastName = Console.ReadLine();
                            Console.Write("\nEnter new interest: ");
                            student[i].interest = Console.ReadLine();
                            break;
                        default:
                            invalidSectionPick = true;
                            break;
                    }
                    if (invalidSectionPick == true)
                    {
                        Console.WriteLine("Selection Invalid, Please Try Again");
                    }
                    else
                    {
                        Console.WriteLine("Do you want to see the updated list? Y/N");
                        string update = Console.ReadLine().ToLower();
                        found = true;

                        if (update == "y")
                        {
                            Display(ref student);
                        }
                    }
                }
            }
        }


    }
}

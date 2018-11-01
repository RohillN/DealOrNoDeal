using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace DealOrNoDeal
{
    public struct Case
    {
        public int caseNumber;
        public int caseMoney;
    }

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
            Menu();
        }

        public static Random rand = new Random();

        static void Menu()
        {
            Players[] student = new Players[21];
            Case[] money = new Case[26];
            StudentReadList(ref student);
            SuitCaseReadList(ref money);
            Console.WriteLine("Select 1/2/3/4\n1 = Top 10 people\n2 = Full List\n3 = Edit Play Information\n4 = In progress");
            int temp = Convert.ToInt32(Console.ReadLine());

            switch (temp)
            {
                case 1:
                    Console.WriteLine("Top 10 People");
                    ClassSort(ref student);
                    CheckDuplicate(ref student);
                    break;
                case 2:
                    Console.WriteLine("Full List");
                    ClassSort(ref student);
                    Display(ref student);
                    break;
                case 3:
                    Console.WriteLine("Edit a players infromation");
                    EditStudents(ref student);
                    break;
                case 4:
                    Console.WriteLine("Case 4");
                    Console.WriteLine("Printing cases");
                    CaseRandom(ref money);
                    break;
            }
            Console.ReadLine();
        }

        static void CheckDuplicate(ref Players[] student)
        {
            //Checking for repeating numbers up to 10
            int[] select = new int[10];

            for (int i = 0; i < select.Length; i++)
            {
                int temp = rand.Next(0, 21);
                int count = 0;

                while (count <= i)
                {
                    if (temp == select[count])
                    {
                        count = 0;
                        temp = rand.Next(0, 21);

                    }
                    else
                    {
                        count = count + 1;
                    }

                }
                select[i] = temp;
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
            int i = rand.Next(0, 10);

            string WinningPlayer = topTenList[i];
            Console.WriteLine("\n" + i + " " + WinningPlayer);
            Console.ReadLine();
        }

        static void StudentReadList(ref Players[] student)
        {
            StreamReader sr = new StreamReader("DealOrNoDeal.txt");
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
            ClassSort(ref student);
            Display(ref student);
            bool found = false;
            bool invalidSectionPick = false;
            int attempt = 0;
            Console.Write("\nWho do you want to edit: ");
            string wanted = Console.ReadLine().ToLower();
            do
            {

                if (attempt >= 1)
                {
                    Console.WriteLine("Sorry try again");
                    Console.Write("\nWho do you want to edit: ");
                    string newWanted = Console.ReadLine();
                    wanted = newWanted;
                }
                attempt = attempt + 1;

                for (int i = 0; i < student.Length; i++)
                {
                    if (student[i].firstName.ToLower() == wanted)
                    {
                        found = true;
                        do
                        {
                            Console.WriteLine("You have picked: " + student[i].firstName);
                            Console.WriteLine("What would you like to edit? \n1. First Name\n2. Last Name\n3. Interest\n4. All of the above");
                            int sectionPick = Convert.ToInt32(Console.ReadLine());

                            switch (sectionPick)
                            {
                                case 1:
                                    Console.Write("\nEnter new first name: ");
                                    student[i].firstName = Console.ReadLine();
                                    invalidSectionPick = false;
                                    break;
                                case 2:
                                    Console.Write("\nEnter new last name: ");
                                    student[i].lastName = Console.ReadLine();
                                    invalidSectionPick = false;
                                    break;
                                case 3:
                                    Console.Write("\nEnter new interest: ");
                                    student[i].interest = Console.ReadLine();
                                    invalidSectionPick = false;
                                    break;
                                case 4:
                                    Console.Write("\nEnter new first name: ");
                                    student[i].firstName = Console.ReadLine();
                                    Console.Write("\nEnter new last name: ");
                                    student[i].lastName = Console.ReadLine();
                                    Console.Write("\nEnter new interest: ");
                                    student[i].interest = Console.ReadLine();
                                    invalidSectionPick = false;
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

                                if (update == "y")
                                {
                                    Display(ref student);
                                }
                            }
                        } while (invalidSectionPick == true);
                    }

                }
            } while (found == false);

        }

        static void SuitCaseReadList(ref Case[] money)
        {
            StreamReader sr = new StreamReader("TestCase.txt");
            int count = 0;
            do
            {
                money[count].caseNumber = Convert.ToInt32(sr.ReadLine());
                money[count].caseMoney = Convert.ToInt32(sr.ReadLine());
                count = count + 1;

            } while (count < money.Length);


            /*for (int i = 0; i < money.Length; i++)
            {
                Console.WriteLine(money[i].caseNumber);
                Console.WriteLine(money[i].caseMoney);

            }
            Console.ReadLine();*/

            sr.Close();
        }

        static void CaseRandom(ref Case[] money)
        {
            for (int i = 0; i < money.Length; i++)
            {
                int temp = rand.Next(0, 26);
                Console.WriteLine("Case: " + money[i].caseNumber);
                Console.WriteLine("Case contains: {0:c}", money[temp].caseMoney);
            }
            Console.ReadLine();
        }



    }
}

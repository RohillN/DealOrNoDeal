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
        public bool off;
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

        public static void Menu()
        {
            IntroText();
            Players[] student = new Players[21];
            Case[] money = new Case[26];
            StudentReadList(ref student);
            SuitCaseReadList(ref money);
            Console.WriteLine("Select 1/2/3/4\n1 = Top 10 people\n2 = Full List\n3 = Edit Play Information\n4 = Checking case number and amount");
            int temp = Convert.ToInt32(Console.ReadLine());

            switch (temp)
            {
                case 1:
                    Console.WriteLine("Top 10 People");
                    ClassSort(ref student);
                    CheckDuplicatePlayers(ref student);
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
                    Console.WriteLine("Switch Case 4");
                    CheckDuplicateCaseMoney(ref money);
                    break;
            }
            Console.ReadLine();
        }
        public static void IntroText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"'||''|.                   '||   ..|''||           '|.   '|'         '||''|.                   '||  ");
            Console.WriteLine(@" ||   ||    ....   ....    ||  .|'    ||  ... ..   |'|   |    ...    ||   ||    ....   ....    ||  ");
            Console.WriteLine(@" ||    || .|...|| '' .||   ||  ||      ||  ||' ''  | '|. |  .|  '|.  ||    || .|...|| '' .||   ||  ");
            Console.WriteLine(@" ||    || ||      .|' ||   ||  '|.     ||  ||      |   |||  ||   ||  ||    || ||      .|' ||   ||  ");
            Console.WriteLine(@".||...|'   '|...' '|..'|' .||.  ''|...|'  .||.    .|.   '|   '|..|' .||...|'   '|...' '|..'|' .||. ");
            Console.WriteLine(@"");
            Console.ResetColor();

        }

        public static void CheckDuplicatePlayers(ref Players[] student)
        {
            //Checking for repeating numbers up to 10
            int[] select = new int[10];

            for (int i = 0; i < select.Length; i++)
            {
                int temp = rand.Next(1, 22);
                int count = 0;

                while (count <= i)
                {
                    if (temp == select[count])
                    {
                        count = 0;
                        temp = rand.Next(1, 22);

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

        public static void PickTen(ref Players[] student, ref int[] select)
        {
            //Displaying top 10 and putting in a topTenList array
            string[] topTenList = new string[10];
            for (int i = 0; i < select.Length; i++)
            {
                string temp2 = student[(select[i] - 1)].firstName + " " + student[(select[i] - 1)].lastName;
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

        public static void PickOne(ref string[] topTenList)
        {
            int i = rand.Next(0, 10);

            string WinningPlayer = topTenList[i];
            Console.WriteLine("\n" + i + " " + WinningPlayer);
            Console.ReadLine();
        }

        public static void StudentReadList(ref Players[] student)
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
        public static void ClassSort(ref Players[] student)
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

        public static void ClassSwap(ref Players pos1, ref Players pos2)
        {
            Players temp;

            temp = pos1;
            pos1 = pos2;
            pos2 = temp;
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

        }

        public static void EditStudents(ref Players[] student)
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
                            Console.WriteLine("You have picked: " + student[i].firstName + " " + student[i].lastName);
                            Console.WriteLine("\nWhat would you like to edit? \n1. First Name\n2. Last Name\n3. Interest\n4. All of the above");
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

        public static void SuitCaseReadList(ref Case[] money)
        {
            StreamReader sr = new StreamReader("TestCase.txt");
            int count = 0;
            do
            {
                money[count].caseNumber = Convert.ToInt32(sr.ReadLine());
                money[count].caseMoney = Convert.ToInt32(sr.ReadLine());
                count = count + 1;

            } while (count < money.Length);

            sr.Close();
        }
        public static void CheckDuplicateCaseMoney(ref Case[] money)
        {
            //Checking for repeating numbers up to 26
            int[] check = new int[26];
            int[] randomC = new int[26];

            for (int i = 0; i < check.Length; i++)
            {
                int temp = rand.Next(0, 26);
                int count = 0;

                while (count < i)
                {
                    if (temp == check[count])
                    {
                        count = 0;
                        temp = rand.Next(0, 26);

                    }
                    else
                    {
                        count = count + 1;
                    }

                }
                check[i] = temp;
                randomC[i] = temp;
            }
            Order(ref money, ref check, ref randomC);
        }

        public static void Order(ref Case[] money, ref int[] check, ref int[] randomC)
        {
            for (int i = 0; i < check.Length - 1; i++)
            {
                for (int pos = 0; pos < check.Length - 1; pos++)
                {
                    if (check[pos + 1] < check[pos])
                    {
                        CaseSwap(ref check[pos + 1], ref check[pos]);
                    }
                }
            }
            DisplayAvalibleCases(ref money, ref check, ref randomC);
        }

        public static void CaseSwap(ref int pos1, ref int pos2)
        {
            int temp;

            temp = pos1;
            pos1 = pos2;
            pos2 = temp;
        }

        public static void DisplayAvalibleCases(ref Case[] money, ref int[] check, ref int[] randomC)
        {
            int count = 1;
            for (int i = 0; i < check.Length; i++)
            {
                Console.WriteLine("{0}\t\t{1:c}\t\t\t\t{2}", count, money[randomC[i]].caseMoney, money[i].off);
                count = count + 1;
            }
            CasePick(ref money, ref check, ref randomC);
        }


        public static void CasePick(ref Case[] money, ref int[] check, ref int[] randomC)
        {
            int caseHold;
            Console.Write("\n\nPlease pick a case number to keep: ");
            caseHold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Players case number: {0}", caseHold);
            Console.WriteLine("Case contains: {0:c}", money[randomC[caseHold - 1]].caseMoney);     //users input - 1 == index in array slot

            Hide(ref money, ref check, ref randomC, ref caseHold);
        }

        public static void Hide(ref Case[] money, ref int[] check, ref int[] randomC, ref int caseHold)
        {
            bool found = false;
            int playC;
            int round = 1;
            do
            {
                Console.Write("\n{0} / 6: ",round);
                Console.Write("\n\nPick Case: ");
                playC = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Case Number: {0}", playC);
                Console.WriteLine("Case contains: {0:c}", money[randomC[playC - 1]].caseMoney);     //users input - 1 == index in array slot
                do
                {
                    for (int i = 0; i < check.Length; i++)
                    {
                        if (check[i] == (playC - 1))
                        {
                            found = true;
                            money[check[playC - 1]].off = true;
                        }
                    }

                } while (found != true);
                round = round + 1;
            } while (round <= 6);

            for (int i = 0; i < check.Length; i++)
                {
                    if (money[i].off == false)
                    {
                        Console.WriteLine("{0}\t\t{1:c}\t\t\t\t{2}", (money[check[i]].caseNumber + 1), money[randomC[i]].caseMoney, money[i].off);
                    }
                }

            Console.ReadLine();


        }

    }
}

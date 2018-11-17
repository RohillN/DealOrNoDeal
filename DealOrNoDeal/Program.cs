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
        public static void Main()
        {
            Menu();
        }
        private static int end = 6, choicePick = 1;
        private static int[] select;
        public static Random rand = new Random();

        public static void Menu()
        {
            bool invalidSectionPick = false;
            IntroText();
            Players[] student = new Players[21];
            Case[] money = new Case[26];
            StudentReadList(ref student);
            SuitCaseReadList(ref money);
            do
            {
                Console.Write("Select 1/2/3/4\n1 = Read Full List\n2 = Edit Players Information\n3 = Top 10 Players / Finalist / Game\n4 = Finalist / Game\n\nEnter Here: ");
                int temp = Convert.ToInt32(Console.ReadLine());

                switch (temp)
                {
                    case 1:
                        Console.WriteLine("Full List");
                        ClassSort(ref student);
                        Display(ref student);
                        ToMenu();
                        invalidSectionPick = false;
                        break;
                    case 2:
                        Console.WriteLine("Edit a players infromation");
                        EditStudents(ref student);
                        invalidSectionPick = false;
                        break;
                    case 3:
                        Console.WriteLine("Top 10 People and Finalist");
                        ClassSort(ref student);
                        CheckDuplicatePlayers(ref student, ref money);
                        invalidSectionPick = false;
                        break;
                    case 4:
                        Checker(ref student, ref money);
                        break;
                    case 5:
                        Console.WriteLine("Deal or No Deal");
                        CheckDuplicateCaseMoney(ref money);
                        invalidSectionPick = false;
                        break;
                    default:
                        invalidSectionPick = true;
                        break;
                }
                if (invalidSectionPick == true)
                {
                    Console.Clear();
                    IntroText();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*** Invalid input try again ***\n\n");
                    Console.ResetColor();
                }

            } while (invalidSectionPick == true);

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

        public static void CheckDuplicatePlayers(ref Players[] student, ref Case[] money)
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

            PickTen(ref student, ref money, ref select);

        }

        public static void Checker(ref Players[] student, ref Case[] money)
        {
            //Checking for repeating numbers up to 10
            Console.Clear();
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

            PickPlay(ref student, ref money, ref select);

        }

        public static void PickPlay(ref Players[] student, ref Case[] money, ref int[] select)
        {
            int i = rand.Next(0, 10);
            int menuFourPlayer = 0;
            int winner = select[i];
            Console.WriteLine("Winning player is... " + student[winner].firstName + " " + student[winner].lastName);

            Console.Write("\nWould you like to play the game? Y/N: ");
            string temp = Console.ReadLine().ToLower();

            if (temp == "y")
            {
                menuFourPlayer = menuFourPlayer + 1;
                Console.Clear();
                GameFlash();
                CheckDuplicateCaseMoney(ref money);
            }
            else
            {
                Console.Clear();
                Menu();
            }
        }

        public static void PickTen(ref Players[] student, ref Case[] money, ref int[] select)
        {
            //Displaying top 10 and putting in a topTenList array
            Console.Clear();

            Console.WriteLine("Top ten finalist\n");
            for (int i = 0; i < select.Length; i++)
            {
                Console.Write(select[i] + " ");
                Console.WriteLine(student[(select[i] - 1)].firstName + " " + student[(select[i] - 1)].lastName);
            }
            //Checking if users wants to draw a winner from the topTenList
            Console.Write("\nPick one random winning player? Y/N: ");
            string temp = Console.ReadLine().ToLower();

            if (temp == "y")
            {
                PickOne(ref student, ref money, ref select);
            }
            else
            {
                Console.Clear();
                Menu();
            }

        }

        public static void PickOne(ref Players[] student, ref Case[] money, ref int[] select)
        {
            int i = rand.Next(0, 10);
            int menuThreePlayer = 0;
            Console.Clear();
            int WinningPlayer = select[i];
            Console.WriteLine("Winning player is... " + student[WinningPlayer].firstName + " " + student[WinningPlayer].lastName);

            Console.Write("\nWould you like to play the game? Y/N: ");
            string temp = Console.ReadLine().ToLower();

            if (temp == "y")
            {
                menuThreePlayer = menuThreePlayer + 1;
                Console.Clear();
                GameFlash();
                CheckDuplicateCaseMoney(ref money);
            }
            else
            {
                Console.Clear();
                Menu();
            }
        }

        public static void GameFlash()
        {
            for (int i = 0; i <= 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("DEAL OR NO DEAL");
                Thread.Sleep(200);
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DEAL OR NO DEAL");
                Thread.Sleep(200);
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("DEAL OR NO DEAL");
                Thread.Sleep(200);
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DEAL OR NO DEAL");
                Thread.Sleep(200);
                Console.Clear();
                Console.ResetColor();
            }

        }

        public static void ToMenu()
        {
            Console.Write("\nPress ENTER to retrun to menu");
            Console.ReadLine();
            Console.Clear();
            Menu();
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

            } while (!sr.EndOfStream);

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
            Console.Clear();
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
            Console.Write("\nEnter LAST name\nWho do you want to edit: ");
            string wanted = Console.ReadLine().ToLower();
            do
            {

                if (attempt >= 1)
                {
                    Console.WriteLine("\nSorry try again");
                    Console.Write("\nWho do you want to edit: ");
                    string newWanted = Console.ReadLine();
                    wanted = newWanted;
                    Console.Clear();
                    Display(ref student);

                }
                attempt = attempt + 1;

                for (int i = 0; i < student.Length; i++)
                {
                    if (student[i].lastName.ToLower() == wanted)
                    {
                        found = true;
                        do
                        {
                            Console.Write("\nYou have picked: " + student[i].firstName + " " + student[i].lastName + "\n");
                            Console.Write("\n\nPick a NUMBER equivalent\nWhat would you like to edit? \n1. First Name\n2. Last Name\n3. Interest\n4. All of the above\n5. Exit\n\nEnter Here: ");
                            int sectionPick = Convert.ToInt32(Console.ReadLine());

                            switch (sectionPick)
                            {
                                case 1:
                                    Console.Write("\nEnter new first name: ");
                                    student[i].firstName = Console.ReadLine();
                                    WriteNewList(ref student);
                                    invalidSectionPick = false;
                                    break;
                                case 2:
                                    Console.Write("\nEnter new last name: ");
                                    student[i].lastName = Console.ReadLine();
                                    WriteNewList(ref student);
                                    invalidSectionPick = false;
                                    break;
                                case 3:
                                    Console.Write("\nEnter new interest: ");
                                    student[i].interest = Console.ReadLine();
                                    WriteNewList(ref student);
                                    invalidSectionPick = false;
                                    break;
                                case 4:
                                    Console.Write("\nEnter new first name: ");
                                    student[i].firstName = Console.ReadLine();
                                    Console.Write("\nEnter new last name: ");
                                    student[i].lastName = Console.ReadLine();
                                    Console.Write("\nEnter new interest: ");
                                    student[i].interest = Console.ReadLine();
                                    WriteNewList(ref student);
                                    invalidSectionPick = false;
                                    break;
                                case 5:
                                    StudentReadList(ref student);
                                    Console.Clear();
                                    Menu();
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
                                Console.Write("\nDo you want to see the updated list? Y/N: ");
                                string update = Console.ReadLine().ToLower();

                                if (update == "y")
                                {
                                    Console.Clear();
                                    Display(ref student);
                                    Console.Write("\nPress ENTER to retrun to menu");
                                    Console.ReadLine();
                                    Console.Clear();
                                    Menu();
                                }
                            }
                            Console.Clear();
                            Display(ref student);
                        } while (invalidSectionPick == true);
                    }

                }
            } while (found == false);

        }

        public static void WriteNewList(ref Players[] student)
        {
            StreamWriter sw = new StreamWriter("DealOrNoDeal.txt");
            int count = 0;
            do
            {
                sw.WriteLine(student[count].firstName);
                sw.WriteLine(student[count].lastName);
                sw.WriteLine(student[count].interest);
                count = count + 1;
            } while (count < student.Length);

            sw.Close();

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

            } while (!sr.EndOfStream);

            sr.Close();
        }
        public static void CheckDuplicateCaseMoney(ref Case[] money)
        {
            //Checking for repeating numbers up to 26
            Console.Clear();

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
            CasePick(ref money, ref check, ref randomC);
        }

        public static void CaseSwap(ref int pos1, ref int pos2)
        {
            int temp;

            temp = pos1;
            pos1 = pos2;
            pos2 = temp;
        }

        public static void CasePick(ref Case[] money, ref int[] check, ref int[] randomC)
        {
            int caseHold;
            Console.Write("Pick a case from 1 - 26: ");
            caseHold = Convert.ToInt32(Console.ReadLine());
            if (caseHold <= 0 || caseHold > 26)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n*** Invalid! Input is out of range! ***");
                    Console.ResetColor();
                    Console.Write("\nEnter a case number from 1 - 26: ");
                    caseHold = Convert.ToInt32(Console.ReadLine());

                } while (caseHold <= 0 || caseHold > 26);
            }
            Console.Clear();
            money[caseHold - 1].off = true;
            Hide(ref money, ref check, ref randomC, ref caseHold);
        }

        public static void Hide(ref Case[] money, ref int[] check, ref int[] randomC, ref int caseHold)
        {
            bool found = false;
            int playC;
            int round = 1;
            do
            {

                GameDisplay(ref money, ref check, ref randomC, ref caseHold);
                Console.Write("\n\n\nYour case: {0}".PadLeft(30) + "| Value: {1:c}".PadLeft(15) + "\n", caseHold, money[randomC[caseHold - 1]].caseMoney); //Change padding distance // also the value will be blanked out

                Console.Write("\n{0} / {1} Pick Case: ", round, end);       //Asking for players input 
                playC = Convert.ToInt32(Console.ReadLine());               //Storing the players input and converting to int data type
                do
                {
                    if (playC <= 0 || playC > 26)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\n*** Invalid! Input is out of range! ***");
                        Console.ResetColor();
                        Console.Write("\nEnter a case number from 1 - 26: ");
                        playC = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        GameDisplay(ref money, ref check, ref randomC, ref caseHold);
                    }

                    if ((playC - 1) == (caseHold - 1))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\n*** Case has already been picked! ***");
                        Console.ResetColor();
                        Console.Write("\nEnter a case number from 1 - 26: ");
                        playC = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        GameDisplay(ref money, ref check, ref randomC, ref caseHold);
                    }
                } while (playC <= 0 || playC > 26 || (playC - 1) == (caseHold - 1));

                for (int i = 0; i < money.Length; i++)
                {
                    if ((playC - 1) == money[playC - 1].caseNumber && money[playC - 1].off == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\n*** Case has already been picked! ***");
                        Console.ResetColor();
                        Console.Write("\nEnter another case: ");
                        playC = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        GameDisplay(ref money, ref check, ref randomC, ref caseHold);
                    }
                }

                Console.Write("\n\nCase Number: {0}", playC);                                       //Display the case number and value of the case amount
                Console.Write("\n\nCase contains: {0:c}", money[randomC[playC - 1]].caseMoney);     //users input - 1 == index in array slot
                Console.ReadLine();
                do
                {
                    for (int i = 0; i < check.Length; i++)          //Checking through the lenght of check array
                    {
                        if (check[i] == (playC - 1))               //Checking if users input is inside check array
                        {
                            found = true;                          //If users input is inside array found will = true
                            money[playC - 1].off = true;    //Case struct "off" will equal true
                        }
                        else
                        {
                            Console.Write("");
                        }
                    }

                } while (found != true);                        //Keep checking thought if users input is in the array // until found is not true
                Console.Clear();
                round = round + 1;
            } while (round <= end);                             //Do this whole method till round is less that end
            Banker(ref money, ref check, ref randomC, ref caseHold, ref playC);
        }

        public static void GameDisplay(ref Case[] money, ref int[] check, ref int[] randomC, ref int caseHold)
        {
            for (int i = 0; i < money.Length; i++)
            {
                if (money[i].off == false)
                {
                    Console.Write("| {0} ", (money[i].caseNumber + 1)); //Change padding distance
                }
                else
                {
                    Console.Write("|   ");
                }

            }
            //Console.Write("|");
        }
        public static void Banker(ref Case[] money, ref int[] check, ref int[] randomC, ref int caseHold, ref int playC)
        {
            double offer;
            double average = 0;
            int counter = 0;
            string choice;

            if (choicePick < 9)
            {

                for (int i = 0; i < money.Length; i++)
                {
                    if (money[i].off == false)
                    {
                        counter = counter + 1;
                        average = (average + money[i].caseMoney + money[caseHold - 1].caseMoney);
                    }
                }


                offer = ((average / counter) * choicePick) / 10;

                Console.WriteLine("Banker offers: {0:c}", offer);
                Console.Write("\n\nDeal or No Deal: ");
                choice = Console.ReadLine().ToLower().Substring(0, 1);

                if (choice == "n")
                {
                    if (end == 1)
                    {
                        end = end + 1;
                    }
                    end = end - 1;
                    counter = 0;
                    average = 0;
                    choicePick = choicePick + 1;
                    Console.WriteLine("No Deal!");
                    Console.Clear();
                    Hide(ref money, ref check, ref randomC, ref caseHold);
                }
                if (choice == "d")
                {
                    Console.Clear();
                    Console.WriteLine("DEAL!!\nYou have won {0:c}", offer);
                    ToMenu();
                }
            }
            else
            {
                LastTwoCasePick(ref money, ref randomC, ref check, ref playC, ref caseHold);
                choicePick = choicePick + 1;
            }

            Console.ReadLine();
        }

        public static void LastTwoCasePick(ref Case[] money, ref int[] randomC, ref int[] check, ref int playC, ref int caseHold)
        {
            int lastPick = 0;
            GameDisplay(ref money, ref check, ref randomC, ref caseHold);

            Console.Write("\n\nWould you like to keep your original case OR Take the case that is left\n");
            Console.Write("\n\nYour case: {0}".PadLeft(30) + " | Value: ???????".PadLeft(15) + "\n", caseHold);
            Console.Write("\nEnter here: ");
            lastPick = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < money.Length; i++)
            {
                if ((lastPick - 1) == money[i].caseNumber && money[i].off == false)
                {
                    Console.Clear();
                    Console.Write("\n| You have picked case {0} you have WON {1:c} |", (money[i].caseNumber + 1), money[randomC[i - 1]].caseMoney);
                    Console.Write("\n\n\nYour original case: {0} Contained: {1:c}".PadLeft(15) + "\n", caseHold, money[randomC[caseHold - 1]].caseMoney);
                }

                if ((lastPick - 1) == (caseHold - 1) && money[i].off == false)
                {
                    Console.Clear();
                    Console.Write("\n\n\n| You decided to keep the original case: {0}".PadLeft(30) + " You have WON: {1:c} |".PadLeft(15) + "\n", caseHold, money[randomC[caseHold - 1]].caseMoney);
                    Console.Write("\nThe other case {0} Contained {1:c}", (money[i].caseNumber + 1), money[randomC[i]].caseMoney);
                }
            }

            ToMenu();

        }
    }
}


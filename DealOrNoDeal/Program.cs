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
        //private static int[] select;
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
                Console.Write("Select 1/2/3/4\n1 = Read Full List\n2 = Edit Players Information\n3 = Top 10 Players / Finalist / Game\n4 = Finalist / Game\n5 = Game\n\nEnter Here: ");
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
                        invalidSectionPick = false;
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
            //Ascii generated text found online 

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
            //Checking for repeating numbers up to 10 // This method is for the top ten // FOR MENU 3
            int[] select = new int[10];

            for (int i = 0; i < select.Length; i++)         //Looping for the length of the array (10) or (0 to 9)
            {
                int temp = rand.Next(1, 22);                //temp holding a random number
                int count = 0;                              //count starting at 0

                while (count <= i)                          //While count is less than or equal to i
                {
                    if (temp == select[count])              //checking if the temps random numbers equals array slot "count" value
                    {
                        count = 0;                          //if its true count will reset 
                        temp = rand.Next(1, 22);            //if its true temp will get another rand number

                    }
                    else                                    //Do this if temp is not equal to the array slot "count" value
                    {
                        count = count + 1;                  //Count + 1, moving to the next index of the select index
                    }

                }
                select[i] = temp;                           //select and the index of i will equal the temp value
            }

            PickTen(ref student, ref money, ref select);    //Calling or going to a method

        }

        public static void Checker(ref Players[] student, ref Case[] money)
        {
            //Checking for repeating numbers up to 10 // This method is filling in 10 slots from the one pick // FOR MENU 4
            Console.Clear();
            int[] select = new int[10];

            for (int i = 0; i < select.Length; i++)         //Looping for the length of the array (10) or (0 to 9)
            {
                int temp = rand.Next(1, 22);                //temp holding a random number
                int count = 0;                              //count starting at 0

                while (count <= i)                          //While count is less than or equal to i
                {
                    if (temp == select[count])              //checking if the temps random numbers equals array slot "count" value
                    {
                        count = 0;                          //if its true count will reset 
                        temp = rand.Next(1, 22);            //if its true temp will get another rand number

                    }
                    else                                    //Do this if temp is not equal to the array slot "count" value
                    {
                        count = count + 1;                  //Count + 1, moving to the next index of the select index
                    }

                }
                select[i] = temp;                           //select and the index of i will equal the temp value
            }

            PickPlay(ref student, ref money, ref select);   //Calling or going to a method

        }

        public static void PickPlay(ref Players[] student, ref Case[] money, ref int[] select)
        {
            int i = rand.Next(0, 10);               //variable i will hold a random slot which will be used for an index
            int menuFourPlayer = 0;
            Console.WriteLine("Winning player is... " + student[select[i]].firstName + " " + student[select[i]].lastName);        //Selecting a winner from the select array and using the rand i index slot 

            Console.Write("\nWould you like to play the game? Y/N: ");
            string temp = Console.ReadLine().ToLower();     //Asking user to play the game and storing input

            if (temp == "y")                                                //if true
            {
                menuFourPlayer = menuFourPlayer + 1;
                Console.Clear();
                GameFlash();                                                //Calling or going to the intro to the game method
                CheckDuplicateCaseMoney(ref money);                        //Calling or going to game method
            }
            else                                                           //if false 
            {
                Console.Clear();
                Menu();                                                   //Calling or going to the menu method
            }
        }

        public static void PickTen(ref Players[] student, ref Case[] money, ref int[] select)
        {
            //Displaying top 10 and putting in a topTenList array
            Console.Clear();
            string[] TopTenList = new string[10];

            Console.WriteLine("Top ten finalist");
            for (int i = 0; i < select.Length; i++)             //For looping the length of select array (10 slots) or (0 to 9)
            {
                string temp2 = student[(select[i] - 1)].firstName + " " + student[(select[i] - 1)].lastName;   //Players name will be transfered to a temp 
                TopTenList[i] = temp2;       //top ten array will be filled with temp and transfered over to pick one
            }

            for(int i =0; i < TopTenList.Length; i++)
            {
                //Console.Write(select[i] + " ");       //Displays the index number of the players //Can be turned on to see the index numbers
                Console.Write("\n" + TopTenList[i]);    //Displays the top ten players
            }

            Console.Write("\n\nPick one random winning player? Y/N: ");       //Checking if users wants to pick a finalist from the 10
            string temp = Console.ReadLine().ToLower().Substring(0, 1);     //Storing input

            if (temp == "y")                                                //If true
            {
                PickOne(ref student, ref money, ref TopTenList);                //Calling or going to picking finalist method
            }
            else                                                            //If false
            {
                Console.Clear();
                Menu();                                                     //Calling or going to menu method
            }

        }

        public static void PickOne(ref Players[] student, ref Case[] money, ref string[] TopTenList)
        {
            //This method will select one player from the top 10  // Also asking user if they want to play the game
            int i = rand.Next(0, 10);                  //variable i will hold a random slot which will be used for an index
            int menuThreePlayer = 0;
            //Console.Clear();                    //Comment this out if your wanting to see top 10 and finalist at the same time
            Console.WriteLine("\nWinning player is... " + TopTenList[i] + "\n");   //Selecting a winner from the top ten array and using the rand i index slot 

            Console.Write("\nWould you like to play the game? Y/N: ");
            string temp = Console.ReadLine().ToLower().Substring(0, 1);   //Asking user to play the game and storing input

            if (temp == "y")                                             //If true
            {
                menuThreePlayer = menuThreePlayer + 1;
                Console.Clear();
                GameFlash();                                            //Calling or going to the intro to the game method
                CheckDuplicateCaseMoney(ref money);                     //Calling or going to game method
            }
            else                                                        //If false
            {
                Console.Clear();
                Menu();                                                //Calling or going to the menu method 
            }
        }

        public static void GameFlash()
        {
            //This method is the intro to the game // It will false the text and change colors 

            for (int i = 0; i <= 1; i++)            //For looping once
            {
                Console.ForegroundColor = ConsoleColor.Yellow;    //Foreground color will change 
                Console.WriteLine("DEAL OR NO DEAL");             //The text that is going to be displayed
                Thread.Sleep(200);                                //Small pause
                Console.Clear();                                  //Clear console
                Console.ResetColor();                            //All the color will reset 
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
            //Simple return to menu method that doesnt require storing of text / number input

            Console.Write("\nPress ENTER to retrun to menu");         //Tell the user to press ENTER
            Console.ReadLine();                                       //It will stay as a read line untill ENTER is pressed
            Console.Clear();                                          //Clear console
            Menu();                                                   //Calling or going to the menu method
        }

        public static void StudentReadList(ref Players[] student)
        {
            //This method will be reading in the deal or no deal text 

            StreamReader sr = new StreamReader("DealOrNoDeal.txt");      //Declare stream reader and the text file // Text file located in bin > Debug 
            int count = 0;                                               //count starting from 0 // This will act as the index slot
            do                                                           //do this
            {
                student[count].firstName = sr.ReadLine();                //using the struct array name "student" and using the index "count" and selecting the struct name "firstName" // Then stream reading it in that slot
                student[count].lastName = sr.ReadLine();                 //using the struct array name "student" and using the index "count" and selecting the struct name "lastName" // Then stream reading it in that slot
                student[count].interest = sr.ReadLine();                 //using the struct array name "student" and using the index "count" and selecting the struct name "interest"// Then stream reading it in that slot
                count = count + 1;                                       //count will + 1 // moving the the next index slot

            } while (!sr.EndOfStream);                                  //While stream reader is not at the end or the stream or file

            sr.Close();                                                 //Making sure to close the stream reader
        }
        public static void ClassSort(ref Players[] student)
        {
            //This method will be sorting the last name from a - z

            for (int i = 0; i < student.Length - 1; i++)                //For the length of student array (21) - 1 // so it doesnt fall off the array
            {
                for (int pos = 0; pos < student.Length - 1; pos++)      //For the length of student array (21)  - 1 and using pos // so it doesnt fall off the array
                {
                    if (student[pos + 1].lastName.CompareTo(student[pos].lastName) < 0)     //comparing pos + 1 to pos // if its less that zero   
                    {
                        ClassSwap(ref student[pos + 1], ref student[pos]);                  //Calling or going to the swap method
                    }
                }
            }
        }

        public static void ClassSwap(ref Players pos1, ref Players pos2)
        {
            //Swaping method 
            Players temp;       //Temp will hold the players struct data type

            temp = pos1;        //General idea: pos1 = pos2 && pos2 = pos1
            pos1 = pos2;
            pos2 = temp;
        }

        public static void Display(ref Players[] student)
        {
            //This method will display the list of player or students 

            Console.Clear();
            int count = 0;              //count will act as the index counter
            Console.WriteLine("First Name".PadRight(15) + "Last Name".PadRight(15) + "Interest".PadRight(15) + "\n");   //Title of each column
            do                                  //do this
            {
                Console.WriteLine(student[count].firstName.PadRight(15) + student[count].lastName.PadRight(15) + student[count].interest.PadRight(15));    //Display first and last name and interest will padding
                count = count + 1;      //count + 1, will move to the next index slot                                                                      //Using the struct array name "student" 

            } while (count < student.Length);  //while count is less than the student length (21)
        }

        public static void EditStudents(ref Players[] student)
        {
            ClassSort(ref student);
            Display(ref student);
            bool found = false;
            bool invalidSectionPick = false;
            int attempt = 0;
            Console.Write("\nEnter LAST name\nWho do you want to edit: ");
            string wanted = Console.ReadLine().ToLower();                   //Asking user who that want to end and storing           
            do
            {

                if (attempt >= 1)           //if user got input incorrect this will run 
                {
                    Console.WriteLine("\nSorry try again");
                    Console.Write("\nWho do you want to edit: ");
                    string newWanted = Console.ReadLine().ToLower().Substring(0, 1);    //Asking for input again and storing it 
                    wanted = newWanted;                                                 //old input will equal the new input
                    Console.Clear();
                    Display(ref student);                                               //Calling or going to the display method

                }
                attempt = attempt + 1;                  //Attempt will + 1 if input was wrong

                for (int i = 0; i < student.Length; i++)        //For the length of student array (21)
                {
                    if (student[i].lastName.ToLower() == wanted)        //checking if input is in the array and looking through last name
                    {
                        found = true;                           //found will eqaul true
                        do
                        {
                            Console.Write("\nYou have picked: " + student[i].firstName + " " + student[i].lastName + "\n");         //Display name hat the user has picked 
                            Console.Write("\n\nPick a NUMBER equivalent\nWhat would you like to edit? \n1. First Name\n2. Last Name\n3. Interest\n4. All of the above\n5. Exit\n\nEnter Here: ");
                            int sectionPick = Convert.ToInt32(Console.ReadLine());                       //Give user selection pick and store the input

                            switch (sectionPick)
                            {
                                case 1:
                                    Console.Write("\nEnter new first name: ");
                                    student[i].firstName = Console.ReadLine();                  //Case 1 will be only edit first name
                                    WriteNewList(ref student);                                  //Calling or going to stream write method
                                    invalidSectionPick = false;
                                    break;
                                case 2:
                                    Console.Write("\nEnter new last name: ");
                                    student[i].lastName = Console.ReadLine();                   //Case 2 will only edit last name
                                    WriteNewList(ref student);                                  //Calling or going to stream write method
                                    invalidSectionPick = false;
                                    break;
                                case 3:
                                    Console.Write("\nEnter new interest: ");
                                    student[i].interest = Console.ReadLine();                   //Case 3 will only edit interest
                                    WriteNewList(ref student);                                  //Calling or going to stream write method
                                    invalidSectionPick = false;
                                    break;
                                case 4:
                                    Console.Write("\nEnter new first name: ");                  //Case 4 the user will be able to edit all the fields
                                    student[i].firstName = Console.ReadLine();
                                    Console.Write("\nEnter new last name: ");
                                    student[i].lastName = Console.ReadLine();
                                    Console.Write("\nEnter new interest: ");
                                    student[i].interest = Console.ReadLine();
                                    WriteNewList(ref student);                                  //Calling or going to stream write method
                                    invalidSectionPick = false;
                                    break;
                                case 5:
                                    StudentReadList(ref student);                               //Calling or going to the readlist method
                                    Console.Clear();
                                    Menu();                                                     //Calling or going to the menu method
                                    break;
                                default:
                                    invalidSectionPick = true;                              //bool will equal true
                                    break;
                            }

                            if (invalidSectionPick == true)
                            {
                                Console.WriteLine("Selection Invalid, Please Try Again");   //from the bool being true // Display this

                            }
                            else
                            {
                                Console.Write("\nDo you want to see the updated list? Y/N: ");
                                string update = Console.ReadLine().ToLower();                   //Ask user for updated list and store input

                                if (update == "y")                              //if true
                                {
                                    Console.Clear();
                                    Display(ref student);                   //Display updated list
                                    ToMenu();                               //Take then back to the menu
                                }
                            }
                            Console.Clear();
                            Display(ref student);
                        } while (invalidSectionPick == true); //Keep doing this while invalidSectionPick is true
                    }

                }
            } while (found == false);   //Keep doing this while found is false

        }

        public static void WriteNewList(ref Players[] student)
        {
            //This method will write back to the main text file

            StreamWriter sw = new StreamWriter("DealOrNoDeal.txt"); //Deaclare the stream writer and the text file name located in bin > Debug
            int count = 0;                                          //count acting as index
            do
            {
                sw.WriteLine(student[count].firstName);            //Stream write line the array "student" and the index "count" to the section "firstName"
                sw.WriteLine(student[count].lastName);             //Stream write line the array "student" and the index "count" to the section "lastName"
                sw.WriteLine(student[count].interest);             //Stream write line the array "student" and the index "count" to the section "interest"
                count = count + 1;                                 //count + 1, moving to the next index
            } while (count < student.Length);                      //while count is less than the student length (21)

            sw.Close();                                 //Making sure to close stream writer

        }

        public static void SuitCaseReadList(ref Case[] money)
        {
            //Method will read a file holding the case numbers and values

            StreamReader sr = new StreamReader("TestCase.txt");     //Declare stream reader and the text file name located bin > Debug
            int count = 0;                                      //count will act as index
            do
            {
                money[count].caseNumber = Convert.ToInt32(sr.ReadLine());       //array struct name "money" and the index slot "count" with the holder name "caseNumber" will be read into that slot and converted
                money[count].caseMoney = Convert.ToInt32(sr.ReadLine());        //array struct name "money" and the index slot "count" with the holder name "caseMoney" will be read into that slot and converted
                count = count + 1;                                              //count + 1, moving to the next index slot

            } while (!sr.EndOfStream);                      //While stream reader is not at the end or the stream or file

            sr.Close();
        }
        public static void CheckDuplicateCaseMoney(ref Case[] money)
        {
            //Checking for repeating numbers up to 26
            Console.Clear();

            int[] check = new int[26];
            int[] randomC = new int[26];

            for (int i = 0; i < check.Length; i++)           //Looping for the length of the array (10) or (0 to 9)
            {
                int temp = rand.Next(0, 26);                //temp holding a random number
                int count = 0;                              //count starting at 0

                while (count < i)                          //While count is less than or equal to i
                {
                    if (temp == check[count])              //checking if the temps random numbers equals array slot "count" value
                    {
                        count = 0;                          //if its true count will reset 
                        temp = rand.Next(0, 26);            //if its true temp will get another rand number

                    }
                    else                                    //Do this if temp is not equal to the array slot "count" value
                    {
                        count = count + 1;                  //Count + 1, moving to the next index of the select index
                    }

                }
                check[i] = temp;
                randomC[i] = temp;
            }
            Order(ref money, ref check, ref randomC);
        }

        public static void Order(ref Case[] money, ref int[] check, ref int[] randomC)
        {
            for (int i = 0; i < check.Length - 1; i++)                //For the length of check array (26) - 1 // so it doesnt fall off the array
            {
                for (int pos = 0; pos < check.Length - 1; pos++)      //For the length of check array (26)  - 1 and using pos // so it doesnt fall off the array
                {
                    if (check[pos + 1] < check[pos])                //checking if pos + 1 is less that pos
                    {
                        CaseSwap(ref check[pos + 1], ref check[pos]);   //Calling or going to swap method
                    }
                }
            }
            CasePick(ref money, ref check, ref randomC);        //Calling or going to case pick method
        }

        public static void CaseSwap(ref int pos1, ref int pos2)
        {
            //Swaping method of numbers
            int temp;

            temp = pos1;            //General idea: pos1 = pos2  && pos2 = pos1
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

                GameDisplay(ref money, ref check, ref randomC, ref caseHold);       //Calling or going to the display method
                Console.Write("\n\n\nYour case: {0}".PadLeft(30) + "| Value: {1:c}".PadLeft(15) + "\n", caseHold, money[randomC[caseHold - 1]].caseMoney); //Change padding distance // also the value will be blanked out

                Console.Write("\n{0} / {1} Pick Case: ", round, end);       //Asking for players input 
                playC = Convert.ToInt32(Console.ReadLine());               //Storing the players input and converting to int data type
                do
                {
                    if (playC <= 0 || playC > 26)                               //User error checking
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\n*** Invalid! Input is out of range! ***");   //Telling user input is out of range
                        Console.ResetColor();
                        Console.Write("\nEnter a case number from 1 - 26: ");           //Asking for input again and storing
                        playC = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        GameDisplay(ref money, ref check, ref randomC, ref caseHold);   //Going to display method
                    }

                    if ((playC - 1) == (caseHold - 1))                          //User error checking
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\n*** Case has already been picked! ***");   //Telling user case has been picked
                        Console.ResetColor();
                        Console.Write("\nEnter a case number from 1 - 26: ");       //Asking for input again and storing
                        playC = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        GameDisplay(ref money, ref check, ref randomC, ref caseHold); //Going to display method
                    }
                } while (playC <= 0 || playC > 26 || (playC - 1) == (caseHold - 1)); //Keep doing it if the input is the same or is out of range

                for (int i = 0; i < money.Length; i++)          //for the length of money (26)
                {
                    if ((playC - 1) == money[playC - 1].caseNumber && money[playC - 1].off == true)     //User error checking // if case has already been picked
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\n*** Case has already been picked! ***");     //Telling user case has been picked
                        Console.ResetColor();
                        Console.Write("\nEnter another case: ");                        //Asking for input again and storing
                        playC = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        GameDisplay(ref money, ref check, ref randomC, ref caseHold);    //Going to display method
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
                            money[playC - 1].off = true;           //Case struct "off" will equal true
                        }
                        else
                        {
                            Console.Write("");                      //Display as blank
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
                if (money[i].off == false)              //Only display the cases that are false
                {
                    Console.Write("| {0} ", (money[i].caseNumber + 1)); //Change padding distance
                }
                else
                {
                    Console.Write("|   ");              //Decoration
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

            if (choicePick < 9)                                 //round checker
            {

                for (int i = 0; i < money.Length; i++)      //for the length of money (26)
                {
                    if (money[i].off == false)             //checking all the slots that equal false
                    {
                        counter = counter + 1;            //will count all the false slots
                        average = (average + money[i].caseMoney + money[caseHold - 1].caseMoney); //add up all the values remaing and the users orginal case
                    }
                }


                offer = ((average / counter) * choicePick) / 10;        //bankers offer 

                Console.WriteLine("Banker offers: {0:c}", offer);   //Display off
                Console.Write("\n\nDeal or No Deal: ");             //Ask user for deal or no deal // store input
                choice = Console.ReadLine().ToLower().Substring(0, 1);

                if (choice == "n")
                {
                    if (end == 1)
                    {
                        end = end + 1;              //Making sure that the round will keep as 1 
                    }
                    end = end - 1;                  //Round count before banker makes and offer // eg 6 rounds offer // 5 rounds offer // 4 rounds offer etc
                    counter = 0;                    //count set to 0
                    average = 0;                    //average set to 0
                    choicePick = choicePick + 1;    //round checker will + 1
                    Console.WriteLine("No Deal!");
                    Console.Clear();
                    Hide(ref money, ref check, ref randomC, ref caseHold);  //Calling or going to the hide method
                }
                if (choice == "d")
                {
                    Console.Clear();
                    Console.WriteLine("DEAL!!\nYou have won {0:c}", offer);     //Display the offer if the user takes it
                    ToMenu();                                                   //Calling or going to the Tomenu method
                }
            }
            else
            {
                LastTwoCasePick(ref money, ref randomC, ref check, ref playC, ref caseHold);       //Calling or going to the last two cases method
                //choicePick = choicePick + 1;                                                       //round checker will + 1
            }

            Console.ReadLine();
        }

        public static void LastTwoCasePick(ref Case[] money, ref int[] randomC, ref int[] check, ref int playC, ref int caseHold)
        {
            int lastPick = 0;
            GameDisplay(ref money, ref check, ref randomC, ref caseHold); //Calling or going to display methos 

            Console.Write("\n\nWould you like to keep your original case OR Take the case that is left\n");
            Console.Write("\n\nYour case: {0}".PadLeft(30) + " | Value: ???????".PadLeft(15) + "\n", caseHold);             //Asking users if the want to keep or change cases
            Console.Write("\nEnter here: ");                                                                        //Getting input and storing it 
            lastPick = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < money.Length; i++)            //For the length of money (26)
            {
                if ((lastPick - 1) == money[i].caseNumber && money[i].off == false)         //if input equals last case and its bool is false
                {
                    Console.Clear();
                    Console.Write("\n| You have picked case {0} you have WON {1:c} |", (money[i].caseNumber + 1), money[randomC[i - 1]].caseMoney);             //Display cases picked 
                    Console.Write("\n\n\nYour original case: {0} Contained: {1:c}".PadLeft(15) + "\n", caseHold, money[randomC[caseHold - 1]].caseMoney);       //Display what was in the other case
                }

                if ((lastPick - 1) == (caseHold - 1) && money[i].off == false)      //if input equals original case and its bool is false
                {
                    Console.Clear();
                    Console.Write("\n\n\n| You decided to keep the original case: {0}".PadLeft(30) + " You have WON: {1:c} |".PadLeft(15) + "\n", caseHold, money[randomC[caseHold - 1]].caseMoney); //Display cases picked 
                    Console.Write("\nThe other case {0} Contained {1:c}", (money[i].caseNumber + 1), money[randomC[i]].caseMoney);                                                                  //Display what was in the other case
                }
            }

            ToMenu();           //Calling or going to the menu method

        }
    }
}


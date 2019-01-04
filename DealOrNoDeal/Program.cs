using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DealOrNoDeal
{
    class Program
    {
        //private static int end = 6, choicePick = 1;
        //private static Random rand = new Random();

        public static void Main()
        {
            MenuOperations menuOps = new MenuOperations();
            menuOps.DisplayMenu();
        }

        /// <summary>
        /// Checking for repeating numbers up to 10. This method is for the top ten (FOR MENU 3)
        /// </summary>
        /// <param name="student"></param>
        /// <param name="money"></param>
        //public static void CheckDuplicatePlayers(ref Players[] student, ref Case[] money)
        //{
        //    int[] select = new int[10];

        //    for (int i = 0; i < select.Length; i++)         //Looping for the length of the array (10) or (0 to 9)
        //    {
        //        int temp = rand.Next(1, 22);                //temp holding a random number
        //        int count = 0;                              //count starting at 0

        //        while (count <= i)                          //While count is less than or equal to i
        //        {
        //            if (temp == select[count])              //checking if the temps random numbers equals array slot "count" value
        //            {
        //                count = 0;                          //if its true count will reset 
        //                temp = rand.Next(1, 22);            //if its true temp will get another rand number
        //            }
        //            else                                    //Do this if temp is not equal to the array slot "count" value
        //            {
        //                count = count + 1;                  //Count + 1, moving to the next index of the select index
        //            }
        //        }
        //        select[i] = temp;                           //select and the index of i will equal the temp value
        //    }

        //    PickTen(ref student, ref money, ref select);    //Calling or going to a method
        //}

        /// <summary>
        /// Checking for repeating numbers up to 10. This method is filling in 10 slots from the one pick (FOR MENU 4)
        /// </summary>
        /// <param name="student"></param>
        /// <param name="money"></param>
        //public static void Checker(ref Players[] student, ref Case[] money)
        //{
        //    Console.Clear();
        //    int[] select = new int[10];

        //    for (int i = 0; i < select.Length; i++)         //Looping for the length of the array (10) or (0 to 9)
        //    {
        //        int temp = rand.Next(1, 22);                //temp holding a random number
        //        int count = 0;                              //count starting at 0

        //        while (count <= i)                          //While count is less than or equal to i
        //        {
        //            if (temp == select[count])              //checking if the temps random numbers equals array slot "count" value
        //            {
        //                count = 0;                          //if its true count will reset 
        //                temp = rand.Next(1, 22);            //if its true temp will get another rand number
        //            }
        //            else                                    //Do this if temp is not equal to the array slot "count" value
        //            {
        //                count = count + 1;                  //Count + 1, moving to the next index of the select index
        //            }
        //        }
        //        select[i] = temp;                           //select and the index of i will equal the temp value
        //    }

        //    PickPlay(ref student, ref money, ref select);   //Calling or going to a method
        //}

        //public static void PickPlay(ref Players[] student, ref Case[] money, ref int[] select)
        //{
        //    int i = rand.Next(0, 10);               //variable i will hold a random slot which will be used for an index
        //    Console.WriteLine("Winning player is... " + student[select[i]].firstName + " " + student[select[i]].lastName);        //Selecting a winner from the select array and using the rand i index slot 

        //    Console.Write("\nWould you like to play the game? Y/N: ");
        //    string temp = Console.ReadLine().ToLower();     //Asking user to play the game and storing input

        //    if (temp == "y")                                                //if true
        //    {
        //        Console.Clear();
        //        GameFlash();                                                //Calling or going to the intro to the game method
        //        CheckDuplicateCaseMoney(ref money);                        //Calling or going to game method
        //    }
        //    else                                                           //if false 
        //    {
        //        Console.Clear();
        //        DisplayMenu();                                                   //Calling or going to the menu method
        //    }
        //}

        /// <summary>
        /// Displaying top 10 and putting in a topTenList array
        /// </summary>
        /// <param name="student"></param>
        /// <param name="money"></param>
        /// <param name="select"></param>
        //public static void PickTen(ref Players[] student, ref Case[] money, ref int[] select)
        //{
        //    Console.Clear();
        //    string[] TopTenList = new string[10];

        //    Console.WriteLine("Top ten finalist");
        //    for (int i = 0; i < select.Length; i++)             //For looping the length of select array (10 slots) or (0 to 9)
        //    {
        //        string temp2 = student[(select[i] - 1)].firstName + " " + student[(select[i] - 1)].lastName;   //Players name will be transfered to a temp 
        //        TopTenList[i] = temp2;       //top ten array will be filled with temp and transfered over to pick one
        //    }

        //    for(int i =0; i < TopTenList.Length; i++)
        //    {
        //        //Console.Write(select[i] + " ");       //Displays the index number of the players //Can be turned on to see the index numbers
        //        Console.Write("\n" + TopTenList[i]);    //Displays the top ten players
        //    }

        //    Console.Write("\n\nPick one random winning player? Y/N: ");       //Checking if users wants to pick a finalist from the 10
        //    string temp = Console.ReadLine().ToLower().Substring(0, 1);     //Storing input

        //    if (temp == "y")                                                //If true
        //    {
        //        PickOne(ref student, ref money, ref TopTenList);                //Calling or going to picking finalist method
        //    }
        //    else                                                            //If false
        //    {
        //        Console.Clear();
        //        DisplayMenu();                                                     //Calling or going to menu method
        //    }
        //}

        //public static void PickOne(ref Players[] student, ref Case[] money, ref string[] TopTenList)
        //{
        //    //This method will select one player from the top 10  // Also asking user if they want to play the game
        //    int i = rand.Next(0, 10);                  //variable i will hold a random slot which will be used for an index
        //    //Console.Clear();                    //Comment this out if your wanting to see top 10 and finalist at the same time
        //    Console.WriteLine("\nWinning player is... " + TopTenList[i] + "\n");   //Selecting a winner from the top ten array and using the rand i index slot 

        //    Console.Write("\nWould you like to play the game? Y/N: ");
        //    string temp = Console.ReadLine().ToLower().Substring(0, 1);   //Asking user to play the game and storing input

        //    if (temp == "y")                                             //If true
        //    {
        //        Console.Clear();
        //        GameFlash();                                            //Calling or going to the intro to the game method
        //        CheckDuplicateCaseMoney(ref money);                     //Calling or going to game method
        //    }
        //    else                                                        //If false
        //    {
        //        Console.Clear();
        //        DisplayMenu();                                                //Calling or going to the menu method 
        //    }
        //}

        /// <summary>
        /// This method is the intro to the game. It will false the text and change colors
        /// </summary>
        //public static void GameFlash()
        //{
        //    for (int i = 0; i <= 1; i++)            //For looping once
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;    //Foreground color will change 
        //        Console.WriteLine("DEAL OR NO DEAL");             //The text that is going to be displayed
        //        Thread.Sleep(200);                                //Small pause
        //        Console.Clear();                                  //Clear console
        //        Console.ResetColor();                            //All the color will reset 
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("DEAL OR NO DEAL");
        //        Thread.Sleep(200);
        //        Console.Clear();
        //        Console.ResetColor();
        //        Console.ForegroundColor = ConsoleColor.Blue;
        //        Console.WriteLine("DEAL OR NO DEAL");
        //        Thread.Sleep(200);
        //        Console.Clear();
        //        Console.ResetColor();
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.WriteLine("DEAL OR NO DEAL");
        //        Thread.Sleep(200);
        //        Console.Clear();
        //        Console.ResetColor();
        //    }
        //}
        
        /// <summary>
        /// Checking for repeating numbers up to 26
        /// </summary>
        /// <param name="money"></param>
        //public static void CheckDuplicateCaseMoney(ref Case[] money)
        //{
        //    Console.Clear();

        //    int[] check = new int[26];
        //    int[] randomC = new int[26];

        //    for (int i = 0; i < check.Length; i++)           //Looping for the length of the array (10) or (0 to 9)
        //    {
        //        int temp = rand.Next(0, 26);                //temp holding a random number
        //        int count = 0;                              //count starting at 0

        //        while (count < i)                          //While count is less than or equal to i
        //        {
        //            if (temp == check[count])              //checking if the temps random numbers equals array slot "count" value
        //            {
        //                count = 0;                          //if its true count will reset 
        //                temp = rand.Next(0, 26);            //if its true temp will get another rand number
        //            }
        //            else                                    //Do this if temp is not equal to the array slot "count" value
        //            {
        //                count = count + 1;                  //Count + 1, moving to the next index of the select index
        //            }
        //        }
        //        check[i] = temp;
        //        randomC[i] = temp;
        //    }
        //    Order(ref money, ref check, ref randomC);
        //}

        //public static void Order(ref Case[] money, ref int[] check, ref int[] randomC)
        //{
        //    for (int i = 0; i < check.Length - 1; i++)                //For the length of check array (26) - 1 // so it doesnt fall off the array
        //    {
        //        for (int pos = 0; pos < check.Length - 1; pos++)      //For the length of check array (26)  - 1 and using pos // so it doesnt fall off the array
        //        {
        //            if (check[pos + 1] < check[pos])                //checking if pos + 1 is less that pos
        //            {
        //                CaseSwap(ref check[pos + 1], ref check[pos]);   //Calling or going to swap method
        //            }
        //        }
        //    }
        //    CasePick(ref money, ref check, ref randomC);        //Calling or going to case pick method
        //}

        /// <summary>
        /// Swaping method of numbers
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        //public static void CaseSwap(ref int pos1, ref int pos2)
        //{
        //    int temp;

        //    temp = pos1;            //General idea: pos1 = pos2  && pos2 = pos1
        //    pos1 = pos2;
        //    pos2 = temp;
        //}

        //public static void CasePick(ref Case[] money, ref int[] check, ref int[] randomC)
        //{
        //    int caseHold;
        //    Console.Write("Pick a case from 1 - 26: ");
        //    caseHold = Convert.ToInt32(Console.ReadLine());
        //    if (caseHold <= 0 || caseHold > 26)
        //    {
        //        do
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.Write("\n\n*** Invalid! Input is out of range! ***");
        //            Console.ResetColor();
        //            Console.Write("\nEnter a case number from 1 - 26: ");
        //            caseHold = Convert.ToInt32(Console.ReadLine());
        //        } while (caseHold <= 0 || caseHold > 26);
        //    }
        //    Console.Clear();
        //    money[caseHold - 1].off = true;
        //    Hide(ref money, ref check, ref randomC, ref caseHold);
        //}

        //public static void Hide(ref Case[] money, ref int[] check, ref int[] randomC, ref int caseHold)
        //{
        //    bool found = false;
        //    int playC;
        //    int round = 1;
        //    do
        //    {
        //        GameDisplay(ref money, ref check, ref randomC, ref caseHold);       //Calling or going to the display method
        //        Console.Write("\n\n\nYour case: {0}".PadLeft(30) + "| Value: ????????" + "\n", caseHold); //Change padding distance // also the value will be blanked out
        //        Console.Write("\n{0} / {1} Pick Case: ", round, end);       //Asking for players input 
        //        playC = Convert.ToInt32(Console.ReadLine());               //Storing the players input and converting to int data type
        //        do
        //        {
        //            if (playC <= 0 || playC > 26)                               //User error checking
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.Write("\n\n*** Invalid! Input is out of range! ***");   //Telling user input is out of range
        //                Console.ResetColor();
        //                Console.Write("\nEnter a case number from 1 - 26: ");           //Asking for input again and storing
        //                playC = Convert.ToInt32(Console.ReadLine());
        //                Console.Clear();
        //                GameDisplay(ref money, ref check, ref randomC, ref caseHold);   //Going to display method
        //            }

        //            if ((playC - 1) == (caseHold - 1))                          //User error checking
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.Write("\n\n*** Case has already been picked! ***");   //Telling user case has been picked
        //                Console.ResetColor();
        //                Console.Write("\nEnter a case number from 1 - 26: ");       //Asking for input again and storing
        //                playC = Convert.ToInt32(Console.ReadLine());
        //                Console.Clear();
        //                GameDisplay(ref money, ref check, ref randomC, ref caseHold); //Going to display method
        //            }
        //        } while (playC <= 0 || playC > 26 || (playC - 1) == (caseHold - 1)); //Keep doing it if the input is the same or is out of range

        //        for (int i = 0; i < money.Length; i++)          //for the length of money (26)
        //        {
        //            if ((playC - 1) == money[playC - 1].caseNumber && money[playC - 1].off == true)     //User error checking // if case has already been picked
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.Write("\n\n*** Case has already been picked! ***");     //Telling user case has been picked
        //                Console.ResetColor();
        //                Console.Write("\nEnter another case: ");                        //Asking for input again and storing
        //                playC = Convert.ToInt32(Console.ReadLine());
        //                Console.Clear();
        //                GameDisplay(ref money, ref check, ref randomC, ref caseHold);    //Going to display method
        //            }
        //        }

        //        Console.Write("\n\nCase Number: {0}", playC);                                       //Display the case number and value of the case amount
        //        Console.Write("\n\nCase contains: {0:c}", money[randomC[playC - 1]].caseMoney);     //users input - 1 == index in array slot
        //        Console.ReadLine();
        //        do
        //        {
        //            for (int i = 0; i < check.Length; i++)          //Checking through the lenght of check array
        //            {
        //                if (check[i] == (playC - 1))               //Checking if users input is inside check array
        //                {
        //                    found = true;                          //If users input is inside array found will = true
        //                    money[playC - 1].off = true;           //Case struct "off" will equal true
        //                }
        //                else
        //                {
        //                    Console.Write("");                      //Display as blank
        //                }
        //            }
        //        } while (found != true);                        //Keep checking thought if users input is in the array // until found is not true
        //        Console.Clear();
        //        round = round + 1;
        //    } while (round <= end);                             //Do this whole method till round is less that end
        //    Banker(ref money, ref check, ref randomC, ref caseHold, ref playC);
        //}

        //public static void GameDisplay(ref Case[] money, ref int[] check, ref int[] randomC, ref int caseHold)
        //{
        //    for (int i = 0; i < money.Length; i++)
        //    {
        //        if (money[i].off == false)              //Only display the cases that are false
        //        {
        //            Console.Write("| {0} ", (money[i].caseNumber + 1)); //Change padding distance
        //        }
        //        else
        //        {
        //            Console.Write("|   ");              //Decoration
        //        }
        //    }
        //}

        //public static void Banker(ref Case[] money, ref int[] check, ref int[] randomC, ref int caseHold, ref int playC)
        //{
        //    double offer;
        //    double average = 0;
        //    int counter = 0;
        //    string choice;

        //    if (choicePick < 9)                                 //round checker
        //    {
        //        for (int i = 0; i < money.Length; i++)      //for the length of money (26)
        //        {
        //            if (money[i].off == false)             //checking all the slots that equal false
        //            {
        //                counter = counter + 1;            //will count all the false slots
        //                average = (average + money[i].caseMoney + money[caseHold - 1].caseMoney); //add up all the values remaing and the users orginal case
        //            }
        //        }

        //        offer = ((average / counter) * choicePick) / 10;        //bankers offer 
        //        Console.WriteLine("Banker offers: {0:c}", offer);   //Display off
        //        Console.Write("\n\nDeal or No Deal: ");             //Ask user for deal or no deal // store input
        //        choice = Console.ReadLine().ToLower().Substring(0, 1);

        //        if (choice == "n")
        //        {
        //            if (end == 1)
        //            {
        //                end = end + 1;              //Making sure that the round will keep as 1 
        //            }
        //            end = end - 1;                  //Round count before banker makes and offer // eg 6 rounds offer // 5 rounds offer // 4 rounds offer etc
        //            counter = 0;                    //count set to 0
        //            average = 0;                    //average set to 0
        //            choicePick = choicePick + 1;    //round checker will + 1
        //            Console.WriteLine("No Deal!");
        //            Console.Clear();
        //            Hide(ref money, ref check, ref randomC, ref caseHold);  //Calling or going to the hide method
        //        }
        //        if (choice == "d")
        //        {
        //            Console.Clear();
        //            Console.WriteLine("DEAL!!\nYou have won {0:c}", offer);     //Display the offer if the user takes it
        //            ReturnToMenu();                                                   //Calling or going to the Tomenu method
        //        }
        //    }
        //    else
        //    {
        //        LastTwoCasePick(ref money, ref randomC, ref check, ref playC, ref caseHold);       //Calling or going to the last two cases method
        //    }

        //    Console.ReadLine();
        //}

        //public static void LastTwoCasePick(ref Case[] money, ref int[] randomC, ref int[] check, ref int playC, ref int caseHold)
        //{
        //    int lastPick = 0;
        //    GameDisplay(ref money, ref check, ref randomC, ref caseHold); //Calling or going to display methos 

        //    Console.Write("\n\nWould you like to keep your original case OR Take the case that is left\n");
        //    Console.Write("\n\nYour case: {0}".PadLeft(30) + " | Value: ???????".PadLeft(15) + "\n", caseHold);             //Asking users if the want to keep or change cases
        //    Console.Write("\nEnter here: ");                                                                        //Getting input and storing it 
        //    lastPick = Convert.ToInt32(Console.ReadLine());

        //    for (int i = 0; i < money.Length; i++)            //For the length of money (26)
        //    {
        //        if ((lastPick - 1) == money[i].caseNumber && money[i].off == false)         //if input equals last case and its bool is false
        //        {
        //            Console.Clear();
        //            Console.Write("\n| You have picked case {0} you have WON {1:c} |", (money[i].caseNumber + 1), money[randomC[i - 1]].caseMoney);             //Display cases picked 
        //            Console.Write("\n\n\nYour original case: {0} Contained: {1:c}".PadLeft(15) + "\n", caseHold, money[randomC[caseHold - 1]].caseMoney);       //Display what was in the other case
        //        }

        //        if ((lastPick - 1) == (caseHold - 1) && money[i].off == false)      //if input equals original case and its bool is false
        //        {
        //            Console.Clear();
        //            Console.Write("\n\n\n| You decided to keep the original case: {0}".PadLeft(30) + " You have WON: {1:c} |".PadLeft(15) + "\n", caseHold, money[randomC[caseHold - 1]].caseMoney); //Display cases picked 
        //            Console.Write("\nThe other case {0} Contained {1:c}", (money[i].caseNumber + 1), money[randomC[i]].caseMoney);                                                                  //Display what was in the other case
        //        }
        //    }

        //    ReturnToMenu();           //Calling or going to the menu method
        //}
    }
}

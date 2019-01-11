namespace DealOrNoDeal
{
    class Program
    {
        //private static int end = 6, choicePick = 1;

        public static void Main()
        {
            MenuOperations menuOps = new MenuOperations();
            menuOps.DisplayMenu();
        }
        
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

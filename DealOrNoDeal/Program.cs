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

using DealOrNoDeal.Models;
using System;
using System.Collections.Generic;

namespace DealOrNoDeal
{
    public class MenuOperations
    {
        public void ShowIntroText()
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

        /// <summary>
        /// Simple return to menu method that doesnt require storing of text / number input
        /// </summary>
        public void ReturnToMenu()
        {
            Console.Write("\nPress ENTER to return to menu");
            Console.ReadLine();
            Console.Clear();
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            List<Players> playersList = Helpers.PlayerHelper.ReadPlayerList();
            List<Case> briefcaseList = Helpers.BriefcaseHelper.ReadBriefcaseList();
            int menuChoice = 0;

            ShowIntroText();
            while (menuChoice != 6)
            {
                Console.Write("Select 1/2/3/4/5/6\n1 = Read Full Player List\n2 = Edit Players Information\n3 = Top 10 Players / Finalist / Game\n4 = Finalist / Game\n5 = Game\n6 = Quit\nEnter Here: ");
                menuChoice = Convert.ToInt32(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        Console.WriteLine("Full Player List");
                        Helpers.PlayerHelper.PrintPlayerInfo(playersList);
                        ReturnToMenu();
                        break;
                    case 2:
                        Console.WriteLine("Edit a players information");
                        Helpers.PlayerHelper.EditPlayersInfo(playersList);
                        break;
                    case 3:
                        Console.WriteLine("Top 10 People and Finalist");
                        //ClassSort(ref student);
                        //CheckDuplicatePlayers(ref student, ref money);
                        break;
                    case 4:
                        //Checker(ref student, ref money);
                        break;
                    case 5:
                        Console.WriteLine("Deal or No Deal");
                        //CheckDuplicateCaseMoney(ref money);
                        break;
                    case 6:
                        Console.WriteLine("Quitting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        ShowIntroText();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*** Invalid input try again ***\n\n");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}

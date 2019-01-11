using DealOrNoDeal.Models;
using System;
using System.Collections.Generic;
using System.Threading;

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
                        Helpers.PlayerHelper.CheckDuplicatePlayers(playersList, true);
                        break;
                    case 4:
                        Console.WriteLine("Finalist");
                        Helpers.PlayerHelper.CheckDuplicatePlayers(playersList, false);
                        break;
                    case 5:
                        Console.WriteLine("Deal or No Deal");
                        Helpers.BriefcaseHelper.CasePick();
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

        /// <summary>
        /// This method is the intro to the game. It will false the text and change colors
        /// </summary>
        public void GameFlash()
        {
            for (int i = 0; i <= 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;    //Foreground color will change
                Console.WriteLine("DEAL OR NO DEAL");             //The text that is going to be displayed
                Thread.Sleep(200);                                //Small pause
                Console.Clear();                                  //Clear console
                Console.ResetColor();                             //All the color will reset
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
    }
}

using DealOrNoDeal.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace DealOrNoDeal.Helpers
{
    public class PlayerHelper
    {
        private static Random rand = new Random();

        /// <summary>
        /// This method will be reading in the deal or no deal text
        /// </summary>
        /// <returns>List of students</returns>
        public static List<Players> ReadPlayerList()
        {
            List<Players> students = new List<Players>();

            try
            {
                using (StreamReader sr = new StreamReader("..\\..\\Assets\\DealOrNoDeal.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        Players student = new Players
                        {
                            FirstName = sr.ReadLine(),
                            LastName = sr.ReadLine(),
                            Interest = sr.ReadLine()
                        };
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from DealOrNoDeal.txt file...");
                Console.WriteLine(ex.Message);
            }

            return students;
        }

        /// <summary>
        /// This method will print the list of players
        /// </summary>
        /// <param name="playerList"></param>
        public static void PrintPlayerInfo(List<Players> playerList)
        {
            Console.Clear();
            playerList.Sort();
            Console.WriteLine("First Name".PadRight(15) + "Last Name".PadRight(15) + "Interest".PadRight(15) + "\n"); // Title of each column
            foreach (Players player in playerList)
            {
                Console.WriteLine(player.FirstName.PadRight(15) + player.LastName.PadRight(15) + player.Interest.PadRight(15)); // print first name, last name and interest with padding
            }
        }

        public static void EditPlayersInfo(List<Players> playerList)
        {
            bool isPlayerFound = false;
            PrintPlayerInfo(playerList);
            Console.Write("\nEnter LAST name\nWho do you want to edit: ");
            string targetPlayer = Console.ReadLine().ToUpper();
            
            while (!isPlayerFound)
            {
                foreach(Players player in playerList)
                {
                    if(targetPlayer.Equals(player.LastName.ToUpper()))
                    {
                        isPlayerFound = true;
                        Console.Write("\nYou have picked: " + player.FirstName + " " + player.LastName + "\n");
                        Console.Write("\n\nPick a NUMBER equivalent\nWhat would you like to edit? \n1. First Name\n2. Last Name\n3. Interest\n4. All of the above\n5. Exit\n\nEnter Here: ");
                        int sectionPick = Convert.ToInt32(Console.ReadLine());
                        EditPlayerInfoActions(sectionPick, player, playerList);
                    }
                }

                if(!isPlayerFound)
                {
                    Console.WriteLine("\nSorry try again");
                    Console.Write("\nEnter LAST name\nWho do you want to edit: ");
                    targetPlayer = Console.ReadLine().ToUpper();
                    Console.Clear();
                    PrintPlayerInfo(playerList);
                }
            }
        }

        public static void EditPlayerInfoActions(int sectionPick, Players player, List<Players> playerList)
        {
            MenuOperations menuOps = new MenuOperations();
            bool isValidSectionProcessed = false;
 
            while(!isValidSectionProcessed)
            {
                switch (sectionPick)
                {
                    case 1:
                        Console.Write("\nEnter new first name: ");
                        player.FirstName = Console.ReadLine();
                        WriteNewList(playerList);
                        isValidSectionProcessed = true;
                        break;
                    case 2:
                        Console.Write("\nEnter new last name: ");
                        player.LastName = Console.ReadLine();
                        WriteNewList(playerList);
                        isValidSectionProcessed = true;
                        break;
                    case 3:
                        Console.Write("\nEnter new interest: ");
                        player.Interest = Console.ReadLine();
                        WriteNewList(playerList);
                        isValidSectionProcessed = true;
                        break;
                    case 4:
                        Console.Write("\nEnter new first name: ");
                        player.FirstName = Console.ReadLine();
                        Console.Write("\nEnter new last name: ");
                        player.LastName = Console.ReadLine();
                        Console.Write("\nEnter new interest: ");
                        player.Interest = Console.ReadLine();
                        WriteNewList(playerList);
                        isValidSectionProcessed = true;
                        break;
                    case 5:
                        isValidSectionProcessed = true;
                        Console.Clear();
                        menuOps.DisplayMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid entry...");
                        Console.Write("\n\nPick a NUMBER equivalent\nWhat would you like to edit? \n1. First Name\n2. Last Name\n3. Interest\n4. All of the above\n5. Exit\n\nEnter Here: ");
                        sectionPick = Convert.ToInt32(Console.ReadLine());
                        break;
                }
            }

            Console.Write("\nDo you want to see the updated list? Y/N: ");
            string printUpdatedPlayerList = Console.ReadLine().ToUpper();
            if (printUpdatedPlayerList == "Y")
            {
                Console.Clear();
                PrintPlayerInfo(playerList);
                menuOps.ReturnToMenu();
            }
        }

        /// <summary>
        /// This method will write back to the main text file
        /// </summary>
        /// <param name="playerList"></param>
        public static void WriteNewList(List<Players> playerList)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("..\\..\\Assets\\DealOrNoDeal.txt"))
                {
                    foreach(Players player in playerList)
                    {
                        sw.WriteLine(player.FirstName);
                        sw.WriteLine(player.LastName);
                        sw.WriteLine(player.Interest);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to DealOrNoDeal.txt file...");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Checking for repeating numbers up to 10. This method is for the top ten (FOR MENU 3)
        /// </summary>
        /// <param name="playerList"></param>
        /// <param name="briefcaseList"></param>
        public static void CheckDuplicatePlayers(List<Players> playerList, List<Case> briefcaseList, bool displayTopTen)
        {
            List<int> playerIndexList = new List<int>();
            bool isIndexUnique = false;
            for(int i = 0; i < 10; i++)
            {
                int playerIndex = rand.Next(0, 21);
                while(!isIndexUnique)
                {
                    if (!playerIndexList.Contains(playerIndex))
                    {
                        isIndexUnique = true;
                        playerIndexList.Add(playerIndex);
                    }
                    else
                    {
                        playerIndex = rand.Next(1, 21);
                    }
                }
                isIndexUnique = false;
            }

            if(displayTopTen)
            {
                PickTenPlayers(playerList, briefcaseList, playerIndexList);
            }
            else
            {
                PickOne(playerList, briefcaseList, playerIndexList);
            }
        }

        /// <summary>
        /// Displaying top 10 indexes and putting in a playerIndexList
        /// </summary>
        /// <param name="playerList"></param>
        /// <param name="briefcaseList"></param>
        /// <param name="playerIndexList"></param>
        public static void PickTenPlayers(List<Players> playerList, List<Case> briefcaseList, List<int> playerIndexList)
        {
            MenuOperations menuOps = new MenuOperations();
            Console.Clear();
            Console.WriteLine("Top ten finalist");

            foreach(int playerIndex in playerIndexList)
            {
                Console.WriteLine(playerList[playerIndex].FirstName + " " + playerList[playerIndex].LastName);
            }

            Console.Write("\n\nPick one random winning player? Y/N: ");
            string resp = Console.ReadLine().ToUpper().Substring(0, 1);

            if (resp == "Y")
            {
                PickOne(playerList, briefcaseList, playerIndexList);
            }
            else
            {
                Console.Clear();
                menuOps.DisplayMenu();
            }
        }

        public static void PickOne(List<Players> playerList, List<Case> briefcaseList, List<int> playerIndexList)
        {
            MenuOperations menuOps = new MenuOperations();
            int winningPlayerIndex = playerIndexList[rand.Next(0, 10)];
            Console.WriteLine("\nWinning player is... " + playerList[winningPlayerIndex].FirstName +
                " " + playerList[winningPlayerIndex].LastName + "\n");

            Console.Write("\nWould you like to play the game? Y/N: ");
            string resp = Console.ReadLine().ToUpper().Substring(0, 1);

            if (resp == "Y")
            {
                Console.Clear();
                menuOps.GameFlash();
                //CheckDuplicateCaseMoney(ref money);
            }
            else
            {
                Console.Clear();
                menuOps.DisplayMenu();
            }
        }
    }
}

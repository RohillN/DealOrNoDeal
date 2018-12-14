using System;
using System.Collections.Generic;
using System.IO;

namespace DealOrNoDeal.Helpers
{
    public class PlayerHelper
    {
        /// <summary>
        /// This method will be reading in the deal or no deal text
        /// </summary>
        /// <returns>List of students</returns>
        public static List<Models.Players> ReadPlayerList()
        {
            List<Models.Players> students = new List<Models.Players>();

            try
            {
                using (StreamReader sr = new StreamReader("..\\..\\Assets\\DealOrNoDeal.txt")) // Text file located in bin > Debug
                {
                    while (!sr.EndOfStream)
                    {
                        Models.Players student = new Models.Players
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
        public static void PrintPlayerInfo(List<Models.Players> playerList)
        {
            Console.Clear();
            playerList.Sort();
            Console.WriteLine("First Name".PadRight(15) + "Last Name".PadRight(15) + "Interest".PadRight(15) + "\n"); // Title of each column
            foreach (Models.Players player in playerList)
            {
                Console.WriteLine(player.FirstName.PadRight(15) + player.LastName.PadRight(15) + player.Interest.PadRight(15)); // print first name, last name and interest with padding
            }
        }
    }
}

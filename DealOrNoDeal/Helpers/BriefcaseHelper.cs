using DealOrNoDeal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DealOrNoDeal.Helpers
{
    public class BriefcaseHelper
    {
        private static Random rand = new Random();

        /// <summary>
        /// Method will read a file holding the case numbers and values
        /// </summary>
        /// <param name="money"></param>
        public static List<Case> ReadBriefcaseList()
        {
            List<Case> moneyList = new List<Case>();

            try
            {
                using (StreamReader sr = new StreamReader("..\\..\\Assets\\TestCase.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        Case suitcase = new Case
                        {
                            CaseMoney = Convert.ToDouble(sr.ReadLine())
                        };
                        moneyList.Add(suitcase);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from TestCase.txt file...");
                Console.WriteLine(ex.Message);
            }

            return moneyList.OrderBy(x => rand.Next()).ToList();
        }

        public static void CasePick()
        {
            List<Case> briefcaseList = Helpers.BriefcaseHelper.ReadBriefcaseList();
            for (int i = 0; i < briefcaseList.Count; i++)
            {
                briefcaseList[i].CaseNumber = i + 1;
            }

            Console.Clear();
            Console.Write("Pick a case from 1 - 26: ");
            int caseHeld = Convert.ToInt32(Console.ReadLine());
            while(caseHeld <= 0 || caseHeld > 26)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\n*** Invalid! Input is out of range! ***");
                Console.ResetColor();
                Console.Write("\nEnter a case number from 1 - 26: ");
                caseHeld = Convert.ToInt32(Console.ReadLine());
            }

            Console.Clear();
            briefcaseList[caseHeld - 1].Off = true;
            StartGameLoop(briefcaseList, 6, caseHeld, true);
        }

        private static int StartGameLoop(List<Case> briefcaseList, int suitcasesToOpenThisRound, int caseHeld, bool printCaseHeld)
        {
            int briefcasesToOpen = briefcaseList.Count(c => c.Off == false);
            if(briefcasesToOpen == 0 && suitcasesToOpenThisRound == 1)
            {
                // All cases have been picked... decide to keep or not???
                // LastTwoCasePick(...)
                return 0;
            }

            for (int i = 0; i < suitcasesToOpenThisRound; i++)
            {
                bool wasCaseSelectionValidated = false;
                DisplayAvailableCases(briefcaseList);
                if(printCaseHeld)
                {
                    Console.Write("\n\n\nYour case: {0}".PadLeft(30) + "| Value: ????????" + "\n", caseHeld);
                    printCaseHeld = false;
                }
                Console.Write("\n{0} / {1} pick case: ", i + 1, suitcasesToOpenThisRound);
                int caseSelection = Convert.ToInt32(Console.ReadLine());
                while(!wasCaseSelectionValidated)
                {
                    wasCaseSelectionValidated = true;
                    if(caseSelection <= 0 || caseSelection >= 26)
                    {
                        wasCaseSelectionValidated = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\n*** Invalid! Input is out of range! ***");
                        Console.ResetColor();
                        Console.Write("\nEnter a case number from 1 - 26: ");
                        caseSelection = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        DisplayAvailableCases(briefcaseList);
                    }
                    if(caseSelection == caseHeld)
                    {
                        wasCaseSelectionValidated = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\n*** Case has already been picked! ***");
                        Console.ResetColor();
                        Console.Write("\nEnter a case number from 1 - 26: ");
                        caseSelection = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        DisplayAvailableCases(briefcaseList);
                    }
                }
                briefcaseList[caseSelection-1].Off = true;
                Console.WriteLine("\n\nCase contains {0:c}\n", briefcaseList[caseSelection - 1].CaseMoney);
            }

            GetOfferFromBanker();

            if (suitcasesToOpenThisRound > 1)
                return StartGameLoop(briefcaseList, suitcasesToOpenThisRound - 1, caseHeld, true);
            else
                return StartGameLoop(briefcaseList, suitcasesToOpenThisRound, caseHeld, true);
        }

        private static void DisplayAvailableCases(List<Case> briefcaseList)
        {
            foreach(Case targetCase in briefcaseList)
            {
                if(!targetCase.Off)
                {
                    Console.Write("| {0} ", (targetCase.CaseNumber));
                }
                else
                {
                    Console.Write("|   ");
                }
            }
        }

        private static void GetOfferFromBanker()
        {
            Console.WriteLine("Calling the banker...\n\n");
        }
    }
}

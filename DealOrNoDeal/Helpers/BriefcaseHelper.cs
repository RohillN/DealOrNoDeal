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
                            //CaseNumber = Convert.ToInt32(sr.ReadLine()),
                            CaseMoney = Convert.ToInt32(sr.ReadLine())
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
            int caseHold = Convert.ToInt32(Console.ReadLine());
            while(caseHold <= 0 || caseHold > 26)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\n*** Invalid! Input is out of range! ***");
                Console.ResetColor();
                Console.Write("\nEnter a case number from 1 - 26: ");
                caseHold = Convert.ToInt32(Console.ReadLine());
            }

            //Console.Clear();
            briefcaseList[caseHold - 1].Off = true;
            //Hide(ref money, ref check, ref randomC, ref caseHold);
        }
    }
}

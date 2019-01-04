using DealOrNoDeal.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace DealOrNoDeal.Helpers
{
    public class BriefcaseHelper
    {
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
                            CaseNumber = Convert.ToInt32(sr.ReadLine()),
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

            return moneyList;
        }
    }
}

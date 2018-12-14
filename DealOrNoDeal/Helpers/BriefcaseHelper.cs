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
        public static List<Models.Case> ReadBriefcaseList()
        {
            List<Models.Case> moneyList = new List<Models.Case>();

            try
            {
                using (StreamReader sr = new StreamReader("..\\..\\Assets\\TestCase.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        Models.Case suitcase = new Models.Case
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

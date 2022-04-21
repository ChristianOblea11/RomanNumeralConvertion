using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumConvertAPI.Models
{
    public class RomanNumViewModel
    {

        public class RomanNumeral
        {
            public int TransactionID { get; set; }
            public int DecimalNumber { get; set; }
            public string RomanNumeralConvert
            {
                get;
                set;
            }




            private static List<RomanNumeral> romanNumerals = new List<RomanNumeral>
            {
                new RomanNumeral
                {
                   TransactionID = 1,
                   DecimalNumber = 1,
                   RomanNumeralConvert = "I"

                }
                //new RomanNumeral
                //{
                //    TransactionID = 2,
                 //   DecimalNumber = 5,
                 //   RomanNumeralConvert = "V"

                //}
            };
            public RomanNumeral GetRomanNumeral(int id)
            {
                return romanNumerals.FirstOrDefault(a => a.TransactionID == id);
            }
            public List<RomanNumeral> GetRomanNumerals(int pageNumber = 1)
            {
                int pageSize = 10;
                int skip = pageSize * (pageNumber - 1);
                if (romanNumerals.Count < pageSize)
                    pageSize = romanNumerals.Count;
                return romanNumerals
                  .Skip(skip)
                  .Take(pageSize).ToList();
            }
            public bool Save(int defNum, string value)
            {


                //add a new user with the information above
                romanNumerals.Add(new RomanNumeral { 
                    TransactionID = romanNumerals.Count + 1,
                    DecimalNumber = defNum,
                    RomanNumeralConvert= value});
                //var result = romanNumerals.Where(a => a.TransactionID == romanNumeral.TransactionID);
                //if (result != null)
                //{
                //   if (result.Count() == 0)
                //    {
                //        romanNumerals.Add(romanNumeral);
                        return true;
                //    }
                //}
                //return false;
            }
        }
    }
}


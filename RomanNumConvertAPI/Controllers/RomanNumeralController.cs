using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomanNumConvertAPI.Models;
using static RomanNumConvertAPI.Models.RomanNumViewModel;

namespace RomanNumConvertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RomanNumeralController : ControllerBase
    {

        // Set up key numerals and numeral pairs
        private readonly int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private readonly string[] numerals = new string[]
            { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };


        public static List<RomanNumeral> romanNumerals = new List<RomanNumeral>
            {
                //Put sample default value in the list
                new RomanNumeral
                {
                   TransactionID = 1,
                   DecimalNumber = 1,
                   RomanNumeralConvert = "I"

                }
                
            };


        // Converts an integer value into Roman numerals
        public string NumberToRoman(int number)
        {
            int defNum = number;
            // Validate
            if (number < 0 || number > 3999)
                throw new ArgumentException("Value must be in the range 0 - 3,999.");

            if (number == 0) return "N";

            // Initialise the string builder
            StringBuilder result = new StringBuilder();


            // Loop through each of the values to diminish the number
            for (int i = 0; i < 13; i++)
            {
                // If the number being converted is less than the test value, append
                // the corresponding numeral or numeral pair to the resultant string
                while (number >= values[i])
                {
                    number -= values[i];
                    result.Append(numerals[i]);
                }
            }

        

            RomanNumeral convert = new RomanNumeral();
            convert.TransactionID = romanNumerals.Count + 1;
            convert.RomanNumeralConvert = result.ToString();
            convert.DecimalNumber = defNum;

            romanNumerals.Add(convert);

           
            return result.ToString();
        }


      
    }
}
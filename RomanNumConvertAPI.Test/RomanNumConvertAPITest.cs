using NUnit.Framework;
using RomanNumConvertAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
namespace RomanNumConvertAPI.Test
{
    public class RomanNumConvertAPITest
    {
        private Controllers.RomanNumeralController _service;
        [SetUp]
        public void Setup()
        {
            _service = new  RomanNumeralController();
        }

        [Test]
        public void ConvertsCorrectly()
        {
            var cases = new List<(int value, string expected)>()
            {
                (1, "I"),
                (4, "IV"),
                (5, "V"),
                (9, "IX"),
                (10, "X"),
                (100, "C"),
                (40, "XL"),
                (50, "L"),
                (90, "XC"),
                (400, "CD"),
                (500, "D"),
                (900, "CM"),
                (1000, "M")
            };

            foreach (var testCase in cases)
            {
                var actual = _service.NumberToRoman(testCase.value);
                Assert.AreEqual(actual, testCase.expected);
            }
        }

        [Test]
        public void ConvertsSomeSpecialCases()
        {
            var actual = _service.NumberToRoman(3999);
            Assert.AreEqual(actual, "MMMCMXCIX");

            actual = _service.NumberToRoman(2016);
            Assert.AreEqual(actual, "MMXVI");

            actual = _service.NumberToRoman(2018);
            Assert.AreEqual(actual, "MMXVIII");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace RomanMath.Impl
{
    public static class Service
    {
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>

        private static readonly DataTable DTable = new DataTable();
        private static readonly Dictionary<char, int> RomanNumbers = new Dictionary<char, int>
        {
            {'M', 1000}, {'D', 500}, {'C', 100}, {'L', 50}, {'X', 10}, {'V', 5}, {'I', 1}
        };

        public static int Evaluate(string expression)
        {
            var stringResult = "";
            if (!Validate(expression)) throw new Exception("Incorrect input");
            var splittedExpression = Regex.Split(expression.Replace(" ", ""), "([-+*])");
            foreach (var currentString in splittedExpression)
            {
                if (currentString == "+" || currentString == "*" || currentString == "-")
                {
                    stringResult += currentString;
                }
                else
                {
                    stringResult += RomanToInteger(currentString);
                }
            }
            var result = DTable.Compute(stringResult, "");
            if (result is int @res)
            {
                return @res;
            }
            throw new Exception("Computing ERROR");
        }

        private static int RomanToInteger(string romanString)
        {
            try
            {
                var number = 0;
                var previousChar = romanString[0];
                foreach (var currentChar in romanString)
                {
                    Console.WriteLine(currentChar);
                    number += RomanNumbers[currentChar];
                    Console.WriteLine(number);
                    if (RomanNumbers[previousChar] < RomanNumbers[currentChar])
                    {
                        number -= RomanNumbers[previousChar] * 2;                 
                    }
                    Console.WriteLine(previousChar);
                    previousChar = currentChar;
                }
                return number;
            }
            catch (Exception)
            {
                throw new Exception("Computing ERROR");
            }

        }
        private static bool Validate(string expression)
        {
            var regex = (new Regex(@"^[+*-MDCLXVI(\s)]*$"));
            return !string.IsNullOrEmpty(expression) && regex.IsMatch(expression);
        }
    }
}

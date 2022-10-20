using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Final_Project.VALIDATION
{
    
        public static class Validator
        {
            public static bool IsValidId(string input)
            {
                if (!(Regex.IsMatch(input, @"^\d{4}$")))
                {
                    return false;
                }

                return true;
            }

            public static bool IsValidName(string input)
            {
                if (input.Length == 0)
                {
                    return false;
                }
                for (int i = 0; i < input.Length; i++)
                {
                    if (!(Char.IsLetter(input[i])) && !(Char.IsWhiteSpace(input[i])))
                    {
                        return false;
                    }
                }

                return true;
            }

            public static bool IsEmpty(string input)
            {
                if (input.Length == 0)
                {
                    return true;
                }

                return false;
            }
        }
}

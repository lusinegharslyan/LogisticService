using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogisticService.Extentions
{
    public static class ValidationExtentions
    {
        public static void IntValidation(this string input, out int choice)
        {
            int result;

            if (string.IsNullOrWhiteSpace(input))
            {
                choice = -1;
                return;
            }

            if (int.TryParse(input, out result))
            {
                choice = result;
                return;
            }

            choice = -1;

        }

        public static bool BooleanValidation(this string input)
        {
            bool result;

            if (bool.TryParse(input, out result))
            {
               return result;
            }

            throw new Exception("Invalid choice");
        }
    }
}

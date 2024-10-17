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
        public static int IntValidation(this string input)
        {
            int result;

            if (int.TryParse(input, out result))
            {
                return result;     
            }

            throw new Exception("Invalid input");

        }

        public static bool BooleanValidation(this string input)
        {
            bool result;

            if (bool.TryParse(input, out result))
            {
                return result;
            }

            throw new Exception("Invalid input");
        }

        public static float FloatValidation(this string input)
        {
            float result;

            if (float.TryParse(input, out result))
            {
                return result;
            }

            throw new Exception("Invalid input");
        }
    }
}

using LogisticService.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Helpers
{
    public static class InputGeters
    {
        public static string StringGeter(string value)
        {
            string result;
            while (true)
            {
                Console.Write($"{value}: ");
                result = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        public static float FloatGeter(string value)
        {
            float result;
            while (true)
            {
                Console.Write($"{value}: ");
                try
                {
                    result = Console.ReadLine().FloatValidation();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            return result;
        }

        public static int IntGeter(string value)
        {
            int result;
            while (true)
            {
                Console.Write($"{value}: ");
                try
                {
                    result = Console.ReadLine().IntValidation();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            return result;
        }


        public static bool BoolGeter(string value)
        {
            bool result;
            while (true)
            {
                Console.Write($"{value}: ");
                try
                {
                    result = Console.ReadLine().BooleanValidation();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            return result;
        }
    }
}

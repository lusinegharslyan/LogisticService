using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticService.Models;
using LogisticService.Menues;
using LogisticService.Extentions;

namespace LogisticService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Logistic Service");

            while (true)
            {
                Menu menu = null;

                Console.WriteLine(" 1- Admin | 2- User | 0 -Exit");
                Console.Write("Login as: ");

                int login;

                Console.ReadLine().IntValidation(out login);

                if (login == -1)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                if (login == 0)
                {
                    return;
                }
                switch (login)
                {
                    case 1:
                        menu = new AdminMenu();
                        break;
                    case 2:
                        menu = new UserMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                menu.Start();

            }
        } 
    } 
}

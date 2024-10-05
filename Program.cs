using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticService.Classes;

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
                int login = int.Parse(Console.ReadLine());
                if(login == 0)
                {
                    Console.WriteLine("End programm");
                    break;
                }
                switch (login)
                {
                    case 1:  menu= new AdminMenu();
                        break;
                    case 2: menu = new UserMenu();
                        break;
                    default: Console.WriteLine("Invalid choice");
                        break;
                }

                menu.Start();

            }

        }
    }
}

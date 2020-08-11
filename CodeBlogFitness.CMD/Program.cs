using System;
using System.Runtime.CompilerServices;
using CodeBlogFitness.BL.Controllers;


namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our app CodeBlogFitness");

            Console.WriteLine("Enter user name: ");
            var name = Console.ReadLine();



            var userController = new UserController(name);

            Console.WriteLine(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Enter gender: ");
                var gender = Console.ReadLine();
                DateTime birthDateTime = ParseDateTime();
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDateTime, weight,height);
            }

        }

        private static DateTime ParseDateTime()
        {
             DateTime birthDate;
             while (true)
             {
                    Console.Write("Enter date of birth (DD.MM.YYYY): ");
                    if ((DateTime.TryParse(Console.ReadLine(), out birthDate)))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect date format");
                    }
             }
             return birthDate;
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Incorrect date format {name}");
                }
            }

        }

    }
}
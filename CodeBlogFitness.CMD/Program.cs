using System;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using CodeBlogFitness.BL.Controllers;
using CodeBlogFitness.BL.Model;


namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceMagager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceMagager.GetString("Hello", culture));

            Console.WriteLine(resourceMagager.GetString("Enter name", culture));
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Enter gender: ");
                var gender = Console.ReadLine();
                DateTime birthDateTime = ParseDateTime();
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDateTime, weight,height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What you want to do?");
            Console.WriteLine("E - enter food consume");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var food = EnterEating();
                eatingController.Add(food.Food, food.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item} - {item.Value}");
                }
            }


            Console.ReadLine();

        }

        private static (Food  Food, double Weight) EnterEating()
        {
            Console.Write("Enter poduct`s name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carb = ParseDouble("carbohydrates");

            var weight = ParseDouble("weight of portion");
            var product = new Food(food, calories, proteins, fats, carb);

            return (product, weight) ;

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
                    Console.WriteLine($"Incorrect field format {name}");
                }
            }

        }
    }
}
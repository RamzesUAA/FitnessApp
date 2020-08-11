using System;
using System.ComponentModel.Design;
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
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Enter gender: ");
                var gender = Console.ReadLine();
                DateTime birthDateTime = ParseDateTime("date of birth");
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDateTime, weight,height);
            }
            Console.WriteLine(userController.CurrentUser);


            while (true)
            {
                Console.WriteLine("What you want to do?");
                Console.WriteLine("E - enter food consume");
                Console.WriteLine("A - enter exercise");
                Console.WriteLine("Q - exit");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var food = EnterEating();
                        eatingController.Add(food.Food, food.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item} - {item.Value}");
                        }

                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Start, exe.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} since {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
            Console.ReadLine();
        }

        private static (DateTime Start, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Enter name of exercise:");
            var name = Console.ReadLine();
            var energy = ParseDouble("Energy consumption per minute");
            var begin = ParseDateTime("Start of doing exercise: ");
            var end = ParseDateTime("End of doing exercise: ");

            var activity = new Activity(name, energy);
            return (begin, end, activity);

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

        private static DateTime ParseDateTime(string name)
        {
             DateTime birthDate;
             while (true)
             {
                    Console.Write($"Enter {name}: ");
                    if ((DateTime.TryParse(Console.ReadLine(), out birthDate)))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect format {name}");
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
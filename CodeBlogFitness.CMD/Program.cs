using System;
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

            Console.WriteLine("Enter gender: ");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter date of birth: ");
            var birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter weight: ");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height: ");
            var height = double.Parse(Console.ReadLine());


            var userController = new UserController(name, gender, birthDate, weight, height);

            userController.Save();
        }
    }
}

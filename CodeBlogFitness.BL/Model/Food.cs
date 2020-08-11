using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Name of food
        /// </summary>
        public string Name { get; }

        public double Callories { get; }

        /// <summary>
        /// Proteins
        /// </summary>
        public double Proteins  { get; set; }
        /// <summary>
        /// Fats
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Carbohydrates
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Calories per 100 grm of product
        /// </summary>
        public double Calories { get; }

        public Food(string name):this(name, 0, 0 ,0 , 0)
        {
        }

        public Food(string name, double callories, double proteins, double fats, double carbohydrates)
        {
            // TODO: checking 

            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

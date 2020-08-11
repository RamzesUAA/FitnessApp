using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Eating
    /// </summary>
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; set; }
        public Dictionary<Food, double> Foods { get; }

        public User User { get; set; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("user cannot be empty or null", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }

        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {

            // TODO: checking
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

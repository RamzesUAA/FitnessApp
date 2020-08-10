using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
   
        /// <summary>
        ///  Gender
        /// </summary>
    public class Gender
    {
        /// <summary>
        ///  Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///  Create new gender
        /// </summary>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender name can`t be empty or equal to null");
            }
            Name = name;
        }

        /// <summary>
        ///  Name
        /// </summary>
        public override string ToString()
        {
            return Name;
        }
    }
}

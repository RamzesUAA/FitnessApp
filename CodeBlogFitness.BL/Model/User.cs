using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        #region properties

        

     
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Birth of Date
        /// </summary>

        public DateTime BirthDate { get; }
        /// <summary>
        /// Weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="name"> Name. </param>
        /// <param name="gender"> Gender. </param>
        /// <param name="birthDate"> Date of birth. </param>
        /// <param name="weight"> Weight. </param>
        /// <param name="height"> Height. </param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {

            #region Checking conditions

            if (string.IsNullOrWhiteSpace(name))
            {
                throw  new ArgumentNullException("User name can`t be empty or null", nameof(name));
            }

            if (Gender == null)
            {
                throw new ArgumentNullException("Gender name can`t be empty or null", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Inexisting date of birth", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentNullException("Weight cannot be equal or less than zero", nameof(weight));

            }

            if (height <= 0)
            {
                throw new ArgumentNullException("Height cannot be equal or less than zero", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}

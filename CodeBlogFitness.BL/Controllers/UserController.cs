using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controllers
{
    /// <summary>
    /// User`s controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User of the app
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Creating new controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height )
        {
            // TODO: checking
            var gender = new Gender(genderName);
            User = new User(userName, gender,birthDay,weight, height);
        }

        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                // TODO: What we have to do if we haven`t rad user
            }
        }


        /// <summary>
        /// Save user`s data
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Load user`s data
        /// </summary>
        /// <returns></returns>
       
    }
}

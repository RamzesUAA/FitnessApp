﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class UserController:ControllerBase
    {
        private const string USER_FILE_NAME = "user.dat";
        /// <summary>
        /// User of the app
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Creating new controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName )
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("userName cannot be empty", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }



        /// <summary>
        /// Get list of users
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // TODO: Checking

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Height = height;
            CurrentUser.Weight = weight;

            Save();
        }

        /// <summary>
        /// Save user`s data
        /// </summary>
        public void Save()
        {
            Save(USER_FILE_NAME, Users);
        }

     
        /// <summary>
        /// Load user`s data
        /// </summary>
        /// <returns></returns>
       
    }
}

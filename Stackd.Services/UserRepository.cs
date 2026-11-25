using Stackd.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Stackd.Services;

namespace Stackd.Services
{
    //Anica Janjic 991799177
    //This is used to implement our methods that are being called in the Controller class.
    //Creating the methods here, so it doesn't directly interact with our database directly.

    public class UserRepository : IUserServices
    {
        //holds the database context used for saving data
        private readonly StackdDb _context;

        //constructor to pass all the StackdDb implementations (dependency injection)
        public UserRepository(StackdDb context)
        {
            _context = context;
        }

        //adds the new user to the database 
        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        //this is used to allow user to login and confirm if they are correct
        public User Login(string email, string password)
        {
            //comfirms if the email ad password are correct then to allow to access profile page
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        //this is used to find a user and return the data based off their Id
        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        //this is used to allow users to edit their current profile information
        public User UpdateUser(User updatedUser)
        {
            _context.Users.Update(updatedUser);
            _context.SaveChanges();
            return updatedUser;
        }
    }
}

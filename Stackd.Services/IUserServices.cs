using Stackd.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Stackd.Services
{
    //Anica Janjic 991799177
    //this is used to specify what methods exist for user feature
    public interface IUserServices
    {
        //this is used to register a new user to the site
        User Register(User user);

        //this is used for user to login and verify if correct
        User Login(string email, string password);

        //this is used to finds the user and display the data if user is correct
        User GetUserById(int userId);

        //this is used to allow users to update their profile information
        User UpdateUser(User updatedUser);

    }
}

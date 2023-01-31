using RemoteNotes.Service.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteNotes.Service.Console
{
    public class UserManager : IUserManager
    {
        public Task<User> GetUserByLoginAsync(string login)
        {
            if (login.Equals("login")) 
            {
                return Task<User>.Run(() =>
                {
                    User user = new User();
                    user.Login = "login";
                    return user;
                });
            }
            throw new ArgumentException("User doesn't exist");
        }
    }
}

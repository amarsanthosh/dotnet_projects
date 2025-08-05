using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Splitwiseapp
{
    public class UserManager
    {
        public List<User> users = new List<User>();

        public void Adduser(User user)
        {
            if (user != null && !users.Any(u => u.GetUserId() == user.GetUserId()))
            {
                users.Add(user);
            }
        }

        public void GetUsers()
        {
            foreach (var i in users)
            {
                Console.WriteLine(i.UserName + " "); 
            }
        }
    }
}
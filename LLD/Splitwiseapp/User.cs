using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Splitwiseapp
{
    public class User
    {
        public int UserId { get;  set; }
        public string UserName { get;set; } = string.Empty;

        public User(int UserId, string UserName)
        {
            this.UserId = UserId;
            this.UserName = UserName;
        }
        public int GetUserId()
        {
            return UserId;
        }
        public string GetUserName()
        {
            return UserName;
        }
    }
}
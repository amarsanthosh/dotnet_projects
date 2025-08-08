using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public class LoginDetails
    {
        public static string MovieAdmin = string.Empty; 
        public string LoginId { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string LoginType { get; set; } = string.Empty;

        public LoginDetails(string LoginId, string Password, string LoginType)
        {
            this.Password = Password;
            this.LoginId = LoginId;
            this.LoginType = LoginType;
            if (LoginType == "Admin") MovieAdmin = LoginId;
        }

    }
}
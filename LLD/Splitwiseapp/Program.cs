// See https://aka.ms/new-console-template for more information
using Splitwiseapp;

class Program
{
    static void Main()
    {
        UserManager userManager = new UserManager();

        User user = new User(1, "Amar");
        userManager.Adduser(user);
        userManager.GetUsers();
    }
}
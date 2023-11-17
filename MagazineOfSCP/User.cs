using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineOfSCP
{
    public class User : Fond
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public int Access_lvl { get; private set; }
        public User(string login, string password, int access_lvl)
        {
            Login = login;
            Password = password;
            Access_lvl = access_lvl ;
        }
    }
    static class UserAccess
    {
        public static string login { get; set; }
        public static int access_lvl { get; set; }

    }
}

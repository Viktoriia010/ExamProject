using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject;

internal class User
{
    public string Login { get; set; }
    public string Password { get; set; }

    public DateTime Birthday { get; set; }

    public User(string login, string password, DateTime birthday)
    {
        Login = login;
        Password = password;
        Birthday = birthday;
    }

    public User()
    {

    }

    public override string ToString()
    {
        return $"Login: {Login}, Birthday: {Birthday.ToShortDateString()}";
    }
}

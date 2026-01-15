using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject;

internal class UserManager:IEnumerable<User>
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public IEnumerator<User> GetEnumerator()
    {
        return users.GetEnumerator();
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public bool IsLoginExists(string login)
    {
        foreach (User user in users)
        {
            if (user.Login == login)
            {
                return true;
            }
        }
        return false;
    }
    public bool Register(string log, string pas, DateTime birthday)
    {
        if (IsLoginExists(log)) return false;
        User newUser = new User(log, pas, birthday);
        
        users.Add(newUser);
        return true;
    }

    public User Login(string log, string pas)
    {
        foreach (User user in users)
        {
            if (user.Login == log && user.Password == pas)
            {
                Console.WriteLine("Login successful!");
                return user;
            }
        }

        Console.WriteLine("No user found");
        return null;
        
    }
}

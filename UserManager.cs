using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ExamProject;

internal class UserManager:IEnumerable<User>
{
    private List<User> users;
    
    private const string filePath = "users.json";

    public UserManager()
    {
        if (File.Exists(filePath))
        {
            users = DeserializeUsers();
        }
        else
        {
            users = new List<User>();
        }
        
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
        SerializeUsers();
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

        Console.WriteLine("No user found or invalid password");
        return null;
        
    }

    public void SerializeUsers()
    {
        string json = JsonConvert.SerializeObject(users);
        File.WriteAllText(filePath, json);
    }

    public List<User> DeserializeUsers()
    {
        string data = File.ReadAllText(filePath);
        List<User>? personsFromJson = JsonConvert.DeserializeObject<List<User>>(data);
        return personsFromJson == null ? new List<User>() : personsFromJson;    
    }

    //public void SortUsersResult()
    //{
    //    var sorted = users.OrderBy(u => u.Results)
    //}
}

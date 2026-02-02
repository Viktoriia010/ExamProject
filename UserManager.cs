using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ExamProject;

internal class UserManager 
{
    private List<User> users;
    private ILogger logger;

    private const string filePath = "users.json";

    public UserManager(ILogger logger)
    {
        this.logger = logger;
        if (File.Exists(filePath))
        {
            users = DeserializeUsers();
        }
        else
        {
            users = new List<User>();
        }
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
        if (IsLoginExists(log))
        {
            logger.LogWarning("Registration failed. Login already exists: {Login}", log);
            return false;
        }
        User newUser = new User(log, pas, birthday);

        users.Add(newUser);
        SerializeUsers();
        logger.LogInformation("User registered: {Login}", log);
        return true;
    }

    public User Login(string log, string pas)
    {
        logger.LogInformation("Login attempt: {Login}", log);
        foreach (User user in users)
        {
            if (user.Login == log && user.Password == pas)
            {
                Console.WriteLine("Вхід успішний!");
                logger.LogInformation("User logged in successfully: {Login}", log);
                return user;
            }
        }

        Console.WriteLine("Користувача не знайдено або пароль недійсний");
        logger.LogWarning("Failed login attempt: {Login}", log);
        return null;

    }

    public void SerializeUsers()
    {
        try
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, json);
            logger.LogInformation("Users data saved to file");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while saving users data");
        }

    }

    public List<User> DeserializeUsers()
    {
        string data = File.ReadAllText(filePath);
        List<User>? personsFromJson = JsonConvert.DeserializeObject<List<User>>(data);
        return personsFromJson == null ? new List<User>() : personsFromJson;
    }
    public void AddResult(User user, Result result)
    {
        user.Results.Add(result);
        SerializeUsers();
        logger.LogInformation("Result added. User: {Login}, Quiz: {Quiz}, Score: {Score}", user.Login, result.QuizName, result.CorrectAnswers);
    }

    public void SortUsersByResult(string nameQuiz)
    {
        // беремо кожен результат кожного користувача з конкретної вікторини, створюємо об'єкт
        var sortedUsers = users
      .SelectMany(u => u.Results
          .Where(r => r.QuizName == nameQuiz)
          .Select(r => new { User = u, Result = r }))
      .GroupBy(x => x.User.Login) 
      .Select(g => g
          .OrderByDescending(x => x.Result.Date)
          .First())// щоб був тільки один результат юзера
      .OrderByDescending(x => x.Result.CorrectAnswers)
      .ThenByDescending(x => x.Result.Date)
      .Take(20);

        int place = 1;
        Console.WriteLine();
        foreach (var t in sortedUsers)
        {
            Console.WriteLine($"\t{place++}\t{t.User.Login} — {t.Result.CorrectAnswers}/20, {t.Result.Date}");
        }
        Console.WriteLine();

    }

    public int UserPlace(User user, string nameQuiz)
    {
        var sortedUsers = users
      .SelectMany(u => u.Results
          .Where(r => r.QuizName == nameQuiz)
          .Select(r => new { User = u, Result = r }))
      .GroupBy(x => x.User.Login)
      .Select(g => g
          .OrderByDescending(x => x.Result.Date)
          .First())
      .OrderByDescending(x => x.Result.CorrectAnswers)
      .ThenByDescending(x => x.Result.Date)
      .Take(20);

        int place = 1;
        foreach (var item in sortedUsers)
        {
            if (item.User.Login == user.Login)
            {
                Console.WriteLine($"Ваше місце в таблиці: {place}");
                return place;
            }
            place++;
        }

        Console.WriteLine("Ви не увійшли в топ-20.");
        return 0;

    }
}
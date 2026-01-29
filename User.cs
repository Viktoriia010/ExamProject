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
    public List<Result> Results { get; set; }


    public User(string login, string password, DateTime birthday)
    {
        Login = login;
        Password = password;
        Birthday = birthday;
        Results = new List<Result>();
    }


    public User()
    {
        Results = new List<Result>();
    }


    public override string ToString()
    {
        return $"Login: {Login}, Birthday: {Birthday.ToShortDateString()}";
    }

    public void ShowResults()
    {
        if(Results.Count == 0)
        {
            Console.WriteLine("\nРезультатів немає\n");
            return;
        }

        var groups = from result in Results
                     group result by result.QuizName;


        foreach (var g in groups)
        {
            Console.WriteLine();
            Console.WriteLine(g.Key + " quiz");
            foreach (var t in g)
                Console.WriteLine($"\t{t.CorrectAnswers}/20, {t.Date}");
        }
        Console.WriteLine('\n');
    }

    public void ChangePassword()
    {
        Console.WriteLine($"Теперішній пароль: {Password}");
        while (true)
        {
            Console.Write("Введіть новий пароль: ");
            string? password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Пароль невалідний!");
                return;
            }
            else
            {
                Password = password;
                break;
            }
        }

        Console.WriteLine("Новий пароль збережено!");
    }

    public void ChangeBirthday()
    {
        Console.WriteLine($"Теперішня дата народження: {Birthday}");

        while (true)
        {
            Console.Write("Введіть нову дату народження: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Birthday = date;
                Console.WriteLine("Нову дату народження збережено!");
                break;
            }

            Console.WriteLine("Неправильний формат дати!");
        }
    }
}

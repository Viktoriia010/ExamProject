using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject;

internal abstract class Person
{
    public string Login { get; set; }
    public string Password { get; set; }

    public DateTime Birthday { get; set; }

    protected Person(string login, string password, DateTime birthday)
    {
        Login = login;
        Password = password;
        Birthday = birthday;
    }

    public void ChangePassword()
    {
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

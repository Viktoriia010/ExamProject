using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace ExamProject;

internal class Menu
{
    private readonly UserManager _userManager;
    private readonly ILogger _logger;
    public Menu(UserManager userManager, ILogger logger)
    {
        _userManager = userManager;
        _logger = logger;
    }
    public void Run()
    {
        bool isExit = false;

        while (!isExit)
        {
            Console.WriteLine("0 Вихід");
            Console.WriteLine("1 Увійти");
            Console.WriteLine("2 Зареєструватись");
            Console.Write("Введіть число: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (choice)
            {
                case 0:
                    isExit = true;
                    break;

                case 1:
                    LoginMenu();
                    break;

                case 2:
                    RegisterMenu();
                    break;

                default:
                    Console.WriteLine("Неправильний пункт меню!");
                    break;
            }
        }
    }

    private void LoginMenu()
    {
        Console.Write("Введіть логін: ");
        string? login = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(login))
        {
            Console.WriteLine("Невірний логін!");
            return;
        }

        Console.Write("Введіть пароль: ");
        string? password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Невірний пароль!");
            return;
        }


        User user = _userManager.Login(login, password);

        if (user == null)
        {
            Console.WriteLine("Помилка входу!");
            return;
        }

        UserMenu(user);
    }

    private void UserMenu(User user)
    {
        bool isExit = false;

        while (!isExit)
        {
            Console.WriteLine("0 Вихід");
            Console.WriteLine("1 Почати нову вікторину");
            Console.WriteLine("2 Переглянути свої результати");
            Console.WriteLine("3 Переглянути топ-20");
            Console.WriteLine("4 Змінити налаштування");
            Console.Write("Введіть число: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (choice)
            {
                case 0:
                    _logger.LogInformation("User {Login} selected menu option {Choice}", user.Login, choice);
                    isExit = true;
                    break;
                case 1:
                    _logger.LogInformation("User {Login} selected menu option {Choice}", user.Login, choice);
                    QuizMenu(user);
                    break;
                case 2:
                    _logger.LogInformation("User {Login} selected menu option {Choice}", user.Login, choice);
                    user.ShowResults();
                    break;
                case 3:
                    _logger.LogInformation("User {Login} selected menu option {Choice}", user.Login, choice);
                    ResultsMenu(user);
                    break;
                case 4:
                    _logger.LogInformation("User {Login} selected menu option {Choice}", user.Login, choice);
                    SettingsMenu(user);
                    break;

                default:
                    Console.WriteLine("Неправильний пункт меню!");
                    break;
            }
        }
    }

    private void QuizMenu(User user)
    {
        bool turnBack = false;

        while (!turnBack)
        {

            Console.WriteLine("0 Повернутись назад");
            Console.WriteLine("1 Вікторина з історії");
            Console.WriteLine("2 Вікторина з географії");
            Console.WriteLine("3 Вікторина з біології");
            Console.WriteLine("4 Міксована вікторина ");
            Console.Write("Введіть число: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (choice)
            {
                case 0:
                    turnBack = true;
                    break;

                case 1:
                    {
                        _logger.LogInformation("User {Login} started quiz {QuizName}", user.Login, "History");
                        Quiz myQuiz = new Quiz().DeserializeQuiz("historyTest.json");
                        int res = myQuiz.ShowQuiz();
                        _logger.LogInformation("Quiz finished. Result: {Result}/20", res);
                        Console.WriteLine($"Ваш результат: {res}/20 ");
                        Result result = new Result("History", res, DateTime.Now);
                        _userManager.AddResult(user, result);
                        _userManager.UserPlace(user, "History");

                    }
                    break;

                case 2:
                    {
                        _logger.LogInformation("User {Login} started quiz {QuizName}", user.Login, "Geography");

                        Quiz myQuiz = new Quiz().DeserializeQuiz("geographyTest.json");
                        int res = myQuiz.ShowQuiz();
                        _logger.LogInformation("Quiz finished. Result: {Result}/20", res);
                        Console.WriteLine($"Ваш результат: {res}/20 ");
                        Result result = new Result("Geography", res, DateTime.Now);
                        _userManager.AddResult(user, result);
                        _userManager.UserPlace(user, "Geography");

                    }
                    break;

                case 3:
                    {
                        _logger.LogInformation("User {Login} started quiz {QuizName}", user.Login, "Biology");

                        Quiz myQuiz = new Quiz().DeserializeQuiz("biologyTest.json");
                        int res = myQuiz.ShowQuiz();
                        _logger.LogInformation("Quiz finished. Result: {Result}/20", res);
                        Console.WriteLine($"Ваш результат: {res}/20 ");
                        Result result = new Result("Biology", res, DateTime.Now);
                        _userManager.AddResult(user, result);
                        _userManager.UserPlace(user, "Biology");
                    }
                    break;

                case 4:
                    {
                        _logger.LogInformation("User {Login} started quiz {QuizName}", user.Login, "Mixed");

                        Quiz myQuiz = new Quiz().CreateMixedQuiz();
                        int res = myQuiz.ShowQuiz(true);
                        _logger.LogInformation("Quiz finished. Result: {Result}/20", res);
                        Console.WriteLine($"Ваш результат: {res}/20 ");
                        Result result = new Result("Mixed", res, DateTime.Now);
                        _userManager.AddResult(user, result);
                        _userManager.UserPlace(user, "Mixed");

                    }
                    break;

                default:
                    Console.WriteLine("Неправильний пункт меню!");
                    break;
            }
        }
    }

    private void ResultsMenu(User user)
    {
        bool turnBack = false;

        while (!turnBack)
        {

            Console.WriteLine("0 Повернутись назад");
            Console.WriteLine("1 З історичної вікторини");
            Console.WriteLine("2 З географічної вікторини");
            Console.WriteLine("3 З біологічної вікторини");
            Console.WriteLine("4 З міксованої вікторини");
            Console.Write("Введіть число: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (choice)
            {
                case 0:
                    turnBack = true;
                    break;

                case 1:
                    _userManager.SortUsersByResult("History");
                    break;

                case 2:
                    _userManager.SortUsersByResult("Geography");
                    break;

                case 3:
                    _userManager.SortUsersByResult("Biology");
                    break;

                case 4:
                    _userManager.SortUsersByResult("Mixed");
                    break;

                default:
                    Console.WriteLine("Неправильний пункт меню!");
                    break;
            }
        }
    }
    private void SettingsMenu(User user)
    {
        bool turnBack = false;

        while (!turnBack)
        {
            Console.WriteLine("0 Повернутись назад");
            Console.WriteLine("1 Змінити пароль");
            Console.WriteLine("2 Змінити дату народження");
            Console.Write("Введіть число: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (choice)
            {
                case 0:
                    turnBack = true;
                    break;

                case 1:
                    user.ChangePassword();
                    _userManager.SerializeUsers();
                    break;

                case 2:
                    user.ChangeBirthday();
                    _userManager.SerializeUsers();
                    break;

                default:
                    Console.WriteLine("Неправильний пункт меню!");
                    break;
            }
        }
    }
    private void RegisterMenu()
    {
        string login;

        while (true)
        {
            Console.Write("Введіть логін: ");
            login = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(login))
                break;

            Console.WriteLine("Invalid login format!");
        }

        if (_userManager.IsLoginExists(login))
        {
            Console.WriteLine("Такий логін уже існує!");
            return;
        }

        string password;

        while (true)
        {
            Console.Write("Введіть пароль: ");
            password = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(password))
                break;

            Console.WriteLine("Invalid password format!");
        }


        Console.Write("Введіть дату народження: ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
        {
            Console.WriteLine("Invalid date format!");
            return;
        }

        Console.WriteLine(_userManager.Register(login, password, birthday) ? "Реєстрація пройшла успішно!" : "Реєстрація не пройшла!");
    }
}
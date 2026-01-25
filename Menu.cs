using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject;

internal class Menu
{
    private readonly UserManager _userManager;

    public Menu(UserManager userManager)
    {
        _userManager = userManager;
    }

    public void Run()
    {
        bool isExit = false;

        while (!isExit)
        {
            ShowMainMenu();

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
                    Console.WriteLine("Wrong menu option!");
                    break;
            }
        }
    }

    private void ShowMainMenu()
    {
        Console.WriteLine("0 Exit");
        Console.WriteLine("1 Login");
        Console.WriteLine("2 Registration");
        Console.Write("Enter number: ");
    }
    private void LoginMenu()
    {
        Console.Write("Enter login: ");
        string? login = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(login))
        {
            Console.WriteLine("Invalid login!");
            return;
        }

        Console.Write("Enter password: ");
        string? password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Invalid password!");
            return;
        }


        User user = _userManager.Login(login, password);

        if (user == null)
        {
            Console.WriteLine("Login failed!");
            return;
        }

        UserMenu(user);
    }

    private void UserMenu(User user)
    {
        bool isExit = false;

        while (!isExit)
        {
            Console.WriteLine("0 Exit");
            Console.WriteLine("1 Start a new quiz");
            Console.WriteLine("2 View your results");
            Console.WriteLine("3 View Top 20");
            Console.WriteLine("4 Change settings");
            Console.Write("Enter number: ");

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
                    QuizMenu(user);
                    break;
                case 2:
                    {
                        var developerGroups = from result in user.Results
                                              group result by result.QuizName;

                        foreach (var g in developerGroups)
                        {
                            Console.WriteLine(g.Key);
                            foreach (var t in g)
                                Console.WriteLine($"\t{t.CorrectAnswers}/20, {t.Date}");
                            Console.WriteLine();
                        }
                        Console.WriteLine('\n');
                    }
                    break;
                case 3:
                    ResultsMenu(user);
                    break;
                case 4:
                    SettingsMenu(user);
                    break;

                default:
                    Console.WriteLine("Option not implemented yet.");
                    break;
            }
        }
    }

    private void QuizMenu(User user)
    {
        bool turnBack = false;

        while (!turnBack)
        {
            
            Console.WriteLine("0 Turn back");
            Console.WriteLine("1 History quiz");
            Console.WriteLine("2 Geography quiz");
            Console.WriteLine("3 Biology quiz");
            Console.WriteLine("4 Mixed quiz");
            Console.Write("Enter number: ");

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
                        Quiz myQuiz = Quiz.DeserializeQuiz("historyTest.json");
                        int res = myQuiz.ShowQuiz();
                        Console.WriteLine($"Your result: {res}/20 ");
                        Result result = new Result("History", res, 0, DateTime.Now);
                        user.Results.Add(result);

                    }
                    break;

                case 2:
                    {
                       
                        
                    }
                    break;

                case 3:
                    {


                    }
                    break;

                case 4:
                    {


                    }
                    break;

                default:
                    Console.WriteLine("Wrong menu option!");
                    break;
            }
        }
    }

    //private void MyResultsMenu(User user)
    //{
    //    bool turnBack = false;

    //    while (!turnBack)
    //    {

    //        Console.WriteLine("0 Turn back");
    //        Console.WriteLine("1 From history quiz");
    //        Console.WriteLine("2 From geography quiz");
    //        Console.WriteLine("3 From biology quiz");
    //        Console.WriteLine("4 From mixed quiz");
    //        Console.Write("Enter number: ");

    //        if (!int.TryParse(Console.ReadLine(), out int choice))
    //        {
    //            Console.WriteLine("Invalid input!");
    //            continue;
    //        }

    //        switch (choice)
    //        {
    //            case 0:
    //                turnBack = true;
    //                break;

    //            case 1:
    //                {
    //                    //Quiz myQuiz = Quiz.DeserializeQuiz("historyTest.json");
    //                    //int res = myQuiz.ShowQuiz();
    //                    //Console.WriteLine($"Your result: {res}/20 ");
    //                    //Result result = new Result("History", res, 0);
    //                    //user.Results.Add(result);

    //                }
    //                break;

    //            case 2:
    //                {


    //                }
    //                break;

    //            case 3:
    //                {


    //                }
    //                break;

    //            case 4:
    //                {


    //                }
    //                break;

    //            default:
    //                Console.WriteLine("Wrong menu option!");
    //                break;
    //        }
    //    }
    //}
    private void ResultsMenu(User user)
    {
        bool turnBack = false;

        while (!turnBack)
        {

            Console.WriteLine("0 Turn back");
            Console.WriteLine("1 From history quiz");
            Console.WriteLine("2 From geography quiz");
            Console.WriteLine("3 From biology quiz");
            Console.WriteLine("4 From mixed quiz");
            Console.Write("Enter number: ");

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
                        //Quiz myQuiz = Quiz.DeserializeQuiz("historyTest.json");
                        //int res = myQuiz.ShowQuiz();
                        //Console.WriteLine($"Your result: {res}/20 ");
                        //Result result = new Result("History", res, 0);
                        //user.Results.Add(result);

                    }
                    break;

                case 2:
                    {


                    }
                    break;

                case 3:
                    {


                    }
                    break;

                case 4:
                    {


                    }
                    break;

                default:
                    Console.WriteLine("Wrong menu option!");
                    break;
            }
        }
    }
    private void SettingsMenu(User user)
    {
        bool turnBack = false;

        while (!turnBack)
        {
            Console.WriteLine("0 Turn back");
            Console.WriteLine("1 Change password");
            Console.WriteLine("2 Change birthday");
            Console.Write("Enter number: ");

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
                        Console.WriteLine($"Current password: {user.Password}");
                        Console.Write("Enter new password: ");
                        user.Password = Console.ReadLine();
                        Console.WriteLine("Password updated!");
                        _userManager.SerializeUsers();
                    }
                    break;

                case 2:
                    {
                        Console.WriteLine($"Current birthday: {user.Birthday}");

                        while (true)
                        {
                            Console.Write("Enter new birthday: ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                            {
                                user.Birthday = date;
                                Console.WriteLine("Birthday updated!");
                                _userManager.SerializeUsers();
                                return;
                            }

                            Console.WriteLine("Invalid date format!");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Wrong menu option!");
                    break;
            }
        }
    }
    private void RegisterMenu()
    {
        string login;

        while (true)
        {
            Console.Write("Enter login: ");
            login = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(login))
                break;

            Console.WriteLine("Invalid login format!");
        }

        if (_userManager.IsLoginExists(login))
        {
            Console.WriteLine("This login already exists!");
            return;
        }

        string password;

        while (true)
        {
            Console.Write("Enter password: ");
            password = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(password))
                break;

            Console.WriteLine("Invalid password format!");
        }


        Console.Write("Enter birthday: ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
        {
            Console.WriteLine("Invalid date format!");
            return;
        }

        Console.WriteLine(_userManager.Register(login, password, birthday)? "Registration successful!": "Registration failed!");
    }
}

namespace ExamProject;

internal class Program
{
    static void Main(string[] args)
    {
        bool isExit = false;
        int pmenu;
        UserManager userManager = new UserManager();

        while (!isExit)
        {
            Console.WriteLine("0 Exit");
            Console.WriteLine("1 Login");
            Console.WriteLine("2 Registration");


            Console.Write("Enter number: ");
            if (!int.TryParse(Console.ReadLine(), out pmenu))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (pmenu)
            {
                case 0:
                    isExit = true;
                    break;

                case 1:
                    {
                        Console.Write("Enter login: ");
                        string login = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();

                        User user = userManager.Login(login, password);
                    }
                    break;

                case 2:
                    {
                        Console.Write("Enter login: ");
                        string login = Console.ReadLine();

                        if (userManager.IsLoginExists(login))
                        {
                            Console.WriteLine("This login already exists!");
                            break;
                        }

                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();

                        Console.Write("Enter birthday (yyyy-MM-dd): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
                        {
                            Console.WriteLine("Invalid date format!");
                            break;
                        }

                        bool success = userManager.Register(login, password, birthday);

                        if (success)
                            Console.WriteLine("Registration successful!");
                        else
                            Console.WriteLine("Registration failed!");
                    }
                    break;

                default:
                    Console.WriteLine("Wrong menu option!");
                    break;
            }
        }
    }
}

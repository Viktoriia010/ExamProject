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
                        if (user == null)
                        {
                            break;
                        }

                        int newMenu;

                        bool ifExit = false;
                        while (!ifExit)
                        {
                            Console.WriteLine("0 Exit");
                            Console.WriteLine("1 Start a new quiz");
                            Console.WriteLine("2 View your results");
                            Console.WriteLine("3 View Top 20");
                            Console.WriteLine("4 Change settings");


                            Console.Write("Enter number: ");
                            if (!int.TryParse(Console.ReadLine(), out newMenu))
                            {
                                Console.WriteLine("Invalid input! Please enter a number.");
                                continue;
                            }

                            switch (newMenu)
                            {
                                case 0:
                                    ifExit = true;
                                    break;

                                case 1:
                                    {



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
                                        bool turnBack = false;
                                        int changeMenu;
                                     

                                        while (!turnBack)
                                        {
                                            Console.WriteLine("0 Turn back");
                                            Console.WriteLine("1 Change password");
                                            Console.WriteLine("2 Change birthday");


                                            Console.Write("Enter number: ");
                                            if (!int.TryParse(Console.ReadLine(), out changeMenu))
                                            {
                                                Console.WriteLine("Invalid input! Please enter a number.");
                                                continue;
                                            }

                                            switch (changeMenu)
                                            {
                                                case 0:
                                                    turnBack = true;
                                                    break;

                                                case 1:
                                                    {
                                                        Console.WriteLine($"Current password: {user.Password}");
                                                        Console.Write("Enter new password: ");
                                                        user.Password = Console.ReadLine();
                                                        
                                                        Console.WriteLine($"Now your password: {user.Password}");

                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        Console.WriteLine($"Current birthday: {user.Birthday}");
                                                        DateTime date;
                                                        bool valid = false;
                                                        while (!valid)
                                                        {
                                                            Console.Write("Enter new birthday: ");
                                                            string temp = Console.ReadLine();
                                                            if(DateTime.TryParse(temp, out date))
                                                            {
                                                                valid = true;
                                                                user.Birthday = date;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid date format, try again");
                                                            }
                                                        }
                                                        Console.WriteLine($"Now your birthday: {user.Birthday}");

                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("Wrong menu option!");
                                                    break;
                                            }
                                        } break;
                                    }
                            }
                        }
                        break;
                    }
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


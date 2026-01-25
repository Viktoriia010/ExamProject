using Serilog;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
namespace ExamProject;


internal class Program
{
    //"historyTest.json"
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSerilog();
        });

        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogInformation("Лог пишется в файл и консоль");

        UserManager userManager = new UserManager();
        Menu menu = new Menu(userManager);
        menu.Run();

        Quiz q = new Quiz
        {
            Text = "History test",
            Questions = new List<Question>
            {
                new Question {
                Name = "1. Хто був першим президентом США?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Авраам Лінкольн",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Томас Джефферсон",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) Джордж Вашингтон",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Джон Адамс",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "2. У якому році розпочалася Друга світова війна?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) 1914",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) 1939",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "C) 1941",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "D) 1945",
                    IsCorrect = false
                }
                }
                },
                 new Question {
                Name = "3. Яка держава побудувала піраміди?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Греція",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Рим",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) Єгипет",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Китай",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "4. Хто відкрив Америку в 1492 році?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Васко да Гама",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Христофор Колумб",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "C) Фернан Магеллан",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "D) Марко Поло",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "5. Яке місто було столицею Римської імперії?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Афіни",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Константинополь",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) Рим",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Александрія",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "6. Хто був першим князем Київської Русі?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Володимир Великий",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Ярослав Мудрий",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) Олег",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Ігор",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "7. Яка країна почала Першу світову війну?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Франція",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Німеччина",
                    IsCorrect = true 
                },
                new Answer
                {
                    Text = "C) США",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "D) Італія",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "8. Хто був автором “Кобзаря”?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Іван Франко",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Леся Українка",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) Тарас Шевченко",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Михайло Коцюбинський",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "9. У якому столітті відбулося хрещення Русі?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) IX",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) X",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "C) XI",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "D) XII",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "10. Який фараон був похований у Долині царів і став відомий завдяки знайденій гробниці?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Рамзес II",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Тутанхамон",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "C) Хеопс",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "D) Ехнатон",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "11. Яка подія відбулася у 1945 році?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Початок Другої світової війни",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Закінчення Другої світової війни",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "C) Початок Холодної війни",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "D) Розпад СРСР",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "12. Хто був першим імператором Риму?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Юлій Цезар",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Нерон",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) Октавіан Август",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Калігула",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "13. Яка країна подарувала США Статую Свободи?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Велика Британія",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Франція",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "C) Іспанія",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "D) Італія",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "14. У якому місті почалася Французька революція?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Марсель",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Ліон",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) Париж",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Бордо",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "15. Хто очолював німецьку державу під час Другої світової війни?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Вінстон Черчилль",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Беніто Муссоліні",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) Адольф Гітлер",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Франклін Рузвельт",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "16. Яка держава першою запустила людину в космос?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) США",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Китай",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) СРСР",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Японія",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "17. Хто був першим космонавтом?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Ніл Армстронг",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Юрій Гагарін",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "C) Валентина Терешкова",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "D) Алан Шепард",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "18. У якому році Україна проголосила незалежність?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) 1989",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) 1990",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) 1991",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) 1992",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "19. Яка держава існувала раніше: Київська Русь чи Римська імперія?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Київська Русь",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Римська імперія",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "C) Вони виникли одночасно",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "D) Важко сказати",
                    IsCorrect = false
                }
                }
                },
                new Question {
                Name = "20. Який континент вважається колискою людства?",
                Answers = new List<Answer>{
                new Answer
                {
                    Text = "A) Європа",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "B) Азія",
                    IsCorrect = false
                },
                new Answer
                {
                    Text = "C) Африка",
                    IsCorrect = true
                },
                new Answer
                {
                    Text = "D) Австралія",
                    IsCorrect = false
                }
                }
                }
            }
        };

        //string json = JsonConvert.SerializeObject(q);
        //File.WriteAllText("historyTest.json", json);

        //string data = File.ReadAllText("historyTest.json");
        //Quiz? personFromJson = JsonConvert.DeserializeObject<Quiz>(data);
        //Console.WriteLine(personFromJson);

        //bool isExit = false;
        //int pmenu;
        //UserManager userManager = new UserManager();

        //while (!isExit)
        //{
        //    Console.WriteLine("0 Exit");
        //    Console.WriteLine("1 Login");
        //    Console.WriteLine("2 Registration");


        //    Console.Write("Enter number: ");
        //    if (!int.TryParse(Console.ReadLine(), out pmenu))
        //    {
        //        Console.WriteLine("Invalid input! Please enter a number.");
        //        continue;
        //    }

        //    switch (pmenu)
        //    {
        //        case 0:
        //            isExit = true;
        //            break;

        //        case 1:
        //            {
        //                Console.Write("Enter login: ");
        //                string login = Console.ReadLine();

        //                Console.Write("Enter password: ");
        //                string password = Console.ReadLine();

        //                User user = userManager.Login(login, password);
        //                if (user == null)
        //                {
        //                    break;
        //                }

        //                int newMenu;

        //                bool ifExit = false;
        //                while (!ifExit)
        //                {
        //                    Console.WriteLine("0 Exit");
        //                    Console.WriteLine("1 Start a new quiz");
        //                    Console.WriteLine("2 View your results");
        //                    Console.WriteLine("3 View Top 20");
        //                    Console.WriteLine("4 Change settings");


        //                    Console.Write("Enter number: ");
        //                    if (!int.TryParse(Console.ReadLine(), out newMenu))
        //                    {
        //                        Console.WriteLine("Invalid input! Please enter a number.");
        //                        continue;
        //                    }

        //                    switch (newMenu)
        //                    {
        //                        case 0:
        //                            ifExit = true;
        //                            break;

        //                        case 1:
        //                            {



        //                            }
        //                            break;

        //                        case 2:
        //                            {

        //                            }
        //                            break;
        //                        case 3:
        //                            {

        //                            }
        //                            break;
        //                        case 4:
        //                            {
        //                                bool turnBack = false;
        //                                int changeMenu;


        //                                while (!turnBack)
        //                                {
        //                                    Console.WriteLine("0 Turn back");
        //                                    Console.WriteLine("1 Change password");
        //                                    Console.WriteLine("2 Change birthday");


        //                                    Console.Write("Enter number: ");
        //                                    if (!int.TryParse(Console.ReadLine(), out changeMenu))
        //                                    {
        //                                        Console.WriteLine("Invalid input! Please enter a number.");
        //                                        continue;
        //                                    }

        //                                    switch (changeMenu)
        //                                    {
        //                                        case 0:
        //                                            turnBack = true;
        //                                            break;

        //                                        case 1:
        //                                            {
        //                                                Console.WriteLine($"Current password: {user.Password}");
        //                                                Console.Write("Enter new password: ");
        //                                                user.Password = Console.ReadLine();

        //                                                Console.WriteLine($"Now your password: {user.Password}");

        //                                            }
        //                                            break;
        //                                        case 2:
        //                                            {
        //                                                Console.WriteLine($"Current birthday: {user.Birthday}");
        //                                                DateTime date;
        //                                                bool valid = false;
        //                                                while (!valid)
        //                                                {
        //                                                    Console.Write("Enter new birthday: ");
        //                                                    string temp = Console.ReadLine();
        //                                                    if(DateTime.TryParse(temp, out date))
        //                                                    {
        //                                                        valid = true;
        //                                                        user.Birthday = date;
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        Console.WriteLine("Invalid date format, try again");
        //                                                    }
        //                                                }
        //                                                Console.WriteLine($"Now your birthday: {user.Birthday}");

        //                                            }
        //                                            break;
        //                                        default:
        //                                            Console.WriteLine("Wrong menu option!");
        //                                            break;
        //                                    }
        //                                } break;
        //                            }
        //                    }
        //                }
        //                break;
        //            }
        //            case 2:
        //                    {
        //                        Console.Write("Enter login: ");
        //                        string login = Console.ReadLine();



        //                        if (userManager.IsLoginExists(login))
        //                        {
        //                            Console.WriteLine("This login already exists!");
        //                            break;
        //                        }

        //                        Console.Write("Enter password: ");
        //                        string password = Console.ReadLine();

        //                        Console.Write("Enter birthday (yyyy-MM-dd): ");
        //                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
        //                        {
        //                            Console.WriteLine("Invalid date format!");
        //                            break;
        //                        }

        //                        bool success = userManager.Register(login, password, birthday);

        //                        if (success)
        //                            Console.WriteLine("Registration successful!");
        //                        else
        //                            Console.WriteLine("Registration failed!");
        //                    }
        //                    break;

        //                default:
        //                    Console.WriteLine("Wrong menu option!");
        //                    break;

        //                }
        //            }
    }
}


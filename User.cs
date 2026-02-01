using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject;

internal class User: Person
{
    
    public List<Result> Results { get; set; }


    public User(string login, string password, DateTime birthday) : base(login, password, birthday)
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
        // групуємо результати по вікторинах, нові результати будуть перші
        var groups = from result in Results
                     orderby result.Date descending
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

   
}

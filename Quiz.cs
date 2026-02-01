using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ExamProject;

internal class Quiz
{
    public string Text { get; set; }
    public List<Question> Questions {get; set; }

    public Quiz(string text)
    {
        Text = text;
        Questions = new List<Question>();
    }

    public Quiz()
    {
        Questions = new List<Question>();
    }

    public override string ToString()
    {
        string result = Text + "\n\n";

        if (Questions == null || Questions.Count == 0)
            return result + "Питань немає.\n";

        foreach (var question in Questions)
        {
            result += question + "\n";
        }

        return result;
    }

    public Quiz DeserializeQuiz(string path)
    {
        string data = File.ReadAllText(path);
        Quiz? questionFromJson = JsonConvert.DeserializeObject<Quiz>(data);
        return questionFromJson;
    }

    public int ShowQuiz(bool numberQuestions = false)
    {
        int res = 0;
        foreach (var question in Questions)
        {
            if (numberQuestions) 
            {
                string cleanQuestion =  question.ToString().Substring(3); // вирізаємо перші три символи (цифри і крапки), щоб не було нумерації питань
                Console.WriteLine(cleanQuestion);
            }
            else
            {
                Console.WriteLine(question);   
            }
            Console.Write("Введіть свою відповідь (розділивши її комами): ");
            string? ans = Console.ReadLine();

            var userAnswers = ans.Split(',', StringSplitOptions.RemoveEmptyEntries)  // створюємо список відповідей користувача, розділяючи елементи через кому, "пусті" елементи прибераємо
                .Select(a => a.Trim()) // прибераємо пробіли біля елементів
                .ToList();

            var correctAnswers = question.Answers.Where(a => a.IsCorrect) 
                .Select(a => a.Text.Trim()[0].ToString())
                .ToList();

            bool isCorrect = correctAnswers.All(c => userAnswers.Contains(c, StringComparer.OrdinalIgnoreCase)) &&
                userAnswers.All(a => correctAnswers.Contains(a, StringComparer.OrdinalIgnoreCase));

            if (isCorrect)
            {
                res++;
            }
        }
        
        return res;
    }

    public Quiz CreateMixedQuiz()
    {
        Quiz mixedQuiz = new Quiz("Mixed Quiz");

        Quiz historyQuiz = new Quiz().DeserializeQuiz("historyTest.json");
        Quiz geographyQuiz = new Quiz().DeserializeQuiz("geographyTest.json");
        Quiz biologyQuiz = new Quiz().DeserializeQuiz("biologyTest.json");

        // Додаємо всі питання у одну колекцію
        mixedQuiz.Questions.AddRange(historyQuiz.Questions);
        mixedQuiz.Questions.AddRange(geographyQuiz.Questions);
        mixedQuiz.Questions.AddRange(biologyQuiz.Questions);

        Random rnd = new Random();
        mixedQuiz.Questions = mixedQuiz.Questions.OrderBy(q => rnd.Next()).Take(20).ToList();

        return mixedQuiz;
    }

}

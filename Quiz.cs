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

    public static Quiz DeserializeQuiz(string path)
    {
        string data = File.ReadAllText(path);
        Quiz? questionFromJson = JsonConvert.DeserializeObject<Quiz>(data);
        return questionFromJson;
    }

    public int ShowQuiz()
    {
        int res = 0;
        foreach (var question in Questions)
        {
            Console.WriteLine(question);
            Console.Write("Enter your answer (comma separated): ");
            string? ans = Console.ReadLine();

            var userAnswers = ans.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
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
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject;

internal class Result
{
    public string QuizName { get; set; }      
    public int CorrectAnswers { get; set; }
    public DateTime Date { get; set; }

    public Result() { }

    public Result(string quizName, int correctAnswers, DateTime date) 
    {
        QuizName = quizName;
        CorrectAnswers = correctAnswers;
        Date = date;

    }
}

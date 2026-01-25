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
    public int Place { get; set; }
    public DateTime Date { get; set; }

    public Result(string quizName, int correctAnswers, int place, DateTime date) 
    {
        QuizName = quizName;
        CorrectAnswers = correctAnswers;
        Place = place;
        Date = date;

    }
}

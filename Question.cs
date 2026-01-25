using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExamProject;

internal class Question
{
    public string Name { get; set; }

    public List<Answer> Answers {  get; set; }

    public Question(string name)
    {
        Name = name;
    }

    public Question()
    {
    }

    public override string ToString()
    {
        string result = Name + "\n\n";

        if (Answers == null || Answers.Count == 0)
            return result + "Питань немає.\n";

        foreach (var question in Answers)
        {
            result += question;
        }

        return result;
    }
}

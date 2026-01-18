using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject;

internal class Quiz
{
    public string Text { get; set; }
    List<Question> questions = new List<Question>();
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject;

internal class Question
{
    public string Name { get; set; }

    List<Answer> answers = new List<Answer>();
}

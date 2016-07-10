using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Le_Banc
{
    public class Question
    {
        public int Id { get; set; }
        public int AmountOfAnswers { get; set; }
        public int AmountOfRightAnswers { get; set; }
        public string TheQuestion { get; set; }
        public string Group { get; set; }
        public string RightAnswer { get; set; }

        public List<Answer> ListAnswer { get; set; }
        public List<RightAnswer> ListRightAnswer { get; set; }

    }
}
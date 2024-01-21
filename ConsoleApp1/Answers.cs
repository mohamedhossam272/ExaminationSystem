using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Answers
    {
        int AnswerId;
        double Mark;
        string Question;
        string AnswerText;
        string AnswerChoices_a;
        string AnswerChoices_b;
        string AnswerChoices_c;


        public Answers()
        { }
        public Answers(int _answerid,int _mark,string _question, string _answertext, string _answerChoices_a, string _answerChoices_b, string _answerChoices_c)
        {
            AnswerId = _answerid;
            Question = _question;
            Mark = _mark;
            AnswerText = _answertext;
            AnswerChoices_a = _answerChoices_a;
            AnswerChoices_b = _answerChoices_b;
            AnswerChoices_c = _answerChoices_c;
        }

        public int AnswerID
        {
            get { return AnswerId; }
            set { AnswerId = value; }
        }

        public double MARK
        {
            get { return Mark; }
            set { Mark = value; }
        }

        public string QUESTION
        {
            get { return Question; }
            set { Question = value; }
        }

        public string AnswerTEXT
        {
            get { return AnswerText; }
            set { AnswerText = value; }
        }

        public string AnswerCHOICES_a
        {
            get { return AnswerChoices_a; }
            set { AnswerChoices_a = value; }
        }

        public string AnswerCHOICES_b
        {
            get { return AnswerChoices_b; }
            set { AnswerChoices_b = value; }
        }

        public string AnswerCHOICES_c
        {
            get { return AnswerChoices_c; }
            set { AnswerChoices_c= value; }
        }



        public override string ToString()
        {
            return $"{AnswerId} : {Question} : {AnswerText} : ({AnswerChoices_a} - {AnswerChoices_b} - {AnswerChoices_c})";
        }
    }
}

using System;
using System.Drawing;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //QuestionBase[] AnsArr = QuestionBase.GetAnswersArr(1);
            //QuestionBase.InsertAnswers(AnsArr);
            //Console.Clear();
            //QuestionBase.Print(AnsArr);

            Exam exam = new Exam();
            Subject Sub1 = new Subject();
            Sub1.CreateExam();


        }
    }
}

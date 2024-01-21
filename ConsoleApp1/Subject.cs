using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum ExamType
    {
        Practical=1,
        Final =2
    }
    enum QuestionType
    {
        TrueORFalse=1,
        MCQ =2

    }
    internal class Subject : QuestionBase
    {

        public void CreateExam()
        {

            FinalExam finalexam = new FinalExam();
            PracticeExam practiceexam = new PracticeExam();
            bool flag;
            int examType;

            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create( 1 for Practical and 2 for Final): ");
                flag = int.TryParse(Console.ReadLine(), out examType);
            } while (!(flag && Enum.IsDefined(typeof(ExamType), examType)));
            if (examType == 1)
            {
                practiceexam.TypeOfQuestions();
            }
            else if (examType == 2)
            {
                finalexam.TypeOfQuestions();
            }


            //int examTime;
            //do
            //{
            //    Console.Write("Please Enter The Time Of Exam in Minutes: ");
            //    flag = int.TryParse(Console.ReadLine(), out examTime);
            //} while (!flag);


            //Console.Clear();






        }
    }
}

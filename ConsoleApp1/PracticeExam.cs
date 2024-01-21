using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum PraciceExamQuestionType
    {
        MCQ = 1
    }
    internal class PracticeExam : QuestionBase
    {
        MultipleChoices multiplechoices = new MultipleChoices();



        public void TypeOfQuestions()
        {
            bool flag;

            int NoQuestions;

            do
            {
                Console.Write("Please Enter The Number of Questions You Wanted To Create In the Practical Exam: ");
                flag = int.TryParse(Console.ReadLine(), out NoQuestions);
            } while (!flag);
            QuestionBase[] AnsArr = QuestionBase.GetAnswersArr(NoQuestions);
            MultipleChoices[] MCQAnsArr = MultipleChoices.GetMCQAnswersArr(NoQuestions);

            int praciceexamquestiontype;
            do
            {
                Console.Write("Please Choose The Type Of Questions (1 for MCQ) : ");
                flag = int.TryParse(Console.ReadLine(), out praciceexamquestiontype);
            } while (!(flag && Enum.IsDefined(typeof(PraciceExamQuestionType), praciceexamquestiontype)));
            if (praciceexamquestiontype == 1)
            {
                MultipleChoices.InsertMCQAnswers(MCQAnsArr);
            }
        }
    }
}

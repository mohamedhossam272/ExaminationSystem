using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    enum FinalExamQuestionType
    {
        TrueORFalse = 1,
        MCQ = 2

    }
    public class FinalExam : QuestionBase
    {
        TFQuestion tfquestion= new TFQuestion();
        MultipleChoices multiplechoices = new MultipleChoices();



        public void TypeOfQuestions()
        {
            bool flag;

            int NoQuestions;

            do
            {
                Console.Write("Please Enter The Number of Questions You Wanted To Create In the Final Exam: ");
                flag = int.TryParse(Console.ReadLine(), out NoQuestions);
            } while (!flag);
            QuestionBase[] AnsArr = QuestionBase.GetAnswersArr(NoQuestions);
            MultipleChoices[] MCQAnsArr = MultipleChoices.GetMCQAnswersArr(NoQuestions);
            TFQuestion[] TFAnsArr = TFQuestion.GetTFAnswersArr(NoQuestions);

            int finalexamquestiontype;
            do
            {
                Console.Write("Please Choose The Type Of Questions (1 for True OR False || 2 for MCQ) : ");
                flag = int.TryParse(Console.ReadLine(), out finalexamquestiontype);
            } while (!(flag && Enum.IsDefined(typeof(FinalExamQuestionType), finalexamquestiontype)));

            if (finalexamquestiontype == 1)
            {
                TFQuestion.InsertTFAnswers(TFAnsArr);
            }
            else if (finalexamquestiontype == 2)
            {
                MultipleChoices.InsertMCQAnswers(MCQAnsArr);
            }

        }

    }

}

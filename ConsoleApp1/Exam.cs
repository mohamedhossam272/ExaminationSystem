using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum ExamQuestionType
    {
        TrueORFalse = 1,
        MCQ = 1
    }
    public class Exam : QuestionBase
    {
        public void ShowExam()
        {

            bool flag;
            int NoQuestions;
            do
            {
                Console.Write("Please Enter The Number of Questions You Wanted To Create: ");
                flag = int.TryParse(Console.ReadLine(), out NoQuestions);
            } while (!flag);

            MultipleChoices multiplechoices = new MultipleChoices();

            MultipleChoices[] MCQAnsArr = MultipleChoices.GetMCQAnswersArr(NoQuestions);

            //multiplechoices.MCQAnswers();
            //tfquestion.TFAnswers();
            multiplechoices.ToString();

        }

        //public void MCQAnswers()
        //{

        //    MultipleChoices[] MCQAnsArr = MultipleChoices.GetMCQAnswersArr(MultipleChoices.NoOfMCQAnswers());
        //    MultipleChoices.Print(MCQAnsArr);
        //}

        //public void TFAnswers()
        //{

        //    TFQuestion[] TFAnsArr = TFQuestion.GetTFAnswersArr(TFQuestion.NoOfTFAnswers());
        //    TFQuestion.Print(TFAnsArr);

        //}

    }
}

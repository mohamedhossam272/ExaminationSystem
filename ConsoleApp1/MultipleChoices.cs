using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum MCQAnswer 
    {
        a=1,
        b=2,
        c=3

    }
    internal class MultipleChoices : QuestionBase
    {


        public static int NoOfMCQAnswers()
        {
            bool flag;
            int NoQuestions;
            do
            {
                Console.Write("Please Enter The Number of Questions You Wanted To Create: ");
                flag = int.TryParse(Console.ReadLine(), out NoQuestions);
            } while (!flag);

            return NoQuestions;
        }

        public void MCQExam()
        {

            Console.WriteLine("MCQ questions");
            Console.WriteLine("please enter the body of question:");

            Console.Clear();

            MultipleChoices[] MCQAnsArr = MultipleChoices.GetMCQAnswersArr(MultipleChoices.NoOfMCQAnswers());
            QuestionBase.InsertAnswers(MCQAnsArr);

        }
        
        public override string ToString()
        {
            return $"MCQ Question     Mark({answers.MARK}) \n{answers.QUESTION} \n(a) {answers.AnswerCHOICES_a}             (b) {answers.AnswerCHOICES_b}             (c) {answers.AnswerCHOICES_c}\n--------------------------- "/*{ answers.AnswerTEXT}*/;
        }

        public static MultipleChoices[] GetMCQAnswersArr(int size)
        {
            MultipleChoices[] MCQAnsArr = new MultipleChoices[size];

            for (int i = 0; i < MCQAnsArr.Length; i++)
            {

                MCQAnsArr[i] = new MultipleChoices();
            }

            return MCQAnsArr;
        }

        public static Answers[] InsertMCQAnswers(MultipleChoices[] MCQAnsArr)
        {
            Answers[] FinalMCQAnsArr = new Answers[MCQAnsArr.Length];
            for (int i = 0; i < MCQAnsArr.Length; i++)
            {
                Console.WriteLine("================================");
                Console.WriteLine($"Question number {i + 1}");
                Console.WriteLine("================================");

                bool flag;

                string Question;

                do
                {
                    Console.Write("Enter header of MCQ Question : ");
                    Question = Console.ReadLine();
                } while (!Regex.IsMatch(Question, @"^[a-zA-Z]"));
                MCQAnsArr[i].answers.QUESTION = Question;

                do
                {

                    Console.Write("Body : ");
                    MCQAnsArr[i].body = Console.ReadLine();

                } while (!Regex.IsMatch(MCQAnsArr[i].body, @"^[a-zA-Z]"));

                double Mark;
                do
                {
                    Console.Write("Mark : ");

                    flag = double.TryParse(Console.ReadLine(), out Mark);
                } while (!flag);
                MCQAnsArr[i].answers.MARK = Mark;


                //Console.WriteLine("answers ");

                int AnswerId;
                string AnswerText;
                do
                {
                    Console.Write("AnswerId : ");
                    flag = int.TryParse(Console.ReadLine(), out AnswerId);
                } while (!flag);
                MCQAnsArr[i].answers.AnswerID = AnswerId;

                Console.WriteLine("The Choices Of Question: ");

                for (int k = 1; k <= 3; k++)
                {
                    Console.WriteLine($"Please Enter The Choice Number {k}:");
                    if (k== 1)
                    {
                        MCQAnsArr[i].answers.AnswerCHOICES_a = Console.ReadLine();
                    }
                    else if (k == 2)
                    {
                        MCQAnsArr[i].answers.AnswerCHOICES_b = Console.ReadLine();
                    }
                    else if (k == 3)
                    {
                        MCQAnsArr[i].answers.AnswerCHOICES_c = Console.ReadLine();
                    }



                }

                string MCQanswer;

                do
                {
                    Console.Write("Please Specify The Right Choice of Question(a,b,c): ");
                    MCQanswer = Console.ReadLine();
                } while (!(flag && Enum.IsDefined(typeof(MCQAnswer), MCQanswer)));
                MCQAnsArr[i].answers.AnswerTEXT = MCQanswer;

                FinalMCQAnsArr[i] = new Answers();

                FinalMCQAnsArr[i].AnswerID = MCQAnsArr[i].answers.AnswerID;
                FinalMCQAnsArr[i].QUESTION = MCQAnsArr[i].answers.QUESTION;
                FinalMCQAnsArr[i].AnswerTEXT = MCQAnsArr[i].answers.AnswerTEXT;
                FinalMCQAnsArr[i].MARK = MCQAnsArr[i].answers.MARK;

            }

            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam (y | n): ");

            if (char.Parse(Console.ReadLine()) == 'y')
            {
                var sw = Stopwatch.StartNew();
                double Grade = 0;
                double FinalGrade = 0;
                for (int i = 0; i < MCQAnsArr.Length; i++)
                {
                    Console.Write("Please Enter The Time Of Exam in Minutes: ");
                    Console.WriteLine($"Enterd Answers Of The Question Number {i + 1}: ");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine(MCQAnsArr[i]);

                    FinalGrade += FinalMCQAnsArr[i].MARK;
                    if (Console.ReadLine() == FinalMCQAnsArr[i].AnswerTEXT)
                    {
                        Grade += FinalMCQAnsArr[i].MARK;
                    }
                    else/* if (Console.ReadLine() != FinalMCQAnsArr[i].AnswerTEXT)*/
                    {
                        Grade = FinalGrade - FinalMCQAnsArr[i].MARK;
                    }
                    Console.WriteLine("====================================");

                }

                long ticks = sw.ElapsedMilliseconds;

                Console.Clear();
                Console.WriteLine("Your Answers : ");
                for (int i = 0; i < FinalMCQAnsArr.Length; i++)
                {
                    Console.WriteLine($"Q{i+1})   {FinalMCQAnsArr[i].QUESTION} : {FinalMCQAnsArr[i].AnswerTEXT}");
                }
                Console.WriteLine($"\nYour Exam Grade is {Grade} from {FinalGrade}");
                Console.WriteLine($"The Elapsed Time = {(ticks * 0.001) / 60} min");
            }

            return FinalMCQAnsArr;
        }

        public void MCQAnswers()
        {
            MultipleChoices[] TFAnsArr = MultipleChoices.GetMCQAnswersArr(TFQuestion.NoOfTFAnswers());
            MultipleChoices.Print(TFAnsArr);

        }


    }
}

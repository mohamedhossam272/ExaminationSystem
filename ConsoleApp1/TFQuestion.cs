using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum TFAnswer
    {
        T = 'T',
        F = 'F'

    }
    internal class TFQuestion :QuestionBase
    {



        public static int NoOfTFAnswers()
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
        public void TFExam()
        {
            Console.WriteLine("true | false question");
            Console.WriteLine("please enter the body of question:");

            Console.Clear();

            TFQuestion[] TFAnsArr = TFQuestion.GetTFAnswersArr(TFQuestion.NoOfTFAnswers());
            QuestionBase.InsertAnswers(TFAnsArr);


        }

        public override string ToString()
        {
            return $"True | False Question     Mark({answers.MARK}) \n{answers.QUESTION} \n(T) True             (T) False\n---------------------------"/*{ answers.AnswerTEXT}*/;
        }



        public static TFQuestion[] GetTFAnswersArr(int size)
        {
            TFQuestion[] TFAnsArr = new TFQuestion[size];

            for (int i = 0; i < TFAnsArr.Length; i++)
            {

                TFAnsArr[i] = new TFQuestion();
            }

            return TFAnsArr;
        }

        public static Answers[] InsertTFAnswers(TFQuestion[] TFAnsArr)
        {
            Answers[] FinalTFAnsArr = new Answers[TFAnsArr.Length];
            for (int i = 0; i < TFAnsArr.Length; i++)
            {
                Console.WriteLine("================================");
                Console.WriteLine($"Question number {i + 1}");
                Console.WriteLine("================================");

                bool flag;

                string Question;

                do
                {
                    Console.Write("Enter header of TF Question : ");
                    Question = Console.ReadLine();
                } while (!Regex.IsMatch(Question, @"^[a-zA-Z]"));
                TFAnsArr[i].answers.QUESTION = Question;

                do
                {

                    Console.Write("Body : ");
                    TFAnsArr[i].body = Console.ReadLine();

                } while (!Regex.IsMatch(TFAnsArr[i].body, @"^[a-zA-Z]"));


                double Mark;
                do
                {
                    Console.Write("Mark : ");

                    flag = double.TryParse(Console.ReadLine(), out Mark);
                } while (!flag);
                TFAnsArr[i].answers.MARK = Mark;

                //Console.WriteLine("answers ");
                int AnswerId;
                string AnswerText;
                do
                {
                    Console.Write("AnswerId : ");
                    flag = int.TryParse(Console.ReadLine(), out AnswerId);
                } while (!flag);
                TFAnsArr[i].answers.AnswerID = AnswerId;

                string TFanswer;

                do
                {
                    Console.Write("True(T) or False(F) : ");
                    TFanswer = Console.ReadLine();
                } while (!(flag && Enum.IsDefined(typeof(TFAnswer), TFanswer)));
                TFAnsArr[i].answers.AnswerTEXT = TFanswer;


                FinalTFAnsArr[i] = new Answers() ;

                FinalTFAnsArr[i].AnswerID = TFAnsArr[i].answers.AnswerID;
                FinalTFAnsArr[i].QUESTION = TFAnsArr[i].answers.QUESTION;
                FinalTFAnsArr[i].AnswerTEXT = TFAnsArr[i].answers.AnswerTEXT;
                FinalTFAnsArr[i].MARK = TFAnsArr[i].answers.MARK;
                

            }

            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam (y | n): ");

            if (char.Parse(Console.ReadLine()) == 'y')
            {
                var sw = Stopwatch.StartNew();
                double Grade=0;
                double FinalGrade=0;
                for (int i = 0; i < TFAnsArr.Length; i++)
                {
                    Console.Write("Please Enter The Time Of Exam in Minutes: ");
                    Console.WriteLine($"Enterd Answers Of The Question Number {i + 1}: ");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine(TFAnsArr[i]);

                    FinalGrade += FinalTFAnsArr[i].MARK;
                    if (Console.ReadLine() == FinalTFAnsArr[i].AnswerTEXT)
                    {
                        Grade += FinalTFAnsArr[i].MARK;
                    }
                    else/* if(Console.ReadLine() != FinalTFAnsArr[i].AnswerTEXT)*/
                    {
                        Grade = FinalGrade - FinalTFAnsArr[i].MARK;
                    }
                    Console.WriteLine("====================================");

                    

                }

                long ticks = sw.ElapsedMilliseconds;

                Console.Clear();
                Console.WriteLine("Your Answers : ");
                for (int i = 0; i < FinalTFAnsArr.Length; i++)
                {
                    Console.WriteLine($"Q{i+1})   {FinalTFAnsArr[i].QUESTION} : {FinalTFAnsArr[i].AnswerTEXT}");
                }
                Console.WriteLine($"\nYour Exam Grade is {Grade} from {FinalGrade}");
                Console.WriteLine($"The Elapsed Time = {(ticks * 0.001) / 60} min");
            }


            return FinalTFAnsArr;
        }


        public void TFAnswers()
        {
            TFQuestion[] TFAnsArr = TFQuestion.GetTFAnswersArr(TFQuestion.NoOfTFAnswers());
            TFQuestion.Print(TFAnsArr);

        }
    }





}


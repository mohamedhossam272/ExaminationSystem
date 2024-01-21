using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class QuestionBase :Answers
    {
        public string header;
        public string body;
        public double mark;
        public Answers answers;

        public string Header { get => header; set => header = value; }
        public string Body { get => body; set => body = value; }
        public double Mark { get => mark; set => mark = value; }
        public Answers Answers { get => answers; set => answers = value; }

        public QuestionBase()
        {
            Answers = new Answers();
        }

        public override string ToString()
        {
            return $" Header = {header} \n Body = {body} \n Mark = {mark}\n Answers = {answers}";

        }

        public static QuestionBase[] GetAnswersArr(int size)
        {
            QuestionBase[] AnsArr = new QuestionBase[size];

            for (int i = 0; i < AnsArr.Length; i++)
            {

                AnsArr[i] = new QuestionBase();
            }

            return AnsArr;
        }

        public static void InsertAnswers(QuestionBase[] AnsArr)
        {
            for (int i = 0; i < AnsArr.Length; i++)
            {
                Console.WriteLine($"Question number {i + 1}");
                Console.WriteLine("================================");

                bool flag;

                do
                {
                    Console.Write("Enter header of the Question : ");
                    AnsArr[i].header = Console.ReadLine();
                } while (!Regex.IsMatch(AnsArr[i].header, @"^[a-zA-Z]"));

                do
                {

                    Console.Write("Body : ");
                    AnsArr[i].body = Console.ReadLine();

                } while (!Regex.IsMatch(AnsArr[i].body, @"^[a-zA-Z]"));

                do
                {
                    Console.Write("Mark : ");

                    flag = double.TryParse(Console.ReadLine(), out AnsArr[i].mark);
                } while (!flag);


                Console.WriteLine("answers ");
                int AnswerId;
                string AnswerText;
                do
                {
                    Console.Write("AnswerId : ");
                    flag = int.TryParse(Console.ReadLine(), out AnswerId);
                } while (!flag);
                AnsArr[i].answers.AnswerID = AnswerId;


                do
                {
                    Console.Write("AnswerText : ");
                    AnswerText = Console.ReadLine();
                } while (!flag);
                AnsArr[i].answers.AnswerTEXT = AnswerText;

            }
        }

        public static void Print(QuestionBase[] AnsArr)
        {
            for (int i = 0; i < AnsArr.Length; i++)
            {
                Console.WriteLine($"Enterd Answers Of The Question Number {i + 1}: ");
                Console.WriteLine("---------------------------");
                Console.WriteLine(AnsArr[i]);
                Console.WriteLine("====================================");
            }

        }



    }
}

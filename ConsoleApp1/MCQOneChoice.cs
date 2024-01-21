using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MCQOneChoice : Answers
    {
        int MyAnswerId;
        string MyAnswerText;
        Answers answers = new Answers();
        public MCQOneChoice()
        {

        }

        public MCQOneChoice(int _myAnswerId, string _myAnswerText)
        {
            MyAnswerId = _myAnswerId;
            MyAnswerText = _myAnswerText;
        }

        public int MyAnswerID
        {
            get { return MyAnswerId; }
            set { MyAnswerId = value; }
        }


        public string MyAnswerTEXT
        {
            get { return MyAnswerText; }
            set { MyAnswerText = value; }
        }

    }
}

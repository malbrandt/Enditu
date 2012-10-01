using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Reader
{
    public class Engine
    {
        public static DateTime PauseForMilliSeconds(int MilliSecondsToPauseFor)
        {


            System.DateTime ThisMoment = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, MilliSecondsToPauseFor);
            System.DateTime AfterWards = ThisMoment.Add(duration);


            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = System.DateTime.Now;
            }


            return System.DateTime.Now;
        }
        
        public int SleepMsEachLetter = 5;
        public int CharactersPerMinute = 2000;
        public int SleepTimeBasic = 50;


        internal void Read(string text, TextBox viewer)
        {
            if (text == string.Empty || text == null)
                return;

            Console.Write("Znaków: {0}", text.Length);
            string[] toRead = text.Split(' ');
            Console.WriteLine(", w tym słów: {0}", toRead.Length);

            int wordsLeft = 0;
            int sleepTime = 0;
            

            for (int i = 0; i < toRead.Length; ++i)
            {
                SleepMsEachLetter = 60 * 1000 / CharactersPerMinute;
                sleepTime = 0;
                wordsLeft = toRead.Length - i;

                //if (wordsLeft >= 3)
                //{
                //    viewer.Text = toRead[i] + ' ' + toRead[i + 1] + ' ' + toRead[i + 2] + ' ';
                //    sleepTime += (toRead[i].Length + toRead[i + 1].Length + toRead[i + 2].Length) * SleepMsEachLetter + SleepTimeBasic;
                //}
                //else if (wordsLeft >= 2)
                //{
                //    viewer.Text = toRead[i] + ' ' + toRead[i + 1] + ' ';
                //    sleepTime += (toRead[i].Length + toRead[i + 1].Length) * SleepMsEachLetter + SleepTimeBasic;
                //}
                if (wordsLeft >= 1)
                {
                    viewer.Text = toRead[i] + ' ';
                    sleepTime += (toRead[i].Length) * SleepMsEachLetter + SleepTimeBasic;
                }
                else if (wordsLeft == 0)
                    break;
                else break;

                PauseForMilliSeconds(sleepTime);
            }
            
        }
    }
}

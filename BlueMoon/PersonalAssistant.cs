using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class PersonalAssistant
    {
        int left = 37;
        int top = 14;
        int topC;
        string textC;
        int topM;
        string textM;
        int topR;
        string textR;

        public void Start()
        {
            Console.Title = "BlueMoon - Personal Assistant";
            PersonalAssistantUI();
            PersonalAssistantFunction();
        }


        private void PersonalAssistantUI()
        {

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);
            
            Console.SetCursorPosition(left, top);
            Console.WriteLine("PERSONAL ASSISTANT APPLICATION");

            top++;
            Console.SetCursorPosition(37, top);
            Console.WriteLine("==============================");

            top += 3;
            topC = top;
            Console.SetCursorPosition(39, top);
            textC = "(C). Contacts";
            Console.WriteLine(textC);

            top += 2;
            topM = top;
            Console.SetCursorPosition(39, top);
            textM = "(M). Meetings and appointment";
            Console.WriteLine(textM);

            top += 2;
            topR = top;
            Console.SetCursorPosition(39, top);
            textR = "(R). Return to Main Menu ";
            Console.WriteLine(textR);


        }

        private void PersonalAssistantFunction()
        {

            Station.StartTimeThread();

            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);


            if (key.Key == ConsoleKey.C)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topC, textC);
                ContactDetails cd = new ContactDetails();
                cd.Start();
            }


            else if (key.Key == ConsoleKey.M)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topM, textM);
                MeetingAppointment ma = new MeetingAppointment();
                ma.Start();

            }


            else if (key.Key == ConsoleKey.R)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topR, textR);
                MainMenu mm = new MainMenu();
                mm.Start();
            }


            else
            {
                Station.StopTimeThread();
                top += 4;
                Station.BeepError();
                Console.SetCursorPosition(39, top);
                Console.WriteLine("Invalid Key.");
                Thread.Sleep(200);
                top = 14;
                Console.Clear();
                Start();
            }


        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class MeetingAppointment
    {
        int left = 37;
        int top = 14;
        int topA;
        string textA;
        int topE;
        string textE;
        int topV;
        string textV;
        int topS;
        string textS;
        int topD;
        string textD;
        int topR;
        string textR;
        public void Start()
        {

            MeetingAppointmentUI();
            MeetingAppointmentFunction();
            

        }


        private void MeetingAppointmentUI()
        {
            Console.Title = "BlueMoon - Meeting Appointments";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);


            Console.SetCursorPosition(left, top);
            Console.WriteLine("PERSONAL ASSISTANT APPLICATION");

            top++;
            Console.SetCursorPosition(37, top);
            Console.WriteLine("Appointments Details Page.");

            top += 3;
            topA = top;
            Console.SetCursorPosition(39, top);
            textA = "(A). Add Appointments";
            Console.WriteLine(textA);

            top += 2;
            topE = top;
            Console.SetCursorPosition(39, top);
            textE = "(E). Edit Appointments";
            Console.WriteLine(textE);

            top += 2;
            topV = top;
            Console.SetCursorPosition(39, top);
            textV = "(V). View Appointments ";
            Console.WriteLine(textV);

            top += 2;
            topS = top;
            Console.SetCursorPosition(39, top);
            textS = "(S). Search Appointments ";
            Console.WriteLine(textS);

            top += 2;
            topD = top;
            Console.SetCursorPosition(39, top);
            textD = "(D). Delete Appointments ";
            Console.WriteLine(textD);

            top += 2;
            topR = top;
            Console.SetCursorPosition(39, top);
            textR = "(R). Return to Main Page ";
            Console.WriteLine(textR);
        }

        private void MeetingAppointmentFunction()
        {

            Station.StartTimeThread();

            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.A)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topA, textA);
                AddAppointments ap = new AddAppointments();
                ap.Start();
            }
            else if (key.Key == ConsoleKey.E)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topE, textE);
                EditAppointments ea = new EditAppointments();
                ea.Start();
            }
            else if (key.Key == ConsoleKey.V)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topV, textV);
                ViewAppointments va = new ViewAppointments();
                va.Start();
            }
            else if (key.Key == ConsoleKey.S)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topS, textS);
                SearchAppointments sa = new SearchAppointments();
                sa.Start();
            }
            else if (key.Key == ConsoleKey.D)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topD, textD);
                DeleteAppointments da = new DeleteAppointments();
                da.Start();
            }
            else if (key.Key == ConsoleKey.R)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topR, textR);
                PersonalAssistant pa = new PersonalAssistant();
                pa.Start();
            }
            else
            {
                top += 4;
                Station.StopTimeThread();
                Station.BeepError();
                Console.SetCursorPosition(39, top);
                Console.WriteLine("Invalid Key.");
                Thread.Sleep(200);
                Console.Clear();
                top = 14;
                Start();
            }


        }

    }
}

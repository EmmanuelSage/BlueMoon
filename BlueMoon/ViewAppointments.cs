using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueMoon
{
    class ViewAppointments
    {   
        public void Start()
        {

            Console.Title = "BlueMoon - View Appointments";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);


            Console.SetCursorPosition(37, 13);
            Console.WriteLine("==========PERSONAL ASSISTANT APPLICATION==========");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press any Key to View Appointments....");
            Console.ReadKey(true);



            Console.SetCursorPosition(39, 17);
            Console.WriteLine("       ======Appointment Details======");



            string curPath = Directory.GetCurrentDirectory();

            string path = curPath + "\\Schedule.ebase";


            string[] EbRows = File.ReadAllLines(path);

            string[] fieldName = { "Name of appointment", "Year", "Month", "Day", "Hour", "Minute","Location" };

            int topDisplay = 20;
            int leftDisplay = 0;
            int countingLeft = 1;
            //int countingtop = 0;
            int displaySet = 0;

            // Move logged in to upper left 
            Console.MoveBufferArea(0, 38, 40, 2, 1, 2);

            Station.StopTimeThread();

            int initial = EbRows.Length - 1;

            for (int q = initial; q >= 0; q--)
            {
                string[] EbCol = EbRows[q].Split('~');


                countingLeft++;

                if (countingLeft % 2 == 0)
                {
                    leftDisplay = 5;
                }
                else
                {
                    leftDisplay = 62;
                    topDisplay = displaySet;
                }

                displaySet = topDisplay;

                for (int i = 0; i < EbCol.Length; i++)
                {

                    Console.SetCursorPosition(leftDisplay, topDisplay);
                    Console.WriteLine("{0,-20} : {1}", fieldName[i], EbCol[i]);
                    topDisplay++;
                }



                topDisplay += 2;
            }

            int count = displaySet;

            Station.BorderThread(2, 18, 115, count, 10);
            Console.CursorVisible = false;

            int leftB = 60;
            int topB = 18;
            for (int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(leftB, topB);
                Console.Write("|");
                topB++;
            }

            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press any Key to Return to previous Menu....");
            Console.ReadKey(true);
            

            MeetingAppointment ma = new MeetingAppointment();
            ma.Start();
        }

        
    }
}

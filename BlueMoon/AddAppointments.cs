using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueMoon
{
    class AddAppointments : IDisposable
    {
        FileStream fs;
        StreamWriter w;
        string name;
        string year;
        string month;
        string day;
        string hour;
        string minute;
        string location;
        string concatenate;

        public void Start()
        {

            Console.Title = "BlueMoon - Add Appointments";

            AddAppointmentHeader();

            OpenStream();

            InputAppointment();
            
            WriteStream();

            CloseStream();

            MeetingAppointment ma = new MeetingAppointment();
            ma.Start();

        }
        
        private void AddAppointmentHeader()
        {

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);


            Console.SetCursorPosition(37, 13);
            Console.WriteLine("==========PERSONAL ASSISTANT APPLICATION==========");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press any Key to View Contacts....");
            Console.ReadKey(true);



            Console.SetCursorPosition(39, 17);
            Console.WriteLine("       ======Contact Details======        ");

            

        }

        
        private void OpenStream()
        {
            // open stream
            fs = new FileStream("Schedule.ebase", FileMode.Append, FileAccess.Write);
            w = new StreamWriter(fs);
        }

        private void InputAppointment()
        {
            Station.writer(39, 19, "Enter Name of Appointment Max(12)");
            name = Station.MeteredInput(12, 39, 20);

            Station.writer(39, 22, "Enter year Max(4) i.e 2018");
            year = Station.MeteredInputNum(4, 39, 23);

            DisplayMonths();
            Station.writer(39, 25, "Enter month Max(2)");
            month = Station.MeteredInputNum(2, 39, 26);

            if(Convert.ToInt32(year) == 2018)
            {
                if(Convert.ToInt32(month) == 6)
                {
                    Station.writer(3, 27, "===June 2018===");
                    Calender.JuneCal(3, 28);
                }
                else if (Convert.ToInt32(month) == 7)
                {
                    Station.writer(3, 28, "===July 2018===");
                    Calender.JulyCal(3, 29);
                }
            }
            
            Station.writer(39, 28, "Enter day Max(2)");
            day = Station.MeteredInputNum(2, 39, 29);

            Station.writer(39, 31, "Enter hour Max(2)");
            hour = Station.MeteredInputNum(2, 39, 32);

            Station.writer(39, 34, "Enter minute Max(2)");
            minute = Station.MeteredInputNum(2, 39, 35);

            Station.writer(39, 37, "Enter Location Max(12)");
            location = Station.MeteredInput(12, 39, 38);
            
            Station.writer(39, 39, "(P). PM or (A). AM");
            EnterAmPm(39, 39);

        }

        private void WriteStream()
        {
            CloseStream();

            bool det = ValidateDate();

            OpenStream();

            if (det)
            {
                Station.Blink("Saving Data.......", 3000, 75, 27);
                concatenate = name + "~" + year + "~" + month + "~" + day + "~" + hour + "~" + minute + "~" + location;

                //write stream
                w.WriteLine(concatenate);
            }
            else
            {
                Station.writer(75, 26, "Appointment could not be");
                Station.writer(75, 27, "saved because :");
                Station.writer(75, 28, "This Date Already Exists");
                Station.writer(75, 29, "Please try again, and");
                Station.writer(75, 30, "Select a different date");
                Station.writer(75, 30, "Press any key to continue");
                Console.CursorVisible = false;
                Console.ReadKey(true);
            }
            
        }

        private void CloseStream()
        {
            w.Flush();
            w.Close();
            fs.Close();
        }

        public void Dispose()
        {
            ((IDisposable)fs).Dispose();
            ((IDisposable)w).Dispose();
        }

        private void DisplayMonths()
        {
            int left = 3;
            int top = 19;

            Station.writer(left, top, "Select month number");

            top++;
            Station.writer(left, top, "(1) . Jan   (2) . Feb");

            top++;
            Station.writer(left, top, "(3) . Mar   (4) . Apr");

            top++;
            Station.writer(left, top, "(5) . May   (6) . June");

            top++;
            Station.writer(left, top, "(7) . July  (8) . Aug");

            top++;
            Station.writer(left, top, "(9) . Sept  (10). Oct");

            top++;
            Station.writer(left, top, "(11). Nov   (12). Dec");


        }

        private void EnterAmPm(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.CursorVisible = false;
            ConsoleKeyInfo key;

            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.P)
            {
                int _hour = Convert.ToInt32(hour);
                _hour = _hour + 12;

                hour = _hour.ToString();
                //Console.Write("PM");
            }
            else if (key.Key == ConsoleKey.A)
            {
                //Console.Write("AM");
            }

            else
            {
                Console.WriteLine("Invalid Key.");
                Station.clearRow(left, top, 12);
                EnterAmPm(left, top);
            }
        }

        private bool ValidateDate()
        {

            string curPath = Directory.GetCurrentDirectory();

            string path = curPath + "\\Schedule.ebase";

            string[] EbRows = File.ReadAllLines(path);

            bool test = true;

            for (int i = 0; i < EbRows.Length; i++)
            {
                string[] EbCol = EbRows[i].Split('~');
                
                if (year == EbCol[1] && month == EbCol[2] && day == EbCol[3] && hour == EbCol[4] && minute == EbCol[5])
                {
                    test = false;
                    break;
                }
                
            }

            return test;

        }
    }
}

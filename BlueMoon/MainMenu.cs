using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BlueMoon
{
    class MainMenu
    {

        string curPath;

        string path;
        string[] EbRows;

        List<string> displayer = new List<string>();


        public void Start()
        {
            
            Console.Title = "BlueMoon - Main Menu";
            CheckAppointments();
            //DisplayAllAppointments();
            DisplayMainMenu();
        }
        
        private void DisplayMainMenu()
        {
            
            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);

            Console.SetCursorPosition(37, 14);
            Console.WriteLine("press the letter in the bracket to select option.");

            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Example : press 'p' for personal assistant.");

            Console.SetCursorPosition(39, 18);
            string textP = "(P). Personal Assistant Application";
            Console.WriteLine(textP);

            Console.SetCursorPosition(39, 20);
            string textS = "(S). Settings";
            Console.WriteLine(textS);

            Console.SetCursorPosition(39, 22);
            string textL = "(L). Log out";
            Console.WriteLine(textL);

            Console.SetCursorPosition(39, 24);
            Console.WriteLine("(X). Exit");


            Station.StartTimeThread();


            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.P)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, 18, textP);
                PersonalAssistant pa = new PersonalAssistant();
                pa.Start();
            }
            else if (key.Key == ConsoleKey.S)
            {
                
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, 20, textS);
                SettingsMenu sm = new SettingsMenu();
                sm.Start();
            }
            else if (key.Key == ConsoleKey.L)
            {

                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, 22, textL);
                Login l = new Login();
                l.DisplayPassword();
            }
            else if (key.Key == ConsoleKey.X)
            {
                Station.StopTimeThread();
                Environment.Exit(0);
                Application.Exit();
            }
            else
            {
                Station.StopTimeThread();
                Station.BeepError();
                Console.SetCursorPosition(39, 26);
                Console.WriteLine("Invalid Key.");
                Thread.Sleep(200);
                Console.Clear();
                DisplayMainMenu();
            }



        }

        private void CheckAppointments()
        {

           
            curPath = Directory.GetCurrentDirectory();

            //Thread.Sleep(5000);

            path = curPath + "\\Schedule.ebase";
            
            
            EbRows = File.ReadAllLines(path);


           

            for (int i = 0; i < EbRows.Length; i++)
            {
                string[] EbCol = EbRows[i].Split('~');



                if (DateTime.Now.Year.ToString() == EbCol[1] && DateTime.Now.Month.ToString() == EbCol[2] && DateTime.Now.Day.ToString() == EbCol[3])

                {
                    string hour = EbCol[4];
                    int hourNumber = Int32.Parse(hour);

                    string minute = EbCol[5];
                    int minuteNumber = Int32.Parse(minute);

                    string timeOfDay;

                    if (hourNumber > 12)
                    {
                        hourNumber -= 12;
                        timeOfDay = "PM";
                    }
                    else
                    {
                        timeOfDay = "AM";
                    }


                    //if (DateTime.Now.Minute >= minuteNumber)
                    //{
                        Station.BeepRemind();                                      
                        MessageBox.Show("there is an Appointment slated for  " + hourNumber + ":" + EbCol[5] + " " + timeOfDay + " at " + 
                            EbCol[6] + ". ", EbCol[0],MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //}

                }


            }
          
            


        }


















        /*
        private void DisplayAllAppointments()
        {

            Console.Clear();

            string curPath = Directory.GetCurrentDirectory();

            string path = curPath + "\\Schedule.ebase";



            string[] EbRows = File.ReadAllLines(path);

            string[] fieldName = { "Name of appointment", "Year", "Month", "Day", "Hour", "Minute", "Location" };


            for (int i = 0; i < EbRows.Length; i++)
            {
                string[] EbCol = EbRows[i].Split('~');



                if (DateTime.Now.Year.ToString() == EbCol[1] && DateTime.Now.Month.ToString() == EbCol[2] && DateTime.Now.Day.ToString() == EbCol[3])

                {
                    

                    Console.Clear();


                }


            }




        }
        
      
        private void DisplayAppointments(List<string> displayer)
        {
            string[] fieldName = { "Name of appointment", "Year", "Month", "Day", "Hour", "Minute", "Location" };

            string[] Ebcol = displayer.ToArray();

            int topDisplay = 20;
            int leftDisplay = 0;
            int countingLeft = 1;
            int displaySet = 0;


            int initial = EbRows.Length - 1;

            for (int q = initial; q >= 0; q--)
            {

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

                for (int o = 0; o < EbCol.Length; o++)
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
            for (int p = 0; p < count; p++)
            {
                Console.SetCursorPosition(leftB, topB);
                Console.Write("|");
                topB++;
            }

            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press any Key to Return to previous Menu....");
            Console.ReadKey(true);
        }

       */
    }
}

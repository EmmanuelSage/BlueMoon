using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class EditAppointments
    {


        public void Start()
        {
            Console.Title = "BlueMoon - Edit Appointments";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);


            Console.SetCursorPosition(37, 13);
            Console.WriteLine("==========PERSONAL ASSISTANT APPLICATION==========");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press any Key to Edit Appointments....");
            Console.ReadKey(true);



            Console.SetCursorPosition(39, 17);
            Console.WriteLine("       ======   Appointments Details   ======        ");




            string curPath = Directory.GetCurrentDirectory();

            string path = curPath + "\\Schedule.ebase";

            string tempPath = curPath + "\\temp.txt";

            string[] EbRows = File.ReadAllLines(path);



            Console.SetCursorPosition(39, 19);
            Console.WriteLine("enter the name of the Appointments to Edit");
            Console.SetCursorPosition(39, 20);
            string name = Station.MeteredInput(12, 39, 20);

            name = name.ToLower();

            bool editer = true;
            bool found = false;

            string[] fieldName = { "Name", "Year", "Month", "Day", "Hour", "Minute","Location" };

            List<string> newData = new List<string>();

            while (editer)
            {
                found = false;
                newData = new List<string>();

                for (int i = 0; i < EbRows.Length; i++)
                {
                    string[] EbCol = EbRows[i].Split('~');

                    #region editer loop

                    for (int j = 0; j < EbCol.Length; j++)
                    {
                        if (editer)
                        {
                            string EbColtemp = EbCol[0].ToLower();

                            if (name == EbColtemp || EbColtemp.Contains(name))
                            {
                                found = true;
                                Console.SetCursorPosition(39, 22);
                                Console.WriteLine("=======Appointments==============");

                                EditContactsClear();

                                Console.SetCursorPosition(39, 24);
                                Console.WriteLine("{0,-12} : {1}", fieldName[0], EbCol[0]);

                                Console.SetCursorPosition(39, 25);
                                Console.WriteLine("{0,-12} : {1}", fieldName[1], EbCol[1]);

                                Console.SetCursorPosition(39, 26);
                                Console.WriteLine("{0,-12} : {1}", fieldName[2], EbCol[2]);

                                Console.SetCursorPosition(39, 27);
                                Console.WriteLine("{0,-12} : {1}", fieldName[3], EbCol[3]);

                                Console.SetCursorPosition(39, 28);
                                Console.WriteLine("{0,-12} : {1}", fieldName[4], EbCol[4]);

                                Console.SetCursorPosition(39, 29);
                                Console.WriteLine("{0,-12} : {1}", fieldName[5], EbCol[5]);

                                Console.SetCursorPosition(39, 30);
                                Console.WriteLine("{0,-12} : {1}", fieldName[6], EbCol[6]);



                                Console.SetCursorPosition(15, 32);
                                Console.WriteLine("(E). edit Appointments  --  (Backspace) to return  --  (N) to Next Search  --  (any key) to start again");


                                Console.CursorVisible = false;
                                ConsoleKeyInfo key;
                                key = Console.ReadKey(true);

                                if (key.Key == ConsoleKey.E)
                                {

                                    Station.clearRow(15, 32, 105);


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter Name :            ");
                                    string newName = Station.MeteredInput(12, 39, 33);

                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);

                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter Year :         ");
                                    string year = Station.MeteredInputNum(4, 39, 33);


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter Month :      ");
                                    string month = Station.MeteredInputNum(2, 39, 33);


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter Day : ");
                                    string day = Station.MeteredInputNum(2, 39, 33);


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter Hour :    ");
                                    string hour = Station.MeteredInputNum(2, 39, 33);


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter minute :          ");
                                    string minute = Station.MeteredInputNum(2, 39, 33);

                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);

                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter location :          ");
                                    string location = Station.MeteredInput(12, 39, 33);

                                    EbRows[i] = newName + "~" + year + "~" + month + "~" + day + "~" + hour + "~" + minute + "~" + location;


                                    editer = false;

                                }
                                else if (key.Key == ConsoleKey.Backspace)
                                {
                                    MeetingAppointment ma1 = new MeetingAppointment();
                                    ma1.Start();
                                }
                                else if (key.Key == ConsoleKey.N)
                                {
                                    break;
                                }
                                else
                                {
                                    EditAppointments eac = new EditAppointments();
                                    eac.Start();
                                }



                            }

                        }
                    }

                    #endregion

                    newData.Add(EbRows[i]);

                }

                if (!found)
                {
                    Console.SetCursorPosition(48, 27);
                    Console.Write("Contact Not Found");
                    Thread.Sleep(500);
                    Start();
                }
            }


            string[] newDataarr = newData.ToArray();


            File.WriteAllLines(tempPath, newDataarr);

            File.Delete("Schedule.ebase");
            Station.Blink("Editing Contact Information.............", 5000, 39, 35);
            File.Move("temp.txt", "Schedule.ebase");

            MeetingAppointment ma = new MeetingAppointment();
            ma.Start();

        }



        private void EditContactsClear()
        {
            Console.SetCursorPosition(39, 24);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 25);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 26);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 27);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 28);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 29);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 30);
            Console.WriteLine("                                     ");
        }


    }
}

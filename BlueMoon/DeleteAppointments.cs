using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class DeleteAppointments
    {


        public void Start()
        {
            Console.Title = "BlueMoon - Delete Appointment";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);


            Console.SetCursorPosition(37, 13);
            Console.WriteLine("==========PERSONAL ASSISTANT APPLICATION==========");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press BackSpace to go to previous menu or any key to start delete....");

            Console.CursorVisible = false;
            ConsoleKeyInfo key1;
            key1 = Console.ReadKey(true);

            if (key1.Key == ConsoleKey.Backspace)
            {
                ContactDetails cd2 = new ContactDetails();
                cd2.Start();
                return;
            }

            Console.SetCursorPosition(37, 15);
            Console.WriteLine("                                                                           ");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Delete Appointment Menu");



            Console.SetCursorPosition(39, 17);
            Console.WriteLine("       ======Appointment Details======");


            bool writeRow;



            string curPath = Directory.GetCurrentDirectory();

            string path = curPath + "\\Schedule.ebase";

            string tempPath = curPath + "\\temp.txt";

            string[] EbRows = File.ReadAllLines(path);




            Console.SetCursorPosition(39, 19);
            Console.WriteLine("enter the name of the Appointment to delete");

            Console.SetCursorPosition(39, 20);
            // Start add
            string name = Station.MeteredInput(12, 39, 20);


            name = name.ToLower();


            bool editer = true;
            bool found = false;
            // end add

            string[] fieldName = { "Name", "Year", "Month", "Day", "Hour", "Minute","Location" };

            List<string> newData = new List<string>();



            while (editer)
            {
                newData = new List<string>();
                //add
                found = false;

                for (int i = 0; i < EbRows.Length; i++)
                {
                    string[] EbCol = EbRows[i].Split('~');
                    writeRow = true;

                    for (int j = 0; j < EbCol.Length; j++)
                    {

                        //Start add 
                        if (editer)
                        {
                            string EbColtemp = EbCol[0].ToLower();

                            if (name == EbColtemp || EbColtemp.Contains(name))
                            {

                                found = true;
                                // End add make sure to complete }

                                Console.SetCursorPosition(39, 22);
                                Console.WriteLine("=======Appointment Found=======");

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
                                Console.WriteLine("(Y) Delete Appointment  --  (N) Next Search  --  (AnyKey) Start Again -- (BackSpace) to Return to Menu");


                                Console.CursorVisible = false;
                                ConsoleKeyInfo key;
                                key = Console.ReadKey(true);

                                if (key.Key == ConsoleKey.Y)
                                {

                                    Station.clearRow(15, 32, 105);
                                    Console.SetCursorPosition(30, 32);
                                    Console.WriteLine("Are you sure you want to delete Appointment !! (Y). Yes or anykey to Cancel ?");

                                    Console.CursorVisible = false;
                                    ConsoleKeyInfo key2;
                                    key2 = Console.ReadKey(true);

                                    if (key2.Key == ConsoleKey.Y)
                                    {
                                        writeRow = false;
                                        editer = false;
                                        Station.clearRow(30, 32, 90);


                                    }
                                    else if (key2.Key != ConsoleKey.Y)
                                    {

                                        MainMenu ddc = new MainMenu();
                                        ddc.Start();
                                    }


                                }
                                else if (key.Key == ConsoleKey.N)
                                {
                                    break;
                                }
                                else if (key.Key == ConsoleKey.Backspace)
                                {
                                    MeetingAppointment ma1 = new MeetingAppointment();
                                    ma1.Start();
                                }
                                else
                                {
                                    DeleteAppointments da1 = new DeleteAppointments();
                                    da1.Start();
                                }

                            }


                        }

                    }

                    if (writeRow)
                    {
                        newData.Add(EbRows[i]);
                    }


                }

                if (!found)
                {
                    Console.SetCursorPosition(48, 27);
                    Console.Write("Appointment Not Found");
                    Thread.Sleep(500);
                    Start();
                }
            }

            string[] newDataarr = newData.ToArray();



            File.WriteAllLines(tempPath, newDataarr);

            File.Delete("Schedule.ebase");
            Station.Blink("Deleting Appointment Information.............", 5000, 39, 33);
            File.Move("temp.txt", "Schedule.ebase");


            MeetingAppointment ma2 = new MeetingAppointment();
            ma2.Start();

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

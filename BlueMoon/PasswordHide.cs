using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class PasswordHide
    {
        int left = 37;
        int top = 14;
        int topA;
        string textA;
        int topI;
        string textI;
        int topR;
        string textR;


        public void Start()
        {
            PasswordHideMenuUI();
            PasswordHideMenuFunction();
        }


        private void PasswordHideMenuUI()
        {
            Console.Title = "BlueMoon - Settings - Password hide type";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);

            Console.SetCursorPosition(left, top);
            Console.WriteLine("PERSONAL ASSISTANT APPLICATION");

            top += 2;
            Console.SetCursorPosition(37, top);
            Console.WriteLine("=====Password hide type=====");

            top += 3;
            topA = top;
            Console.SetCursorPosition(39, top);
            textA = "(A). Use Asterix to Hide";
            Console.WriteLine(textA);

            top += 2;
            topI = top;
            Console.SetCursorPosition(39, top);
            textI = "(I). Make Password Invisible";
            Console.WriteLine(textI);

            top += 2;
            topR = top;
            Console.SetCursorPosition(39, top);
            textR = "(R). Return to Main Menu ";
            Console.WriteLine(textR);


        }

        private void PasswordHideMenuFunction()
        {

            Station.StartTimeThread();

            if (Station.passHide == "A")
            {
                Station.writerClearedRow(70, topA, "Active");
                Station.clearRow(70, topI, 6);
            }
            else if (Station.passHide == "I")
            {
                Station.writerClearedRow(70, topI, "Active");
                Station.clearRow(70, topA, 6);
            }


            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);


            if (key.Key == ConsoleKey.A)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topA, textA);

                int toperA = topR + 3;

                Station.writerClearedRow(39, toperA, "Asterix has been selected.");
                toperA++;
                Station.writerClearedRow(39, toperA, "");

                Console.ReadKey();

                SaveToSettingsFile("A");

                Station.writerClearedRow(70, topA, "Active");
                Station.clearRow(70, topI, 6);

                SettingsLoginDetails sl = new SettingsLoginDetails();
                sl.Start();

            }


            else if (key.Key == ConsoleKey.I)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topI, textI);


                int toperA = topR + 3;

                Station.writerClearedRow(39, toperA, "Invisible has been selected.");
                toperA++;
                Station.writerClearedRow(39, toperA, "");

                Console.ReadKey();
                SaveToSettingsFile("I");

                Station.writerClearedRow(70, topI, "Active");
                Station.clearRow(70, topA, 6);

                SettingsLoginDetails sl = new SettingsLoginDetails();
                sl.Start();

            }


            else if (key.Key == ConsoleKey.R)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topR, textR);
                SettingsLoginDetails sld = new SettingsLoginDetails();
                sld.Start();
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

        private void SaveToSettingsFile(string chract)
        {
            // decrypt settings
            Station.writerClearedRow(39, 35, "Verifying Data Source");
            string curPath = Directory.GetCurrentDirectory();
            string path = curPath + "\\Settings.ebase";
            string tempPath = curPath + "\\temp.txt";

            Encryption.Decrypt(path);

            string[] EbRows = File.ReadAllLines(path);

            //
            EbRows[2] = chract;


            File.WriteAllLines(tempPath, EbRows);

            File.Delete("Settings.ebase");
            Station.writerClearedRow(39, 35, "Saving data ..");
            Station.Blink("Saving data ....", 5000, 39, 35);
            File.Move("temp.txt", "Settings.ebase");

            Station.Blink("Saving data ......", 2000, 39, 35);

            Encryption.Encrypt(path);
            Station.writerClearedRow(39, 35, "Saved");
            Thread.Sleep(2000);
        }



    }
}

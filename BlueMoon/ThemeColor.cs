using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class ThemeColor
    {

        public void Start()
        {
            Console.Title = "BlueMoon - Settings - Change Theme Color";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);

            int left = 37;
            int top = 14;

            Console.SetCursorPosition(left, top);
            Console.WriteLine("PERSONAL ASSISTANT APPLICATION");

            top++;
            Console.SetCursorPosition(37, top);
            Console.WriteLine("Press the letter in brackets to select Theme Color");

            top += 3;
            int topCyan = top;
            Console.SetCursorPosition(39, top);
            String textCyan = "(C). Theme Cyan (default)";
            Console.WriteLine(textCyan);

            top += 2;
            int topGreen = top;
            Console.SetCursorPosition(39, top);
            string textGreen = "(G). Theme Green";
            Console.WriteLine(textGreen);

            top += 2;
            int topBlue = top;
            Console.SetCursorPosition(39, top);
            string textBlue = "(B). Theme Blue ";
            Console.WriteLine(textBlue);

            top += 2;
            int topMagenta = top;
            Console.SetCursorPosition(39, top);
            string textMagenta = "(M). Theme Magenta ";
            Console.WriteLine(textMagenta);

            top += 2;
            int topGray = top;
            Console.SetCursorPosition(39, top);
            string textGray = "(A). Theme Gray ";
            Console.WriteLine(textGray);

            top += 2;
            int topYellow = top;
            Console.SetCursorPosition(39, top);
            string textYellow = "(Y). Theme Yellow";
            Console.WriteLine(textYellow);

            top += 2;
            int topRed = top;
            Console.SetCursorPosition(39, top);
            string textRed = "(R). Theme Red";
            Console.WriteLine(textRed);

            top += 2;
            int topX = top;
            Console.SetCursorPosition(39, top);
            string textX = "(X). Exit this page ";
            Console.WriteLine(textX);


            Station.StartTimeThread();

            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.C)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topCyan, textCyan);

                //
                Station.writerClearedRow(39, 34, "Theme Cyan Selected.");

                Station.writerClearedRow(39, 35, "Press any key to save and return to settings");

                SaveToSettingsFile("Cyan");

                SettingsLoginDetails sld = new SettingsLoginDetails();
                sld.Start();


            }
            else if (key.Key == ConsoleKey.G)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topGreen, textGreen);

                Station.writerClearedRow(39, 34, "Theme Green Selected.");

                Station.writerClearedRow(39, 35, "Press any key to save and return to settings");

                SaveToSettingsFile("Green");

                SettingsLoginDetails sld = new SettingsLoginDetails();
                sld.Start();
            }

            else if (key.Key == ConsoleKey.B)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topBlue, textBlue);

                Station.writerClearedRow(39, 34, "Theme Blue Selected.");

                Station.writerClearedRow(39, 35, "Press any key to save and return to settings");

                SaveToSettingsFile("Blue");

                SettingsLoginDetails sld = new SettingsLoginDetails();
                sld.Start();
            }

            else if (key.Key == ConsoleKey.M)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topMagenta, textMagenta);

                Station.writerClearedRow(39, 34, "Theme Magenta Selected.");

                Station.writerClearedRow(39, 35, "Press any key to save and return to settings");

                SaveToSettingsFile("Magenta");

                SettingsLoginDetails sld = new SettingsLoginDetails();
                sld.Start();
            }

            else if (key.Key == ConsoleKey.A)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topGray, textGray);

                Station.writerClearedRow(39, 34, "Theme Gray Selected.");

                Station.writerClearedRow(39, 35, "Press any key to save and return to settings");

                SaveToSettingsFile("Gray");

                SettingsLoginDetails sld = new SettingsLoginDetails();
                sld.Start();
            }

            else if (key.Key == ConsoleKey.Y)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topYellow, textYellow);

                Station.writerClearedRow(39, 34, "Theme Yellow Selected.");

                Station.writerClearedRow(39, 35, "Press any key to save and return to settings");

                SaveToSettingsFile("Yellow");

                SettingsLoginDetails sld = new SettingsLoginDetails();
                sld.Start();
            }

            else if (key.Key == ConsoleKey.R)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topRed, textRed);

                Station.writerClearedRow(39, 34, "Theme Red Selected.");

                Station.writerClearedRow(39, 35, "Press any key to save and return to settings");

                SaveToSettingsFile("Red");

                SettingsLoginDetails sld = new SettingsLoginDetails();
                sld.Start();
            }

            else if (key.Key == ConsoleKey.X)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topX, textX);
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
                Console.Clear();
                Start();
            }



        }

        private void SaveToSettingsFile(string color)
        {
            // decrypt settings
            Station.writerClearedRow(39, 35, "Verifying Data Source");
            string curPath = Directory.GetCurrentDirectory();
            string path = curPath + "\\Settings.ebase";
            string tempPath = curPath + "\\temp.txt";

            Encryption.Decrypt(path);

            string[] EbRows = File.ReadAllLines(path);

            //
            EbRows[3] = color;
            

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

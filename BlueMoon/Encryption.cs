using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueMoon
{ 
    class Encryption
    {
        

        public void Start()
        {
            //Encrypt("Settings.ebase");
            Decrypt("Settings.ebase");
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public static void Encrypt(string file)
        {
            EncryptFile(file, "out.txt");
            File.Delete(file);
            Thread.Sleep(2000);
            File.Move("out.txt", file);
        }

        public static void Decrypt(string file)
        {
            DecryptFile(file, "out.txt");
            File.Delete(file);
            Thread.Sleep(2000);
            File.Move("out.txt", file);
        }

        private static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myKey123"; 
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateEncryptor(key, key),
                CryptoStreamMode.Write);
                FileStream fsIn = new FileStream(inputFile, FileMode.Open);
                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }


        private static void DecryptFile(string inputFile, string outputFile)
        {
            {
                string password = @"myKey123"; 
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                Thread.Sleep(5000);
                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);
                FileStream fsOut = new FileStream(outputFile, FileMode.Create);
                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);
                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
        }


        


    }
}

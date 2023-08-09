using symmetriskKrypteringØvelse;
using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("                            Encrypt and decrypt");
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine(" Vælg en symmetrisk krypterings algoritme.");
        Console.WriteLine();
        Console.WriteLine(" 1 : DES");
        Console.WriteLine(" 2 : TripleDES");
        Console.WriteLine(" 3 : AES");
        Console.WriteLine();




        var input = Console.ReadKey();
        switch (input.Key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                DesUI();
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                TripleDesUI();
                break;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                AESUI();
                break;
        }



        void DesUI()
        {
            Encrypter encrypter = new Encrypter();
            Decrypter decrypter = new Decrypter();
            RandomGenerator rnd = new RandomGenerator();
            byte[] Key;
            byte[] IV;
            string? MessageToEncrypt;

            Console.Write(" Indtast Besked du vil sende : ");
            MessageToEncrypt = Console.ReadLine();

            byte[] HEX = Encoding.Default.GetBytes(MessageToEncrypt);

            Key = rnd.GenerateRandomNumber(8);
            IV = rnd.GenerateRandomNumber(8);

            // starter tids tagning for kryptering
            Stopwatch stopwatchencrypt = new Stopwatch();
            stopwatchencrypt.Start();

            byte[] EncryptedMessage = encrypter.Des(Encoding.UTF8.GetBytes(MessageToEncrypt), Key, IV);

            // stopper tids tagning
            stopwatchencrypt.Stop();


            // starter tids tagning for dekryptering
            Stopwatch stopwatchdekryptering = new Stopwatch();
            stopwatchdekryptering.Start();

            byte[] DecryptedMessage = decrypter.Des(EncryptedMessage, Key, IV);

            // stopper tids tagning
            stopwatchdekryptering.Stop();

            // Efter kryptering of dekryptering UI data
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("                            Resultat DES");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Key : " + Convert.ToBase64String(Key));
            Console.WriteLine(" IV : " + Convert.ToBase64String(IV));
            Console.WriteLine();
            Console.WriteLine(" Besked i ASCII : " + MessageToEncrypt);
            Console.WriteLine(" Besked i Hex : " + Convert.ToHexString(HEX).Replace("-", ""));
            Console.WriteLine();
            Console.WriteLine(" Kryptered besked : " + Convert.ToBase64String(EncryptedMessage));
            Console.WriteLine(" Dekrypted besked : " + Encoding.UTF8.GetString(DecryptedMessage));
            Console.WriteLine();
            Console.WriteLine(" Krypterings tid: {0}", stopwatchencrypt.Elapsed);
            Console.WriteLine(" Dekrypterings tid: {0}", stopwatchdekryptering.Elapsed);
            Console.ReadKey();
        }

        void TripleDesUI()
        {
            Encrypter encrypter = new Encrypter();
            Decrypter decrypter = new Decrypter();
            RandomGenerator rnd = new RandomGenerator();
            byte[] Key;
            byte[] IV;
            string? MessageToEncrypt;

            Console.Write(" Indtast Besked du vil sende : ");
            MessageToEncrypt = Console.ReadLine();

            byte[] HEX = Encoding.Default.GetBytes(MessageToEncrypt);

            Key = rnd.GenerateRandomNumber(24);
            IV = rnd.GenerateRandomNumber(8);

            // starter tids tagning for kryptering
            Stopwatch stopwatchencrypt = new Stopwatch();
            stopwatchencrypt.Start();

            byte[] EncryptedMessage = encrypter.TripleDes(Encoding.UTF8.GetBytes(MessageToEncrypt), Key, IV);

            // stopper tids tagning
            stopwatchencrypt.Stop();

            // starter tids tagning for dekryptering
            Stopwatch stopwatchdekryptering = new Stopwatch();
            stopwatchdekryptering.Start();

            byte[] DecryptedMessage = decrypter.TripleDes(EncryptedMessage, Key, IV);

            // stopper tids tagning
            stopwatchdekryptering.Stop();

            // Efter kryptering of dekryptering UI data
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("                            Resultat TripleDES");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Key : " + Convert.ToBase64String(Key));
            Console.WriteLine(" IV : " + Convert.ToBase64String(IV));
            Console.WriteLine();
            Console.WriteLine(" Besked i ASCII : " + MessageToEncrypt);
            Console.WriteLine(" Besked i Hex : " + Convert.ToHexString(HEX).Replace("-", ""));
            Console.WriteLine();
            Console.WriteLine(" Kryptered besked : " + Convert.ToBase64String(EncryptedMessage));
            Console.WriteLine(" Dekrypted besked : " + Encoding.UTF8.GetString(DecryptedMessage));
            Console.WriteLine();
            Console.WriteLine(" Krypterings tid: {0}", stopwatchencrypt.Elapsed);
            Console.WriteLine(" Dekrypterings tid: {0}", stopwatchdekryptering.Elapsed);
            Console.ReadKey();
        }

        void AESUI()
        {
            Encrypter encrypter = new Encrypter();
            Decrypter decrypter = new Decrypter();
            RandomGenerator rnd = new RandomGenerator();
            byte[] Key;
            byte[] IV;
            string? MessageToEncrypt;

            Console.Write(" Indtast Besked du vil sende : ");
            MessageToEncrypt = Console.ReadLine();

            byte[] HEX = Encoding.Default.GetBytes(MessageToEncrypt);

            Key = rnd.GenerateRandomNumber(32);
            IV = rnd.GenerateRandomNumber(16);

            // starter tids tagning for kryptering
            Stopwatch stopwatchencrypt = new Stopwatch();
            stopwatchencrypt.Start();

            byte[] EncryptedMessage = encrypter.AES(Encoding.UTF8.GetBytes(MessageToEncrypt), Key, IV);

            // stopper tids tagning
            stopwatchencrypt.Stop();


            // starter tids tagning for dekryptering
            Stopwatch stopwatchdekryptering = new Stopwatch();
            stopwatchdekryptering.Start();

            byte[] DecryptedMessage = decrypter.AES(EncryptedMessage, Key, IV);

            // stopper tids tagning
            stopwatchdekryptering.Stop();

            // Efter kryptering of dekryptering UI data
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("                            Resultat AES");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Key : " + Convert.ToBase64String(Key));
            Console.WriteLine(" IV : " + Convert.ToBase64String(IV));
            Console.WriteLine();
            Console.WriteLine(" Besked i ASCII : " + MessageToEncrypt);
            Console.WriteLine(" Besked i Hex : " + Convert.ToHexString(HEX).Replace("-", ""));
            Console.WriteLine();
            Console.WriteLine(" Kryptered besked : " + Convert.ToBase64String(EncryptedMessage));
            Console.WriteLine(" Dekrypted besked : " + Encoding.UTF8.GetString(DecryptedMessage));
            Console.WriteLine();
            Console.WriteLine(" Krypterings tid: {0}", stopwatchencrypt.Elapsed);
            Console.WriteLine(" Dekrypterings tid: {0}", stopwatchdekryptering.Elapsed);
            Console.ReadKey();
        }
    }
}
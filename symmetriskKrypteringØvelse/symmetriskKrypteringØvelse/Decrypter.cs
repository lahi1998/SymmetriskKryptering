using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace symmetriskKrypteringØvelse
{
    internal class Decrypter
    {
        // Metode til at udføre dekryptering ved hjælp af DES-algoritmen.
        public byte[] Des(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            byte[] retur;

            // Opret en instans af DES-dekrypteringsalgoritmen.
            using (var des = new DESCryptoServiceProvider())
            {
                // Konfigurer dekrypteringsindstillingerne.
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;

                // Opret en memoryStream til dekrypteret data.
                using (var memoryStream = new MemoryStream())
                {
                    // Opret en cryptostream  baseret på DES-algoritmen og tilstand 'Decrypt'.
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    // Skriv data til cryptostream, dekrypter det og skriv til memoryStream.
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    // Konverter den dekrypterede memoryStream til et byte-array.
                    retur = memoryStream.ToArray();
                }
            }

            // Returner det dekrypterede byte-array.
            return retur;
        }

        // Metode til at udføre dekryptering ved hjælp af TripleDes-algoritmen.
        public byte[] TripleDes(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            byte[] retur;

            // Opret en instans af TripleDes-dekrypteringsalgoritmen.
            using (var tripledes = new TripleDESCryptoServiceProvider())
            {
                // Konfigurer dekrypteringsindstillingerne.
                tripledes.Mode = CipherMode.CBC;
                tripledes.Padding = PaddingMode.PKCS7;

                tripledes.Key = key;
                tripledes.IV = iv;

                // Opret en memoryStream til dekrypteret data.
                using (var memoryStream = new MemoryStream())
                {
                    // Opret en cryptostream  baseret på TripleDes-algoritmen og tilstand 'Decrypt'.
                    var cryptoStream = new CryptoStream(memoryStream, tripledes.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    // Skriv data til cryptostream, dekrypter det og skriv til memoryStream.
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    // Konverter den dekrypterede memoryStream til et byte-array.
                    retur = memoryStream.ToArray();
                }
            }


            return (retur);
        }

        // Metode til at udføre dekryptering ved hjælp af AES-algoritmen.
        public byte[] AES(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            byte[] retur;

            // Opret en instans af AES-dekrypteringsalgoritmen.
            using (var aes = new AesCryptoServiceProvider())
            {
                // Konfigurer dekrypteringsindstillingerne.
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                // Opret en memoryStream til dekrypteret data.
                using (var memoryStream = new MemoryStream())
                {
                    // Opret en cryptostream  baseret på AES-algoritmen og tilstand 'Decrypt'.
                    var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    // Skriv data til cryptostream, dekrypter det og skriv til memoryStream.
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    // Konverter den dekrypterede memoryStream til et byte-array.
                    retur = memoryStream.ToArray();
                }
            }

            return (retur);
        }


    }
}




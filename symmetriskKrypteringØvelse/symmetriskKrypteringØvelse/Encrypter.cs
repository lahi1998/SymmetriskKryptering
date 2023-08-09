using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace symmetriskKrypteringØvelse
{
    internal class Encrypter
    {

        // Metode til at udføre kryptering ved hjælp af DES-algoritmen.
        public byte[] Des(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            byte[] retur;

            // Opret en instans af DES-krypteringsalgoritmen.
            using (var des = DES.Create())
            {
                // Konfigurer krypteringsindstillingerne.
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;

                // Opret en memoryStream til krypteret data.
                using (var memoryStream = new MemoryStream())
                {
                    // Opret en Cryptostream baseret på DES-algoritmen og tilstand 'Encrypt'.
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    // Skriv data til Cryptostream, krypter det og skriv til memoryStream.
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    // Konverter den krypterede memoryStream til et byte-array.
                    retur = memoryStream.ToArray();
                }
            }

            // Returner det krypterede byte-array.
            return retur;
        }

        // Metode til at udføre kryptering ved hjælp af TripleDes-algoritmen.
        public byte[] TripleDes(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            byte[] retur;

            // Opret en instans af TripleDES-krypteringsalgoritmen.
            using (var tripledes = TripleDES.Create())
            {
                // Konfigurer krypteringsindstillingerne.
                tripledes.Mode = CipherMode.CBC;
                tripledes.Padding = PaddingMode.PKCS7;

                tripledes.Key = key;
                tripledes.IV = iv;

                // Opret en memoryStream til krypteret data.
                using (var memoryStream = new MemoryStream())
                {
                    // Opret en cryptoStream baseret på TripleDES-algoritmen og tilstand 'Encrypt'.
                    var cryptoStream = new CryptoStream(memoryStream, tripledes.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    // Skriv data til Cryptostream, krypter det og skriv til memoryStream.
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    // Konverter den krypterede memoryStream til et byte-array.
                    retur = memoryStream.ToArray();
                }
            }

            // Returner det krypterede byte-array.
            return (retur);
        }

        // Metode til at udføre kryptering ved hjælp af AES-algoritmen.
        public byte[] AES(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            byte[] retur;
            // Opret en instans af AES-krypteringsalgoritmen.
            using (var aes = Aes.Create())
            {
                // Konfigurer krypteringsindstillingerne.
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;
                
                // Opret en memoryStream til krypteret data.
                using (var memoryStream = new MemoryStream())
                {
                    // Opret en cryptoStream baseret på AES-algoritmen og tilstand 'Encrypt'.
                    var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    // Skriv data til Cryptostream, krypter det og skriv til memoryStream.
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    // Konverter den krypterede memoryStream til et byte-array.
                    retur = memoryStream.ToArray();
                }
            }

            // Returner det krypterede byte-array.
            return (retur);
        }
    }
}

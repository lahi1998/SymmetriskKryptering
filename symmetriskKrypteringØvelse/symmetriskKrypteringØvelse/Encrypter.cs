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

                // Opret en hukommelsesstrøm til krypteret data.
                using (var memoryStream = new MemoryStream())
                {
                    // Opret en kryptostream baseret på DES-algoritmen.
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    // Skriv data til kryptostreamen, krypter det og skriv til hukommelsesstrømmen.
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    // Konverter den krypterede hukommelsesstrøm til et byte-array.
                    retur = memoryStream.ToArray();
                }
            }

            // Returner det krypterede byte-array.
            return retur;
        }

        public byte[] TripleDes(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            byte[] retur;
            using (var tripledes = TripleDES.Create())
            {
                tripledes.Mode = CipherMode.CBC;
                tripledes.Padding = PaddingMode.PKCS7;

                tripledes.Key = key;
                tripledes.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, tripledes.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    retur = memoryStream.ToArray();
                }
            }


            return (retur);
        }

        public byte[] AES(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            byte[] retur;
            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    retur = memoryStream.ToArray();
                }
            }


            return (retur);
        }
    }
}

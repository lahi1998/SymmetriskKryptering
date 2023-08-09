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
        public byte[] Des(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            byte[] retur;
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = key;
                des.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    retur = memoryStream.ToArray();
                }
            }


            return (retur);
        }

        public byte[] TripleDes(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            byte[] retur;
            using (var tripledes = new TripleDESCryptoServiceProvider())
            {
                tripledes.Mode = CipherMode.CBC;
                tripledes.Padding = PaddingMode.PKCS7;

                tripledes.Key = key;
                tripledes.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, tripledes.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    retur = memoryStream.ToArray();
                }
            }


            return (retur);
        }

        public byte[] AES(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            byte[] retur;
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    retur = memoryStream.ToArray();
                }
            }

            return (retur);
        }


    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace symmetriskKrypteringØvelse
{
    internal class RandomGenerator
    {
        //generere et array af tilfældige bytes
        public byte[] GenerateRandomNumber(int length)
        {
            // Længden af det genererede array angives som parameter til metoden.
            var randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[length];
            randomNumberGenerator.GetBytes(randomBytes);

            return randomBytes;
        }
    }
}

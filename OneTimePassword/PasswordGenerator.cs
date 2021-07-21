
using System;

namespace OneTimePassword
{
    public class PasswordGenerator :IPasswordGenerator
    {
        public string Generate()
        {
            var passwordLength = 6;
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];

            var seed = (int)DateTime.Now.Ticks;
            var random = new Random(seed);

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}

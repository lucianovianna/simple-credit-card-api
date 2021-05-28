using System.Linq;
using System;
using System.Security.Cryptography;


namespace creditCardApi.Utils
{
    public class RandomCardNumber
    {
        private static Random randomNumber = new Random();

        public static string generate()
        {
            string charsList = "0123456789";

            string firstChar = randomNumber.Next(1,9).ToString(); // evita que o primeiro numero seja 0

            string randomStr = new string(Enumerable.Repeat(charsList, 15)
                .Select(s => s[randomNumber.Next(s.Length)]).ToArray());

            return firstChar + randomStr;
        }
    }
}
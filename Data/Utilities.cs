using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnLineClothing.Data
{
    public class Utilities
    {

        public static string Hash(string value)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value)));
        }

        public static string GenerateSalt(int max_length = 32)
        {
            //Setup RNGCrypto object for generating salt byte.
            var random = new RNGCryptoServiceProvider();

            //Empty array for the salt
            var salt = new byte[max_length];

            //Build random bytes.
            random.GetNonZeroBytes(salt);

            //Dispose the IDisposable implementation from RNGCryptoServiceProvider class
            random.Dispose();

            //Return the string encoded salt
            return Convert.ToBase64String(salt);

        }

        //A method that checks if there is a duplicate username in the database
        //Returns TRUE if there is
        //Returns FALSE if there isn't
        public static bool DuplicateUsername(string username, DataContext context)
        {

            bool duplicate;

          
            var user = from u in context.Login
                       where u.UserName == username
                       select u;

            if (user.Count() >= 1)
                duplicate = true;

            else
                duplicate = false;

            return duplicate;


        }

        //A method to check if a pasword matches the complexity requirements
        public static bool PasswordCheck(string password)
        {
            //Keeps track of the password strength score, 5 is required to pass
            int score = 0;

            if (password.Length > 8)
                score++;

            if (Regex.Match(password, @"\d+", RegexOptions.ECMAScript).Success)
                score++;

            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success)
                score++;

            if (Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
                score++;

            if (Regex.Match(password, @".[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
                score++;


            if (score >= 5)
                return true;

            else
                return false;
        }
    }
}

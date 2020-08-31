using System;
using System.Globalization;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Social Security Number (YYMMDD-XXXX): ");

            string socialSecurityNumber = Console.ReadLine();

            string genderNumberString = socialSecurityNumber.Substring(socialSecurityNumber.Length -2, 1);

            int genderNumber = int.Parse(genderNumberString);

            bool isFemale = genderNumber % 2 == 0;

            string gender = isFemale ? "Female" : "Male";

            string birthDayString = socialSecurityNumber.Substring(0, 6);

            DateTime birthDate = DateTime.ParseExact(birthDayString, "yyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Month > DateTime.Today.Month || birthDate.Month == DateTime.Today.Month && birthDate.Day > DateTime.Now.Day)
            {
                age--;
            }

            Console.WriteLine($"This is a {gender}, and the age is {age}");
        }
    }
}

using System;
using System.Globalization;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string socialSecurityNumber;

            if (args.Length > 0)
            {
                Console.WriteLine($"You provide: {args[0]}");
                socialSecurityNumber = args[0];
            }
            else
            {
                Console.WriteLine("Please input ssn yymmdd-xxx:");
                socialSecurityNumber = Console.ReadLine();
            }
                        
            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length -2, 1));

            bool isFemale = genderNumber % 2 == 0;

            string gender = isFemale ? "Female" : "Male";

            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 6), "yyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Month > DateTime.Today.Month || birthDate.Month == DateTime.Today.Month && birthDate.Day > DateTime.Now.Day)
            {
                age--;
            }

            Console.WriteLine($"This is a {gender}, and the age is {age}");
        }
    }
}
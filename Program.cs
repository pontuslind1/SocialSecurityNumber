using System;
using System.Globalization;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string socialSecurityNumber;

            if (args.Length > 0)
            {
                firstName = args[0];
                lastName = args[1];
                socialSecurityNumber = args[2];
            }
            else
            {
                Console.Write("Please type in your first name: ");
                firstName = Console.ReadLine();

                Console.Write("Please type in your family name: ");
                lastName = Console.ReadLine();

                Console.Write("Please type in your Social securtiy number(YYYYMMDD-XXXX): ");
                socialSecurityNumber = Console.ReadLine();
                Console.Clear();
            }

            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            bool isFemale = genderNumber % 2 == 0;

            string gender = isFemale ? "Female" : "Male";

            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Month > DateTime.Today.Month || birthDate.Month == DateTime.Today.Month && birthDate.Day > DateTime.Now.Day)
            {
                age--;
            }

            const int silentGenerationStart = 1900;
            const int silentGenerationStop = 1945;
            const int babyBoomersStart = 1946;
            const int babyBoombersStop = 1964;
            const int generationXStart = 1965;
            const int generationXStop = 1976;
            const int millenialsStart = 1977;
            const int millenialsStop = 1995;
            const int generationZStart = 1996;
            const int generationZStop = 2020;

            string generation = null;

            if (birthDate.Year >= silentGenerationStart && birthDate.Year <= silentGenerationStop)
            {
                generation = "Silent Generation";
            }
            else if (birthDate.Year >= babyBoomersStart && birthDate.Year <= babyBoombersStop)
            {
                generation = "Baby Boomer";
            }
            else if (birthDate.Year >= generationXStart && birthDate.Year <= generationXStop)
            {
                generation = "Generation X";
            }
            else if (birthDate.Year >= millenialsStart && birthDate.Year <= millenialsStop)
            {
                generation = "Millenial";
            }
            else if (birthDate.Year >= generationZStart && birthDate.Year <= generationZStop)
            {
                generation = "Generation Z";
            }

            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Social security number: {socialSecurityNumber}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Generation: {generation}");
        }
    }
}
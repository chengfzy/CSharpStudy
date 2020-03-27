using System;
using static System.Console;

namespace Eg01_Basic
{

    class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        //
        public string FullName => $"{FirstName} {LastName}";
    }

    public enum Color
    {
        Red,
        Green,
        Blue
    }

    [Flags]
    public enum DaysOfWeek
    {
        Monday = 0x1,
        TuesDay = 0x2,
        Wednesday = 0x4,
        Thursday = 0x8,
        Friday = 0x10,
        Saturday = 0x20,
        Sunday = 0x40,
        Weekend = Saturday | Sunday,
        Workday = 0x1f,
        AllWeek = Workday | Weekend
    }

    class Program
    {
        static void classStudy()
        {
            Person person = new Person("Cheng", "Jeffery");
            WriteLine($"Person is \"{person.FullName}\"");
        }

        static void enumStudy()
        {
            DaysOfWeek mondayAndWednesday = DaysOfWeek.Monday | DaysOfWeek.Wednesday;
            WriteLine(mondayAndWednesday);
            WriteLine(DaysOfWeek.Weekend);

            foreach (var day in Enum.GetNames(typeof(Color)))
            {
                WriteLine(day);
            }
        }

        static void Main(string[] args)
        {
            classStudy();
            enumStudy();
        }
    }
}
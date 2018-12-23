using System;
using System.Reflection;

namespace ContactWriter
{
    class Program
    {
        public string ProgramName
        {
            get;
            set;
        }

        static void Main(string[] args)
        {

            Contact gosia = new Contact
            {
                FirstName = "Gosia",
                AgeInYears = 49
            };

            ContactConsoleWriter gosiaWriter = new ContactConsoleWriter(gosia);
            gosiaWriter.Write();

        }
    }
}

using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ContactWriter
{
    public class ContactConsoleWriter
    {
        private readonly Contact contact;
        private ConsoleColor _color;

        public ContactConsoleWriter(Contact contact)
        {
            this.contact = contact;
        }

        //The Obsolete attribute for giving information about obsolete content, as default it gives a warning, 
        //can be set to give an error instead.
        //[Obsolete("This method will be deprecated in 2 months")]
        public void Write()
        {
            UseDefaultColor();
            WriteFirstName();
            WriteAge();
            RestoreForegroundColor();
        }

        private void UseDefaultColor()
        {
            DefaultColorAttribute defaultColorAttribute = 
                (DefaultColorAttribute) Attribute.GetCustomAttribute(typeof(Contact), typeof(DefaultColorAttribute));

            //If the DefaultColorAttribute was found int the Contact class.
            if(defaultColorAttribute != null)
            {
                Console.ForegroundColor = defaultColorAttribute.Color;
            }
        }

        private void WriteFirstName()
        {
            PropertyInfo propertyInfo = typeof(Contact).GetProperty(nameof(Contact.FirstName));

            DisplayAttribute displayAttribute = (DisplayAttribute) Attribute.GetCustomAttribute(propertyInfo, typeof(DisplayAttribute));

            IndentAttribute[] indentAttributes = (IndentAttribute[])Attribute.GetCustomAttributes(propertyInfo, typeof(IndentAttribute));


            PreserveForegroundColor();
            StringBuilder sb = new StringBuilder();

            if(indentAttributes != null)
            {
                foreach (var indentAttr in indentAttributes)
                {
                    sb.Append(' ', 4);
                }
            }

            //if a DisplayAttribute was found in the Contact first name info property
            if (displayAttribute != null)
            {
                sb.Append(displayAttribute.Label); //Append the label property value of the display attribute
                Console.ForegroundColor = displayAttribute.Color; //Change the foreground console color of the Color property of the display attribute
            }

            if(contact.FirstName != null)
            {
                sb.Append(contact.FirstName);
            }

            Console.WriteLine(sb);

            RestoreForegroundColor();
        }

        private void WriteAge()
        {
            OutputDebugInfo();
            Console.WriteLine(contact.AgeInYears);
        }

        //The DEBUG string argument must be uppercase.
        //This method is invoked only in debug mode.
        [Conditional("DEBUG")]
        private void OutputDebugInfo()
        {
            Console.WriteLine("***DEBUG***");
        }

        private void PreserveForegroundColor()
        {
            _color = Console.ForegroundColor;
        }

        private void RestoreForegroundColor()
        {
            Console.ForegroundColor = _color;
        }
    }
}

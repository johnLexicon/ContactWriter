using System.Diagnostics;

namespace ContactWriter
{

    //Custom attributes that sets the console color to DarkYellow if value not changed by property.
    [DefaultColor(Color = System.ConsoleColor.Yellow)]
    //Displays this information in the debugger.
    [DebuggerDisplay("First name = {FirstName}, Age in years = {AgeInYears}")]
    //Displays the properties in the ContactDebugDisplay class in the debugger.
    [DebuggerTypeProxy(typeof(ContactDebugDisplay))]
    public class Contact
    {
        [Indent]
        [Indent]
        [Indent]
        [DisplayAttribute("First name: ", System.ConsoleColor.Green)]
        public string FirstName { get; set; }

        //Does not show this property in the debugger.
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int AgeInYears { get; set; }
    }
}

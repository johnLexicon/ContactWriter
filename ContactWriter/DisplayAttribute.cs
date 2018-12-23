using System;

namespace ContactWriter
{
    /// <summary>
    /// A custom property that can be used by property elements.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayAttribute : Attribute
    {

        public DisplayAttribute(string label, ConsoleColor color = ConsoleColor.Black)
        {
            Label = label ?? throw new ArgumentNullException(nameof(label));
            Color = color;
        }

        public string Label
        {
            get;
        }

        public ConsoleColor Color
        {
            get;
        }
    }
}

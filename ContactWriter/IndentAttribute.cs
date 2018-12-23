using System;

namespace ContactWriter
{
    /// <summary>
    /// Property attribute that allows multiple decorations on the same property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IndentAttribute : Attribute
    {
        public IndentAttribute()
        {
        }
    }
}

using System;

namespace MicroEngine.Core.Attributes
{
    [Flags]
    public enum PropertyFlags
    {
        Replicated
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Property : Attribute
    {
        public PropertyFlags PropertyFlags { get; }

        public Property(PropertyFlags propertyFlags)
        {
            PropertyFlags = propertyFlags;
        }
    }
}

using System;

namespace MicroEngine.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class Package : Attribute
    {
        public Guid PackageGuid { get; }

        public Package(string packageGuid)
        {
            PackageGuid = new Guid(packageGuid);
        }
    }
}

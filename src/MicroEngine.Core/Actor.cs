using MicroEngine.Core.Primitives.Attributes;
using System.Collections.Generic;

namespace MicroEngine.Core
{
    public class Actor : XObject
    {
        bool AllowReplication { get; set; }

        public bool Property1 { get; set; }

        [Property(PropertyFlags.Replicated)]
        public virtual bool Property2 { get; set; }

        [RemoteFunction(ExecutionSide.Client, ExecutionReliability.Reliable)]
        public virtual bool Some(int a, List<bool> b)
        {
            return true;
        }
    }
}

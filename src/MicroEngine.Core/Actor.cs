using MicroEngine.Core.Attributes;

namespace MicroEngine.Core
{
    public class Actor
    {
        bool AllowReplication { get; set; }

        public bool Property1 { get; set; }

        [Property(PropertyFlags.Replicated)]
        public virtual bool Property2 { get; set; }

        [RemoteFunction(ExecutionSide.Client, ExecutionReliability.Reliable)]
        public virtual void Some()
        {

        }
    }
}

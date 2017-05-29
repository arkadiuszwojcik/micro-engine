using System;

namespace MicroEngine.Core.Primitives.Attributes
{
    public enum ExecutionSide
    {
        Client,
        Server,
        Multicast
    }

    public enum ExecutionReliability
    {
        Unreliable,
        Reliable
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class RemoteFunction : Attribute
    {
        public ExecutionSide ExecutionSide { get; }
        public ExecutionReliability ExecutionReliability { get; }

        public RemoteFunction(ExecutionSide executionSide, ExecutionReliability executionReliability)
        {
            ExecutionSide = executionSide;
            ExecutionReliability = executionReliability;
        }
    }
}

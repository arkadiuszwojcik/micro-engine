using System;
using Castle.DynamicProxy;
using System.Reflection;
using MicroEngine.Core.Attributes;

namespace MicroEngine.Core.Replication
{
    public class ActorRemoteFunctionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (!IsRemoteFunction(invocation.Method)) return; 
        }

        private bool IsRemoteFunction(MethodInfo methodInfo)
        {
            return methodInfo.GetCustomAttribute<RemoteFunction>() != null;
        }
    }
}

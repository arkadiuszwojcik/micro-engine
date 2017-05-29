using System;
using Castle.DynamicProxy;
using System.Reflection;
using MicroEngine.Core.Primitives.Attributes;

namespace MicroEngine.Core.Replication
{
    class ObjectRemoteFunctionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var obj = invocation.InvocationTarget as Object;
            //invocation.re
            //invocation.Proceed();
        }
    }
}

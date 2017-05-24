using System;
using Castle.DynamicProxy;
using System.Reflection;

namespace MicroEngine.Core.Replication
{
    public class ActorPropertyInterceptor : IInterceptor
    {
        private const string SetPrefix = "set_";

        public void Intercept(IInvocation invocation)
        {
            if (!IsPropertySetter(invocation.Method)) return;
            var propertyName = invocation.Method.Name.Substring(SetPrefix.Length);
        }

        private bool IsPropertySetter(MethodInfo methodInfo)
        {
            return methodInfo.IsSpecialName && methodInfo.Name.StartsWith(SetPrefix, StringComparison.Ordinal);
        }
    }
}

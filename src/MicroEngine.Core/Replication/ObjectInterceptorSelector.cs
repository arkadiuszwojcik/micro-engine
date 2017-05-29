using System;
using System.Reflection;
using Castle.DynamicProxy;
using MicroEngine.Core.Primitives.Attributes;

namespace MicroEngine.Core.Replication
{
    class ObjectInterceptorSelector : IInterceptorSelector
    {
        private const string SetPrefix = "set_";

        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {

            if (IsRemoteFunction(method))
            {
                return new[] { OfType<ObjectRemoteFunctionInterceptor>(interceptors) };
            }

            if (IsPropertySetter(method))
            {
                return new[] { OfType<ObjectPropertyInterceptor>(interceptors) };
            }

            return null;
        }

        private IInterceptor OfType<TType>(IInterceptor[] interceptors)
        {
            foreach (var interceptor in interceptors)
            {
                if (interceptor.GetType() == typeof(TType)) return interceptor;
            }

            return null;
        }

        private bool IsRemoteFunction(MethodInfo methodInfo)
        {
            return methodInfo.GetCustomAttribute<RemoteFunction>() != null;
        }

        private bool IsPropertySetter(MethodInfo methodInfo)
        {
            return methodInfo.IsSpecialName && methodInfo.Name.StartsWith(SetPrefix, StringComparison.Ordinal);
        }
    }
}

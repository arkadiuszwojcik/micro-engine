using System;
using System.Reflection;
using Castle.DynamicProxy;
using MicroEngine.Core.Attributes;

namespace MicroEngine.Core.Replication
{
    public class ActorProxyGenerationHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        private const string SetPrefix = "set_";
        private const string GetPrefix = "get_";

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            if (memberInfo.Name.StartsWith(SetPrefix, StringComparison.Ordinal) ||
                memberInfo.Name.StartsWith(GetPrefix, StringComparison.Ordinal))
            {
                var propertyName = memberInfo.Name.Substring(SetPrefix.Length);
                if (type.GetProperty(propertyName)?.GetCustomAttribute<Property>() != null)
                {
                    throw new InvalidOperationException($"Can't use non virtual properties. Class: {type.Name} Property: {propertyName}");
                }
            }
            else
            {
                if (memberInfo.GetCustomAttribute<RemoteFunction>() != null)
                {
                    throw new InvalidOperationException($"Can't use non virtual functions. Class: {type.Name} Function: {memberInfo.Name}");
                }
            }
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            if (methodInfo.Name.StartsWith(SetPrefix, StringComparison.Ordinal) ||
                methodInfo.Name.StartsWith(GetPrefix, StringComparison.Ordinal))
            {
                var propertyName = methodInfo.Name.Substring(SetPrefix.Length);
                if (type.GetProperty(propertyName)?.GetCustomAttribute<Property>() != null) return true;
            }
            else
            {
                if (methodInfo.GetCustomAttribute<RemoteFunction>() != null) return true;
            }

            return false;
        }
    }
}

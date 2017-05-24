using Castle.DynamicProxy;
using MicroEngine.Core.Replication;

namespace MicroEngine.Core
{
    public enum NetworkRole
    {
        None,
        SimulatedProxy,
        AutonomousProxy,
        Authority
    }

    public static class ActorUtils
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();

        public static TActor CreateActor<TActor>() where TActor : Actor, new() 
        {
            var options = new ProxyGenerationOptions(new ActorProxyGenerationHook());
            var proxy = _generator.CreateClassProxy<TActor>(options, new ActorPropertyInterceptor(), new ActorRemoteFunctionInterceptor());
            return proxy;
        }
    }
}

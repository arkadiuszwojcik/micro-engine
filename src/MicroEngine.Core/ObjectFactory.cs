using Castle.DynamicProxy;
using MicroEngine.Core.Replication;

namespace MicroEngine.Core
{
    public class ObjectFactory
    {
        private readonly ProxyGenerator _generator;
        private readonly ProxyGenerationOptions _options;
        private readonly IInterceptor[] _interceptors;

        public ObjectFactory()
        {
            _interceptors = new IInterceptor[] { new ObjectPropertyInterceptor(), new ObjectRemoteFunctionInterceptor() };
            _options = new ProxyGenerationOptions(new ObjectProxyGenerationHook()) { Selector = new ObjectInterceptorSelector() };
            _generator = new ProxyGenerator();
        }

        public TObject CreateObject<TObject>() where TObject : XObject, new()
        {
            return _generator.CreateClassProxy<TObject>(_options, _interceptors);
        }
    }
}

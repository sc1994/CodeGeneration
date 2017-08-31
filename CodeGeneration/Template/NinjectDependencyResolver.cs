using Ninject;
using Ninject.Web.WebApi;
using System.Web.Http.Dependencies;

namespace Template.Infrastructure
{
    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Mvc.IDependencyResolver, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            _kernel = kernel;
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            BindToConfig.BindTo(_kernel);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}
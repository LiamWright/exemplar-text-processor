using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Threading.Tasks;

namespace Process.Course.Text.Common.DependencyInjection
{
    internal class InjectBindingProvider : IInjectBindingProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public InjectBindingProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context) =>
            Task.FromResult((IBinding)new InjectBinding(_serviceProvider, context.Parameter.ParameterType));
    }
}
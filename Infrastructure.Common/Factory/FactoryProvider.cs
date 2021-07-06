using Infrastructure.Common.Factory.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Factory
{
    public class FactoryProvider : IFactoryProvider
    {
        private readonly IServiceProvider _provider;

        public FactoryProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Create<T>()
        {
            return _provider.GetRequiredService<T>();
        }
    }
}

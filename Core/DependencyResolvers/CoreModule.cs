using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Core.CrossCuttingCorncerns.Caching;
using Core.CrossCuttingCorncerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCachingManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1
{
    public static class Extensions
    {
        public static async Task<IServiceCollection> AddWorkerService(this IServiceCollection services) 
        {
            var interfaceType = typeof(IHostService);

          //  var types = Assembly.GetExecutingAssembly().GetTypes()
                //.Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass);

            var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass);
            foreach (var type in types)
            {
                
            
                // Dinamik olaraq instansiya yaradın
                var instance = Activator.CreateInstance(type) as IHostService;
                await instance?.ExecuteAsync(); // Metodu işə sal
            }
            return services;
        }
    }
}

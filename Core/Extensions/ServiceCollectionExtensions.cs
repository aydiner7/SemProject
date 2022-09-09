using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Eklenecek tüm injectionsları tek bir yerde kontrol edebildiğim nokta
        // this: genişletmek istediğim 
        // 

        // IServiceCollection : API nin servis bağımlılıklarını veya araya girmesini istediğimiz koleksiyonumuz.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            // Oluşturulan tüm servisleri 
            return ServiceTool.Create(serviceCollection);
        }
    }
}

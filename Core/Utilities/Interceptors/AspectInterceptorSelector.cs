using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            // Class ın attributelarını oku
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList(); 

            // Method un attributelarını oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            // Loglama alt yapısı kurulup, default olarak eklendiğinde, her yerde otomatik loglama aktif olacaktır.
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));


            // Çalışmasını öncelik değerine göre sırala.
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}

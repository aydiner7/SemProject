using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        // Injectionslarım için oluşturduğum interface.
        void Load(IServiceCollection serviceDescriptors);
        // oluşturduğumuz servisleri vereceğiz ve yükleme işlemi burada gerçekleşecek.
    }
}

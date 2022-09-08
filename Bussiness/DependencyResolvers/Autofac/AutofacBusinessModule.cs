using Autofac;
using Autofac.Extras.DynamicProxy;
using Bussiness.Abstract;
using Bussiness.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    // Module : Reflection değil, Autofac.
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // IUserService isteyene, UserManager instance ı verilir.
            // Data taşıma gibi işlemlerde kullanmayacaksak, SingleInstance.
            // SingleInstance 1 referans numarası oluşturup, her işlemde onu kullanır.
            // Bunu kullanma sebebim, sadece method çalışmak için ihtiyacım olması.

            //Teacher
            builder.RegisterType<TeacherManager>().As<ITeacherService>().SingleInstance();
            builder.RegisterType<EfTeacherDal>().As<ITeacherDal>().SingleInstance();
            //Lesson
            builder.RegisterType<LessonManager>().As<ILessonService>().SingleInstance();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>().SingleInstance();
            //User
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            //Url
            builder.RegisterType<UrlManager>().As<IUrlService>();
            builder.RegisterType<EfUrlDal>().As<IUrlDal>();
            //Ip Check
            builder.RegisterType<IpCheckManager>().As<IIpCheckService>();
            builder.RegisterType<EfIpCheckDal>().As<IIpCheckDal>();
            //Auth
            builder.RegisterType<AuthManager>().As<IAuthService>();
            //JWT
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();




            // Autofac aynı zamanda bize interceptors görevi verir. Tercih Sebebi.
            // Autofac tüm sınıflar için önce AspectInterceptorSelector ' ı çağır
            // Sınıflara ait Aspect var mı? kontrolü yapılır.


            // Çalışan uygulama içerisinde
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            // implemente edilmiş interfaceleri bul.
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    // onlar için AspectInterceptorSelector() ' ı çağır.
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

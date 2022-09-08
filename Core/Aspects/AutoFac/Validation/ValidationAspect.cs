using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.AutoFac.Validation
{
    /*
     * Interceptionlarla bellekte sadece referans tutarak,belleği yormadan
     * Methotlardan önce koşulları kontrol eder ve uygunsuzluk görürse hata kodu fırlatır.
     * Validate etmek : Doğrulamak.
     */

    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // Gelen typeof Validator, IValidator mu kontrol ediyor.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }

        // Doğrulama işlemi ne zaman yapılacak? OnBefore : Method çalışmadan önce.
        protected override void OnBefore(IInvocation invocation)
        {
            // Reflacation : Çalışma anında araya gir ve çalıştır. Instance oluştur.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            // Validatorun çalışma tipini bul.
            // BaseType : AbstractValidator, Argümanlardan ilkini bul ( <Lesson>, <Teacher> ... )
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            // İnvocation : Method. 
            // Tipe ait parametreleri bul.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            /*   Tüm parametleri gez ve doğrula.
                 Projede tek parametre kullanıldı fakat 
                 daha fazla kullanılması durumunda problemsiz çalışacaktır. */
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
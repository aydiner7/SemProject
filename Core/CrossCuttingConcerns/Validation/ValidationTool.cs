using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        /*
         * Her şeyin base i object olduğu için türünü object girdim.
         * Cross Cutting Concerns : Layerlar arası kesişimi sağlayamak
         * Veri kontrolünü sağlamak için oluşturmuş oldugum kuralları karşılanıp, karşılanmadığını kontrol eder.
         */

        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        //ValidationTool.Validate(new LessonValidator(), lesson)    // Aspect Öncesi kullanım şekli

            // Generic Yapıya Döndü.

        //var context = new ValidationContext<Lesson>(lesson);
        //LessonValidator lessonValidator = new LessonValidator();
        //var result = lessonValidator.Validate(lesson);
        //if (!result.IsValid)
	    //      {
        //            throw new ValidationException(result.Errors);
        //      }
    }
}

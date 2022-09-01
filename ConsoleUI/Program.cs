using Bussiness.Abstract;
using Bussiness.Concrete;
using Bussiness.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TeacherTest();

            //LessonTest();

            //IpCheckTest();

            //ValidatorTest();

            LessonManager lessonManager = new LessonManager(new EfLessonDal(), new TeacherManager(new EfTeacherDal()));
            var result = lessonManager.GetLessonDetails();
            if (result.Success)
            {
                Console.WriteLine("\t"+result.Message+"\n");
                foreach (var item in result.Data)
                {
                    Console.WriteLine("{0}, {1} dersi veriyor.", item.TeacherName, item.Name);
                }
            }

        }

        private static void ValidatorTest()
        {
            Lesson lesson = new Lesson
            {
                TeacherId = 3,
                Name = "CR"
            };

            LessonValidator validator = new LessonValidator();
            ValidationResult results = validator.Validate(lesson);

            if (!results.IsValid)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    Console.WriteLine($"{failure.ErrorMessage}");
                }
            }
        }

        private static void IpCheckTest()
        {
            IpCheckManager ipCheckManager = new IpCheckManager(new EfIpCheckDal());
            foreach (var item in ipCheckManager.GetAll().Data)
            {
                Console.WriteLine(item.IpAdres);
            }
        }

        private static void LessonTest()
        {
            LessonManager lessonManager = new LessonManager(new EfLessonDal(), new TeacherManager(new EfTeacherDal()));
            foreach (var item in lessonManager.GetLessonDetails().Data)
            {
                Console.WriteLine(item.TeacherName);
            }
        }

        private static void TeacherTest()
        {
            Teacher t1 = new Teacher
            {
                TeacherName = "Ünal Binbaşı"
            };



            TeacherManager teacherManager = new TeacherManager(new EfTeacherDal());
            var result = teacherManager.Add(t1);
            if (result.Success)
            {
                Console.WriteLine(result.Message + "\n");
                foreach (var item in teacherManager.GetAll().Data)
                {
                    Console.WriteLine(item.TeacherName);
                }
            }
        }
    }
}

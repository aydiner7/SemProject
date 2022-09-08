using Bussiness.Abstract;
using Bussiness.BussinessAspect.Autofac;
using Bussiness.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class LessonManager : ILessonService
    {

        ILessonDal _lessonDal;
        ITeacherService _teacherService;

        public LessonManager(ILessonDal lessonDal, ITeacherService teacherService)
        {
            _lessonDal = lessonDal;
            _teacherService = teacherService;
        }

        public IResult Add(Lesson lesson)
        {
            IResult result = BusinessRules.Run(CheckIfLessonNameExists(lesson), CheckTotalOfLesson(lesson));
            if (result != null)
            {
                return result;
            }
            _lessonDal.Add(lesson);
            return new SuccessResult();
        }

        public IResult Delete(Lesson lesson)
        {
            _lessonDal.Delete(lesson);
            return new SuccessResult();
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<Lesson>> GetAll()
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll());
        }

        public IDataResult<Lesson> GetById(int lessonId)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(l => l.Id == lessonId));    
        }

        public IDataResult<Lesson> GetByLessonName(string lessonName)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(l => l.Name == lessonName));
        }

        public IDataResult<List<Lesson>> GetByTeacherId(int teacherId)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(l => l.TeacherId == teacherId));
        }

        public IDataResult<List<LessonDetailDto>> GetLessonDetails()
        {
            return new SuccessDataResult<List<LessonDetailDto>>(_lessonDal.GetLessonDetails(),Messages.LessonDetailsListed);
        }

        public IResult Update(Lesson lesson)
        {
            _lessonDal.Update(lesson);
            return new SuccessResult();
        }

        private IResult CheckIfLessonNameExists(Lesson lesson)
        {
            var result = _lessonDal.Get(p => p.Name == lesson.Name);
            if (result != null)
            {
                IResult result2 = BusinessRules.Run(CheckTotalOfLesson(lesson));
                if (result2 != null)
                {
                    return result2;
                }
                result.TeacherId = lesson.TeacherId;
                _lessonDal.Update(result);
                return new ErrorResult("Eklenemedi, Güncellendi.");
            }
            return new SuccessResult();
        }

        private IResult CheckTotalOfLesson(Lesson lesson)
        {
            var result = _lessonDal.GetAll(p => p.TeacherId == lesson.TeacherId).Count;
            if (result >= 2)
            {
                return new ErrorResult("Bir Öğretmene 2 den fazla ders atanamaz.");
            }
            return new SuccessResult();
        }
    }
}

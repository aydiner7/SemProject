using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
    public interface ILessonService
    {
        IResult Add(Lesson lesson);

        IResult Delete(Lesson lesson);

        IResult Update(Lesson lesson);

        IDataResult<List<Lesson>> GetAll();

        IDataResult<Lesson> GetById(int userId);

        IDataResult<Lesson> GetByLessonName(string lessonName);

        IDataResult<List<Lesson>> GetByTeacherId(int teacherId);

        IDataResult<List<LessonDetailDto>> GetLessonDetails();
    }
}

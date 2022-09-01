using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLessonDal : EfEntityRepositoryBase<Lesson, SemContext>, ILessonDal
    {

        public List<LessonDetailDto> GetLessonDetails()
        {
            using (SemContext context = new SemContext())
            {
                var result = from l in context.Lessons
                             join t in context.Teachers
                             on l.TeacherId equals t.Id                             
                             select new LessonDetailDto
                             {
                                 Id = l.Id,
                                 Name = l.Name,
                                 TeacherName = t.TeacherName,
                                 DateTime = l.DateTime
                             };
                return result.ToList();

            }
        }
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
    public interface ITeacherService
    {
        IResult Add(Teacher teacher);

        IResult Delete(Teacher teacher);

        IResult Update(Teacher teacher);

        IDataResult<List<Teacher>> GetAll();

        IDataResult<Teacher> GetById(int userId);
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
    public interface IUrlService
    {
        IResult Update(Url url);

        IDataResult<List<Url>> GetAll();

        IDataResult<Url> GetById(int Id);
    }
}

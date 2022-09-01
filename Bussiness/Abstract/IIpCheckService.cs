using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
    public interface IIpCheckService
    {
        IResult Add(IpCheck ipCheck);

        IResult Delete(IpCheck ipCheck);

        IResult Update(IpCheck ipCheck);

        IDataResult<List<IpCheck>> GetAll();

        IDataResult<IpCheck> GetById(string Ip);
    }
}

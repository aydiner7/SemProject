using Bussiness.Abstract;
using Bussiness.BussinessAspect.Autofac;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class UrlManager : IUrlService
    {

        IUrlDal _urlDal;

        public UrlManager(IUrlDal urlDal)
        {
            _urlDal = urlDal;
        }

        
        public IDataResult<List<Url>> GetAll()
        {
            return new SuccessDataResult<List<Url>>(_urlDal.GetAll());
        }

        public IDataResult<Url> GetById(int Id)
        {
            return new SuccessDataResult<Url>(_urlDal.Get(u => u.Id == Id));
        }

        [ValidationAspect(typeof(UrlValidator))]
        //[SecuredOperation("admin")]
        public IResult Update(Url url)
        {
            _urlDal.Update(url);
            return new SuccessResult("Url Güncellendi.");
        }
    }
}

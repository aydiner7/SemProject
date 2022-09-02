using Bussiness.Abstract;
using Bussiness.BussinessAspect.Autofac;
using Bussiness.Constants;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class IpCheckManager : IIpCheckService
    {
        IIpCheckDal _ipCheckDal;

        public IpCheckManager(IIpCheckDal ipCheckDal)
        {
            _ipCheckDal = ipCheckDal;
        }

        [ValidationAspect(typeof(IpCheckValidator))]
        [SecuredOperation("admin")]
        public IResult Add(IpCheck ipCheck)
        {
            IResult result = BusinessRules.Run(CheckIfIpAdressExists(ipCheck));
            if (result != null)
            {
                return result;
            }
            _ipCheckDal.Add(ipCheck);
            return new SuccessResult(Messages.IpCheckControlAdded);
        }

        public IResult Delete(IpCheck ipCheck)
        {
            _ipCheckDal.Delete(ipCheck);
            return new SuccessResult();
        }

        public IDataResult<List<IpCheck>> GetAll()
        {
            return new SuccessDataResult<List<IpCheck>>(_ipCheckDal.GetAll());
        }

        public IDataResult<IpCheck> GetById(string Ip)
        {
            return new SuccessDataResult<IpCheck>(_ipCheckDal.Get(u => u.IpAdres == Ip));
        }

        [ValidationAspect(typeof(IpCheckValidator))]
        [SecuredOperation("admin")]
        public IResult Update(IpCheck ipCheck)
        {
            _ipCheckDal.Update(ipCheck);
            return new SuccessResult(Messages.IpCheckControlUptated);
        }


        private IResult CheckIfIpAdressExists(IpCheck ipCheck)
        {
            var result = _ipCheckDal.Get(p => p.IpAdres == ipCheck.IpAdres);
            if (result != null)
            {
                result.UrlAdres = ipCheck.UrlAdres;
                _ipCheckDal.Update(result);
                return new ErrorResult();
            }
            return new SuccessResult();
        }

    }
}

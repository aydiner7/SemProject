using Business.ValidationRules.FluentValidation;
using Bussiness.Abstract;
using Bussiness.BussinessAspect.Autofac;
using Bussiness.Constants;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Performance;
using Core.Aspects.AutoFac.Transaction;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Bussiness.Concrete
{
    public class TeacherManager : ITeacherService
    {
        ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        [SecuredOperation("teacher.add")]               // Yetkilendirme Kısayolum
        [ValidationAspect(typeof(TeacherValidator))]    // Kurallar Kısayolum
        [CacheRemoveAspect("ITeacherService.Get")]      // Veri üzerinde değişiklik olması durumunda
                                                        // Yeni veri eklendiğinde Get methodunu taşıyan
                                                        // tüm cashleri siler.
        public IResult Add(Teacher teacher)             
        {
            _teacherDal.Add(teacher);
            return new SuccessResult("Ekleme Başarılı");
        }

        public IResult Delete(Teacher teacher)
        {
            _teacherDal.Delete(teacher);
            return new SuccessResult();
        }

        // Cache 'i sadece sık kullanılan methodlara tanımladım.
        // Büyük data veya sık kullanılmayan methodlara tanımlamak belleği şişirebilir.
        [CacheAspect] // Key, Value  -- Default değeri 60 dakikadır. Verilen değer üzerinden x dakika sonra bellekten atılır.
        public IDataResult<List<Teacher>> GetAll()
        {
            return new SuccessDataResult<List<Teacher>>(_teacherDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        [CacheAspect]
        //[PerformanceAspect(10)]  // Bu methodun çalışması 5 saniyeyi geçerse beni uyar. /onbefore
        public IDataResult<Teacher> GetById(int teacherId)
        {
            return new SuccessDataResult<Teacher>(_teacherDal.Get(t => t.Id == teacherId), Messages.TeacherListed);
        }


        [ValidationAspect(typeof(TeacherValidator))]
        [CacheRemoveAspect("ITeacherService.Get")]
        public IResult Update(Teacher teacher)
        {
            _teacherDal.Update(teacher);
            return new SuccessResult();
        } 

        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Teacher teacher)
        {
            Add(teacher);
            if (teacher.TeacherName.Length < 5)
                throw new Exception("");
            Add(teacher);
            return null;
        }

    }
}




/* İş Motoru Kodlarımız */



///* Login Kontrol Kuralı */
//private IResult CheckLogin(string userName, string password)
//{
//    var result = _userDal.GetAll(u => u.UserFirstName == userName && u.UserIdNumber == password).Any();
//    if (!result)
//    {
//        return new ErrorResult(Messages.ErrorLogin);
//    }
//    return new SuccessResult();
//}


///* Kayıt Ol / Kullanıcı Adı Kuralı */
//private IResult CheckIfUserNameExists(string idNumber)
//{
//    var result = _userDal.GetAll(u => u.UserIdNumber == idNumber).Any();
//    if (result)
//    {
//        return new ErrorResult(Messages.UserNameAlreadyExists);
//    }
//    return new SuccessResult();
//}


//public ıdataresult<user> getlogin(user user)
//{
//    if (checklogin(user.userfirstname, user.userıdnumber).success)
//    {
//        return new successdataresult<user>(_userdal.get(u => u.userfirstname == user.userfirstname && u.userıdnumber == user.userıdnumber), messages.logined);
//    }
//    return new errordataresult<user>();
//}


//[SecuredOperation("user.add,admin")]
//[ValidationAspect(typeof(UserValidator))]
//public IResult Add(User user)
//{

//    IResult result = BusinessRules.Run(CheckIfUserNameExists(user.UserIdNumber));
//    if (result != null)
//    {
//        return result;
//    }
//    _userDal.Add(user);
//    return new SuccessResult(Messages.UserAdded);
//}



//public List<UserDetailDto> GetUserDetails()
//{
//    using (SemContext context = new SemContext())
//    {
//        var result = from us in context.Users
//                     join un in context.Units
//                     on us.UnitId equals un.UnitId
//                     select new UserDetailDto
//                     {
//                         UnitName = un.UnitName,
//                         UserFirstName = us.UserFirstName,
//                         UserId = us.UserId,
//                         UserIdNumber = us.UserIdNumber,
//                         UserLastName = us.UserLastName,
//                         UserRegisterNumber = us.UserRegisterNumber
//                     };
//        return result.ToList();
//    }
//}

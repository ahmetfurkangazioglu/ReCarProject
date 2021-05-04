using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal ıUserDal)
        {
            _userDal = ıUserDal;
        }

        [ValidationAspect(typeof(UserValidator))]      
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {         
           _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);          
        }

        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new ErrorResult(Messages.UserDeleted);
        }

      //  [SecuredOperation("user.list,admin,moderator")]
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserLİsted);
        }

       // [SecuredOperation("user.list,admin,moderator")]
        [CacheAspect]
        public IDataResult<User>GetByMail(string email)
        {
            return new SuccessDataResult<User>( _userDal.Get(u => u.Email == email),Messages.UserLİsted);
        }

      //  [SecuredOperation("user.list,admin,moderator")]
        public IDataResult<User> GetByUserId(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == Id),Messages.UserLİsted);
        }

      //  [SecuredOperation("user.list,admin,moderator")]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<User>> GetByEmail(string email)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Email == email), Messages.UserLİsted);
        }
    }
}

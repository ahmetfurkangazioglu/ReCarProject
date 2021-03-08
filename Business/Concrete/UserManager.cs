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
        IUserDal _IUserDal;

        public UserManager(IUserDal ıUserDal)
        {
            _IUserDal = ıUserDal;
        }

        [ValidationAspect(typeof(UserValidator))]      
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {         
           _IUserDal.Add(user);
            return new SuccessResult(Messages.UserAdded);          
        }

        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _IUserDal.Delete(user);
            return new ErrorResult(Messages.UserDeleted);
        }

        [SecuredOperation("user.list,admin,moderator")]
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_IUserDal.GetAll(), Messages.UserLİsted);
        }

        [SecuredOperation("user.list,admin,moderator")]
        [CacheAspect]
        public User GetByMail(string email)
        {
            return _IUserDal.Get(u => u.Email == email);
        }

        [SecuredOperation("user.list,admin,moderator")]
        public IDataResult<User> GetByUserId(int Id)
        {
            return new SuccessDataResult<User>(_IUserDal.Get(u => u.Id == Id),Messages.UserLİsted);
        }

        [SecuredOperation("user.list,admin,moderator")]
        public List<OperationClaim> GetClaims(User user)
        {
            return _IUserDal.GetClaims(user);
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _IUserDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}

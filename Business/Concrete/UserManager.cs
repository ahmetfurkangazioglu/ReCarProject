using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
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
        public IResult Add(User user)
        {         
           _IUserDal.Add(user);
            return new SuccessResult(Messages.UserAdded);          
        }

        public IResult Delete(User user)
        {
            _IUserDal.Delete(user);
            return new ErrorResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_IUserDal.GetAll(), Messages.UserLİsted);
        }

        public IDataResult<User> GetByUserId(int Id)
        {
            return new SuccessDataResult<User>(_IUserDal.Get(u => u.Id == Id),Messages.UserLİsted);
        }

        public IResult Update(User user)
        {
            _IUserDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}

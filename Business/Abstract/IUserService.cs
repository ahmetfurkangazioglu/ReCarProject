using Core.Entities.Concrete;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IResult PasswordUpdate(User user);
        IDataResult<User> GetByUserId(int Id);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<OperationClaim>> GetUserClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<User>> GetByEmail(string email);
        IDataResult<List<UserDetailDto>> GetUserDetailByUserId(int userId);

    }
}

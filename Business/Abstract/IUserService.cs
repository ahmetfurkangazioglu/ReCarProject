using Core.Entities.Concrete;
using Core.Utilities;
using Entities.Concrete;
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
        IDataResult<User> GetByUserId(int Id);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);

    }
}

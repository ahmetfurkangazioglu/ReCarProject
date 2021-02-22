﻿using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer> GetByUserId(int Id);
        IDataResult<List<Customer>> GetAll();
    }
}

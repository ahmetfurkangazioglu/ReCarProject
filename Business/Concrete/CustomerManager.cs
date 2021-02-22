using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _ICustomerDal;

        public CustomerManager(ICustomerDal ıCustomerDal)
        {
            _ICustomerDal = ıCustomerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length > 2)
            {
               _ICustomerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
            return new ErrorResult(Messages.CustomerNameError);
        }

        public IResult Delete(Customer customer)
        {
            _ICustomerDal.Delete(customer);
            return new ErrorResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_ICustomerDal.GetAll(), Messages.CustomerLİsted);
        }

        public IDataResult<Customer> GetByUserId(int Id)
        {
            return new SuccessDataResult<Customer>(_ICustomerDal.Get(u => u.CustomerId == Id), Messages.CustomerLİsted);
        }

        public IResult Update(Customer customer)
        {
            _ICustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}

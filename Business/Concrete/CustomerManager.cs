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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _ICustomerDal;

        public CustomerManager(ICustomerDal ıCustomerDal)
        {
            _ICustomerDal = ıCustomerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {        
               _ICustomerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);                       
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

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _ICustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}

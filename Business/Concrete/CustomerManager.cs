using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal ıCustomerDal)
        {
            _customerDal = ıCustomerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {        
               _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);                       
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new ErrorResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerLİsted);
        }

        public IDataResult<Customer> GetByUserId(int Id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(u => u.CustomerId == Id), Messages.CustomerLİsted);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail(), Messages.CustomerLİsted);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetailByUserId(int UserId)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail(u=>u.Id==UserId), Messages.CustomerLİsted);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}

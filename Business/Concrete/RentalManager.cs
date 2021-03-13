using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _IRentalDal;

        public RentalManager(IRentalDal ıRentalDal)
        {
            _IRentalDal = ıRentalDal;
        }

        [SecuredOperation("rental.add,admin,moderator")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(RentControl(rental.CarId));
            
            if (result!=null)
            {
                return result;
            }
            _IRentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("rental.delete,admin,moderator")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _IRentalDal.Delete(rental);
            return new ErrorResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_IRentalDal.GetAll(), Messages.RentalLİsted);
        }

        public IDataResult<Rental> GetByRentailId(int Id)
        {
            return new SuccessDataResult<Rental>(_IRentalDal.Get(u => u.Id == Id), Messages.RentalLİsted);
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_IRentalDal.GetRentalDetail(), Messages.RentalLİsted);
        }

        [SecuredOperation("rental.update,admin,moderator")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _IRentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        private IResult RentControl(int Id)
        {
            var result = _IRentalDal.GetAll(r => r.CarId == Id && r.ReturnDate == null);
            if (result.Count>0)
            {
                return new ErrorResult(Messages.RentalNameError);
            }
            return new SuccessResult();
        }
    }
}

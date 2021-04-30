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
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal ıRentalDal)
        {
            _rentalDal = ıRentalDal;
        }

       // [SecuredOperation("rental.add,admin,moderator")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(RentControl(rental.CarId));
            
            if (result!=null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("rental.delete,admin,moderator")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new ErrorResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetByRentalId(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(u => u.Id == Id), Messages.RentalListed);
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(), Messages.RentalListed);
        }

        [SecuredOperation("rental.update,admin,moderator")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult CheckRule(Rental rental)
        {

            IResult result = BusinessRules.Run(RentalRule(rental));

            if (result != null)
            {
                return result;
            }
            return new SuccessResult("Başarılı işlem");
        }




        private IResult RentalRule(Rental rental)
        {
            var result = _rentalDal.GetAll(r=>r.CarId==rental.CarId && 
            ((rental.RentDate >= r.RentDate || rental.ReturnDate >= r.RentDate)
            && rental.RentDate <= r.ReturnDate));
            if (rental.RentDate < DateTime.Now || result.Count>0)
            {
                return new ErrorResult("Bu araç seçili tarihler arasında kiralanmış, Lütfen başka bir tarih seçiniz.");
            }
            return new SuccessResult();
        }
        private IResult RentControl(int Id)
        {
            var result = _rentalDal.GetAll(r => r.CarId == Id && r.ReturnDate == null);
            if (result.Count>0)
            {
                return new ErrorResult(Messages.RentalNameError);
            }
            return new SuccessResult();
        }
    }
}

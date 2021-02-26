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
    public class RentalManager : IRentalService
    {
        IRentalDal _IRentalDal;

        public RentalManager(IRentalDal ıRentalDal)
        {
            _IRentalDal = ıRentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _IRentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
           
            if (result.Count>0)
            {
                return new ErrorResult(Messages.RentalNameError);
            }
            _IRentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _IRentalDal.Delete(rental);
            return new ErrorResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_IRentalDal.GetAll(), Messages.RentalLİsted);
        }

        public IDataResult<Rental> GetByRentailId(int Id)
        {
            return new SuccessDataResult<Rental>(_IRentalDal.Get(u => u.Id == Id), Messages.RentalLİsted);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_IRentalDal.GetRentalDetail(), Messages.RentalLİsted);
        }

        public IResult Update(Rental rental)
        {
            _IRentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}

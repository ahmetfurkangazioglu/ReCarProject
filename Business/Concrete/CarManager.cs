using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _ICarDal;

        public CarManager(ICarDal ıCarDal)
        {
            _ICarDal = ıCarDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {       
                _ICarDal.Add(car);
                return new SuccessResult(Messages.CarAdded);           
        }

        public IResult Delete(Car car)
        {
            _ICarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTimer);
            }         
            return new SuccessDataResult<List<Car>>(_ICarDal.GetAll(),Messages.CarLİsted);
        }

        public IDataResult< List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>> ( _ICarDal.GetCarDetail(),Messages.CarLİsted);
        }

        public IDataResult< List<Car>> GetCarsByBrandId(int BranId)
        {
            return new SuccessDataResult<List<Car>> (_ICarDal.GetAll(b => b.BrandId == BranId));
        }

        public IDataResult< List<Car>> GetCarsByColorId(int CarId)
        {
            return new SuccessDataResult<List<Car>> (_ICarDal.GetAll(b => b.CarId == CarId));
        }

        public IResult Update(Car car)
        {
            _ICarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        
    }
}

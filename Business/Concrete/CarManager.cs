using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Transaction;
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
        ICarDal _carDal;

        public CarManager(ICarDal ıCarDal)
        {
            _carDal = ıCarDal;
        }

        [SecuredOperation("admin,car.add,moderator")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {       
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);           
        }

        [SecuredOperation(" car.delete,moderator,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTimer);
            }         
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarLİsted);
        }

        public IDataResult< List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>> ( _carDal.GetCarDetail(),Messages.CarLİsted);
        }

        [CacheAspect]
        public IDataResult< List<CarDetailDto>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetail(b => b.BrandId == Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(b => b.ColorId == Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByCarId(int Id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(b => b.CarId == Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByFilter(int brandId,int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(b => b.BrandId == brandId && b.ColorId==colorId));
        }

        [SecuredOperation("admin,car.add,moderator")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                //must--> code refactoring 
                throw new Exception("Transaction Error");
            }
            Add(car);
            return null;
        }


    }
}

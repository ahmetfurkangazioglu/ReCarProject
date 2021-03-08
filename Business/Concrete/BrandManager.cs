using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public  class BrandManager : IBrandService
    {

        IBrandDal _BrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }

        [SecuredOperation("brand.add,moderator,admin")]
        [ValidationAspect(typeof(BrandValidator))]       
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _BrandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);                                                         
        }

        [SecuredOperation("brand.delete,moderator,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _BrandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        [CacheAspect]
        public IDataResult< List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_BrandDal.GetAll(), Messages.BrandLİsted);
        }

        public IDataResult< List<Brand>> GetBrandByBrandId(int BranId)
        {
            return new SuccessDataResult<List<Brand>> (_BrandDal.GetAll(b => b.BrandId == BranId));
        }

        [SecuredOperation("brand.update,moderator,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _BrandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}

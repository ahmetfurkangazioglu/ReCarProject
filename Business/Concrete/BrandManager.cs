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
   public  class BrandManager : IBrandService
    {

        IBrandDal _BrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _BrandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            return new ErrorResult(Messages.BrandNameError);
                                     
        }

        public IResult Delete(Brand brand)
        {
            _BrandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult< List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_BrandDal.GetAll(), Messages.BrandLİsted);
        }

        public IDataResult< List<Brand>> GetBrandByBrandId(int BranId)
        {
            return new SuccessDataResult<List<Brand>> (_BrandDal.GetAll(b => b.BrandId == BranId));
        }

        public IResult Update(Brand brand)
        {
            _BrandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}

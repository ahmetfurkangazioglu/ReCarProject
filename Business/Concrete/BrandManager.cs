using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class BrandManager : IBrandService
    {

        IBrandDal _BrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _BrandDal.Add(brand);
                Console.WriteLine("Brand is Added");
            }
            else
            {
                Console.WriteLine("Brand name cannot be smaller than 2");
            }
        }

        public void Delete(Brand brand)
        {
            _BrandDal.Delete(brand);
            Console.WriteLine("Brand is Deleted");
        }

        public List<Brand> GetAll()
        {
            return _BrandDal.GetAll();
        }

        public List<Brand> GetBrandByBrandId(int BranId)
        {
            return _BrandDal.GetAll(b => b.BrandId == BranId);
        }

        public void Update(Brand brand)
        {
            _BrandDal.Update(brand);
            Console.WriteLine("Brand is Updated");
        }
    }
}

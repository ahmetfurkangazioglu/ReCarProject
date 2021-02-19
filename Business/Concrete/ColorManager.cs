using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _ColorDal;

        public ColorManager(IColorDal colorDal)
        {
            _ColorDal = colorDal;
        }

        public void Add(Color color)
        {
            if (color.ColorName.Length>2)
            {
                _ColorDal.Add(color);
                Console.WriteLine("Color is Added");
            }
            else
            {
                Console.WriteLine("Color name cannot be smaller than 2 ");
            }
        }

        public void Delete(Color color)
        {
            _ColorDal.Delete(color);
            Console.WriteLine("Color is Deleted");
        }

        public List<Color> GetAll()
        {
            return _ColorDal.GetAll();
        }

        public List<Color> GetColorByColorId(int ColorId)
        {
            return _ColorDal.GetAll(c => c.ColorId == ColorId);
        }

        public void Update(Color color)
        {
            _ColorDal.Update(color);
            Console.WriteLine("Color is Updated");
        }
    }
}

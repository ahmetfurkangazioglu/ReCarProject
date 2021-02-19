using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
     public interface IColorService
    {
        List<Color> GetAll();
        List<Color> GetColorByColorId(int ColorId);
        void Add(Color brand);
        void Delete(Color brand);
        void Update(Color brand);
    }
}

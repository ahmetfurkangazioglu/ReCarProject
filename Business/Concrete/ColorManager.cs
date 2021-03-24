using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [SecuredOperation("color.add,admin,moderator")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {         
             _colorDal.Add(color);
             return new SuccessResult(Messages.ColorAdded);         
           
        }

        [SecuredOperation("color.delete,admin,moderator")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult< List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _colorDal.GetAll(),Messages.ColorLİsted);
        }

        public IDataResult< List<Color>> GetColorByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Color>> (_colorDal.GetAll(c => c.ColorId == ColorId));
        }

        [SecuredOperation("color.update,admin,moderator")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}

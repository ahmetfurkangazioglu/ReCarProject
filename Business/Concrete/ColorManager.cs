﻿using Business.Abstract;
using Business.Constants;
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
        IColorDal _ColorDal;

        public ColorManager(IColorDal colorDal)
        {
            _ColorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length>2)
            {
                _ColorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
            return new SuccessResult(Messages.ColordNameError);
        }

        public IResult Delete(Color color)
        {
            _ColorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult< List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _ColorDal.GetAll(),Messages.ColorLİsted);
        }

        public IDataResult< List<Color>> GetColorByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Color>> (_ColorDal.GetAll(c => c.ColorId == ColorId));
        }

        public IResult Update(Color color)
        {
            _ColorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
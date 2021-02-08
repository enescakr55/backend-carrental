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
        IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }

        public void Add(Color color)
        {
            _colordal.Add(color);
        }

        public void Delete(Color color)
        {
            _colordal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colordal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colordal.Get(c => c.ColorId == id);
        }

        public void Update(Color color)
        {
            _colordal.Update(color);
        }
    }
}

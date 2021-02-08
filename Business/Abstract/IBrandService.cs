using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int id);
        void Update(Brand brand);
        void Delete(Brand brand);
        void Add(Brand brand);
    }
}

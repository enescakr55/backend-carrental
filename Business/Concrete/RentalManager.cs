using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var GetRentals = _rentalDal.GetAll(rent=>rent.CarId == rental.CarId && (rent.ReturnDate == null || rent.ReturnDate > rental.RentDate));
            if(GetRentals.Count > 0)
            {
                return new ErrorResult(Messages.AracYok);
            }
            /* foreach (var rent in RentalGetir)
            {
                if(rent.CarId == rental.CarId && rent.ReturnDate == null)
                {
                    return new ErrorResult(Messages.AracYok);
                }
            } */
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}

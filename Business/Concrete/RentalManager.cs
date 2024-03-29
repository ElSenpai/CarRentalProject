﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerService _customerService;
        ICarService _carService;
        
        public RentalManager(IRentalDal rentalDal ,ICustomerService customerService,ICarService carService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
            _carService = carService;
            
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Rent(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckCarReturnDate(rental), CheckFindeks(rental.CarId,rental.CustomerId));

            if (result !=null)
            {
                return result;
            }
           

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Rented);



        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentOff);
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentList);

        }

        public IDataResult<Rental> GetByRentId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.RentGet);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDtos()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentList);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentUpdate);
        }
        private IResult CheckCarReturnDate(Rental rental)
        {
            var results = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var result in results)
            {
                if (result.ReturnDate==null||rental.RentDate<result.ReturnDate)
                {
                    return new ErrorResult(Messages.ReturnDateNull);
                }
            }
          return new SuccessResult();
           
            
        }
        private IResult CheckFindeks(int carFindeks,int customerFindeks)
        {
            var customerFin = _customerService.Findeks(customerFindeks);
            var carFin = _carService.Findeks(carFindeks);
            if (carFin.Data>customerFin.Data)
            {
                return new ErrorResult(Messages.FindeksFail);
            }
            return new SuccessResult(Messages.FindeksSuccess);
            
        }
       


    }
}

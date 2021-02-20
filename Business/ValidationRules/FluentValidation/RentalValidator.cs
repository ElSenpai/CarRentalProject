
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            
            RuleFor(r => r.ReturnDate).LessThan(r => r.RentDate);
            RuleFor(r => r.ReturnDate).Null();
            RuleFor(r => r.CarId).Must(ReturnDateForCarId).WithMessage(Messages.ReturnDateNull);
            
        }

        private bool ReturnDateForCarId(int arg)
        {
            IRentalDal rentaldal = new EfRentalDal();
            var result = rentaldal.GetAll(r => r.CarId == arg);
            if (result.Count>0)
            {
                return false;
            }

            return true;

        }
    }
}

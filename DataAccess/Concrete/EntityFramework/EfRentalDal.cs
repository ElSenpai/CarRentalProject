﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfRentalDal : EfEntityRepositoryBase<Rental,RentalContext > ,IRentalDal
    {  public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join u in context.Users
                             on r.UserId equals u.Id
                             join co in context.Customers
                             on r.CustomerId equals co.CustomerId
                             select new RentalDetailDto
                             {
                                 RentId=r.Id,
                                 CarId=c.Id,
                                 UserId=u.Id,
                                 CarName=c.CarName,

                                 UserName=u.FirstName+" "+u.LastName,
                                 
                                 RentDate=r.RentDate,
                                 ReturnDate= (DateTime)r.ReturnDate

                             };
                return result.ToList();
            }
                            
            }

        

        
    }
}
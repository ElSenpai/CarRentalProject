using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;

using System.Linq;

using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentalContext context =new RentalContext())
            {
                var result = from c in context.Cars
                                  join b in context.Brands
                                 on c.BrandId equals b.Id
                                  join o in context.Colors
                                  on c.ColorId equals o.Id
                            


                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 
                                 BrandName = b.BrandName+" "+c.CarName,
                                 ColorName = o.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 
                             };
                return result.ToList();
             
                            
            }
        }
    }
}

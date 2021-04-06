using Core.DataAccess.EntityFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentalContext context =new RentalContext())
            {
                var result = from c in filter == null ?  context.Cars : context.Cars.Where(filter)
                                  join b in context.Brands
                                  on c.BrandId equals b.Id
                                  join o in context.Colors
                                  on c.ColorId equals o.Id
                                 


                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId=c.BrandId,
                                 ColorId=c.ColorId,
                                 BrandModel =c.CarName,
                                 BrandName =b.BrandName,
                                 ColorName = o.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear=c.ModelYear,
                                 MinFindeks=c.MinFindeks
                                 
                             };
                return result.ToList();
             
                            
            }
        }
    }
}

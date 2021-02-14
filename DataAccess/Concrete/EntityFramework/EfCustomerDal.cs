using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserID equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.UserID,
                                 UserId = u.Id

                             };
                return result.ToList();
            }
        }
    }
}

using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOperationDal : IEntityRepository<OperationClaim>
    {
         //List<OperationClaim> OperationDto(Expression<Func<User, bool>> filter = null);
    }
}

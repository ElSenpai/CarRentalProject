using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserOperationService
    {
        IResult Add(UserOperationClaim uOperationClaim);

        IResult Update(UserOperationClaim uOperationClaim);
        IResult Delete(UserOperationClaim uOperationClaim);

        IDataResult<List<UserOperationClaim>> GetAll();
    }
}

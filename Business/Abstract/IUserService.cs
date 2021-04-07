using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService 

    {
        IResult Add(User user);
        IResult Update(User user,string password);
        IResult Delete(User user);
        IDataResult<User> GetByUserId(int id);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

    }
}

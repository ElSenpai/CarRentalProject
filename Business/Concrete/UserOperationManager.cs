using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserOperationManager : IUserOperationService
    {
        IUserOperationDal _uOperationDal;
        public UserOperationManager(IUserOperationDal uOperationDal)
        {
            _uOperationDal = uOperationDal;
        }

        public IResult Add(UserOperationClaim uOperationClaim)
        {
            _uOperationDal.Add(uOperationClaim);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(UserOperationClaim uOperationClaim)
        {
            _uOperationDal.Delete(uOperationClaim);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_uOperationDal.GetAll());
        }

        public IResult Update(UserOperationClaim uOperationClaim)
        {
            _uOperationDal.Update(uOperationClaim);
            return new SuccessResult(Messages.Updated);
        }
    }

}

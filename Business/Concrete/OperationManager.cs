using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OperationManager : IOperationService
    {
        IOperationDal _operationDal;
        public OperationManager(IOperationDal operationDal)
        {
            _operationDal = operationDal;
        }
        public IResult Add(OperationClaim operationClaim)
        {
            _operationDal.Add(operationClaim);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            _operationDal.Delete(operationClaim);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationDal.GetAll());
        }

        public IResult Update(OperationClaim operationClaim)
        {
            _operationDal.Update(operationClaim);
            return new SuccessResult(Messages.Updated);
        }
    }

}

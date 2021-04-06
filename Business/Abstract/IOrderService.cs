using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IOrderService
    {
        IResult Add(Order order);

        IResult Update(Order order);
        IResult Delete(Order order);
        IDataResult<List<Order>> GetAll();
    }
}

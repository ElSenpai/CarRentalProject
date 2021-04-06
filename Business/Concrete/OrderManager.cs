using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderdal;
        public OrderManager(IOrderDal orderdal)
        {
            _orderdal = orderdal;
        }
        public IResult Add(Order order)
        {
            _orderdal.Add(order);
            return new SuccessResult(Messages.OrderAdd);
        }

        public IResult Delete(Order order)
        {
            _orderdal.Delete(order);
            return new SuccessResult(Messages.OrderDelete);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderdal.GetAll());
        }

        public IResult Update(Order order)
        {
            _orderdal.Update(order);
            return new SuccessResult(Messages.OrderUpdate);
        }
    }
}

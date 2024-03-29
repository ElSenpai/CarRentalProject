﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICustomerService
    {
        



        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);


        IDataResult<Customer> GetByCustomerId(int id);
        IDataResult<List<Customer>> GetAllCustomers();
        IDataResult<int> Findeks(int cusId);
    }
}

﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        Car GetByCarId(int id);
        List<Car> GetAllCars();

        List<CarDetailDto> GetCarDetailDtos();





    }
}

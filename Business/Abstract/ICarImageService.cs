using Core.Utilities.FileUploads;
using Core.Utilities.Results;
using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService
    {
        IResult Add(FileTools file, CarImage carImage);
        IResult Update(FileTools file, CarImage carImage);
        IResult Delete( CarImage carImage);
        IDataResult<List<CarImage>> GetById(int id);
        IDataResult<List<CarImage>> GetByCarId(int id);
        IDataResult<List<CarImage>> GetAll();

    }
}

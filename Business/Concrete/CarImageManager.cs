using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileUploads;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Business.Concrete
{
   public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(FileTools file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarIMageAmount(carImage.CarId));

            if (result != null)
            {
                return new ErrorResult(Messages.ImagesCantAdded);
            }

           var pathResult= FileHelper.Add(file);
            carImage.ImagePath = pathResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImagesAdded);

            
        }

        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.Id == carImage.Id);
            FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);

        }
        public IResult Update(FileTools file, CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.Id == carImage.Id);
            var result1 = FileHelper.Update(file, result.ImagePath);
            carImage.ImagePath = result1.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }




        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            if (result.ImagePath==null)
            {
                List<CarImage> Cimage = new List<CarImage>();
                Cimage.Add(new CarImage { CarId = id, ImagePath = @"\images\Default.jpg" });
                return new SuccessDataResult<List<CarImage>>(Cimage);

            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(b=>b.Id==id));
        }

        

        

        private IResult CheckCarIMageAmount(int CarId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == CarId);

            if (result.Count > 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();

        }

    }
}

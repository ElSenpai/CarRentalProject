using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());


            //carManager.Add(new Car { Id = 1, CarName = "A3", BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2005 });
            //carManager.Add(new Car { Id = 2, CarName = "R8 LMS Gt3", BrandId = 1, ColorId = 2, DailyPrice = 1000, ModelYear = 2020 });
            //carManager.Add(new Car { Id = 3, CarName = "Mustang", BrandId = 2, ColorId = 1, DailyPrice = 700, ModelYear = 1970 });
            //carManager.Add(new Car { Id = 4, CarName = "Yaris", BrandId = 3, ColorId = 3, DailyPrice = 70, ModelYear = 2000 });
            //carManager.Add(new Car { Id = 5, CarName = "gibi", BrandId = 2, ColorId = 1, DailyPrice = 170, ModelYear = 2010 });
            //colorManager.Add(new Color { ColorId = 1, ColorName = "Siyah" });
            //colorManager.Add(new Color { ColorId = 4, ColorName = "Mor" });
            //colorManager.Add(new Color { ColorId = 2, ColorName = "Kırmızı" });
            //colorManager.Add(new Color { ColorId = 3, ColorName = "Bayaz" });
            //brandManager.Add(new Brand { BrandId = 1, BrandName = "Audi" });
            //brandManager.Add(new Brand { BrandId = 2, BrandName = "Ford" });
            //brandManager.Add(new Brand { BrandId = 3, BrandName = "Toyota" });
            //brandManager.Add(new Brand { BrandId = 5, BrandName = "Toyotax" });
            //brandManager.Add(new Brand { BrandId = 4, BrandName = "BMX" });

            //carManager.Update(new Car { Id = 2, CarName = "R8", BrandId = 1, ColorId = 2, DailyPrice = 1000, ModelYear = 2020 });
            //colorManager.Update(new Color { ColorId = 3, ColorName = "Beyaz" });
           // brandManager.Update(new Brand { BrandId = 3, BrandName = "Toyota" });

            // carManager.Delete(new Car {Id=5 });
            //colorManager.Delete(new Color {ColorId=4 });
            //brandManager.Delete(new Brand { BrandId=5});
            foreach (var colors in colorManager.GetAllColors())
            {
                Console.WriteLine(colors.ColorName);
            }
            Console.WriteLine("----");
            foreach (var cars in carManager.GetAllCars())
            {
                Console.WriteLine(cars.CarName);
            }
            Console.WriteLine("----");

            foreach (var brands in brandManager.GetAllBrands())
            {
                Console.WriteLine(brands.BrandName);
            }

            Console.WriteLine("-------------");
            Console.WriteLine(carManager.GetByCarId(1).CarName);
            Console.WriteLine(colorManager.GetByColorId(2).ColorName);
            Console.WriteLine(brandManager.GetByBrandId(1).BrandName);
            Console.WriteLine("-----------");


            foreach (var cars in carManager.GetCarDetailDtos())
            {
               // Console.WriteLine(cars.CarName+ "  " + cars.BrandName+ "  " + cars.ColorName+ "  " + cars.DailyPrice);
               Console.WriteLine("{0} {1}  {2}  {3}",cars.CarName,cars.BrandName,cars.ColorName,cars.DailyPrice);
            }
            

            Console.WriteLine("----------------------");







           
        }
    }
}

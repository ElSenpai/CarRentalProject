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
            
           // carManager.Add(new Car { Id = 7, CarName = "A3", BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2005 });
           
            //colorManager.Add(new Color { ColorId = 4, ColorName = "Mavi" });
            
            //brandManager.Add(new Brand { BrandId = 4, BrandName = "BMX" });

            //carManager.Update(new Car { Id = 2, CarName = "R8", BrandId = 1, ColorId = 2, DailyPrice = 1000, ModelYear = 2020 });
            //colorManager.Update(new Color { ColorId = 3, ColorName = "Beyaz" });
            // brandManager.Update(new Brand { BrandId = 3, BrandName = "Toyota" });

            //carManager.Delete(new Car {Id=7 });
            //colorManager.Delete(new Color {ColorId=5 });
            //brandManager.Delete(new Brand { BrandId=5});

            //Console.WriteLine(colorManager.Add(new Color { ColorId=5,ColorName="Mavi"}).Message);
            foreach (var colors in colorManager.GetAllColors().Data)
            {
                Console.WriteLine(colors.ColorName);
            }
            Console.WriteLine("----");
            foreach (var cars in carManager.GetAllCars().Data)
            {
                Console.WriteLine(cars.CarName);
            }
            Console.WriteLine("----");

            foreach (var brands in brandManager.GetAllBrands().Data)
            {
                Console.WriteLine(brands.BrandName);
                
            }

            Console.WriteLine("-------------");
            Console.WriteLine(carManager.GetByCarId(1).Data.CarName);
            Console.WriteLine(colorManager.GetByColorId(2).Data.ColorName);
            Console.WriteLine(brandManager.GetByBrandId(1).Data.BrandName);
            Console.WriteLine("-----------");


            foreach (var cars in carManager.GetCarDetailDtos().Data)
            {
               // Console.WriteLine(cars.CarName+ "  " + cars.BrandName+ "  " + cars.ColorName+ "  " + cars.DailyPrice);
               Console.WriteLine("{0} {1}  {2}  {3}",cars.CarName,cars.BrandName,cars.ColorName,cars.DailyPrice);
            }
            

            Console.WriteLine("----------------------");
             
            
           
                
            








        }
    }
}

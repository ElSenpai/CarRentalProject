using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //CrudTest();
            //JoinTest();
            //RentTest();
            RentDetailTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //Console.WriteLine(rentalManager.Rent(new Rental { Id = 5, CarId = 5, CustomerId = 5, RentDate = DateTime.Now }).Message);

            //Console.WriteLine(rentalManager.Delete(new Rental { Id=5}).Message);

        }
        private static void RentDetailTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var item in rentalManager.GetRentalDetailDtos().Data)
            {
                Console.WriteLine("{0} {1}  {2}  {3} {4}  {5}  {6}", item.RentId, item.UserId, item.UserName, item.ReturnDate, item.RentDate, item.CarName, item.CarId);
            }
        }
        private static void RentTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            userManager.Add(new User { Id = 1, FirstName = "Engin", LastName = "Demirog", Email = "Engin@kodlama.io", Password = "ngn123dmrg_" });
            userManager.Add(new User { Id = 2, FirstName = "Ahmet Salih", LastName = "Ucar", Email = "Ahmet@kodlama.io", Password = "_hm_t123" });
            userManager.Add(new User { Id = 3, FirstName = "Kerem", LastName = "Varış", Email = "Kerem@kodlama.io", Password = "123456k_" });
            userManager.Add(new User { Id = 4, FirstName = "Kübra", LastName = "Terzi", Email = "Kubra@kodlama.io", Password = "k7712T1122" });
            userManager.Add(new User { Id = 5, FirstName = "Murat", LastName = "Kurtboğan", Email = "Murat@kodlama.io", Password = "MK12_Kurt" });

            customerManager.Add(new Customer { UserID = 1,  CompanyName = "Kodlamaİo" });
            customerManager.Add(new Customer { UserID = 2,  CompanyName = "null" });
            customerManager.Add(new Customer { UserID = 3,  CompanyName = "Google" });
            customerManager.Add(new Customer { UserID = 4,  CompanyName = "Apple" });
            customerManager.Add(new Customer { UserID = 5,  CompanyName = "Microsoft" });

            Console.WriteLine(rentalManager.Rent(new Rental { Id = 1, CarId = 1, CustomerId = 1,  RentDate = DateTime.Now }).Message);
            Console.WriteLine(rentalManager.Rent(new Rental { Id = 2, CarId = 2, CustomerId = 2, RentDate = DateTime.Now }).Message);
            Console.WriteLine(rentalManager.Rent(new Rental { Id = 3, CarId = 3, CustomerId = 3, RentDate = DateTime.Now }).Message);
            Console.WriteLine(rentalManager.Rent(new Rental { Id = 4, CarId = 4, CustomerId = 4, RentDate = DateTime.Now }).Message);
            Console.WriteLine(rentalManager.Rent(new Rental { Id = 15, CarId = 5, CustomerId = 5, RentDate = DateTime.Now }).Message);
        }
        private static void JoinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
           
            foreach (var cars in carManager.GetCarDetailDtos().Data)
            {
                // Console.WriteLine(cars.CarName+ "  " + cars.BrandName+ "  " + cars.ColorName+ "  " + cars.DailyPrice);
                Console.WriteLine("{0} {1}  {2}  {3}", cars.CarName, cars.BrandName, cars.ColorName, cars.DailyPrice);
            }




        }
        private static void CrudTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine(colorManager.Add(new Color { Id = 5, ColorName = "Mavi" }).Message);
            carManager.Add(new Car {Id = 7, CarName = "A3", BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2005 });
            colorManager.Add(new Color { Id = 4, ColorName = "Mavi" });
            brandManager.Add(new Brand {Id = 4, BrandName = "BMX" });
            carManager.Update(new Car { Id = 2, CarName = "R8", BrandId = 1, ColorId = 2, DailyPrice = 1000, ModelYear = 2020 });
            colorManager.Update(new Color { Id= 3, ColorName = "Beyaz" });
            brandManager.Update(new Brand { Id = 3, BrandName = "Toyota" });
            carManager.Delete(new Car { Id = 7 });
            colorManager.Delete(new Color { Id = 5 });
            brandManager.Delete(new Brand {Id = 5 });

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

        }
    }
}

using System;
using System.Collections.Generic;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //TestCarRentalApplication(carManager); // Test Car Rental Application
            //TestGetAllCars(carManager); //Test getting all cars in DB.
            //TestGetCarById(carManager, 1); //Test getting a car by ID.
            //TestGetCarByBrandId(carManager, 3); //Test getting cars by BrandID.
            //TestGetCarByColorId(carManager, 1); //Test getting cars by ColorID.
            //TestAddCar(carManager); //Test adding a car into DB.
            //TestDeleteCar(carManager); //Test deleting a car from DB.
            //TestUpdateCar(carManager); //Test updating a car in DB.
            //TestGetAllBrands(brandManager); // Test getting all brands in DB.
            //TestGetAllColors(colorManager); // Test getting all colors in DB.
            //TestProductDetails(carManager); // Test getting all details based on predefined DTO class.
            //TestAddCustomer(customerManager); //Test adding a customer into DB.
            //TestAddRental(rentalManager); //Test adding a rental into DB.
        }
        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    var result = carManager.GetCarDetails();
        //    if (result.Success == true)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine(car.CarName + " " + car.BrandName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }

        //}
        private static void TestGetAllCars(CarManager carManager)
        {
            IDataResult<List<Car>> result = carManager.GetAll();

            if (result.Success)
            {
                foreach (Car car in result.Data)
                {
                    Console.WriteLine(car.Id + "-" + car.CarName + "-" + car.DailyPrice + "-" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void TestGetCarById(CarManager carManager, int carId)
        {
            IDataResult<Car> result = carManager.GetById(carId);

            if (result.Success)
            {
                Console.WriteLine(result.Data.Id + "-" + result.Data.CarName + "-" + result.Data.DailyPrice + "-" + result.Data.Description);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void TestGetCarByBrandId(CarManager carManager, int brandId)
        {
            IDataResult<List<Car>> result = carManager.GetByBrandId(brandId);

            if (result.Success)
            {
                foreach (Car car in result.Data)
                {
                    Console.WriteLine(car.Id + "-" + car.CarName + "-" + car.DailyPrice + "-" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void TestGetCarByColorId(CarManager carManager, int colorId)
        {
            IDataResult<List<Car>> result = carManager.GetByColorId(colorId);

            if (result.Success)
            {
                foreach (Car car in result.Data)
                {
                    Console.WriteLine(car.Id + "-" + car.CarName + "-" + car.DailyPrice + "-" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void TestAddCar(CarManager carManager)
        {
            IResult result = carManager.Add(new Car { BrandId = 5, ColorId = 1, CarName = "Renault Megane", ModelYear = "2021", DailyPrice = 150, Description = "Renault Megane, Diesel, Automatic Transmission" });
            IResult result1 = carManager.Add(new Car { BrandId = 5, ColorId = 2, CarName = "Renault clio", ModelYear = "2020", DailyPrice = 100, Description = "Renault Clio, Gasoline, Manual gear " });
            Console.WriteLine(result.Message);
        }

        private static void TestDeleteCar(CarManager carManager)
        {
            IResult result = carManager.Delete(new Car { Id = 1004 });
            Console.WriteLine(result.Message);
        }

        private static void TestUpdateCar(CarManager carManager)
        {
            IResult result = carManager.Update(new Car { Id = 11, BrandId = 5, ColorId = 2, CarName = "Renault Symbol", ModelYear = "2016", DailyPrice = 100, Description = "Renault Symbol, Diesel, Manual Transmission" });
            Console.WriteLine(result.Message);
        }

        private static void TestGetAllColors(ColorManager colorManager)
        {
            IDataResult<List<Color>> result = colorManager.GetAll();

            foreach (Color color in result.Data)
            {
                Console.WriteLine(color.Id + "-" + color.ColorName);
            }
        }

        private static void TestGetAllBrands(BrandManager brandManager)
        {
            IDataResult<List<Brand>> result = brandManager.GetAll();

            foreach (Brand brand in result.Data)
            {
                Console.WriteLine(brand.Id + "-" + brand.BrandName);
            }
        }

        private static void TestProductDetails(CarManager carManager)
        {
            IDataResult<List<CarDetailDto>> result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (CarDetailDto car in result.Data)
                {
                    Console.WriteLine(car.CarName + "-" + car.BrandName + "-" + car.ColorName + "-" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void TestAddCustomer(CustomerManager customerManager)
        {
            IResult Result = customerManager.Add(new Customer { Id = 1, CompanyName = "Siemens" });
            Console.WriteLine(Result.Message);
        }

        public static void TestAddRental(RentalManager rentalManager)
        {
            //var Result = rentalManager.GetByRentalId(5);
            IResult Result = rentalManager.Add(new Rental { Id = 1, CustomerId = 4, RentDate = new DateTime(2021, 1, 20, 10, 30, 00), ReturnDate = new DateTime(2021, 2, 1, 15, 00, 00) });
            Console.WriteLine(Result.Message);
        }

        private static void TestCarRentalApplication(CarManager carManager)
        {
            Console.WriteLine("**********************************************\n" +
                              "***** Welcome to our car rent company!   *****\n" +
                              "***** You can view available cars below: *****\n" +
                              "**********************************************\n");

            IDataResult<List<Car>> result = carManager.GetAll();

            if (result.Success)
            {
                for (int i = 0; i < result.Data.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + result.Data[i].CarName + ", Model Year:" + result.Data[i].ModelYear + ", Daily Price:" + result.Data[i].DailyPrice + ", Description:" + result.Data[i].Description + "\n------------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}

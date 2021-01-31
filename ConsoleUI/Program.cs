using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("------- Id si 1 olan araba --------");
            Car car1 = carManager.GetById(1);
            Console.WriteLine("Id = {3} Açıklama : {0} - Günlük ücret : {1}TL - Model : {2}", car1.Description, car1.DailyPrice, car1.ModelYear,car1.Id);
            Console.WriteLine("\n\n---------Arabalar----------");
            List<Car> cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("Id = {3} Açıklama : {0} - Günlük ücret : {1}TL - Model : {2}", car.Description, car.DailyPrice, car.ModelYear, car.Id);
            }
            Car updateCar = new Car { Id = 1, BrandId = 2, ColorId = 3, DailyPrice = 500, Description = "Volkswagen", ModelYear = "2002" };
            carManager.Update(updateCar);
            Console.WriteLine("\n\n--------Id si 1 olan araba güncellendi-------");
            Console.WriteLine("------- Id si 1 olan araba --------");
            car1 = carManager.GetById(1);
            Console.WriteLine("Id = {3} Açıklama : {0} - Günlük ücret : {1}TL - Model : {2}", car1.Description, car1.DailyPrice, car1.ModelYear, car1.Id);
            Car carToDelete = new Car { Id = 2 };
            carManager.Delete(carToDelete);
            Console.WriteLine("\n\nId si 2 olan araba silindi");
            Console.WriteLine("---------Arabalar----------");
            cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("Id = {3} Açıklama : {0} - Günlük ücret : {1}TL - Model : {2}", car.Description, car.DailyPrice, car.ModelYear, car.Id);
            }
            Car carToAdd = new Car { BrandId = 5, ColorId = 3, DailyPrice = 350, Description = "Audi", Id = 5, ModelYear = "2006" };
            carManager.Add(carToAdd);
            Console.WriteLine("\n\nYeni araba eklendi");
            Console.WriteLine("---------Arabalar----------");
            cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("Id = {3} Açıklama : {0} - Günlük ücret : {1}TL - Model : {2}", car.Description, car.DailyPrice, car.ModelYear, car.Id);
            }

        }
    }
}

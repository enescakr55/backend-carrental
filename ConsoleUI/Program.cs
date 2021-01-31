using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("---------Arabalar----------");
            List<Car> cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("Açıklama : {0} - Günlük ücret : {1}TL - Model : {2}",car.Description,car.DailyPrice,car.ModelYear);
            }

        }
    }
}

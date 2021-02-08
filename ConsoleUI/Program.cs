using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static CarManager carManager = new CarManager(new EfCarDal());
        static BrandManager brandManager = new BrandManager(new EfBrandDal());
        static ColorManager colorManager = new ColorManager(new EfColorDal());
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                Console.WriteLine("İşlem seç \n1)Ekle \n2)Sil \n3)Güncelle \n4)Listele");
                int secim = Convert.ToInt32(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        try { Ekle(); } catch { Console.WriteLine("Bir hata oluştu"); };
                        break;
                    case 2:
                        try { Sil(); } catch { Console.WriteLine("Bir hata oluştu"); };
                        break;
                    case 3:
                        try { Guncelle(); } catch { Console.WriteLine("Bir hata oluştu"); };
                        break;
                    case 4:
                        Listele();
                        break;
                }
                Console.WriteLine("Çıkış yapmak ister misiniz : E/H");
                string rk = Console.ReadLine();
                if(rk == "E" || rk == "e")
                {
                    break;
                }
                Console.Clear();
            }
        }
        static void Ekle()
        {
            // 1: Araba 2:Marka 3:Renk
            Console.WriteLine("Eklenecek öğeyi seçin\n1)Araç \n2)Marka \n3)Renk");
            int secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    Console.WriteLine("Araç adı giriniz");
                    string carName = Console.ReadLine();
                    Listele(2);
                    Console.WriteLine("Marka id'si giriniz");
                    int brandId = Convert.ToInt32(Console.ReadLine());
                    Listele(3);
                    Console.WriteLine("Renk id'si giriniz");
                    int colorId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Araç model yılı giriniz");
                     string modelYear = Console.ReadLine();
                    Console.WriteLine("Aracın günlük ücretini giriniz");
                     decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Araç açıklaması");
                     string description = Console.ReadLine();
                     Car car = new Car { BrandId = brandId, CarName = carName, ColorId = colorId, DailyPrice = dailyPrice, Description = description, ModelYear = modelYear };
                     carManager.Add(car);
                     break;
                case 2:
                    Console.WriteLine("Marka ismi giriniz");
                    string brandName = Console.ReadLine();
                    Brand brand = new Brand { BrandName=brandName};
                    brandManager.Add(brand);
                    break;
                case 3:
                    Console.WriteLine("Renk girin");
                    string colorName = Console.ReadLine();
                    Color color = new Color { ColorName = colorName };
                    colorManager.Add(color);
                    break;
            }
        }
        static void Listele(int def=-1)
        {
            int secim;
            if(def == -1) { 
            Console.WriteLine("Listelenecek öğeyi seçin\n1)Araç \n2)Marka \n3)Renk");
            secim = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                secim = def;
            }
            switch (secim)
            {
                case 1:
                    Console.WriteLine("----------------------------------------------------ARAÇ LİSTESİ----------------------------------------------------");
                    CarManager carManager = new CarManager(new EfCarDal());
                    foreach (var car in carManager.GetCarDetails())
                    {
                        Console.WriteLine("\tAraç Id: {4}\tAraç Adı:{0}\tAraç Markası:{1}\tAraç Rengi:{2}\tKiralama Bedeli:{3}", car.CarName,car.BrandName,car.ColorName,car.DailyPrice,car.Id);
                    }
                    
                    break;
                case 2:
                    Console.WriteLine("----------------------------------------------------MARKA LİSTESİ----------------------------------------------------");
                    foreach (var brand in brandManager.GetAll())
                    {
                        Console.WriteLine("Marka Id : {0}\t Marka İsmi {1}",brand.BrandId,brand.BrandName);
                    }
                    break;
                case 3:
                    Console.WriteLine("----------------------------------------------------RENK LİSTESİ----------------------------------------------------");
                    foreach (var color in colorManager.GetAll())
                    {
                        Console.WriteLine("Renk Id : {0}\t Renk İsmi {1}", color.ColorId, color.ColorName);
                    }
                    break;
            }
        }
        static void Guncelle()
        {
            Console.WriteLine("Güncellenecek öğeyi seçin\n1)Araç \n2)Marka \n3)Renk");
            int secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    Listele(1);
                    Console.WriteLine("Güncellenecek Aracın Id'si");
                    int aracid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Araç adı giriniz");
                    string carName = Console.ReadLine();
                    Listele(2);
                    Console.WriteLine("Marka id'si giriniz");
                    int brandId = Convert.ToInt32(Console.ReadLine());
                    Listele(3);
                    Console.WriteLine("Renk id'si giriniz");
                    int colorId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Araç model yılı giriniz");
                    string modelYear = Console.ReadLine();
                    Console.WriteLine("Aracın günlük ücretini giriniz");
                    decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Araç açıklaması");
                    string description = Console.ReadLine();
                    Car car = new Car { Id=aracid,BrandId = brandId, CarName = carName, ColorId = colorId, DailyPrice = dailyPrice, Description = description, ModelYear = modelYear };
                    CarManager carManager = new CarManager(new EfCarDal());
                    carManager.Update(car);
                    break;
                case 2:
                    Listele(2);
                    Console.WriteLine("Güncellenecek Marka ID si girin");
                    int brid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Yeni marka adını girin");
                    string brname = Console.ReadLine();
                    Brand brand = new Brand { BrandId = brid, BrandName = brname };
                    brandManager.Update(brand);
                    break;
                case 3:
                    Listele(3);
                    Console.WriteLine("Güncellenecek Renk ID si girin");
                    int renkid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Yeni Renk adını girin");
                    string renkisim = Console.ReadLine();
                    Color color = new Color { ColorId = renkid, ColorName = renkisim };
                    colorManager.Update(color);
                    break;
            }
        }
        static void Sil()
        {
            Console.WriteLine("Silincek öğeyi seçin\n1)Araç \n2)Marka \n3)Renk");
            int secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    Listele(1);
                    Console.WriteLine("Silinecek Aracin Id sini girin");
                    int silinecekId = Convert.ToInt32(Console.ReadLine());
                    Car car = new Car
                    {
                        Id = silinecekId,
                    };
                    carManager.Delete(car);
                    break;
                case 2:
                    Listele(2);
                    Console.WriteLine("Silinecek Marka Id sini girin");
                    int silinecekbrId = Convert.ToInt32(Console.ReadLine());
                    Brand brand = new Brand
                    {
                        BrandId = silinecekbrId,
                    };
                    brandManager.Delete(brand);
                    break;
                case 3:
                    Listele(3);
                    Console.WriteLine("Silinecek Renk Id sini girin");
                    int silinecekrId = Convert.ToInt32(Console.ReadLine());
                    Color color = new Color
                    {
                        ColorId = silinecekrId,
                    };
                    colorManager.Delete(color);
                    break;
            }
        }
    }
}

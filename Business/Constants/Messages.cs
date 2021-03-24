using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Başarı ile eklendi.";
        public static string Deleted = "Başarı ile silindi.";
        public static string Updated = "Başarı ile güncellendi.";
        public static string List = "Başarı ile listelendi.";
        public static string CharLenght = "Karakter uzunluğu yetersiz.";
        public static string PriceMin = "Ücret 0 dan fazla olmalıdır.";
        public static string AracYok = "Seçtiğiniz tarihler arasında kiralama yapamıyoruz.";
        public static string ImageCountError = "Bir araç için maksimum 5 resim eklenebilir.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre yanlış";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserExists = "Bu kullanıcı zaten mevcut.";
        public static string UserRegistered = "Üyelik başarılı";
        public  static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkisiz erişim";
        // public static string UyeYok = "Böyle bir kullanıcı yok.";
    }
}

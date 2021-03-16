using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi.";
        public static string CarDeleted = "Araç silindi.";
        public static string CarUpdated = "Araç güncellemesi yapıldı.";
        public static string CarDataInvalid = "Araç verileri geçersiz.";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarRented = "Araç kiralandı.";
        public static string CarNotReturned = "Araç henüz iade edilmedi.";
        public static string MaintenanceTime = "Sistem şuan bakımda";
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerInvalid = "Müşteri verileri geçersiz.";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi.";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi.";
        public static string RentalDateTime = "Araç iade edildi";
        public static string CarImageCouldNotBeAdded = "Resim eklenemedi";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImageUpdated = "Resim güncellendi";
        public static string CarCountOfCarBrandError = "Bir markadan en fazla 8 adet olabilir.";
        public static string CarNameAlreadyExists = "Bu isimde başka bir araç var";
        public static string BrandLimitExists = "Aynı markadan en fazla 6 adet alınabilir.";
        public static string CarImageLimitExceeded = "Resim ekleme sınırı aşıldı.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt olundu.";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        internal static string BrandIdListed;
        internal static string BrandsListed;
        internal static string UsersListed;
        internal static string CustomerDeleted;
        internal static string CustomerUpdated;
    }
}

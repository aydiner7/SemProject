using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bussiness.Constants
{
    public static class Messages
    {
        public static string UserAdded = "Kişi eklendi.";
        public static string UserListed = "Kişiler Listelendi.";
        public static string UserDetailsListed = "Kişinin Detayları Listelendi.";
        public static string Logined = "Kullanıcı Girişi Başarılı.";
        public static string ErrorLogin = "Geçersiz Kullanıcı Bilgileri.";
        public static string UserNameAlreadyExists = "Geçersiz Kullanıcı Adı.";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
        public static string TeacherListed = "Ogretmen listelendi.";
        public static string IpCheckControlAdded = "IP adresine URL atamasi gerceklestirildi.";
        public static string IpCheckControlUptated = "IP adresine URL güncellemesi gerceklestirildi.";
        public static string SameAddressCantBeUsed = "Aynı IP Adresi sadece 1 kez kullanılabilir.";
        public static string LessonDetailsListed = "Dersler Detaylı Olarak Listelendi.";
    }
}

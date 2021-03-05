using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string Added = " Added";
        public static string Deleted = "Deleted";
        public static string Updated = "Updated";        
        public static string Lİsted = " Listed";


        public static string CarAdded = " Car Added";
        public static string CarDeleted = " Car Deleted";
        public static string CarUpdated = " Car Updated";
        public static string CarNameError = "car name cannot be smaller than 3 ";
        public static string MaintenanceTimer = "system is under maintenance";
        public static string CarLİsted = "Car Listed";


        public static string BrandAdded = " Brand Added";
        public static string BrandDeleted = " Brand Deleted";
        public static string BrandUpdated = " Brand Updated";
        public static string BrandNameError = "Brand name cannot be smaller than 3 ";
        public static string BrandLİsted = "Brand Listed";

        public static string ColorAdded = " Color Added";
        public static string ColorDeleted = " Color Deleted";
        public static string ColorUpdated = " Color Updated";
        public static string ColordNameError = "Color name cannot be smaller than 3 ";
        public static string ColorLİsted = "Color Listed";

        public static string UserAdded = " User Added";
        public static string UserDeleted = " User Deleted";
        public static string UserUpdated = " User Updated";
        public static string UserNameError = "User name cannot be smaller than 3 ";      
        public static string UserLİsted = " User Listed";

        public static string CustomerAdded = " Customer Added";
        public static string CustomerDeleted = " Customer Deleted";
        public static string CustomerUpdated = " Customer Updated";
        public static string CustomerNameError = "Customer name cannot be smaller than 3 ";
        public static string CustomerLİsted = " Customer Listed";

        public static string RentalAdded = " Rental Added";
        public static string RentalDeleted = " Rental Deleted";
        public static string RentalUpdated = " Rental Updated";
        public static string RentalNameError = "the car is currently rented ";
        public static string RentalLİsted = " Rental Listed";

        public static string CarImageLimitExceeded = "Araba resim limiti aşıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Girşi başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Hesap oluşturuldu";
        public static string AccessTokenCreated ="Access Token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Hata";
    }
}

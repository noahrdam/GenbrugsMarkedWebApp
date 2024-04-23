using System;
using Core.Model;
using ServerAPI.Repositories;

namespace PurchaseTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a sample purchase object
            var purchase = new Purchase
            {
                PurchaseId = 123,
                TotalPrice = 99.99,
                Advertisement = new Advertisement { AdvertisementId = 3, Name = "Bukser", Price = 149.95, Category = "Tøj", Description = "Et par blå bukser", Status = "Aktiv", IsAtEAA = true},
                User = new User { Email = "fawad@mail.dk", Username = "fawad123"},
                Classroom = new Classroom { ClassroomId = "A105.2", OpenHours = "12:30-13:30" }
            };

            // Create an instance of PurchaseRepository
            var repo = new PurchaseRepository();

            // Make the purchase
            repo.MakePurchase(purchase);

            Console.WriteLine("Purchase made successfully!");

            // Wait for user input before closing the console window
            Console.ReadLine();
        }
    }
}

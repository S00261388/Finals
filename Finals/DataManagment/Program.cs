using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Finals;

namespace DataManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RestaurantData db = new RestaurantData("OODExam_AdamBokobza");

            using (db)
            {
                Customer c1 = new Customer() { Name = "Tom Jones", ContactNumber = "086-123 4567" };
                Customer c2 = new Customer() { Name = "Mary Smith", ContactNumber = "086 546 3214" };
                Customer c3 = new Customer() { Name = "Jo Doyle", ContactNumber = "087 1221 222" };

                Booking b1 = new Booking() { BookingsDate = new DateTime(2024, 5, 13), NumberOfParticipants = 2 };
                Booking b2 = new Booking() { BookingsDate = new DateTime(2024, 4, 13), NumberOfParticipants = 1 };
                Booking b3 = new Booking() { BookingsDate = new DateTime(2024, 5, 13), NumberOfParticipants = 1 };

                c1.Bookings.Add(b1);
                c2.Bookings.Add(b2);
                c3.Bookings.Add(b3);

                db.Customers.Add(c1);
                db.Customers.Add(c2);
                db.Customers.Add(c3);

                db.SaveChanges();

                Console.WriteLine("Database saved !");
                Console.ReadKey();
            }
        
        }
    }
}

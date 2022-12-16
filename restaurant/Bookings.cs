﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace restaurant
{
    public class Bookings
    {
        private string bookingsFile = @"bookings.json";
        private List<Booking> bookings = new List<Booking>();

        public Bookings()
        {
            if (File.Exists(bookingsFile) == true)
            { // If stored json data exists then read
                string jsonBookings = File.ReadAllText(bookingsFile);
                bookings = JsonSerializer.Deserialize<List<Booking>>(jsonBookings);
            }
        }

        public Booking addBooking(string name, string date, string time, string amount)
        {
            Booking obj = new Booking(); // Create object of class Booking

            // Add user input to object 
            obj.Name = name;
            obj.Date = date;
            obj.Time = time;
            obj.Amount = amount;
            bookings.Add(obj);
            marshal(); // Call class method marshal
            return obj;
        }

        public int delBooking(int index)
        {
            bookings.RemoveAt(index); // Remove  at chosen index
            marshal();
            return index;
        }

        public List<Booking> getBookings()
        {
            // Return all bookings
            return bookings;
        }

        private void marshal()
        {
            // Serialize all the objects and save to file
            var jsonString = JsonSerializer.Serialize(bookings);
            File.WriteAllText(bookingsFile, jsonString);
        }
    }
}

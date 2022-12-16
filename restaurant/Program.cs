/*
    Admin for resaturant Glada Änkan.
    The datafiles,'*.json', created is in the format of Json.

    Written by Lina Petersson / Student at Mid Sweden University
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

using System.Text.Json;

namespace restaurant
{
    public class Menu
    {
        private string foodFile = @"food.json";
        private string drinkFile = @"drinks.json";
        private List<Food> foodMenu = new List<Food>();
        private List<Drink> drinkMenu = new List<Drink>();

        public Menu()
        {
            if(File.Exists(foodFile) == true)
            {   
                // If stored json data exists then read
                string jsonFood = File.ReadAllText(foodFile);
                foodMenu = JsonSerializer.Deserialize<List<Food>>(jsonFood);
            }

            if(File.Exists(drinkFile) == true)
            {
                // If stored json data exists then read
                string jsonDrinks = File.ReadAllText(drinkFile);
                drinkMenu = JsonSerializer.Deserialize<List<Drink>>(jsonDrinks);

            }
        }

        public Object addMenuItem(string category, string name, string desc, string price)
        {
            if (category == "m")
            {
                Food obj = new Food(); // Create object of class Food
                // Add user input to object 
                obj.Name = name;
                obj.Description = desc;
                obj.Price = price;

                foodMenu.Add(obj);
                marshal(); // Call class method marshal
                return obj;
            }
            else
            {
                Drink obj = new Drink(); // Create object of class Drink

                // Add user input to object 
                obj.Name = name;
                obj.Description = desc;
                obj.Price = price;

                drinkMenu.Add(obj);
                marshal(); // Call class method marshal
                return obj;
            }
        }

        public int delMenuItem(string category, int index)
        {
            if (category == "m")
            {
                foodMenu.RemoveAt(index); // Remove  at chosen index
                marshal();
            } 
            else
            {
                drinkMenu.RemoveAt(index); // Remove  at chosen index
                marshal();
            }
            return index;
        }

        public List<Food> getFoodMenu()
        {
            // Return full menu
            return foodMenu;
        }
        public List<Drink> getDrinkMenu()
        {
            // Return full menu
            return drinkMenu;
        }

        private void marshal()
        {
            // Serialize all the objects and save to file
            var jsonString = JsonSerializer.Serialize(foodMenu);
            File.WriteAllText(foodFile, jsonString);

            // Serialize all the objects and save to file
            var json = JsonSerializer.Serialize(drinkMenu);
            File.WriteAllText(drinkFile, json);
        }
    }

    public class Food
    {
        private string name;
        private string description;
        private string price;

        public string Name
        {
            set { this.name = value; } // Set input name input to class name
            get { return this.name; }
        }

        public string Description
        {
            set { this.description = value; } // Set input description to class description 
            get { return this.description; }
        }

        public string Price
        {
            set { this.price = value; } 
            get { return this.price; }
        }
    }

    public class Drink
    {
        private string name;
        private string description;
        private string price;

        public string Name
        {
            set { this.name = value; } // Set input name input to class name
            get { return this.name; }
        }

        public string Description
        {
            set { this.description = value; } // Set input description to class description 
            get { return this.description; }
        }

        public string Price
        {
            set { this.price = value; }
            get { return this.price; }
        }
    }

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
            // Return full menu
            return bookings;
        }

        private void marshal()
        {
            // Serialize all the objects and save to file
            var jsonString = JsonSerializer.Serialize(bookings);
            File.WriteAllText(bookingsFile, jsonString);
        }
    }

    public class Booking
    {
        private string name;
        private string date;
        private string time;
        private string amount;

        public string Name
        {
            set { this.name = value; } // Set input name input to class name
            get { return this.name; }
        }

        public string Date
        {
            set { this.date = value; } // Set input description to class description 
            get { return this.date; }
        }

        public string Time
        {
            set { this.time = value; }
            get { return this.time; }
        }
        public string Amount
        {
            set { this.amount = value; }
            get { return this.amount; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create object of class Menu and Bookings
            Menu menu = new Menu();
            Bookings bookings = new Bookings();

            // Declare variables
            int i = 0;
            int input = -1;
            int input2 = -1;
            int input3 = -1;

            while (true)
            {
                Console.Clear(); // Clear consol 
                Console.CursorVisible = false; // Hide cursor

                // Welcome user
                Console.WriteLine("ADMIN GLADA ÄNKAN");
                Console.WriteLine("Välkommen till administrationssystemet för restaurang Glada Änkan!");
                Console.WriteLine("\nHär kan du som personal hantera menyn, bokningar samt beställningar.");

                //Menu options
                Console.WriteLine("HUVUDMENY");
                Console.WriteLine("1. Hantera menyn");
                Console.WriteLine("2. Hantera bokningar");
                Console.WriteLine("3. Hantera beställningar");
                Console.WriteLine("X. Avsluta\n");

                input = (int)Console.ReadKey(true).Key; // Save users menu choice 

                switch (input)
                {
                    case '1':

                        //Menu options for menu
                        Console.WriteLine("MENY FÖR MAT OCH DRYCK");
                        Console.WriteLine("1. Visa menyn");
                        Console.WriteLine("2. Lägg till mat/ dryck");
                        Console.WriteLine("3. Radera mat/ dryck");
                        Console.WriteLine("X. Tillbaka\n");

                        // Let user stay in menu menu til user chooses to go back to main menu
                        while (input2 != 'X')
                        {
                            input2 = (int)Console.ReadKey(true).Key; // Save users menu choice

                            switch (input2)
                            {
                                case '1':
                                    Console.WriteLine("\n**** GLADA ÄNKANS MENY *****");
                                    Console.WriteLine("\nMAT:");
                                    // Loop through foodmenu and print 
                                    i = 0;
                                    foreach (Food food in menu.getFoodMenu())
                                    {
                                        Console.WriteLine("--------------------------------------------------------------------------------");
                                        Console.WriteLine("[" + i++ + "] " + food.Name + " " + food.Price + " kr");
                                        Console.WriteLine(food.Description);
                                    }

                                    Console.WriteLine("\n\nDRYCK:");
                                    // Loop through drinkmenu and print 
                                    i = 0;
                                    foreach (Drink drink in menu.getDrinkMenu())
                                    {
                                        Console.WriteLine("--------------------------------------------------------------------------------");
                                        Console.WriteLine("[" + i++ + "] " + drink.Name + " " + drink.Price + " kr");
                                        Console.WriteLine(drink.Description);
                                    }
                                    Console.CursorVisible = true;
                                    Console.Write("\n\nVälj nytt menyalternativ: ");
                                    break;
                                case '2':
                                    Console.CursorVisible = true;

                                    Console.Write("\nVill du lägga till mat eller dryck (m/d): ");
                                    string category = Console.ReadLine();

                                    // Control if input is correct
                                    if (category != "m" && category != "d")
                                    {
                                        Console.WriteLine("Du måste skriva m eller d. Försök igen");
                                        Console.Write("\nVill du lägga till mat eller dryck (m/d): ");
                                        category = Console.ReadLine();
                                    }

                                    // Ask user for input and save
                                    Console.Write("\nAnge namn på rätten/ drycken: ");
                                    string name = Console.ReadLine();

                                    // If input is empty print error message and ask for new input
                                    while (name == "")
                                    {
                                        Console.Write("\nDu måste ange ett korrekt namn. Försök igen");
                                        Console.Write("\nAnge namn: ");
                                        name = Console.ReadLine();
                                    }

                                    // Ask user for input and save 
                                    Console.Write("Ange beskrivning av rätten/ drycken: ");
                                    string description = Console.ReadLine();

                                    // If input is empty print error message and ask for new input
                                    while (description == "")
                                    {
                                        Console.Write("\nDin beskrivning kan inte vara tomt. Försök igen");
                                        Console.Write("\nAnge beskrivning: ");
                                        description = Console.ReadLine();
                                    }

                                    // Ask user for input and save 
                                    Console.Write("Ange pris på rätten/ drycken: ");
                                    string price = Console.ReadLine();

                                    // If input is empty print error message and ask for new input
                                    while (price == "")
                                    {
                                        Console.Write("\nPriset kan inte lämnas tomt. Försök igen");
                                        Console.Write("\nAnge pris: ");
                                        price = Console.ReadLine();
                                    }

                                    // Add food to menu
                                    if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(description) && !String.IsNullOrEmpty(price))
                                    {
                                        menu.addMenuItem(category, name, description, price);

                                        if (category == "m")
                                        {
                                            Console.WriteLine("\nRätten är sparad");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nDrycken är sparad");
                                        }
                                    }
                                    Console.WriteLine("\nVälj nytt menyalternativ: ");
                                    break;
                                case '3':
                                    Console.CursorVisible = true;
                                    Console.Write("\nVill du radera mat eller dryck (m/d): ");
                                    string cat = Console.ReadLine();

                                    // Control if input is correct
                                    if (cat != "m" && cat != "d")
                                    {
                                        Console.WriteLine("Du måste skriva m eller d. Försök igen");
                                        Console.Write("\nVill du radera mat eller dryck (m/d): ");
                                        cat = Console.ReadLine();
                                    }
                                    Console.Write("\nAnge index att radera: ");
                                    string index = Console.ReadLine();

                                    // Convert input to int and call method delMenuItem in class Menu
                                    i = Convert.ToInt32(index);
                                    menu.delMenuItem(cat, i);
                                    if(cat == "m")
                                    {
                                        Console.WriteLine("Rätten är nu borttagen från menyn");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Drycken är nu borttagen från menyn");
                                    }
                                    break;
                                case 88:
                                    break;
                            }
                        }
                        break;
                    case '2':
                        //Menu options for bookings
                        Console.WriteLine("MENY FÖR BOKNINGAR");
                        Console.WriteLine("1. Visa bokningar");
                        Console.WriteLine("2. Lägg till bokning");
                        Console.WriteLine("3. Radera bokning");
                        Console.WriteLine("X. Tillbaka\n");

                        // Let user stay in menu menu til user chooses to go back to main menu
                        while (input3 != 'X')
                        {
                            input3 = (int)Console.ReadKey(true).Key; // Save users menu choice

                            switch (input3)
                            {
                                case '1':
                                    Console.WriteLine("GLADA ÄNKANS BOKNINGAR");
                                    // Loop through menu and print 
                                    i = 0;
                                    foreach (Booking booking in bookings.getBookings())
                                    {
                                        Console.WriteLine("\n[" + i++ + "] ");
                                        Console.WriteLine(booking.Name + " (" + booking.Amount + " personer)");
                                        Console.WriteLine(booking.Date + " " + booking.Time);
                                    }
                                    Console.CursorVisible = true;
                                    Console.Write("\nVälj nytt menyalternativ: ");
                                    break;
                                case '2':
                                    Console.CursorVisible = true;
                                    // Ask user for input and save
                                    Console.Write("\nAnge namn: ");
                                    string name = Console.ReadLine();

                                    // If input is empty print error message and ask for new input
                                    while (name == "")
                                    {
                                        Console.Write("\nDu måste ange ett korrekt namn. Försök igen");
                                        Console.Write("\nAnge namn: ");
                                        name = Console.ReadLine();
                                    }

                                    // Ask user for input and save 
                                    Console.Write("Ange datum: ");
                                    string date = Console.ReadLine();

                                    // If input is empty print error message and ask for new input
                                    while (date == "")
                                    {
                                        Console.Write("\nDatumet kan inte vara tomt. Försök igen");
                                        Console.Write("\nAnge datum: ");
                                        date = Console.ReadLine();
                                    }

                                    // Ask user for input and save 
                                    Console.Write("Ange tid: ");
                                    string time = Console.ReadLine();

                                    // If input is empty print error message and ask for new input
                                    while (time == "")
                                    {
                                        Console.Write("\nTiden kan inte lämnas tomt. Försök igen");
                                        Console.Write("\nAnge tid: ");
                                        time = Console.ReadLine();
                                    }

                                    // Ask user for input and save 
                                    Console.Write("Ange antal personer: ");
                                    string amount = Console.ReadLine();

                                    // If input is empty print error message and ask for new input
                                    while (amount == "")
                                    {
                                        Console.Write("\nAntal personer måste anges. Försök igen");
                                        Console.Write("\nAnge antal personer: ");
                                        amount = Console.ReadLine();
                                    }

                                    // Add food to menu
                                    if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(date) && !String.IsNullOrEmpty(time) && !String.IsNullOrEmpty(amount))
                                    {
                                        bookings.addBooking(name, date, time, amount);
                                        Console.WriteLine("\nBokningen är sparad");
                                    }
                                    Console.Write("\nVälj nytt menyalternativ: ");
                                    break;
                                case '3':
                                    Console.CursorVisible = true;
                                    Console.Write("\nAnge index att radera: ");
                                    string index = Console.ReadLine();

                                    // Convert input to int and call method delFood in class Menu
                                    bookings.delBooking(Convert.ToInt32(index));
                                    Console.Write("\nBokningen är nu raderad");
                                    break;
                                case 88:
                                    break;
                            }
                        }
                        break;
                    case 88:
                        //Exit application
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
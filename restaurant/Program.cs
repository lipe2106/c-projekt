/*
    Admin for restaurant Glada Änkan.
    The datafiles,'*.json', created is in the format of Json.

    Written by Lina Petersson / Student at Mid Sweden University
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create object of class Menu and Bookings
            Menu menu = new Menu();
            Bookings bookings = new Bookings();
            Orders orders = new Orders();

            // Declare variables
            int i = 0;
            int input = -1;
            int menyInput;
            int bookingInput;
            int orderInput;

            while (true)
            {
                menyInput = -1;
                bookingInput = -1;
                orderInput = -1;

                Console.Clear(); // Clear consol 
                Console.CursorVisible = false; // Hide cursor

                // Welcome user
                Console.WriteLine("ADMIN GLADA ÄNKAN");
                Console.WriteLine("Välkommen till administrationssystemet för restaurang Glada Änkan!");
                Console.WriteLine("\nHär kan du som personal hantera menyn, bokningar samt beställningar.");

                //Menu options
                Console.WriteLine(); // Empty row
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
                        while (menyInput != 'X')
                        {
                            menyInput = (int)Console.ReadKey(true).Key; // Save users menu choice

                            switch (menyInput)
                            {
                                case '1':
                                    Console.WriteLine("\n*** GLADA ÄNKANS MENY ***");
                                    Console.WriteLine("\nMAT:");
                                    // Loop through foodmenu and print 
                                    i = 0;
                                    foreach (Food food in menu.GetFoodMenu())
                                    {
                                        Console.WriteLine("--------------------------------------------------------------------------------");
                                        Console.WriteLine("[" + i++ + "] " + food.Name + " " + food.Price + " kr");
                                        Console.WriteLine(food.Description);
                                    }

                                    Console.WriteLine("\n\nDRYCK:");
                                    // Loop through drinkmenu and print 
                                    i = 0;
                                    foreach (Drink drink in menu.GetDrinkMenu())
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
                                    Console.WriteLine("\nLÄGG TILL I MENYN");
                                    Console.Write("Vill du lägga till mat eller dryck (m/d): ");
                                    string category = Console.ReadLine();

                                    // Control if input is correct
                                    if (category != "m" && category != "d")
                                    {
                                        Console.WriteLine("Du måste skriva m eller d. Försök igen");
                                        Console.Write("\nVill du lägga till mat eller dryck (m/d): ");
                                        category = Console.ReadLine();
                                    }

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
                                    Console.Write("Ange beskrivning: ");
                                    string description = Console.ReadLine();

                                    // If input is empty print error message and ask for new input
                                    while (description == "")
                                    {
                                        Console.Write("\nDin beskrivning kan inte vara tomt. Försök igen");
                                        Console.Write("\nAnge beskrivning: ");
                                        description = Console.ReadLine();
                                    }

                                    // Ask user for input and save 
                                    Console.Write("Ange pris: ");
                                    string price = Console.ReadLine();

                                    // If input is empty print error message and ask for new input
                                    while (price == "")
                                    {
                                        Console.Write("\nPriset kan inte lämnas tomt. Försök igen");
                                        Console.Write("\nAnge pris: ");
                                        price = Console.ReadLine();
                                    }

                                    // Add food to menu
                                    if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(description) && !String.IsNullOrEmpty(price) && !String.IsNullOrEmpty(category))
                                    {
                                        menu.AddMenuItem(category, name, description, price);

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
                                    Console.Write("\nRADERA FRÅN MENYN");
                                    Console.Write("\nVill du radera mat eller dryck (m/d): ");
                                    string cat = Console.ReadLine();

                                    // Control if input is correct
                                    if (cat != "m" && cat != "d")
                                    {
                                        Console.WriteLine("Du måste skriva m eller d. Försök igen");
                                        Console.Write("\nVill du radera mat eller dryck (m/d): ");
                                        cat = Console.ReadLine();
                                    }

                                    Console.WriteLine(); // Empty row

                                    if (cat == "m")
                                    {
                                        i = 0;
                                        foreach (Food food in menu.GetFoodMenu())
                                        {
                                            Console.WriteLine("[" + i++ + "] " + food.Name + " " + food.Price + " kr");
                                        }
                                    }

                                    if (cat == "d")
                                    {
                                        i = 0;
                                        foreach (Drink drink in menu.GetDrinkMenu())
                                        {
                                            Console.WriteLine("[" + i++ + "] " + drink.Name + " " + drink.Price + " kr");
                                        }
                                    }

                                    Console.Write("\nAnge index att radera: ");
                                    string index = Console.ReadLine();

                                    // Convert input to int and call method delMenuItem in class Menu
                                    i = int.Parse(index);
                                    menu.DeleteMenuItem(cat, i);

                                    if (cat == "m")
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

                        // Let user stay in booking menu til user chooses to go back to main menu
                        while (bookingInput != 'X')
                        {
                            bookingInput = (int)Console.ReadKey(true).Key; // Save users menu choice

                            switch (bookingInput)
                            {
                                case '1':
                                    Console.WriteLine("\nGLADA ÄNKANS BOKNINGAR");
                                    // Loop through bookings and print 
                                    i = 0;
                                    foreach (Booking booking in bookings.GetBookings())
                                    {
                                        Console.WriteLine("\n[" + i++ + "] ");
                                        Console.WriteLine(booking.Name + " (" + booking.Amount + " personer)");
                                        Console.WriteLine(booking.Date + " " + booking.Time);
                                    }
                                    Console.CursorVisible = true;
                                    Console.Write("\nVälj nytt menyalternativ: ");
                                    break;
                                case '2':
                                    Console.WriteLine(); // Empty row
                                    Console.WriteLine("\nLÄGG TILL BOKNING");
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
                                        bookings.AddBooking(name, date, time, amount);
                                        Console.WriteLine("\nBokningen är sparad");
                                    }
                                    Console.Write("\nVälj nytt menyalternativ: ");
                                    break;
                                case '3':
                                    Console.WriteLine(); // Empty row
                                    Console.WriteLine("\nRADERA BOKNING");
                                    Console.WriteLine("Nuvarande bokningar: ");
                                    Console.WriteLine(); // Empty row

                                    // Loop through bookings and print 
                                    i = 0;
                                    foreach (Booking booking in bookings.GetBookings())
                                    {
                                        Console.WriteLine("[" + i++ + "] " + booking.Name + " (" + booking.Amount + " personer) " + booking.Date + " " + booking.Time);
                                    }

                                    Console.CursorVisible = true;
                                    Console.Write("\nAnge index att radera: ");
                                    string index = Console.ReadLine();

                                    // Convert input to int and call method delFood in class Menu
                                    bookings.DeleteBooking(Convert.ToInt32(index));
                                    Console.WriteLine("\nBokningen är nu raderad");
                                    Console.Write("\nVälj nytt menyalternativ: ");
                                    break;
                                case 88:
                                    break;
                            }
                        }
                        break;
                    case '3':
                        //Menu options for orders
                        Console.WriteLine("MENY FÖR BESTÄLLNINGAR");
                        Console.WriteLine("1. Lägg till beställning");
                        Console.WriteLine("2. Räkna ut totalsumma");
                        Console.WriteLine("X. Tillbaka\n");

                        // Let user stay in order menu til user chooses to go back to main menu
                        while (orderInput != 'X')
                        {
                            orderInput = (int)Console.ReadKey(true).Key; // Save users menu choice
                            string courseName;
                            string coursePrice;
                            int total = 0;

                            switch (orderInput)
                            {
                                case '1':
                                    Console.CursorVisible = true;
                                    // Ask user for input and save
                                    Console.Write("\nAnge bordsnr: ");
                                    string table = Console.ReadLine();

                                    // If input is incorrect print error message and ask for new input
                                    while (table != "1" && table != "2" && table != "3" && table != "4" && table != "5" && table != "6")
                                    {
                                        Console.Write("\nDu måste ange ett korrekt bordsnr. Försök igen");
                                        Console.Write("\nAnge bordsnr: ");
                                        table = Console.ReadLine();
                                    }

                                    // Ask user if the order is food or drink
                                    Console.Write("\nGäller beställningen mat eller dryck (m/d): ");
                                    string cat = Console.ReadLine();

                                    // Control if input is correct
                                    if (cat != "m" && cat != "d")
                                    {
                                        Console.WriteLine("Du måste skriva m eller d. Försök igen");
                                        Console.Write("\nGäller beställningen mat eller dryck (m/d): ");
                                        cat = Console.ReadLine();
                                    }

                                    // Show shorten menu for chosen category
                                    if (cat == "m")
                                    {
                                        Console.WriteLine("\nMAT:");
                                        // Loop through foodmenu and print 
                                        i = 0;
                                        foreach (Food food in menu.GetFoodMenu())
                                        {
                                            Console.WriteLine("--------------------------------------------------------------------------------");
                                            Console.WriteLine("[" + i++ + "] " + food.Name + " " + food.Price + " kr");
                                        }

                                        // Ask user what index to add
                                        Console.Write("\nAnge index för rätt att beställa: ");
                                        string index = Console.ReadLine();

                                        // If input is empty print error message and ask for new input
                                        while (index == "")
                                        {
                                            Console.Write("\nKorrekt index från menyn måste väljas. Försök igen");
                                            Console.Write("\nAnge index för rätt att beställa: ");
                                            index = Console.ReadLine();
                                        }

                                        // Convert input string to int
                                        int ind = int.Parse(index);

                                        // Get food menu, get specific course and save name and price
                                        var menuForFood = menu.GetFoodMenu();
                                        courseName = menuForFood[ind].Name;
                                        coursePrice = menuForFood[ind].Price;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n\nDRYCK:");
                                        // Loop through drinkmenu and print 
                                        i = 0;
                                        foreach (Drink drink in menu.GetDrinkMenu())
                                        {
                                            Console.WriteLine("--------------------------------------------------------------------------------");
                                            Console.WriteLine("[" + i++ + "] " + drink.Name + " " + drink.Price + " kr");
                                        }

                                        // Ask user what index to add
                                        Console.Write("\nAnge index för dryck att beställa: ");
                                        string index = Console.ReadLine();

                                        // If input is empty print error message and ask for new input
                                        while (index == "")
                                        {
                                            Console.Write("\nKorrekt index från menyn måste väljas. Försök igen");
                                            Console.Write("\nAnge index för dryck att beställa: ");
                                            index = Console.ReadLine();
                                        }

                                        // Convert input string to int
                                        int ind = int.Parse(index);

                                        // Get food menu, get specific course and save name and price
                                        var menuForDrinks = menu.GetDrinkMenu();
                                        courseName = menuForDrinks[ind].Name;
                                        coursePrice = menuForDrinks[ind].Price;
                                    }

                                    // Add to orders
                                    if (!String.IsNullOrEmpty(courseName) && !String.IsNullOrEmpty(coursePrice) && !String.IsNullOrEmpty(table))
                                    {
                                        orders.AddOrder(table, courseName, coursePrice);
                                        Console.WriteLine("\nBeställningen är lagd");
                                    }
                                    Console.Write("\nVälj nytt menyalternativ: ");
                                    break;
                                case '2':
                                    Console.WriteLine(); // Empty row
                                    Console.WriteLine("\nRÄKNA UT SUMMAN FÖR BORDET ATT BETALA");

                                    Console.Write("\nAnge bordsnr: ");
                                    table = Console.ReadLine();

                                    // If input is incorrect print error message and ask for new input
                                    while (table != "1" && table != "2" && table != "3" && table != "4" && table != "5" && table != "6")
                                    {
                                        Console.Write("\nDu måste ange ett korrekt bordsnr. Försök igen");
                                        Console.Write("\nAnge bordsnr: ");
                                        table = Console.ReadLine();
                                    }

                                    Console.WriteLine(); // Empty row
                                    Console.WriteLine("*** Kvitto för bord nr: " + table + " ***");

                                    i = 1;

                                    // Loop through orders and print 
                                    foreach (Order order in orders.GetOrders(table))
                                    {
                                        Console.WriteLine(i++ + ". " + order.Course + " " + order.Price + " kr");
                                        total += int.Parse(order.Price);
                                    }
                                    Console.WriteLine("\nSumma att betala: " + total + " kr");
                                    Console.CursorVisible = true;
                                    if (total != 0)
                                    {
                                        Console.Write("\nAvsluta bordets beställningar och skriv ut kvitto (y)? ");
                                        if (Console.ReadLine() == "y")
                                        {
                                            orders.DeleteOrders(table);
                                            Console.WriteLine("Bord nr " + table + " är nu avslutat.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nDet verkar inte som att bord nr " + table + " har beställt något än");
                                        Console.WriteLine("Testa lägg en beställning (1) eller välj ett annat bord (2).");
                                    }
                                    Console.Write("\nVälj nytt menyalternativ: ");
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
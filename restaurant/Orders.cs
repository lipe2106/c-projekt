using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace restaurant
{
    public class Orders
    {
        // Save json files for orders in strings
        private string table1 = @"table1.json";
        private string table2 = @"table2.json";
        private string table3 = @"table3.json";
        private string table4 = @"table4.json";
        private string table5 = @"table5.json";
        private string table6 = @"table6.json";

        // Create lists for orders
        private List<Order> tableOne = new List<Order>();
        private List<Order> tableTwo = new List<Order>();
        private List<Order> tableThree = new List<Order>();
        private List<Order> tableFour = new List<Order>();
        private List<Order> tableFive = new List<Order>();
        private List<Order> tableSix = new List<Order>();

        public Orders()
        {
            if (File.Exists(table1) == true)
            {
                // If stored json data exists then read
                string jsonOne = File.ReadAllText(table1);
                tableOne = JsonSerializer.Deserialize<List<Order>>(jsonOne);
            }

            if (File.Exists(table2) == true)
            {
                // If stored json data exists then read
                string jsonTwo = File.ReadAllText(table2);
                tableTwo = JsonSerializer.Deserialize<List<Order>>(jsonTwo);
            }

            if (File.Exists(table3) == true)
            {
                // If stored json data exists then read
                string jsonThree = File.ReadAllText(table3);
                tableThree = JsonSerializer.Deserialize<List<Order>>(jsonThree);
            }

            if (File.Exists(table4) == true)
            {
                // If stored json data exists then read
                string jsonFour = File.ReadAllText(table4);
                tableFour = JsonSerializer.Deserialize<List<Order>>(jsonFour);
            }

            if (File.Exists(table5) == true)
            {
                // If stored json data exists then read
                string jsonFive = File.ReadAllText(table5);
                tableFive = JsonSerializer.Deserialize<List<Order>>(jsonFive);
            }

            if (File.Exists(table6) == true)
            {
                // If stored json data exists then read
                string jsonSix = File.ReadAllText(table6);
                tableSix = JsonSerializer.Deserialize<List<Order>>(jsonSix);
            }
        }

        public List<Order> GetOrders(string table)
        {
            if (table == "1") return tableOne;
            if (table == "2") return tableTwo;
            if (table == "3") return tableThree;
            if (table == "4") return tableFour;
            if (table == "5") return tableFive;
            if (table == "6") return tableSix;
            else return tableOne;
        }

        public Object AddOrder(string table, string course, string price)
        {
            Order obj = new Order(); // Create object of class Order
            // Add input to object 
            obj.Course = course;
            obj.Price = price;
                
            if(table == "1") tableOne.Add(obj);
            if(table == "2") tableTwo.Add(obj);
            if(table == "3") tableThree.Add(obj);
            if(table == "4") tableFour.Add(obj);
            if(table == "5") tableFive.Add(obj);
            if(table == "6") tableSix.Add(obj);

            Marshal(table); // Call class method marshal
            return obj;
        }

        /*public int CalculateOrders(string table)
        {
            foreach (var tableOrders in GetOrders(table))
            {
                int total =+ int.Parse(tableOrders.Price);
            }
            return total;
        }
        */
        private void Marshal(string table)
        {
            if (table == "1")
            {
                // Serialize all the objects and save to file
                var jsonString = JsonSerializer.Serialize(tableOne);
                File.WriteAllText(table1, jsonString);
            }

            if (table == "2")
            {
                // Serialize all the objects and save to file
                var jsonString = JsonSerializer.Serialize(tableTwo);
                File.WriteAllText(table2, jsonString);
            }

            if (table == "3")
            {
                // Serialize all the objects and save to file
                var jsonString = JsonSerializer.Serialize(tableThree);
                File.WriteAllText(table3, jsonString);
            }

            if (table == "4")
            {
                // Serialize all the objects and save to file
                var jsonString = JsonSerializer.Serialize(tableFour);
                File.WriteAllText(table4, jsonString);
            }

            if (table == "5")
            {
                // Serialize all the objects and save to file
                var jsonString = JsonSerializer.Serialize(tableFive);
                File.WriteAllText(table5, jsonString);
            }

            if (table == "6")
            {
                // Serialize all the objects and save to file
                var jsonString = JsonSerializer.Serialize(tableSix);
                File.WriteAllText(table6, jsonString);
            }
        }
    }
}

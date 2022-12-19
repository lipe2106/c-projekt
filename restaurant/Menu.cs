using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace restaurant
{
    public class Menu
    {
        // Save json files for menu in strings
        private string foodFile = @"food.json";
        private string drinkFile = @"drinks.json";

        // Create lists for food and drink
        private List<Food> foodMenu = new List<Food>();
        private List<Drink> drinkMenu = new List<Drink>();

        public Menu()
        {
            if (File.Exists(foodFile) == true)
            {
                // If stored json food data exists then read
                string jsonFood = File.ReadAllText(foodFile);
                foodMenu = JsonSerializer.Deserialize<List<Food>>(jsonFood);
            }

            if (File.Exists(drinkFile) == true)
            {
                // If stored json drink data exists then read
                string jsonDrinks = File.ReadAllText(drinkFile);
                drinkMenu = JsonSerializer.Deserialize<List<Drink>>(jsonDrinks);
            }
        }

        public List<Food> GetFoodMenu()
        {
            // Return full menu
            return foodMenu;
        }
        public List<Drink> GetDrinkMenu()
        {
            // Return full menu
            return drinkMenu;
        }

        public Object AddMenuItem(string category, string name, string desc, string price)
        {
            if (category == "m")
            {
                Food obj = new Food(); // Create object of class Food
                // Add user input to object 
                obj.Name = name;
                obj.Description = desc;
                obj.Price = price;

                foodMenu.Add(obj);
                Marshal(); // Call class method marshal
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
                Marshal(); // Call class method marshal
                return obj;
            }
        }

        public int DeleteMenuItem(string category, int index)
        {
            if (category == "m")
            {
                foodMenu.RemoveAt(index); // Remove  at chosen index
                Marshal();
            }
            else
            {
                drinkMenu.RemoveAt(index); // Remove  at chosen index
                Marshal();
            }
            return index;
        }
        
        private void Marshal()
        {
            // Serialize all the objects and save to file
            var jsonString = JsonSerializer.Serialize(foodMenu);
            File.WriteAllText(foodFile, jsonString);

            // Serialize all the objects and save to file
            var json = JsonSerializer.Serialize(drinkMenu);
            File.WriteAllText(drinkFile, json);
        }
    }
}

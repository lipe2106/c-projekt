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
        private string foodFile = @"food.json";
        private string drinkFile = @"drinks.json";
        private List<Food> foodMenu = new List<Food>();
        private List<Drink> drinkMenu = new List<Drink>();

        public Menu()
        {
            if (File.Exists(foodFile) == true)
            {
                // If stored json data exists then read
                string jsonFood = File.ReadAllText(foodFile);
                foodMenu = JsonSerializer.Deserialize<List<Food>>(jsonFood);
            }

            if (File.Exists(drinkFile) == true)
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
}

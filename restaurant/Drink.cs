using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant
{
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
}

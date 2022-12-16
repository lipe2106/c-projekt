using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant
{
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
}

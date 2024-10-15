using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public class Direction
    {
        public Direction()
        {

        }
        public Direction(string from, string to, float distance, float price)
        {
            From = from;
            To = to;
            Distance = distance;
            Price = price;
        }

        public Direction(string from, string to)
        {
            From = from;
            To = to;
        }

        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public float Distance { get; set; }
        public float Price { get; set; }
    }
}

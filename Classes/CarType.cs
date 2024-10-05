using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Classes
{
    public class CarType
    {
        public CarType()
        {

        }
        public CarType(string type, float coefficient)
        {
            Type = type;
            Coefficient = coefficient;
        }

        public CarType(string type)
        {
            Type = type;
          
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public float Coefficient { get; set; }
    }
}

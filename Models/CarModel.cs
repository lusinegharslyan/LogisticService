using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public class CarModel
    {
        public CarModel()
        {

        }

        public CarModel(string model, float coefficient)
        {
            Model = model;
            Coefficient = coefficient;
        }

        public CarModel(string model)
        {
            Model = model;
           
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public float Coefficient { get; set; }
    }
}

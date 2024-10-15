using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.CalculationServices.Models
{
    public class CalculationModel
    {
        public CalculationModel(Direction direction, CarType carType, CarModel carModel, Container container, CrashedCar crashed)
        {
            Direction = direction;
            CarType = carType;
            CarModel = carModel;
            Container = container;
            Crashed = crashed;
        }

        public Direction Direction { get; set; }
        public CarType CarType { get; set; }
        public CarModel CarModel { get; set; }
        public Container Container { get; set; }
        public CrashedCar Crashed { get; set; }
    }
}

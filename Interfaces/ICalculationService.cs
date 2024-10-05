using LogisticService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Interfaces
{
    public interface ICalculationService
    {
        float LogisticserviceCalculation(Direction direction, CarType carType, CarModel carModel, Container container, CrashedCar crashed);
    }
}

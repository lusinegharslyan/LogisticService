using LogisticService.CalculationServices.Models;
using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.CalculationServices.Abstractions
{
    public interface ICalculationService
    {
         Task<float> LogisticServiceCalculation(CalculationModel calculationModel);
    }
}

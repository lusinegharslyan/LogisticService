using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public abstract class BaseModel
    {
    
    }

    public class CrashedCar
    {
        public CrashedCar()
        {

        }

        public CrashedCar(bool isCrashed, float coefficient)
        {
            IsCrashed = isCrashed;
            Coefficient = coefficient;
        }

        public CrashedCar(bool isCrashed)
        {
            IsCrashed = isCrashed;
            
        }

        public int Id { get; set; }
        public bool IsCrashed { get; set; }
        public float Coefficient { get; set; }
    }
}

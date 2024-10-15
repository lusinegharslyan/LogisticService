using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public class Container
    {
        public Container()
        {

        }

        public Container(bool isOpen, float coefficient)
        {
            IsOpen = isOpen;
            Coefficient = coefficient;
        }

        public Container(bool isOpen)
        {
            IsOpen = isOpen;
            
        }

        public int Id { get; set; }
        public bool IsOpen { get; set; }
        public float Coefficient { get; set; }
    }
}

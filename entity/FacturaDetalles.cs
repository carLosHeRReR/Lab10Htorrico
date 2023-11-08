using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity
{
    public class FacturaDetalles
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; } 
        public bool Active { get; set; }
    }
}

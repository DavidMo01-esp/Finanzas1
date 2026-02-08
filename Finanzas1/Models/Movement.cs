using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas1.Models
{

    public enum MovementType
    {
       Income, Expense
    }
   public class Movement
    {

        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public string Category { get; set; } = "";
        public DateTime Date { get; set; }
        public MovementType Type { get; set; }
        public string? Description { get; set; }
    }
}

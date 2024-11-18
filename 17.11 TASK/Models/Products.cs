using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17._11_TASK.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; } 

        public ICollection<Baskets> Baskets { get; set; }
    }
}

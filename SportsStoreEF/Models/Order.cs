using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string Adress { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool Shipped { get; set; }

        public IEnumerable<OrderLine> Lines { get; set; }
    }
}

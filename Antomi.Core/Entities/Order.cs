using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class Order : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public double TotalPrice { get; set; }
        public List<Order> Orders { get; set; }
    }
}

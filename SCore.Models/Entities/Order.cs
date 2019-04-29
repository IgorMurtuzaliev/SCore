using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCore.Models
{
    public class Order
    {
        public Order()
        {
            ProductOrders = new List<ProductOrder>();
        }

        public int OrderId { get; set; }
        public virtual ICollection<CartLine> Lines { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of order")]
        public DateTime TimeOfOrder { get; set; } = DateTime.Now;
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual List<ProductOrder> ProductOrders { get; set; }
    }
}

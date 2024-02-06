using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.order
{
    public class CreateOrderRequest
    {
        public string? PaymentId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public Double TotalAmount { get; set; }
        public Double GstAmount { get; set; }
        public Double ShippingAmount { get; set; }
    }
        
    public class OrderItemRequest
    {
        public string? OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int VariationId { get; set; }
    }
}

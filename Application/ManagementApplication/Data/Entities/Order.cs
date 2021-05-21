using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string InstrumentName { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingAddress { get; set; }
        public DateTime Date { get; set; }
        public int OrderNumber { get; set; }
        public string Status { get; set; }

        public Order()
        {

        }

        public Order(Order order)
        {
            this.OrderId = order.OrderId;
            this.FirstName = order.FirstName;
            this.LastName = order.LastName;
            this.Email = order.Email;
            this.InstrumentName = order.InstrumentName;
            this.Code = order.Code;
            this.Price = order.Price;
            this.Quantity = order.Quantity;
            this.BillingCity = order.BillingCity;
            this.BillingState = order.BillingState;
            this.BillingPostalCode = order.BillingPostalCode;
            this.BillingAddress = order.BillingAddress;
            this.Date = order.Date;
            this.OrderNumber = order.OrderNumber;
            this.Status = order.Status;
        }
    }
}

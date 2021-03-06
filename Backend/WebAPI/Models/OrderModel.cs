﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class OrderModel
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
    }
}

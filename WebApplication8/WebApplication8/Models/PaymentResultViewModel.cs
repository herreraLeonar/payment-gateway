using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class PaymentResultViewModel
    {
        public string Alias { get; set; }
        public string Status { get; set; }
        public string StatusName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CardholderName { get; set; }
    }
}
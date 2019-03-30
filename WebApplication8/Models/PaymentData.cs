using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class PaymentData
    {
        public string OrderId { get; set; }
        public string PaymentAmount { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Logo { get; set; }
        public string PSIPD { get; set; }
        public string Alias { get; set; }
        public string AliasUsage { get; set; }
        public string ReturnUrl { get; set; }
    }
}
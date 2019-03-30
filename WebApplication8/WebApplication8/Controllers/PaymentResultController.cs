using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;
using WebApplication8.Services;

namespace WebApplication8.Controllers
{
    public class PaymentResultController : Controller
    {
        public ActionResult Index()
        {
            //ACCEPTANCE Acceptance code returned by the acquirer
            //AMOUNT  Order amount(not multiplied by 100)
            //BRAND Card brand(our system derives this from the card number)
            //CARDNO Masked card number
            //CN Cardholder/ customer name
            //CURRENCY    Order currency
            //ED Expiry date
            //NCERROR Error code
            //ORDERID Your order reference
            //PAYID Payment reference in our system
            //PM Payment method
            //SHASIGN SHA signature calculated by our system(if SHA - OUT configured)
            //STATUS Transaction status(see Status overview)
            //TRXDATE Transaction date

            string status = Request.QueryString["STATUS"];
            string alias = Request.QueryString["ALIAS"];
            string cardNumber = Request.QueryString["CARDNO"];
            string expiryDate = Request.QueryString["ED"];
            string cardholderName = Request.QueryString["CN"];

            var paymentService = new PaymentService();
            var result = new PaymentResultViewModel
            {
                Status = status,
                StatusName = paymentService.GetStatusName(status),
                Alias = alias,
                CardNumber = cardNumber,
                ExpiryDate = expiryDate,
                CardholderName = cardholderName
            };

            return View(result);
        }
    }
}
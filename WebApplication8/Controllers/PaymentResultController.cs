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
            string status = Request.QueryString["STATUS"];
            var paymentService = new PaymentService();
            var result = new PaymentResultViewModel
            {
                Status = status,
                StatusName = paymentService.GetStatusName(status)
            };

            return View(result);
        }
    }
}
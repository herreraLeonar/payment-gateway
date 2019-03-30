using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Services
{
    public class PaymentService
    {
        // https://support.epdq.co.uk/en/guides/user%20guides/statuses-and-errors

        public string GetStatusName(string statusCode)
        {
            string statusName;
            bool hasStatus = int.TryParse(statusCode, out int statusId);

            if (hasStatus)
            {
                if (transactionResults.ContainsKey(statusId))
                    statusName = transactionResults[statusId];
                else
                    statusName = $"Unknown status code: {statusId}";
            }
            else
                statusName = "Invalid or missing status code";

            return statusName;
        }

        Dictionary<int, string> transactionResults = new Dictionary<int, string>
            {
                {0, "Invalid or incomplete"},
                {1, "Cancelled by customer"},
                {2, "Authorisation refused"},
                {4, "Order stored"},
                {40, "Stored waiting external result"},
                {41, "Waiting for client payment"},
                {46, "Waiting authentication"},
                {5, "Authorised"},
                {50, "Authorized waiting external result"},
                {51, "Authorisation waiting"},
                {52, "Authorisation not known"},
                {55, "Standby"},
                {56, "Ok with scheduled payments"},
                {57, "Not OK with scheduled payments"},
                {59, "Authorization to be requested manually"},
                {6, "Authorised and cancelled"},
                {61, "Author. deletion waiting"},
                {62, "Author. deletion uncertain"},
                {63, "Author. deletion refused"},
                {64, "Authorised and cancelled"},
                {7, "Payment deleted "},
                {71, "Payment deletion pending"},
                {72, "Payment deletion uncertain"},
                {73, "Payment deletion refused"},
                {74, "Payment deleted"},
                {8, "Refund "},
                {81, "Refund pending"},
                {82, "Refund uncertain"},
                {83, "Refund refused"},
                {84, "Refund"},
                {85, "Refund handled by merchant"},
                {9, "Payment requested"},
                {91, "Payment processing"},
                {92, "Payment uncertain"},
                {93, "Payment refused"},
                {94, "Refund declined by the acquirer"},
                {95, "Payment handled by merchant"},
                {96, "Refund reversed"},
                {99, "Being processed"}
            };
    }
}
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class PaymentsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Get([FromBody]PaymentData paymentData)
        {
            var sha = GetSha(paymentData);
            return Ok(sha);
        }

        private string GetSha(PaymentData data)
        {
            string plainDigest = GetPlainDigest(data);
            string sHA1HashData = SHA1HashData(plainDigest);
            return sHA1HashData;
        }

        private string GetPlainDigest(PaymentData data)
        {
            string strPW = "4ca20fd0-5813-44a0-a36f-f5ea1d853f6d";
            bool hasAlias = !string.IsNullOrWhiteSpace(data.Alias);
            string plainDigest = "";

            plainDigest += "ACCEPTURL=" + data.ReturnUrl + strPW;

            if (hasAlias)
            {
                plainDigest +=
                    "ALIAS=" + data.Alias + strPW +
                    "ALIASUSAGE=" + data.AliasUsage + strPW;
            }

            plainDigest +=
                "AMOUNT=" + data.PaymentAmount + strPW +
                "CANCELURL=" + data.ReturnUrl + strPW +
                "CURRENCY=" + data.Currency + strPW +
                "DECLINEURL=" + data.ReturnUrl + strPW +
                "EXCEPTIONURL=" + data.ReturnUrl + strPW +
                "LANGUAGE=" + data.Language + strPW +
                "LOGO=" + data.Logo + strPW +
                "ORDERID=" + data.OrderId + strPW +
                "PSPID=" + data.PSIPD + strPW +
                "";

            //OWNERADDRESS
            //OWNERZIP
            //OWNERTOWN
            //OWNERCTY
            //OWNERTELNO

            return plainDigest;
        }

        private string SHA1HashData(string plainDigest) // encryptor
        {
            SHA512 Hasher = SHA512.Create();
            byte[] NCodedtxt = Encoding.Default.GetBytes(plainDigest);
            byte[] HashedDataBytes = Hasher.ComputeHash(NCodedtxt);


            StringBuilder HashedDataStringBldr = new StringBuilder();
            for (int i = 0; i < HashedDataBytes.Length; i++)
            {
                HashedDataStringBldr.Append(HashedDataBytes[i].ToString("X2"));
            }

            return HashedDataStringBldr.ToString();
        }
    }
}
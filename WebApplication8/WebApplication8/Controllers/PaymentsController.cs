using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class PaymentsController : ApiController
    {
        string secret = "4ca20fd0-5813-44a0-a36f-f5ea1d853f6d";
        string plainDigest = "";

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
            AddToDigest("ACCEPTURL", data.ReturnUrl);
            AddToDigest("ALIAS", data.Alias);
            AddToDigest("ALIASUSAGE", data.AliasUsage);
            AddToDigest("AMOUNT", data.PaymentAmount);
            AddToDigest("CANCELURL", data.ReturnUrl);
            AddToDigest("CURRENCY", data.Currency);
            AddToDigest("DECLINEURL", data.ReturnUrl);
            AddToDigest("EXCEPTIONURL", data.ReturnUrl);
            AddToDigest("LANGUAGE", data.Language);
            AddToDigest("LOGO", data.Logo);
            AddToDigest("ORDERID", data.OrderId);
            AddToDigest("OWNERADDRESS", data.OwnerAddress);
            AddToDigest("OWNERCTY", data.OwnerCounty);
            AddToDigest("OWNERTELNO", data.OwnerTelephone);
            AddToDigest("OWNERTOWN", data.OwnerTown);
            AddToDigest("OWNERZIP", data.OwnerPostcode);
            AddToDigest("PSPID", data.PSIPD);

            return plainDigest;
        }

        private void AddToDigest(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
                plainDigest += $"{name}={value}{secret}";
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
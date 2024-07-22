using PosFix.DeveloperPortal.Core.Entity;
using PosFix.DeveloperPortal.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFix.DeveloperPortal.Core.Request
{
    public class PreAuthRequest:BaseRequest
    {
        public String ThreeD { get; set; }
        public String OrderId { get; set; }
        public String Amount { get; set; }
        public String CardOwnerName { get; set; }
        public String CardNumber { get; set; }
        public String CardExpireMonth { get; set; }
        public String CardExpireYear { get; set; }
        public String Installment { get; set; }
        public String CardCvc { get; set; }

        public String VendorId { get; set; }

        public String UserId { get; set; }

        public String CardId { get; set; }

        public String WaitingConfirmation { get; set; }

        public List<Product> Products { get; set; }

        public Purchaser Purchaser { get; set; }

        public static PreAuthResponse Execute(PreAuthRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey
                + request.OrderId
                + request.Amount
                + request.Mode
                + request.CardOwnerName
                + request.CardNumber
                + request.CardExpireMonth
                + request.CardExpireYear
                + request.CardCvc
                + request.UserId
                + request.CardId
                + request.Purchaser.Name
                + request.Purchaser.SurName
                + request.Purchaser.Email
                + options.TransactionDate;
            return RestHttpCaller.Create()
                .PostJson<PreAuthResponse>(options.BaseUrl + "/rest/payment/preauth", Helper.GetHttpHeaders(options, Helper.application_json),
                    request);
        }
    }
}

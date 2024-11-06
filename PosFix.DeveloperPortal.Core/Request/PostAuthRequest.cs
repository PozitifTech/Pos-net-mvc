using PosFix.DeveloperPortal.Core.Entity;
using PosFix.DeveloperPortal.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFix.DeveloperPortal.Core.Request
{
    public class PostAuthRequest:BaseRequest
    {  
        public String OrderId { get; set; }
        public String Amount { get; set; }
        public String ClientIp { get; set; }

        public static PostAuthResponse Execute(PostAuthRequest request, Settings options)
        {
            options.TransactionDate = Helper.GetTransactionDateString();
            options.HashString = options.PrivateKey
                + request.OrderId
                + request.Amount
                + request.Mode
                + request.ClientIp
                + options.TransactionDate;
            return RestHttpCaller.Create()
                .PostJson<PostAuthResponse>(options.BaseUrl + "/rest/payment/postauth", Helper.GetHttpHeaders(options, Helper.application_json),
                    request);
        }
    }
}

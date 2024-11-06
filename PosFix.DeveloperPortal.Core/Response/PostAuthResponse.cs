using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFix.DeveloperPortal.Core.Response
{
    public class PostAuthResponse:BaseResponse
    {
        public String Amount;
        public String OrderId;
        public String CommissionRate;
    }
}

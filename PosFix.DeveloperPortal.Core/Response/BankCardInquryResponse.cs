using System.Collections.Generic;
using PosFix.DeveloperPortal.Core.Entity;

namespace PosFix.DeveloperPortal.Core.Response
{
    /// <summary>
    /// Cüzdanda bulunan kartları getirmek için kullanılan servis çıktı parametrelerini temsil etmektedir.
    /// </summary>
    public class BankCardInquryResponse : BaseResponse
    {
        public List<BankCard> Cards { get; set; }
    }
}

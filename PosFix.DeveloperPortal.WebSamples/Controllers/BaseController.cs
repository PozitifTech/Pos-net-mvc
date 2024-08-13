using PosFix.DeveloperPortal.Core;
using Microsoft.AspNetCore.Mvc;

namespace PosFix.DeveloperPortal.WebSamples.Controllers
{
    public class BaseController : Controller
    {
        public Settings settings = new()
        {
            PublicKey = "", //"Public Magaza Anahtarı - size mağaza başvurunuz sonucunda gönderilen publik key (açık anahtar) bilgisini kullanınız.",

            PrivateKey = "", //"Private Magaza Anahtarı  - size mağaza başvurunuz sonucunda gönderilen privaye key (gizli anahtar) bilgisini kullanınız.",

            BaseUrl = "https://api.posfix.com.tr/", //PosFix web servisleri API url'lerinin başlangıç bilgisidir. Restful web servis isteklerini takip eden kodlar halinde bulacaksınız. Örneğin "https://api.posfix.com.tr/" + "/rest/payment/auth"  = "https://api.posfix.com.tr/rest/payment/auth"

            Version = "1.0", // Kullandığınız PosFix API versiyonudur.

            Mode = "T", // Test -> T, entegrasyon testlerinin sırasında "T" modunu, canlı sisteme entegre olarak ödeme almaya başlamak için ise Prod -> "P" modunu kullanınız.

            HashString = string.Empty // Kullanacağınız hash bilgisini, bağlanmak istediğiniz web servis bilgisine göre doldurulmalıdır. Bu bilgileri Entegrasyon rehberinin ilgili web servise ait bölümde bulabilirsiniz.
        };
    }
}

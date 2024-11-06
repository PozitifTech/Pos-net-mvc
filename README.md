# PosFix .Net Kütüphanesi

PosFix .Net Client Kütüphanesidir. PosFix API'lerine çok hızlı bir şekilde bağlanmanızı sağlar.
[https://www.posfix.com.tr](https://www.posfix.com.tr) adresimizden mağaza başvurusu yaparak
hesabınızı açabilirsiniz.

## Entegrasyon sürecinde dikkat edilecek noktalar

PosFix servislerini kullanabilmek için [PosFix'e](https://www.posfix.com.tr) üye olmalısınız.
Üye olduktan sonra Mağaza Listesi > Detay sayfası içerisindeki Public ve Private Key sizinle paylaşılacaktır.
Paylaşılan bu anahtarları posfix-net projesinde Settings classda yer alan publicKey ve privateKey alanlarına eklemeniz gerekmektedir.
İlgili örnek proje bir Class Library ve bir de .Net MVC Web projesi barındırır.

```c#
    public Settings settings = new Settings
        {
            PublicKey = "", //"Public Magaza Anahtarı - size mağaza başvurunuz sonucunda gönderilen publik key (açık anahtar) bilgisini kullanınız.",
            PrivateKey = "", //"Private Magaza Anahtarı  - size mağaza başvurunuz sonucunda gönderilen privaye key (gizli anahtar) bilgisini kullanınız.",
            BaseUrl = "https://api.posfix.com.tr/", //PosFix web servisleri API url'lerinin başlangıç bilgisidir. Restful web servis isteklerini takip eden kodlar halinde bulacaksınız.
                                                // Örneğin "https://api.posfix.com.tr/" + "/rest/payment/auth"  = "https://api.posfix.com.tr/rest/payment/auth"
            Version = "1.0", // Kullandığınız PosFix API versiyonudur.
            Mode = "T", // Test -> T, entegrasyon testlerinin sırasında "T" modunu, canlı sisteme entegre olarak ödeme almaya başlamak için ise Prod -> "P" modunu kullanınız.
            HashString = string.Empty // Kullanacağınız hash bilgisini, bağlanmak istediğiniz web servis bilgisine göre doldurulmalıdır. Bu bilgileri Entegrasyon rehberinin ilgili web servise ait bölümde bulabilirsiniz.
        };
    }
```

Örnek projelerimizdeki servislerimizi daha iyi anlamak için [PosFix geliştirici merkezini](http://developer.posfix.com.tr) takip etmeniz büyük önem arz etmektedir.

- Entegrasyon işlemlerinde encoding “UTF-8” kullanılması önerilmektedir.Token parametrelerinden kaynaklı sorun encoding probleminden kaynaklanmaktadır. Özel karakterlerde encoding işlemi yapılmalıdır.
- Servis isteği yaparaken göndermiş olduğunuz alanların başında ve sonunda oluşabilecek boşluk alanlarını kaldırmanızı ( trim() ) önemle rica ederiz. Çünkü bu alanlar oluşacak hash sonuçlarını etkilemektedir.
- Entegrasyon dahilinde gönderilen input alanlarında, kart numarası alanı dışında kart numarası bilgisi gönderilmesi halinde işlem reddedilecektir.

PosFix örnek projelerinin amacı, yazılım geliştiricilere PosFix servislerine entegre olabilecek bir proje örneği sunmak ve entegrasyon adımlarının daha iyi anlaşılmasını sağlamaktır.
Projeleri doğrudan canlı ortamınıza alarak kod değişimi yapmadan kullanmanız için desteğimiz bulunmamaktadır. **Projeyi bir eğitsel kaynak (tutorial) olarak kullanınız.**

### Gerekli Teknolojiler
* .NET 5.0
* C# v9.0

###### Başlangıç projesi olarak PosFix.DeveloperPortal.WebSamples'ı seçiniz

## Test Kartları

Başarılı bir ödemeyi test etmek için aşağıdaki kart numaralarını ve diğer bilgileri kullanabilirsiniz.

| Sıra No | Kart Numarası    | SKT   | CVC | Banka                 | Kart Ailesi            |
| ------- | ---------------- | ----- | --- | --------------------- | ---------------------- |
| 1       | 4282209004348015 | 12/26 | 123 | Garanti Bankası       | BONUS                  |
| 2       | 5571135571135575 | 12/26 | 000 | Akbank                | AXESS                  |
| 3       | 4355084355084358 | 12/26 | 000 | Akbank                | AXESS                  |
| 4       | 4662803300111364 | 10/25 | 000 | Alternatif Bank       | BONUS                  |
| 5       | 4022774022774026 | 12/24 | 000 | Finansbank            | CARD FINANS            |
| 6       | 5456165456165454 | 12/24 | 000 | Finansbank            | CARD FINANS            |
| 7       | 9792023757123604 | 01/26 | 861 | Finansbank            | FINANSBANK DEBIT       |
| 8       | 4531444531442283 | 12/24 | 000 | Aktif Yatırım Bankası | AKTIF KREDI KARTI      |
| 9       | 5818775818772285 | 12/24 | 000 | Aktif Yatırım Bankası | AKTIF KREDI KARTI      |
| 10      | 4508034508034509 | 12/24 | 000 | İş bankası            | MAXIMUM                |
| 11      | 5406675406675403 | 12/24 | 000 | İş bankası            | MAXIMUM                |
| 12      | 4025903160410013 | 07/26 | 123 | Kuveyttürk            | KUVEYTTURK KREDI KARTI |
| 13      | 5345632006230604 | 12/24 | 310 | Aktif Yatırım Bankası | AKTIF KREDI KARTI      |
| 14      | 4282209027132016 | 12/24 | 358 | Garanti Bankası       | BONUS                  |
| 15      | 4029400154245816 | 03/24 | 373 | Vakıf Bank            | WORLD                  |
| 16      | 4029400184884303 | 01/26 | 378 | Vakıf Bank            | WORLD                  |
| 17      | 9792350046201275 | 07/27 | 993 | TÜRK ELEKTRONIK PARA  | PARAM KART             |
| 18      | 6501700194147183 | 03/27 | 136 | Vakıf Bank            | WORLD                  |
| 19      | 6500528865390837 | 01/26 | 686 | Vakıf Bank            | VAKIFBANK DEBIT        |

Test kartlarımızda alınan hata kodları ve çözümleriyle ilgili detaylı bilgiye ulaşabilmek için [PosFix Hata Kodları](https://developer.posfix.com.tr/home/ErrorCode) inceleyebilirsiniz.

## Örnek Kullanım Yöntemi

```c#
    Non3DPaymentRequest request = new();
    request.OrderId = Guid.NewGuid().ToString();
    request.Amount = "100";
    request.CardOwnerName = "Ahmet Veli";
    request.CardNumber = "5456165456165454";
    request.CardExpireMonth = "12";
    request.CardExpireYear = "24";
    request.Installment = "1";
    request.Cvc = "000";

    request.Echo = "Echo";
    request.Mode = settings.Mode;
    request.ThreeD = "false";
    request.CardId = "";
    request.UserId = "";

    request.Purchaser = new();
    request.Purchaser.Name = "Ahmet";
    request.Purchaser.SurName = "Veli";
    request.Purchaser.BirthDate = "1986-07-11";
    request.Purchaser.Email = "ahmet@veli.com";
    request.Purchaser.GsmPhone = "5881231212";
    request.Purchaser.IdentityNumber = "12345678901";
    request.Purchaser.ClientIp = "127.0.0.1";

    request.Purchaser.InvoiceAddress = new();
    request.Purchaser.InvoiceAddress.Name = "Ahmet";
    request.Purchaser.InvoiceAddress.SurName = "Veli";
    request.Purchaser.InvoiceAddress.Address = "Mevlüt Pehlivan Mah. PosFix Plaza Şişli";
    request.Purchaser.InvoiceAddress.ZipCode = "34782";
    request.Purchaser.InvoiceAddress.CityCode = "34";
    request.Purchaser.InvoiceAddress.IdentityNumber = "12345678901";
    request.Purchaser.InvoiceAddress.CountryCode = "TR";
    request.Purchaser.InvoiceAddress.TaxNumber = "123456";
    request.Purchaser.InvoiceAddress.TaxOffice = "Kozyatağı";
    request.Purchaser.InvoiceAddress.CompanyName = "PosFix";
    request.Purchaser.InvoiceAddress.PhoneNumber = "2122222222";

    request.Purchaser.ShippingAddress = new();
    request.Purchaser.ShippingAddress.Name = "Ahmet";
    request.Purchaser.ShippingAddress.SurName = "Veli";
    request.Purchaser.ShippingAddress.Address = "Mevlüt Pehlivan Mah. PosFix Plaza Şişli";
    request.Purchaser.ShippingAddress.ZipCode = "34782";
    request.Purchaser.ShippingAddress.CityCode = "34";
    request.Purchaser.ShippingAddress.IdentityNumber = "12345678901";
    request.Purchaser.ShippingAddress.CountryCode = "TR";
    request.Purchaser.ShippingAddress.PhoneNumber = "2122222222";

    request.Products = new List<Product>();
    Product p = new();
    p.Title = "Telefon";
    p.Code = "TLF0001";
    p.Price = "5000"; //50.00 TL
    p.Quantity = 1;
    request.Products.Add(p);

    p = new();
    p.Title = "Bilgisayar";
    p.Code = "BLG0001";
    p.Price = "5000"; //50.00 TL
    p.Quantity = 1;
    request.Products.Add(p);

    return View(Non3DPaymentRequest.Execute(request, settings));

```

## Hash Hesaplama

PosFix servislerine entegre olurken alınan hataların en sık karşılaşılanı hash değerinin doğru hesaplanmasıdır. Hash değeri her servise göre değişen verilerin yanyana eklenmesi ile oluşan değerin bir dizi işleme tabi tutulması ile oluşur.

Aşağıdaki adreste hash hesaplama ile ilgili detaylar yer almaktadır. Yine burada yer alan interaktif fonksiyon ile hesapladığınız hash fonksiyonlarını test edebilirsiniz.

[PosFix Hash Hesaplama](https://developer.posfix.com.tr/#hashCalculate)

Her örnek projenin Helper sınıfı içinde hash hesaplama ile alakalı bir fonksiyon bulunmaktadır. Entegrasyon sırasında bu hazır fonksiyonları da kullanabilirsiniz.

## Canlı Ortama Geçiş

- Test ortamında kullandığınız statik verilerin canlı ortamda gerçek müşteri datasıyla değiştirildiğinden emin olun.
- Canlı ortamda yanlış, sabit data gönderilmediğinden emin olun. Gönderdiğiniz işlemlere ait verileri mutlaka size özel panelden görüntüleyin.
- Geliştirmeler tamamlandıktan sonra ödeme adımlarını, PosFix test kartları ile tüm olası durumlar için test edin ve sonuçlarını görüntüleyin.
- PosFix servislerinden dönen ve olabilecek tüm hataları karşılayacak ve müşteriye uygun cevabı gösterecek şekilde kodunuzu düzenleyin ve test edin. PosFix hata kodları kullanıcı dostu mesajlar olup müşterinize gösterebilirsiniz.
- Hassas olmayan verileri ve servis yanıtlarını, hata çözümü ve olası sorunların çözümünde yardımcı olması açısından loglamaya dikkat edin.
- Canlı ortama geçiş sonrası ilk işlemleri kendi kredi kartlarınız ile deneyerek sonuçlarını size özel kurum ekranlarından görüntüleyin. Sonuçların ve işlemlerin doğru tamamlandığından emin olun.

Sorularınız olması durumunda bize [Destek](http://developer.posfix.com.tr/Home/Support) üzerinden yazabilirsiniz.

## Versiyon Yenilikleri

| Versiyon | Versiyon Yenilikleri                                                                                                                                                                                                                                                                                                                                                                                                                 |
| -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 1.0.1    | - İki adımlı ThreeD ödemesi kaldırılıp **Tek adımlı ThreeD** ödemesi eklendi.<br />- Ödeme sorgulama servisinde ek olarak **tarih filtresi** eklendi.<br />- **Link ile ödeme, ödeme linki sorgulama,ödeme linki silme** servisleri eklendi.<br />- **Ürün iade bilgisi sorgulama,ürün iade talebi** oluşturma servisleri eklendi. <br />- **Bin sorgulama servisine tutar bilgisi** eklenerek komisyon bilgisi kullanıcıya sunuldu. |

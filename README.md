# E-Ticaret Clone Projesi

Bu proje, .NET ile geliştirilmiş bir e-ticaret platformunun klonudur. Kullanıcıların ürünleri görüntüleyebileceği, sipariş verebileceği, ödeme yapabileceği, kargo takibi gerçekleştirebileceği ve indirim kuponları kullanabileceği bir sistem sunmaktadır.

## İçindekiler

- [Proje Özeti](#proje-özeti)
- [Özellikler](#özellikler)
- [Teknolojiler](#teknolojiler)
- [Mimari](#mimari)
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [API Dökümantasyonu](#api-dökümantasyonu)
- [Testler](#testler)
- [Katkıda Bulunanlar](#katkıda-bulunanlar)
- [Lisans](#lisans)

## Proje Özeti

E-ticaret platformu, kullanıcıların ürünleri keşfetmesini, sepetlerine eklemesini ve güvenli bir şekilde satın alma işlemleri gerçekleştirmesini sağlamaktadır. Ayrıca, kullanıcıların indirim kuponlarını uygulayarak tasarruf etmesine olanak tanır.

## Özellikler

- **Ürün Yönetimi**:
  - Ürün ekleme, güncelleme ve silme.
  - Ürün kategorileri ve alt kategorileri.
  - Ürün varyantları (renk, beden vb.).

- **Sipariş İşleme**:
  - Kullanıcıların siparişlerini oluşturma ve görüntüleme.
  - Sipariş durum takibi (hazırlanıyor, kargoda, teslim edildi).

- **Ödeme Sistemi**:
  - Çeşitli ödeme yöntemleri (kredi kartı, havale vb.).
  - Ödeme geçmişi ve raporlaması.

- **Kargo Takibi**:
  - Kargo durumu güncellemeleri.
  - Kargo şirketi bilgileri.

- **Kupon Yönetimi**:
  - Kupon oluşturma, güncelleme ve silme.
  - Kuponların sepete uygulanması.

## Teknolojiler

- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [PostgreSQL](https://www.postgresql.org/)
- [Npgsql](https://www.npgsql.org/) (PostgreSQL için ADO.NET sağlayıcısı)
- [Swagger](https://swagger.io/) (API dökümantasyonu için)

## Mimari

Proje, katmanlı mimari prensiplerine dayanmaktadır. Temel bileşenler şunlardır:

- **Data Layer**: Veritabanı bağlantısı ve Entity Framework ile çalışmak için gerekli olan DbContext ve Entity sınıflarını içerir.
- **Business Layer**: Uygulama mantığı ve iş kurallarını içerir. Bu katman, veri erişim katmanı ile etkileşimde bulunur.
- **API Layer**: Kullanıcıların uygulama ile etkileşimde bulunabileceği RESTful API'leri sağlar.

## Kurulum

### 1. Depoyu Klonlayın

```bash
git clone https://github.com/kullanici_adiniz/e-ticaret-clone.git

```bash
cd e-ticaret-clone

```bash
dotnet restore

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=127.0.0.1;Database=E-CommerceDb;Username=developer;Password=123456;"
  }
}

```bash
dotnet ef database update

```bash
dotnet run

```bash
# E-Ticaret Projesi Entity İlişkileri

Bu proje, çeşitli entity'lerin etkileşimde bulunduğu bir e-ticaret platformunu temsil etmektedir. Aşağıda ana entity'ler ve aralarındaki ilişkiler açıklanmıştır.

## Entity'ler

### Cargo
- **Açıklama:** Kargo süreçlerini temsil eder.
- **Öznitelikler:**
  - `OrderId` (long): İlgili sipariş kimliği.
  - `TrackingNumber` (string): Kargo takip numarası.
  - `ShippedDate` (DateTime): Kargo gönderim tarihi.
  - `EstimatedDeliveryDate` (DateTime): Tahmini teslim tarihi.
  - `Status` (CargoStatus): Kargo durumu (varsayılan: Pending).
  - `ShippingProvider` (string): Kargo şirketi.

### Coupon
- **Açıklama:** Kullanıcıların siparişlerinde indirim uygulamak için kullanılan kuponları temsil eder.
- **Öznitelikler:**
  - `Id` (int): Birincil anahtar.
  - `Code` (string): Kupon kodu.
  - `DiscountAmount` (decimal): İndirim miktarı.
  - `ValidFrom` (DateTime): Geçerlilik başlangıcı.
  - `ValidTo` (DateTime): Geçerlilik bitiş tarihi.
  - `IsActive` (bool): Kuponun aktif olup olmadığını belirler.
  - `UsageLimit` (int): Kuponun kullanılabileceği maksimum sayıda kullanım.
  - `TimesUsed` (int): Kuponun kaç kez kullanıldığını izler.

### Order
- **Açıklama:** Müşterilerin siparişlerini temsil eder.
- **Öznitelikler:**
  - `CustomerId` (int): Müşteri kimliği.
  - `OrderDate` (DateTime): Sipariş tarihi (varsayılan: Şu anki tarih).
  - `TotalAmount` (decimal): Toplam sipariş tutarı.
  - `Status` (OrderStatus): Sipariş durumu (varsayılan: Pending).
  - `OrderItems` (List<OrderItem>): Siparişin içindeki ürünleri temsil eder.
  - `DiscountAmount` (decimal): Uygulanan indirim miktarı.
  - `ShippingCost` (decimal): Kargo ücreti.
  - `EstimatedDeliveryDate` (DateTime?): Tahmini teslim tarihi.
  - `Payment` (Payment): Siparişe bağlı ödeme.
  - `Cargo` (Cargo): Siparişe bağlı kargo.

### OrderItem
- **Açıklama:** Bir siparişteki ürün kalemlerini temsil eder.
- **Öznitelikler:**
  - `Id` (long): Birincil anahtar.
  - `ProductId` (long): Ürün kimliği.
  - `Quantity` (int): Ürün adedi.
  - `UnitPrice` (decimal): Birim fiyat.
  - `DiscountedUnitPrice` (decimal): İndirimli birim fiyat.
  - `OrderId` (long): Sipariş kimliği.
  - `Order` (Order): Sipariş referansı.

### Payment
- **Açıklama:** Bir siparişin ödemesini temsil eder.
- **Öznitelikler:**
  - `OrderId` (long): İlgili sipariş kimliği.
  - `Amount` (decimal): Ödeme tutarı.
  - `Method` (PaymentMethod): Ödeme yöntemi.
  - `Status` (PaymentStatus): Ödeme durumu (varsayılan: Pending).
  - `PaymentDate` (DateTime): Ödeme tarihi.
  - `TransactionId` (string): İşlem kimliği.

### Product
- **Açıklama:** E-ticaret platformunda satılan ürünleri temsil eder.
- **Öznitelikler:**
  - `Name` (string): Ürün adı.
  - `Description` (string): Ürün açıklaması.
  - `Price` (decimal): Ürün fiyatı.
  - `DiscountedPrice` (decimal?): İndirimli ürün fiyatı.
  - `StockQuantity` (int): Stok miktarı.
  - `SKU` (string): Stok kodu.
  - `Category` (string): Ürün kategorisi.
  - `SubCategory` (string): Ürün alt kategorisi.
  - `Brand` (string): Ürün markası.
  - `Variants` (List<ProductVariant>): Ürün varyantları (örneğin, renk, beden).
  - `Images` (List<ProductImage>): Ürün görselleri.
  - `IsPublished` (bool): Ürünün yayınlanma durumu.
  - `PublishedDate` (DateTime): Yayınlanma tarihi.
  - `IsDeleted` (bool): Ürünün silinme durumu.
  - `ShippingCost` (decimal): Kargo ücreti.
  - `Weight` (decimal): Ürün ağırlığı.
  - `Dimensions` (string): Ürün boyutları.
  - `ReviewCount` (int): Ürün inceleme sayısı.
  - `AverageRating` (double): Ürün ortalama puanı.
  - `SeoMetaTitle` (string): SEO için meta başlık.
  - `SeoMetaDescription` (string): SEO için meta açıklama.
  - `Slug` (string): Ürün URL'si için kullanılacak slug.
  - `Status` (ProductStatus): Ürün durumu.
  - `DiscountRules` (List<DiscountRule>): Ürünle ilişkili indirim kuralları.
  - `StockThreshold` (int): Stok alarm seviyesi.
  - `LeadTimeDays` (int): Tedarik süresi.
  - `RelatedProducts` (List<Product>): İlgili ürünler (öneriler).

## İlişkiler

- **Order ve Cargo İlişkisi:** Her siparişin bir kargo süreci olabilir. `Order` entity'si, `Cargo` entity'sine `Cargo` referansı içerir.
- **Order ve Payment İlişkisi:** Her siparişin bir ödemesi olmalıdır. `Order` entity'si, `Payment` entity'sine `Payment` referansı içerir.
- **Order ve OrderItem İlişkisi:** Bir sipariş bir veya daha fazla ürün kaleminden oluşabilir. `Order` entity'si, `OrderItem` entity'sine bir liste olarak `OrderItems` içerir.
- **Product ve OrderItem İlişkisi:** Her ürün kalemi, bir ürünü temsil eder. `OrderItem` entity'si, `Product` kimliğine (`ProductId`) sahiptir.
- **Product ve DiscountRule İlişkisi:** Bir ürün, bir veya daha fazla indirim kuralına sahip olabilir. `Product` entity'si, `DiscountRules` olarak bir liste içerir.

## Kullanım
Projenin çalışma mantığı, siparişlerin kargo süreçleri, kuponlar üzerinden indirim uygulama süreçleri ve ödemelerin entegre edilmesidir.


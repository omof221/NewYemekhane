🍽️ Yemekhane Otomasyon Sistemi
Çok Katmanlı .NET 9 Tabanlı Yemekhane Yönetim ve Okutma Otomasyonu

🚀 Proje Amacı
Bu proje, kurumlarda yemekhaneye giriş, okutma ve personel takibini kolaylaştırmak için geliştirilen çok katmanlı bir otomasyon sistemidir.
Amaç; personel, admin ve yemekhane çalışanlarını tek bir sistemde yönetmek, okutma ve giriş loglarını güvenli biçimde tutmaktır.

🧱 Mimari ve Katmanlar
Proje Katmanlı Mimari (N-Tier Architecture) yapısıyla geliştirilmiştir:
Katman	Açıklama
🖥️ UıLayer	Windows Forms arayüzü, kullanıcı etkileşimi
⚙️ YemekhaneBussssinesLayer	İş mantığı, doğrulama ve kural yönetimi
💾 YemekhaneDataAccesLayer	Entity Framework Core üzerinden CRUD işlemleri
🧩 YemekhaneEntityLayer	Entity sınıfları, veri modelleri
🧰 YemekhaneHelpersLayer	Yardımcı sınıflar ve araç metodları
🧮 Veritabanı ve EF Core

YemekhaneContext (YemekhaneDataAccesLayer > Context > YemekhaneContext.cs) dosyasında veritabanı işlemleri yönetilmektedir.
DbSet Tabloları
Calisanlar
Okutmalar
Adminler
YemekhaneCalisanlar
GirisLoglar
İlişkiler
GirisLoglar ↔ Calisanlar arasında bire-çok ilişki tanımlanmıştır.
Cascade delete aktif.

Bağlantı
optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=yemekhanePProjesiDB;Integrated Security=True;TrustServerCertificate=True;");


💡 Öneri: Connection string, appsettings.json veya IConfiguration üzerinden yönetilebilir.

🧾 Veri Akışı (Örnek: Yeni Okutma Ekleme)
Kullanıcı, YeniOkutmaEkleForm üzerinden okutma bilgilerini girer.
Form, Business Layer üzerinden doğrulama ve iş kurallarını çalıştırır.
Business katmanı, Data Access Layer aracılığıyla Okutmalar tablosuna ekleme yapar.
Ekleme başarılı olduğunda, GirisLoglar güncellenir ve UI tarafındaki DataGridView yenilenir.

🔐 Güvenlik
SQL bağlantısı şifreli (TrustServerCertificate=True) yapılır.
Rol tabanlı yetkilendirme sistemi (admin, personel, yemekhane çalışanı).
Kullanıcı hatalarına karşı try-catch + anlamlı mesaj yönetimi.

🧠 Teknolojiler
Katman	Teknoloji
Backend	.NET 9, C#
ORM	Entity Framework Core
Veritabanı	SQL Server
UI	Windows Forms
Mimari	Katmanlı Mimari
Ekstra	Dependency Injection, Migrations, Async CRUD

🖥️ Kurulum ve Çalıştırma
Gereksinimler
Windows 10/11
.NET 9 SDK
SQL Server (Express veya üstü)
Visual Studio 2022
Adımlar
Repo’yu klonla:
git clone https://github.com/<kullanici-adi>/YemekhaneOtomasyonSistemi.git


SQL Server’da yemekhanePProjesiDB oluştur.
Terminalde migration çalıştır:
dotnet ef database update
Uygulamayı başlat:
dotnet run
veya Yemekhane.UI.exe dosyasını çalıştır.

💾 Yedekleme & Bakım
Veritabanı düzenli olarak yedeklenmelidir (.bak dosyaları).
Güncellemeler GitHub üzerinden sürüm takibiyle yapılmalıdır.
Hata raporlamaları log.txt veya merkezi log sistemi ile izlenebilir.

🌐 Fiziksel Ağ Yapısı
Sunucu ve istemciler aynı LAN üzerinde veya VPN bağlantısı aracılığıyla haberleşir.
SQL bağlantısı için güvenli port (örn. 1433) kullanılmalıdır.

🧩 Geliştirme Notları
DbContext Scoped yaşam döngüsünde DI ile yönetilmeli.
CRUD işlemleri async (SaveChangesAsync) olarak yapılmalı.

Migration kullanımı:
dotnet ef migrations add InitialCreate
dotnet ef database update


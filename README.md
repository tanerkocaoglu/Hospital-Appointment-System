# Hospital Appointment System

Hospital Appointment System, bir hastanenin randevu yönetimini dijitalleştirmek için geliştirilmiş bir uygulamadır. Proje, hasta, doktor ve randevu yönetimi gibi temel işlevleri kullanıcı dostu bir arayüz ile sunar. Bu sistem, hastaların ve hastane çalışanlarının zamanını daha verimli kullanmalarına olanak tanır.

## Özellikler

### Genel Özellikler
- **Hasta Yönetimi**:
  - Yeni hasta kayıtlarının oluşturulması
  - Mevcut hasta bilgileri düzenleme
  - Hastaların randevu geçmişine erişim
- **Doktor Yönetimi**:
  - Doktor bilgileri ve programlarının yönetimi
  - Branşa göre doktor eşleştirmesi
- **Randevu Planlama**:
  - Hastaların uygun tarih ve saate göre randevu alması
  - Randevuların onaylanması ve iptali
  - Doktorun günlük programının görüntülenmesi
- **Kullanıcı Rolleri**:
  - **Admin**: Sistem yönetimi ve tüm veriler üzerinde tam kontrol
  - **Hasta**: Randevu oluşturma ve yönetim
  - **Doktor**: Hasta listelerini ve randevuları görüntüleme

### Teknik Özellikler
- **Platform**: Windows masaüstü uygulaması
- **Dil**: C#
- **Veritabanı Yönetim Sistemi**: Microsoft SQL Server
- **Arayüz**: Windows Forms kullanılarak oluşturulmuş modern ve kullanıcı dostu UI

## Kurulum ve Çalıştırma
 
### Gereksinimler
- Microsoft Visual Studio 2015 veya üzeri
- .NET Framework 4.7.2 veya üzeri
- Microsoft SQL Server (Yerel veya uzak sunucu)

### Kurulum Adımları
1. Bu repoyu klonlayın:
   ```bash
  git clone https://github.com/tanerkocaoglu/Hospital-Appointment-System.git
2. Visual Studio ile hastaneOtomasyonuProjesi.sln dosyasını açın.
3. Gerekli bağımlılıkları NuGet Paket Yöneticisi'ni kullanarak yükleyin.
4. SQL Server'da bir veritabanı oluşturun ve appsettings.json dosyasını veritabanı bağlantı bilgileriyle güncelleyin.
5. Projeyi derlemek ve başlatmak için F5 tuşuna basın.

## Kullanım
  - **Admin Paneli:**
      - Yeni doktor ve hasta eklemek için kullanılır.
      - Randevuların onaylanması veya iptali burada yapılır.
  - **Hasta Paneli:**
      - Kullanıcılar yeni randevular oluşturabilir ve geçmiş randevularını inceleyebilir.
  - **Doktor Paneli:**
      - Günlük randevu listesi görüntülenebilir ve hasta bilgilerine erişim sağlanır.
## Proje Yapısı
        HospitalAppointmentSystem/
      ├── hastaneOtomasyonuProjesi.sln  # Çözüm dosyası
      ├── hastaneOtomasyonuProjesi/     # Ana proje klasörü
      │   ├── Forms/                    # Windows Forms dosyaları
      │   ├── Models/                   # Veritabanı modelleri
      │   ├── Services/                 # İş mantığı ve servis katmanı
      │   ├── App.config                # Uygulama yapılandırma dosyası
      │   └── Program.cs                # Giriş noktası
      └── README.md                     # Proje açıklama dosyası
## Bilinen Sorunlar
  - İlk çalıştırmada bağlantı sorunları olabilir; bağlantı ayarlarını appsettings.json dosyasından kontrol edin.
  - SQL Server erişim izinleri doğru yapılandırılmalıdır.

  

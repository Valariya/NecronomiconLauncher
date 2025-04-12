<h1 align="center">
  <img src="images/nocturned.png" alt="NecronomiconLauncher" width="100%"/>
</h1>

<p align="center">
  <strong>Modüler, Şifrelenmiş, Lisans Tabanlı Güvenli Launcher Mimarisi</strong><br>
  .NET & WPF teknolojileri ile geliştirilen modern bir kara yazılım framework'ü.
</p>

---

## 📖 Hakkında

**NecronomiconLauncher**, klasik hile yazılımlarının çok ötesinde bir yapıya sahiptir. Modüler olarak geliştirilen sistem, şifreli `.grim` dosyaları ile çalışan ve yalnızca yetkili kullanıcıların erişebildiği güvenli bir API tabanlı mimari sunar.

🔐 Şifreli DLL modülleri  
🧩 JSON ile uzaktan modül yetkilendirmesi  
💀 HWID + Lisans Token ile doğrulama  
📜 Gelişmiş log ve konfigürasyon sistemi  
🧠 AES-GCM destekli bellek içi çözümleme  
🌐 Tamamen dış bağlantılı API ile uzaktan kontrol  
⚔️ Gölge Muhafızları'nın uyanışına hazır olun...

---

## ⚙️ Mimarinin Temel Bileşenleri

| Katman            | Açıklama |
|-------------------|----------|
| **Launcher UI**   | WPF ile geliştirilen kullanıcı arayüzü |
| **Modül Sistemi** | Şifrelenmiş `.grim` dosyaları (DLL tabanlı) |
| **Auth API**      | Node.js ile çalışan lisans kontrol sistemi |
| **Oblivion Loader** | DLL yükleyici / decrypt mekanizması |
| **LogHelper**     | Uygulama içi gelişmiş log sistemi |
| **PathHelper**    | Ortamdan bağımsız modül yolu yönetimi |
| **LangHelper** *(planlandı)* | Çok dilli dil yönetim sistemi |
| **BypassX** *(beta)* | Özel modüller için altyapı |

---

## 🚀 Kullanım Akışı

1. Kullanıcı lisans token ile giriş yapar.
2. HWID doğrulaması yapılır.
3. Uygun modüller modül ekranında görüntülenir.
4. Seçilen modül `.grim` olarak RAM’de açılır, çalıştırılır.
5. Log sistemi tüm işlemleri kayıt altına alır.

---

## 🛡️ Güvenlik

> **Nocturned modülleri**, doğrudan RAM'e çözülür, diskten DLL olarak erişilemez.  
> Bu sistem sayesinde kaynak kodlar ve modül içeriği tamamen korunur.  
> Kullanıcılar sadece izin verilen modülleri, sınırlı sürelerde kullanabilir.

---

## 📂 Proje Yapısı

```bash
📁 modules/         # Şifreli modül dosyaları (.grim)
📁 src/             # Tüm kaynak kodlar
├── NecronomiconLauncher/
│   ├── MainWindow.xaml        # Giriş arayüzü
│   ├── ModuleWindow.xaml      # Modül ekranı
│   ├── Helpers/               # Yardımcı sınıflar (LogHelper, ConfigHelper vs)
│   ├── OblivionLoader.cs      # Şifre çözücü + modül çalıştırıcı
│   └── App.xaml               # Uygulama başlangıç ayarları

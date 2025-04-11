# 🕯️ NecronomiconLauncher

NecronomiconLauncher, sadece yetkilendirilmiş kullanıcıların erişebileceği şekilde tasarlanmış, 
AES-GCM şifreli modül yükleyen, HWID ve token doğrulaması yapan bir Unturned başlatıcısıdır.

## Bileşenler
- MainWindow.xaml: Giriş ekranı (HWID + Token girişi)
- ModuleWindow.xaml: Modül seçimi (Oblivion, Gatekeeper)
- LoadOblivionAsync: .grim modül çözümleyici
- AES-GCM şifreleme sistemi

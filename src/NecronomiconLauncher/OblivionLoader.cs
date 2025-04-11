using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace NecronomiconLauncher
{
    public static class OblivionLoader
    {
        // AES-GCM ile şifre çözme ve assembly yükleme
        public static void LoadOblivionModule(string grimPath, byte[] key, byte[] nonce, byte[] tag)
        {
            try
            {
                byte[] encryptedData = File.ReadAllBytes(grimPath);

                byte[] decrypted = new byte[encryptedData.Length];
                using (var aes = new AesGcm(key, 16)) // 16 byte (128 bit) tag uzunluğu
                {
                    aes.Decrypt(nonce, encryptedData, tag, decrypted);
                }

                Assembly asm = Assembly.Load(decrypted);
                MethodInfo entry = asm.EntryPoint;
                entry?.Invoke(null, new object[] { new string[0] });
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Oblivion yüklenemedi:\n{ex.Message}", "Hata", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}

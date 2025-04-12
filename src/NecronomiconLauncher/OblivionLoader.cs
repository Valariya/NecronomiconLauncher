using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows;

namespace NecronomiconLauncher
{
    public static class OblivionLoader
    {
        public static void LoadOblivionModule(string grimPath, byte[] key, byte[] nonce)
        {
            try
            {
                byte[] encrypted = File.ReadAllBytes(grimPath);

                // 🔄 tag = son 16 byte, ciphertext = geri kalanı
                byte[] tag = encrypted[^16..];
                byte[] ciphertext = encrypted[..^16];

                byte[] decrypted = new byte[ciphertext.Length];

                using (var aes = new AesGcm(key, 16))
                {
                    aes.Decrypt(nonce, ciphertext, tag, decrypted);
                }

                Assembly asm = Assembly.Load(decrypted);
                MethodInfo method = asm.GetType("BypassXModule.Entry")?.GetMethod("Init");

                method?.Invoke(null, null);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("BypassX", ex.Message);
                MessageBox.Show("BypassX yüklenemedi:\n" + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

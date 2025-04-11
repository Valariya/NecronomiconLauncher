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

                byte[] tag = new byte[16];
                byte[] ciphertext = new byte[encrypted.Length - 16];

                Buffer.BlockCopy(encrypted, 0, ciphertext, 0, ciphertext.Length);
                Buffer.BlockCopy(encrypted, ciphertext.Length, tag, 0, tag.Length);

                byte[] decrypted = new byte[ciphertext.Length];

                using (var aes = new AesGcm(key))
                {
                    aes.Decrypt(nonce, ciphertext, tag, decrypted);
                }

                Assembly asm = Assembly.Load(decrypted);
                MethodInfo method = asm.GetType("NocturnedModule.Entry")?.GetMethod("Init");

                method?.Invoke(null, null);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Nocturned", ex.Message);
                MessageBox.Show("Oblivion yüklenemedi:\n" + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

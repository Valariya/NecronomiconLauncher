using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;

namespace NecronomiconLauncher
{
    public partial class ModuleWindow : Window
    {
        public ModuleWindow(JToken modulesJson)
        {
            InitializeComponent();
            List<string> modules = modulesJson.ToObject<List<string>>();

            foreach (string mod in modules)
            {
                Button btn = new Button
                {
                    Content = mod,
                    Height = 35,
                    Margin = new Thickness(0, 5, 0, 5),
                    Background = System.Windows.Media.Brushes.DarkSlateGray,
                    Foreground = System.Windows.Media.Brushes.White
                };

                btn.Click += (s, e) =>
                {
                    if (!ConfigHelper.IsModuleEnabled(mod))
                    {
                        MessageBox.Show("❌ Bu modül devre dışı.", mod, MessageBoxButton.OK, MessageBoxImage.Warning);
                        LogHelper.Write(mod, "Devre dışı olduğu için başlatılamadı.");
                        return;
                    }

                    MessageBox.Show($"🧩 Modül başlatılıyor: {mod}", "Modül Aktif", MessageBoxButton.OK, MessageBoxImage.Information);
                    LogHelper.Write(mod, "Kullanıcı modülü başlattı");

                    if (mod == "Nocturned")
                    {
                        byte[] key = HexToBytes("d46e6a98a2fabcc6ead53b1fd85274b63d69059431e6b663947b5d53ed4e4b14");
                        byte[] nonce = HexToBytes("4aee5c2bd8f2b0582fcace2c");

                        string grimPath = PathHelper.GetModulePath("Nocturned");
                        OblivionLoader.LoadOblivionModule(grimPath, key, nonce);
                    }

                    if (mod == "BypassX")
                    {
                        MessageBox.Show("🛡️ BypassX sistemi yakında aktif edilecek!", "BypassX", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                };

                ModuleButtons.Children.Add(btn);
            }
        }

        private byte[] HexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return bytes;
        }
    }
}

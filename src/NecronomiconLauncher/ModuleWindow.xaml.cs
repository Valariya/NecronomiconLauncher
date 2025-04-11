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
                    MessageBox.Show($"🧩 Modül başlatılıyor: {mod}", "Modül Aktif", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (mod == "Nocturned")
                    {
                        byte[] key = HexToBytes("3e7657df9c417cc88e257fb3078ed130819e726258b005010a2b53f9df6f61b1");
                        byte[] nonce = HexToBytes("41525edac617bd3b5e926303");
                        byte[] tag = HexToBytes("75a4dcd6d15abd8d14fd16565f488a8e");

                        string grimPath = PathHelper.GetModulePath("Nocturned");

                        OblivionLoader.LoadOblivionModule("modules/Nocturned.grim", key, nonce, tag);
                    }

                    if (mod == "BypassX")
                    {
                        MessageBox.Show("🛡️ BypassX sistemi yakında aktif edilecek!", "BypassX", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                };

                ModuleButtons.Children.Add(btn);
            }
        }

        // .NET Framework uyumlu Hex to byte[] çevirici
        private byte[] HexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return bytes;
        }
    }
}

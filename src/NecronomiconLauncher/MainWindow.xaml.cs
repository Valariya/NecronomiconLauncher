using System;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace NecronomiconLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HWIDText.Text = WindowsIdentity.GetCurrent().User.Value;
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string token = TokenBox.Text;
            string hwid = HWIDText.Text;

            var client = new HttpClient();
            var content = new StringContent($@"{{ \"token\": \"{token}\", \"hwid\": \"{hwid}\" }}", Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("http://127.0.0.1:3000/api/auth", content);
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ResultBlock.Text = "✔ Giriş başarılı: " + result;
                    ResultBlock.Foreground = System.Windows.Media.Brushes.LightGreen;
                }
                else
                {
                    ResultBlock.Text = "❌ Giriş başarısız: " + result;
                    ResultBlock.Foreground = System.Windows.Media.Brushes.OrangeRed;
                }
            }
            catch (Exception ex)
            {
                ResultBlock.Text = "⚠ Hata: " + ex.Message;
                ResultBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
        }
    }
}

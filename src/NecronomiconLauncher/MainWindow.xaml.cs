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

            var payload = new JObject
            {
                ["token"] = token,
                ["hwid"] = hwid
            };

            var content = new StringContent(payload.ToString(), Encoding.UTF8, "application/json");

            try
            {
                var client = new HttpClient();
                var response = await client.PostAsync("http://193.164.7.54:3000/api/auth", content);
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ResultBlock.Text = "✔ Giriş başarılı: " + result;
                    ResultBlock.Foreground = System.Windows.Media.Brushes.LightGreen;

                    LogHelper.WriteSystem("Giriş başarılı: Valariya");

                    var json = JObject.Parse(result);
                    var modules = json["modules"];
                    new ModuleWindow(modules).Show();
                    this.Close();
                }
                else
                {
                    ResultBlock.Text = "❌ Giriş başarısız: " + result;
                    ResultBlock.Foreground = System.Windows.Media.Brushes.OrangeRed;
                    LogHelper.WriteSystem("Giriş başarısız!");
                }
            }
            catch (Exception ex)
            {
                ResultBlock.Text = "⚠ Hata: " + ex.Message;
                ResultBlock.Foreground = System.Windows.Media.Brushes.Red;
                LogHelper.WriteError("Launcher", ex.Message);
            }
        }
    }
}

using System;
using System.Windows;

namespace NecronomiconLauncher
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            PathHelper.EnsureDirectories();
            LogHelper.WriteSystem("🕯️ Uygulama başlatıldı.");
            ConfigHelper.Load();
            LogHelper.WriteSystem("Config yüklendi. Dil: " + ConfigHelper.GetLanguage());
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            LogHelper.WriteSystem("⛓️ Uygulama kapatıldı.");
        }
    }
}

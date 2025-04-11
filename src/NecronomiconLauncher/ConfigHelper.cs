using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace NecronomiconLauncher
{
    public static class ConfigHelper
    {
        private static JObject _config;

        public static void Load()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            if (!File.Exists(configPath))
            {
                // Varsayılan config oluştur
                _config = JObject.Parse(@"{
                    'debugMode': true,
                    'language': 'tr',
                    'modules': {
                        'Nocturned': { 'enabled': true },
                        'BypassX': { 'enabled': false }
                    }
                }");
                File.WriteAllText(configPath, _config.ToString());
            }
            else
            {
                string json = File.ReadAllText(configPath);
                _config = JObject.Parse(json);
            }
        }

        public static bool IsModuleEnabled(string moduleName)
        {
            return _config?["modules"]?[moduleName]?["enabled"]?.ToObject<bool>() ?? false;
        }

        public static string GetLanguage()
        {
            return _config?["language"]?.ToString() ?? "tr";
        }

        public static bool IsDebugMode()
        {
            return _config?["debugMode"]?.ToObject<bool>() ?? false;
        }
    }
}

using System;
using System.IO;

namespace NecronomiconLauncher
{
    public static class PathHelper
    {
        public static string ModulesFolder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "modules");

        public static string GetModulePath(string moduleName)
        {
            return Path.Combine(ModulesFolder, moduleName + ".grim");
        }

        public static string LogsFolder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

        public static string GetLogFile(string moduleName)
        {
            return Path.Combine(LogsFolder, moduleName + "_log.txt");
        }
    }
}

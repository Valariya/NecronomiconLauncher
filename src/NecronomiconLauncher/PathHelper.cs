using System;
using System.IO;

namespace NecronomiconLauncher
{
    public static class PathHelper
    {
        public static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;

        public static string ModulesDirectory => Path.Combine(BaseDirectory, "modules");

        public static string GetModulePath(string moduleName)
        {
            return Path.Combine(ModulesDirectory, moduleName + ".grim");
        }

        public static string LogsDirectory => Path.Combine(BaseDirectory, "logs");

        public static string GetLogFile(string moduleName)
        {
            return Path.Combine(LogsDirectory, moduleName + "_log.txt");
        }

        public static string TempDirectory => Path.Combine(BaseDirectory, "temp");

        public static void EnsureDirectories()
        {
            Directory.CreateDirectory(ModulesDirectory);
            Directory.CreateDirectory(LogsDirectory);
            Directory.CreateDirectory(TempDirectory);
        }
    }
}

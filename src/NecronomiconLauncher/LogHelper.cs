using System;
using System.IO;
using NecronomiconLauncher;

namespace NecronomiconLauncher
{
    public static class LogHelper
    {
        public static void Write(string moduleName, string message)
        {
            string logPath = PathHelper.GetLogFile(moduleName);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File.AppendAllText(logPath, $"[{timestamp}] {message}{Environment.NewLine}");
        }

        public static void WriteError(string moduleName, string error)
        {
            Write(moduleName, "❌ HATA: " + error);
        }

        public static void WriteSystem(string message)
        {
            string logPath = Path.Combine(PathHelper.LogsDirectory, "system_log.txt");
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File.AppendAllText(logPath, $"[{timestamp}] {message}{Environment.NewLine}");
        }

        public static void EnsureLogsDirectory()
        {
            Directory.CreateDirectory(PathHelper.LogsDirectory);
        }
    }
}

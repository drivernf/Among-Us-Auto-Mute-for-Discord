using System;
using System.IO;

using CSharpLib;

namespace Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
                return;

            string startupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Among Us Auto Mute.lnk");

            //"Run.lnk"
            if (args[0] == "enable")
            {
                string folderPath = args[1];
                string exePath = Path.Combine(folderPath, "Among Us Auto Mute for Discord.exe");
                string shortcutPath = Path.Combine(folderPath, "Run.lnk");
                if (!File.Exists(shortcutPath))
                    CreateShortcut(exePath, shortcutPath, folderPath);
                if (!File.Exists(startupPath))
                    File.Copy(shortcutPath, startupPath);
            }
            else if (args[0] == "disable")
            {
                if (File.Exists(startupPath))
                    File.Delete(startupPath);
            }
        }

        private static void CreateShortcut(string targetFile, string shortcutFile, string directory)
        {
            Shortcut shortcut = new Shortcut();
            shortcut.CreateShortcutToFile(targetFile, shortcutFile, WorkingDirectory: directory);
        }
    }
}

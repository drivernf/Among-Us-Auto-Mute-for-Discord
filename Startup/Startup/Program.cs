using System;
using System.IO;

namespace Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
                return;

            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Among Us Auto Mute.lnk");

            if (args[0] == "enable")
            {
                if (!File.Exists(shortcutPath))
                    File.Copy(args[1], shortcutPath);
            }
            else if (args[0] == "disable")
            {
                if (File.Exists(shortcutPath))
                    File.Delete(shortcutPath);
            }
        }
    }
}

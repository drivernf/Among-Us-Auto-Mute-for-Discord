using System;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace AmongUsDiscordBot
{
    class Program
    {
        private static Thread loopThread;
        private static NotifyIcon notifyIcon;
        private static ContextMenuStrip CMS;
        private static bool muted = false;
        private static bool dead = false;

        static void Main(string[] args)
        {
            if (!SingleInstanceCheck())
            {
                KillApplication();
                return;
            }

            loopThread = new Thread(new ThreadStart(MainLoop));
            loopThread.Start();

            TaskBarTray();
        }

        private static void MainLoop()
        {
            while (true)
            {
                Rect rect = ProcessRect("Among Us");

                if (rect.right - rect.left == 0)
                {
                    if (muted)
                    {
                        ToggleMute();
                        muted = false;
                    }

                    dead = false;
                    Thread.Sleep(200);
                    continue;
                }

                Bitmap bitmap = CreateBitmap(rect);

                if (SearchPixels(rect, bitmap))
                {
                    muted = !muted;
                    ToggleMute();
                    Thread.Sleep(5000);
                }
                else
                    Thread.Sleep(200);
            }
        }

        private static void ToggleMute()
        {
            SendKeys.SendWait("{END}");
        }

        private static void TaskBarTray()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            notifyIcon = new NotifyIcon();
            notifyIcon.ContextMenuStrip = GetContext();
            notifyIcon.Icon = new Icon("trayicon.ico");
            notifyIcon.Text = "Among Us Auto Mute for Discord";
            notifyIcon.Visible = true;

            Application.Run();
        }

        private static ContextMenuStrip GetContext()
        {
            CMS = new ContextMenuStrip();
            AddCMSItems();
            return CMS;
        }

        private static void AddCMSItems()
        {
            CMS.Items.Clear();
            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Among Us Auto Mute.lnk");
            if (!File.Exists(shortcutPath))
                CMS.Items.Add("Enable Run at Startup", null, new EventHandler(Enable_Run_On_Startup));
            else
                CMS.Items.Add("Disable Run at Startup", null, new EventHandler(Disable_Run_On_Startup));
            CMS.Items.Add("-");
            CMS.Items.Add("Exit", null, new EventHandler(Exit_Click));
        }

        private static void Enable_Run_On_Startup(object sender, EventArgs e)
        {
            string appPath = Path.Combine(Application.StartupPath, "Run.lnk");
            var startupProcess = new ProcessStartInfo();
            startupProcess.FileName = Path.Combine(Application.StartupPath, "Startup.exe");
            startupProcess.Arguments = $"enable \"{appPath}\"";
            startupProcess.Verb = "runas";

            var process = new Process();
            process.StartInfo = startupProcess;
            process.Start();
            process.WaitForExit();

            AddCMSItems();
        }

        private static void Disable_Run_On_Startup(object sender, EventArgs e)
        {
            var startupProcess = new ProcessStartInfo();
            startupProcess.FileName = Path.Combine(Application.StartupPath, "Startup.exe");
            startupProcess.Arguments = $"disable";
            startupProcess.Verb = "runas";

            var process = new Process();
            process.StartInfo = startupProcess;
            process.Start();
            process.WaitForExit();

            AddCMSItems();
        }

        private static bool SingleInstanceCheck()
        {
            Process[] processes = Process.GetProcessesByName("Among Us Auto Mute for Discord");
            if (processes.Length > 1)
                return false;

            return true;
        }

        private static void Exit_Click(object sender, EventArgs e)
        {
            KillApplication();
        }

        private static void KillApplication()
        {
            notifyIcon.Visible = false;
            if (loopThread.ThreadState == System.Threading.ThreadState.Running)
                loopThread.Abort();
            Application.Exit();
            Environment.Exit(0);
        }

        private static Rect ProcessRect(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            var rect = new Rect();
            foreach (Process p in processes)
            {
                GetWindowRect(p.MainWindowHandle, ref rect);
                if (rect.right - rect.left != 0)
                    break;
            }

            return rect;
        }

        private static Bitmap CreateBitmap(Rect rect)
        {
            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            }

            return bitmap;
        }

        private static bool SearchPixels(Rect rect, Bitmap bitmap)
        {
            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            if (!muted)
            {
                if (TestStartGame(bitmap, width, height)) return true;
                if (TestBackInGame(bitmap, width, height)) return true;
            }
            else
            {
                if (TestMeeting(bitmap, width, height)) return true;
                if (TestDefeatScreen(bitmap, width, height)) return true;
                if (TestVictoryScreen(bitmap, width, height)) return true;
            }

            return false;
        }

        private static bool TestStartGame(Bitmap bitmap, int x, int y)
        {
            bool startGame = ComparePixels(bitmap, x / 2, (int)(y * 0.6f), "#C60000");

            if (startGame)
            {
                dead = false;
            }

            return startGame;
        }

        private static bool TestMeeting(Bitmap bitmap, int x, int y)
        {
            if (dead) return false;

            bool meetingAlive = ComparePixels(bitmap, (int)(x * 0.6725f), (int)(y * 0.834f), "#AAC8E5");
            bool meetingDead = ComparePixels(bitmap, (int)(x * 0.6725f), (int)(y * 0.834f), "#242B2E");

            if (meetingAlive)
            {
                return true;
            }
            else if (meetingDead)
            {
                dead = true;
            }

            return false;
        }

        private static bool TestBackInGame(Bitmap bitmap, int x, int y)
        {
            bool backInGame = ComparePixels(bitmap, (int)(x * 0.4428f), (int)(y * 0.051f), "#2E402E");

            if (backInGame)
            {
                return true;
            }

            return false;
        }

        private static bool TestDefeatScreen(Bitmap bitmap, int x, int y)
        {
            bool defeat01 = ComparePixels(bitmap, (int)(x * 0.351f), (int)(y * 0.1826f), "#FF0000");
            bool defeat02 = ComparePixels(bitmap, (int)(x * 0.473f), (int)(y * 0.1855f), "#FF0000");

            if (defeat01 && defeat02)
            {
                dead = false;
                return true;
            }

            return false;
        }

        private static bool TestVictoryScreen(Bitmap bitmap, int x, int y)
        {
            bool victory = ComparePixels(bitmap, (int)(x * 0.3245f), (int)(y * 0.1575f), "#008CFF");

            if (victory)
            {
                dead = false;
                return true;
            }

            return false;
        }

        private static bool ComparePixels(Bitmap bitmap, int x, int y, string searchColor)
        {
            string pixelColor = Hex(bitmap.GetPixel(x, y));

            return pixelColor == searchColor;
        }

        private static string Hex(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
    }
}

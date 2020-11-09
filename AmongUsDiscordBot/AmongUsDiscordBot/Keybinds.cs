using System.Collections.Generic;
using System.Windows.Forms;
using WindowsInput.Native;
using System.Linq;

namespace AmongUsDiscordBot
{
    class Keybinds
    {
        private static Dictionary<Keys, VirtualKeyCode> keyCodes = new Dictionary<Keys, VirtualKeyCode>()
        {
            // Alpha keys
            { Keys.A, VirtualKeyCode.VK_A },
            { Keys.B, VirtualKeyCode.VK_B },
            { Keys.C, VirtualKeyCode.VK_C },
            { Keys.D, VirtualKeyCode.VK_D },
            { Keys.E, VirtualKeyCode.VK_E },
            { Keys.F, VirtualKeyCode.VK_F },
            { Keys.G, VirtualKeyCode.VK_G },
            { Keys.H, VirtualKeyCode.VK_H },
            { Keys.I, VirtualKeyCode.VK_I },
            { Keys.J, VirtualKeyCode.VK_J },
            { Keys.K, VirtualKeyCode.VK_K },
            { Keys.L, VirtualKeyCode.VK_L },
            { Keys.M, VirtualKeyCode.VK_M },
            { Keys.N, VirtualKeyCode.VK_N },
            { Keys.O, VirtualKeyCode.VK_O },
            { Keys.P, VirtualKeyCode.VK_P },
            { Keys.Q, VirtualKeyCode.VK_Q },
            { Keys.R, VirtualKeyCode.VK_R },
            { Keys.S, VirtualKeyCode.VK_S },
            { Keys.T, VirtualKeyCode.VK_T },
            { Keys.U, VirtualKeyCode.VK_U },
            { Keys.V, VirtualKeyCode.VK_V },
            { Keys.W, VirtualKeyCode.VK_W },
            { Keys.X, VirtualKeyCode.VK_X },
            { Keys.Y, VirtualKeyCode.VK_Y },
            { Keys.Z, VirtualKeyCode.VK_Z },
            // Numeric keys
            { Keys.D0, VirtualKeyCode.VK_0 },
            { Keys.D1, VirtualKeyCode.VK_1 },
            { Keys.D2, VirtualKeyCode.VK_2 },
            { Keys.D3, VirtualKeyCode.VK_3 },
            { Keys.D4, VirtualKeyCode.VK_4 },
            { Keys.D5, VirtualKeyCode.VK_5 },
            { Keys.D6, VirtualKeyCode.VK_6 },
            { Keys.D7, VirtualKeyCode.VK_7 },
            { Keys.D8, VirtualKeyCode.VK_8 },
            { Keys.D9, VirtualKeyCode.VK_9 },
            // Arrow keys
            { Keys.Up, VirtualKeyCode.UP },
            { Keys.Down, VirtualKeyCode.DOWN },
            { Keys.Right, VirtualKeyCode.RIGHT },
            { Keys.Left, VirtualKeyCode.LEFT },
            // Decorator keys
            { Keys.Oemcomma, VirtualKeyCode.OEM_COMMA },
            { Keys.OemPeriod, VirtualKeyCode.OEM_PERIOD },
            { Keys.OemQuestion, VirtualKeyCode.OEM_2 },
            { Keys.Oem1, VirtualKeyCode.OEM_1 },
            { Keys.Oem7, VirtualKeyCode.OEM_7 },
            { Keys.OemOpenBrackets, VirtualKeyCode.OEM_4 },
            { Keys.OemCloseBrackets, VirtualKeyCode.OEM_6 },
            { Keys.Oem5, VirtualKeyCode.OEM_5 },
            { Keys.Oemtilde, VirtualKeyCode.OEM_3 },
            { Keys.OemMinus, VirtualKeyCode.OEM_MINUS },
            { Keys.Oemplus, VirtualKeyCode.OEM_PLUS },
            // Modifier keys
            { Keys.Escape, VirtualKeyCode.ESCAPE },
            { Keys.Tab, VirtualKeyCode.TAB },
            { Keys.Capital, VirtualKeyCode.CAPITAL },
            { Keys.ShiftKey, VirtualKeyCode.SHIFT },
            { Keys.LControlKey, VirtualKeyCode.LCONTROL },
            { Keys.Menu, VirtualKeyCode.LMENU },
            { Keys.Space, VirtualKeyCode.SPACE },
            { Keys.RMenu, VirtualKeyCode.RMENU },
            { Keys.Apps, VirtualKeyCode.APPS },
            { Keys.RControlKey, VirtualKeyCode.RCONTROL },
            { Keys.Return, VirtualKeyCode.RETURN },
            { Keys.RShiftKey, VirtualKeyCode.RSHIFT },
            { Keys.Back, VirtualKeyCode.BACK },
            //Above arrow keys
            { Keys.Scroll, VirtualKeyCode.SCROLL },
            { Keys.Pause, VirtualKeyCode.PAUSE },
            { Keys.Insert, VirtualKeyCode.INSERT },
            { Keys.Home, VirtualKeyCode.HOME },
            { Keys.PageUp, VirtualKeyCode.PRIOR },
            { Keys.Delete, VirtualKeyCode.DELETE },
            { Keys.End, VirtualKeyCode.END },
            { Keys.Next, VirtualKeyCode.NEXT },
            // Function keys
            { Keys.F1, VirtualKeyCode.F1 },
            { Keys.F2, VirtualKeyCode.F2 },
            { Keys.F3, VirtualKeyCode.F3 },
            { Keys.F4, VirtualKeyCode.F4 },
            { Keys.F5, VirtualKeyCode.F5 },
            { Keys.F6, VirtualKeyCode.F6 },
            { Keys.F7, VirtualKeyCode.F7 },
            { Keys.F8, VirtualKeyCode.F8 },
            { Keys.F9, VirtualKeyCode.F9 },
            { Keys.F10, VirtualKeyCode.F10 },
            { Keys.F11, VirtualKeyCode.F11 },
            { Keys.F12, VirtualKeyCode.F12 },
            // Numpad
            { Keys.NumLock, VirtualKeyCode.NUMLOCK },
            { Keys.Divide, VirtualKeyCode.DIVIDE },
            { Keys.Multiply, VirtualKeyCode.MULTIPLY },
            { Keys.Subtract, VirtualKeyCode.SUBTRACT },
            { Keys.Add, VirtualKeyCode.ADD },
         };

        private static Dictionary<VirtualKeyCode, string> keyCodeNames = new Dictionary<VirtualKeyCode, string>()
        {
            // Alpha keys
            { VirtualKeyCode.VK_A, "A" },
            { VirtualKeyCode.VK_B, "B" },
            { VirtualKeyCode.VK_C, "C" },
            { VirtualKeyCode.VK_D, "D" },
            { VirtualKeyCode.VK_E, "E" },
            { VirtualKeyCode.VK_F, "F" },
            { VirtualKeyCode.VK_G, "G" },
            { VirtualKeyCode.VK_H, "H" },
            { VirtualKeyCode.VK_I, "I" },
            { VirtualKeyCode.VK_J, "J" },
            { VirtualKeyCode.VK_K, "K" },
            { VirtualKeyCode.VK_L, "L" },
            { VirtualKeyCode.VK_M, "M" },
            { VirtualKeyCode.VK_N, "N" },
            { VirtualKeyCode.VK_O, "O" },
            { VirtualKeyCode.VK_P, "P" },
            { VirtualKeyCode.VK_Q, "Q" },
            { VirtualKeyCode.VK_R, "R" },
            { VirtualKeyCode.VK_S, "S" },
            { VirtualKeyCode.VK_T, "T" },
            { VirtualKeyCode.VK_U, "U" },
            { VirtualKeyCode.VK_V, "V" },
            { VirtualKeyCode.VK_W, "W" },
            { VirtualKeyCode.VK_X, "X" },
            { VirtualKeyCode.VK_Y, "Y" },
            { VirtualKeyCode.VK_Z, "Z" },
            // Numeric keys
            { VirtualKeyCode.VK_0, "0" },
            { VirtualKeyCode.VK_1, "1" },
            { VirtualKeyCode.VK_2, "2" },
            { VirtualKeyCode.VK_3, "3" },
            { VirtualKeyCode.VK_4, "4" },
            { VirtualKeyCode.VK_5, "5" },
            { VirtualKeyCode.VK_6, "6" },
            { VirtualKeyCode.VK_7, "7" },
            { VirtualKeyCode.VK_8, "8" },
            { VirtualKeyCode.VK_9, "9" },
            // Arrow keys
            { VirtualKeyCode.UP, "UP" },
            { VirtualKeyCode.DOWN, "DOWN" },
            { VirtualKeyCode.RIGHT, "RIGHT" },
            { VirtualKeyCode.LEFT, "LEFT" },
            // Decorator keys
            { VirtualKeyCode.OEM_COMMA, "," },
            { VirtualKeyCode.OEM_PERIOD, "." },
            { VirtualKeyCode.OEM_2, "/" },
            { VirtualKeyCode.OEM_1, ";" },
            { VirtualKeyCode.OEM_7, "'" },
            { VirtualKeyCode.OEM_4, "[" },
            { VirtualKeyCode.OEM_6, "]" },
            { VirtualKeyCode.OEM_5, "\\" },
            { VirtualKeyCode.OEM_3, "`" },
            { VirtualKeyCode.OEM_MINUS, "-" },
            { VirtualKeyCode.OEM_PLUS, "+" },
            // Modifier keys
            { VirtualKeyCode.ESCAPE, "ESC" },
            { VirtualKeyCode.TAB, "TAB" },
            { VirtualKeyCode.CAPITAL, "CAPS LOCK" },
            { VirtualKeyCode.SHIFT, "SHIFT" },
            { VirtualKeyCode.LCONTROL, "CTRL" },
            { VirtualKeyCode.LMENU, "ALT" },
            { VirtualKeyCode.SPACE, "SPACE" },
            { VirtualKeyCode.RMENU, "RIGHT ALT" },
            { VirtualKeyCode.APPS, "RIGHT META" },
            { VirtualKeyCode.RCONTROL, "RIGHT CTRL" },
            { VirtualKeyCode.RETURN, "ENTER" },
            { VirtualKeyCode.RSHIFT, "RIGHT SHIFT" },
            { VirtualKeyCode.BACK, "BACKSPACE" },
            //Above arrow keys
            { VirtualKeyCode.SCROLL, "SCROLL LOCK" },
            { VirtualKeyCode.PAUSE, "BREAK" },
            { VirtualKeyCode.INSERT, "INSERT" },
            { VirtualKeyCode.HOME, "HOME" },
            { VirtualKeyCode.PRIOR, "PAGE UP" },
            { VirtualKeyCode.DELETE, "DEL" },
            { VirtualKeyCode.END, "END" },
            { VirtualKeyCode.NEXT, "PAGE DOWN" },
            // Function keys
            { VirtualKeyCode.F1, "F1" },
            { VirtualKeyCode.F2, "F2" },
            { VirtualKeyCode.F3, "F3" },
            { VirtualKeyCode.F4, "F4" },
            { VirtualKeyCode.F5, "F5" },
            { VirtualKeyCode.F6, "F6" },
            { VirtualKeyCode.F7, "F7" },
            { VirtualKeyCode.F8, "F8" },
            { VirtualKeyCode.F9, "F9" },
            { VirtualKeyCode.F10, "F10" },
            { VirtualKeyCode.F11, "F11" },
            { VirtualKeyCode.F12, "F12" },
            // Numpad
            { VirtualKeyCode.NUMLOCK, "NUMPAD CLEAR" },
            { VirtualKeyCode.DIVIDE, "NUMPAD /" },
            { VirtualKeyCode.MULTIPLY, "NUMPAD *" },
            { VirtualKeyCode.SUBTRACT, "NUMPAD -" },
            { VirtualKeyCode.ADD, "NUMPAD +" },
         };

        public static VirtualKeyCode GetVirtualKeyCode(Keys key)
        {
            if (keyCodes.ContainsKey(key))
                return keyCodes[key];
            else
                return VirtualKeyCode.NONAME;
        }

        public static string GetKeyCodeString(VirtualKeyCode keyCode)
        {
            if (keyCodeNames.ContainsKey(keyCode))
                return keyCodeNames[keyCode];
            else
                return "NULL";
        }

        public static VirtualKeyCode KeyCodeLookup(string key)
        {
            return keyCodeNames.FirstOrDefault(x => x.Value == key).Key;
        }
    }
 }

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowsInput.Native;

namespace AmongUsDiscordBot
{
    public partial class ChangeKeybindForm : Form
    {
        public ChangeKeybindForm()
        {
            InitializeComponent();

            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.KeyUp += textBox1_KeyUp;

            // Set keybind text to saved keybind data
            System.Collections.Specialized.StringCollection saved = Properties.Settings.Default.Keybind;
            string[] savedKeybinds = new string[saved.Count];
            saved.CopyTo(savedKeybinds, 0);
            string keybindInputText = "";
            for (int i = 0; i < savedKeybinds.Length; i++)
            {
                keybindInputText += savedKeybinds[i];

                if (i < savedKeybinds.Length - 1)
                    keybindInputText += " + ";
            }
            textBox1.Text = keybindInputText;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ActiveControl = background;
        }

        private void background_Click(object sender, EventArgs e)
        {
            ActiveControl = background;
        }

        private void Keybind_Click(object sender, EventArgs e)
        {
            ActiveControl = background;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            HideCaret(textBox1.Handle);
            textBox1.SelectionLength = 0;
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            HideCaret(textBox1.Handle);
            textBox1.ForeColor = Color.FromArgb(240, 71, 67);
            textBox1.BackColor = Color.FromArgb(48, 51, 57);
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.FromArgb(255, 255, 243);
            textBox1.BackColor = Color.FromArgb(48, 51, 57);
            keysPressed.Clear();
            keys.Clear();
        }

        Stack<Keys> keysPressed = new Stack<Keys>();

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            Keys key = e.KeyCode;

            if (key == Keys.ShiftKey)
            {
                if (GetAsyncKeyState(Keys.RShiftKey) < 0) key = Keys.RShiftKey;
                else key = Keys.ShiftKey;
            }
            else if (key == Keys.ControlKey)
            {
                if (GetAsyncKeyState(Keys.RControlKey) < 0) key = Keys.RControlKey;
                else key = Keys.LControlKey;
            }
            else if (key == Keys.Menu)
            {
                if (GetAsyncKeyState(Keys.RMenu) < 0) key = Keys.RMenu;
                else key = Keys.Menu;
            }

            if (keysPressed.Count == 0 || key != keysPressed.Peek())
            {
                keysPressed.Push(key);
            }

            if (keysPressed.Count == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    keys.Add(keysPressed.Pop());
                }
                HandleKeybind();
            }
        }

        List<Keys> keys = new List<Keys>();
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if (keysPressed.Count == 0)
                return;

            Keys key = keysPressed.Pop();
            keys.Add(key);

            if (keysPressed.Count == 0)
            {
                HandleKeybind();
            }
        }

        private void HandleKeybind()
        {
            keys.Reverse();

            Keys[] keyArr = new Keys[keys.Count];
            int indx = 0;
            foreach (Keys k in keys)
            {
                keyArr[indx] = k;
                indx++;
            }

            string textBoxText = "";
            string[] keybindStrings = new string[keys.Count];
            VirtualKeyCode[] virtualKeyCodes = new VirtualKeyCode[keys.Count];
            Properties.Settings.Default.Keybind.Clear();
            for (int i = 0; i < keyArr.Length; i++)
            {
                VirtualKeyCode vKeyCode = Keybinds.GetVirtualKeyCode(keyArr[i]);
                virtualKeyCodes[i] = vKeyCode;

                string keybindAsString = Keybinds.GetKeyCodeString(vKeyCode);
                textBoxText += keybindAsString;
                keybindStrings[i] = keybindAsString;
                Properties.Settings.Default.Keybind.Add(keybindAsString);

                if (i < keyArr.Length - 1)
                    textBoxText += " + ";
            }

            Properties.Settings.Default.Save();
            Program.muteKeyCodes = virtualKeyCodes;
            textBox1.ForeColor = Color.FromArgb(255, 255, 243);
            textBox1.BackColor = Color.FromArgb(48, 51, 57);
            textBox1.Text = textBoxText;
            

            keys.Clear();
            ActiveControl = background;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys key);

        private void testButton_Click(object sender, EventArgs e)
        {
            Program.Mute();
            Program.Unmute();
            ActiveControl = background;
        }
    }
}

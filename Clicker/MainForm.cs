using Microsoft.Test.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicker
{
    public partial class MainForm : Form
    {
        private KeyStroke currentkeyStroke = null;
        private CancellationTokenSource cancel = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void keyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void keyTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var msKey = MsKeyToTestKey(e.KeyCode);
            if (msKey == Microsoft.Test.Input.Key.None)
                return;
            var keyStroke = new KeyStroke { MsTestKeys = new List<Microsoft.Test.Input.Key>()  };
            if (e.Alt)
                keyStroke.MsTestKeys.Add(Microsoft.Test.Input.Key.LeftAlt);
            if (e.Control)
                keyStroke.MsTestKeys.Add(Microsoft.Test.Input.Key.LeftCtrl);
            if (e.Shift)
                keyStroke.MsTestKeys.Add(Microsoft.Test.Input.Key.LeftShift);
            keyStroke.MsTestKeys.Add(msKey);
            keyTextBox.Text = keyStroke.ToString();
            currentkeyStroke = keyStroke;
        }

        private Microsoft.Test.Input.Key MsKeyToTestKey(Keys keys)
        {
            var name = Enum.GetName(typeof(Keys), keys);
            Microsoft.Test.Input.Key result;
            if (!Enum.TryParse<Microsoft.Test.Input.Key>(name, out result))
                return Microsoft.Test.Input.Key.None;
            return result;
        }

        private void keyStrokeListBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            var selIndex = keyStrokeListBox.SelectedIndex;
            var selItem = keyStrokeListBox.SelectedItem;
            var itemCount = keyStrokeListBox.Items.Count;

            if (e.KeyCode == Keys.Up && e.Modifiers == Keys.None)
            {
                keyStrokeListBox.SelectedIndex = selIndex > 0 ? selIndex - 1 : 0;
                return;
            }

            if (e.KeyCode == Keys.Down && e.Modifiers == Keys.None)
            {
                keyStrokeListBox.SelectedIndex = selIndex == -1 || (selIndex < itemCount - 2) ? selIndex + 1 : itemCount - 1;
                return;
            }

            if (keyStrokeListBox.SelectedItem == null)
                return;
            
            if (e.KeyCode == Keys.Delete)
            {
                keyStrokeListBox.Items.Remove(selItem);
                if (keyStrokeListBox.Items.Count > selIndex)
                    keyStrokeListBox.SelectedIndex = selIndex;
            }
            if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                keyStrokeListBox.Items.Insert(selIndex + 1, selItem);
                keyStrokeListBox.SelectedIndex = selIndex;
            }
            if (e.KeyCode == Keys.Up && e.Modifiers == Keys.Shift && selIndex > 0)
            {
                keyStrokeListBox.Items.Remove(selItem);
                keyStrokeListBox.Items.Insert(selIndex - 1, selItem);
                keyStrokeListBox.SelectedIndex = selIndex - 1;
            }
            if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Shift && selIndex < keyStrokeListBox.Items.Count-1)
            {
                keyStrokeListBox.Items.Remove(selItem);
                keyStrokeListBox.Items.Insert(selIndex + 1, selItem);
                keyStrokeListBox.SelectedIndex = selIndex + 1;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (currentkeyStroke == null)
                return;
            keyStrokeListBox.Items.Add(currentkeyStroke.Clone());
            keyTextBox.Focus();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (cancel == null)
                Start();
            else
                Stop();
        }

        private void Stop()
        {
            cancel.Cancel();
        }

        private void Start()
        {
            repeatTextBox.Text = repeatTextBox.Text.Replace(" ", "");
            delayTextBox.Text = delayTextBox.Text.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(repeatTextBox.Text) || repeatTextBox.Text == "0")
            {
                repeatTextBox.Text = "0";
                MessageBox.Show("Cycle count is not positive. Nothing to do.");
                return;
            }

            if (string.IsNullOrWhiteSpace(delayTextBox.Text) || delayTextBox.Text == "0")
                delayTextBox.Text = "1";

            var repeat = int.Parse(repeatTextBox.Text);
            var delay = int.Parse(delayTextBox.Text);
            var keys = GetStrokeList();

            if (keys.Count == 0)
            {
                MessageBox.Show("Nothing to do");
                return;
            }

            cancel = new CancellationTokenSource();
            startButton.Text = "Stop";

            Task.Run(() => DisplayDelay(delay))
                .ContinueWith(t => PressKeyStrokes(repeat, keys))
                .ContinueWith(t => Cleanup());
        }

        private List<KeyStroke> GetStrokeList()
        {
            var keys = new List<KeyStroke>();
            foreach (KeyStroke k in keyStrokeListBox.Items)
                keys.Add(k);
            return keys;
        }

        private void Cleanup()
        {
            Gui(countDownLabel, c => c.Visible = false);
            Gui(startButton, sb => sb.Text = "Start");
            cancel.Dispose();
            cancel = null;
        }

        private void PressKeyStrokes(int repeat, List<KeyStroke> keys)
        {
            for (var index = 0; index < repeat; index++)
            {
                foreach (var stroke in keys)
                {
                    if (cancel.Token.IsCancellationRequested)
                        return;

                    Gui(countDownLabel, c => c.Text = stroke.ToString());
                    Gui(keyStrokeListBox, l => l.SelectedItem = stroke);

                    foreach (var k in stroke.MsTestKeys)
                        Keyboard.Press(k);
                    foreach (var k in stroke.MsTestKeys.Reverse<Key>())
                        Keyboard.Release(k);
                }
            }
        }

        private void DisplayDelay(int delay)
        {
            var end = DateTime.Now.AddSeconds(delay);
            Gui(countDownLabel, c =>
            {
                c.Text = delay.ToString();
                c.Visible = true;
            });

            while (DateTime.Now < end)
            {
                if (cancel.Token.IsCancellationRequested)
                    return;
                Gui(countDownLabel, c => c.Text = ((int)(end - DateTime.Now).TotalSeconds).ToString());
                Task.Delay(100).Wait();
            }
        }

        public void Gui<T>(T ctrl, Action<T> action)
            where T : Control
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke(action, ctrl);
            else
                action(ctrl);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.AddExtension = true;
                ofd.Filter = "Key Stroke Files|*.strokes|All Files|*.*";
                ofd.CheckFileExists = true;
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                var strokes = KeyStrokeSerializer.Load(ofd.FileName);
                FillList(strokes);    
            }
        }

        private void FillList(List<KeyStroke> strokes)
        {
            keyStrokeListBox.Items.Clear();
            keyStrokeListBox.Items.AddRange(strokes.ToArray<object>());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.Filter = "Key Stroke Files|*.strokes|All Files|*.*";
                if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                KeyStrokeSerializer.Save(sfd.FileName, GetStrokeList());
                Text = Path.GetFileName(sfd.FileName);
            }
        }
    }
}

using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace iCAPS
{
    public partial class MsgBox : Form
    {
        public Form backForm;
        public MsgBox()
        {
            InitializeComponent();

            backForm = new Form()
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                Opacity = .65d,
                BackColor = Color.Black,
                //WindowState = FormWindowState.Maximized,
                Size = Env.FormSize,
                TopMost = true,
                Location = Env.FormLocation,
                ShowInTaskbar = false,
            };
            //if (!System.Diagnostics.Debugger.IsAttached) backForm.Show();
            backForm.Show();

            TopMost = true;
            
            FormBorderStyle = FormBorderStyle.None;
            Width = Env.FormSize.Width;
            int calcHeight = Env.FormSize.Height / 3;
            Height = calcHeight < 380 ? calcHeight : 380;
            Location = new Point(Env.FormLocation.X , Env.FormLocation.Y + (Env.FormSize.Height - Height) / 2);
            //Anchor = AnchorStyles.None;
        }

        public static void Show(string msg, string title = "Message")
        {
            MsgBox thisform = new MsgBox();
            thisform.label1.Text = title;
            thisform.richTextBox1.Text = msg;
            thisform.ShowDialog();
        }
        public static async Task ShowFlash(string msg, string title = "Message", int show_millisecond = 3000)
        {
            MsgBox thisform = new MsgBox();
            thisform.label1.Text = title;
            thisform.richTextBox1.Text = msg;
            thisform.Show();
            //System.Timers.Timer _timer = new System.Timers.Timer(show_millisecond); // 設定 3 秒後觸發
            //_timer.Elapsed += (sender, e) =>
            //{
            //    if (thisform.IsDisposed) return;
            //    thisform.Invoke(new Action(() => 
            //    { 
            //        thisform.backForm?.Close(); 
            //        thisform?.Close(); 
            //    }));
            //};
            //_timer.AutoReset = false; // 只執行一次
            //_timer.Start();


            await thisform.FlashDelay(show_millisecond);     // Task.Delay(show_millisecond);

            thisform.MsgBox_Close();

        }

        CancellationTokenSource cts = new CancellationTokenSource();
        private async Task FlashDelay(int show_millisecond = 3000)
        {
            try
            {
                await Task.Delay(show_millisecond, cts.Token); // 傳入 CancellationToken
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MsgBox_Close();
        }

        private void MsgBox_Close()
        {
            cts.Cancel(); // 取消 Delay
            this.Close();
            this.backForm.Close();
        }
    }
}

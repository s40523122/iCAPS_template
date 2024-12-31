using System;
using System.Drawing;
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
            thisform.backForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

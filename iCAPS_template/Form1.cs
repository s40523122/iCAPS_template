using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace iCAPS
{ 
    public partial class Form1 : Form
    {
        /// <summary>
        /// 連線狀態文字
        /// </summary>
        public string ConnectStatus
        {
            get { return connStatusLabel.Text; }
            set { connStatusLabel.Text = value; }
        }

        List<Button> menu_button_list = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            
            SizeChanged += Form1_SizeChanged;
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.Site?.DesignMode ?? false) return;
            
            WindowState = FormWindowState.Maximized;    // 全螢幕

            menu_add_setting();     // 加入 menu 的 setting 設定
            LoadFormsFromFolder();  // 讀取資料夾建立 menu
        }

        private void menu_add_setting()
        {
            menu_button_list.Add(btnSetting);

            // 嘗試在目前專案中找到 Setting
            Type formType = Assembly.GetEntryAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.Equals("Setting", StringComparison.OrdinalIgnoreCase)
                                     && t.IsSubclassOf(typeof(Form)));

            if (formType == null)
            {
                MessageBox.Show("請確定在專案中已建立Forms/Setting.cs。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Form form = Activator.CreateInstance(formType) as Form;
            btnSetting.Click += (sender, e) => menu_x_Click(sender, e, form);
            // 創建一個新的 Bitmap，並使用 Graphics 類別進行縮放
            Bitmap resizedImage = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(btnSetting.Image, 0, 0, 50, 50);  // 縮放並繪製圖片
            }
            resizedImage = menu_button.icon_black_to_white(resizedImage);
            btnSetting.Image = resizedImage;
        }

        private void LoadFormsFromFolder()
        {
            // string base_directory = AppDomain.CurrentDomain.BaseDirectory;   // 取得目前執行檔所在的目錄
            string base_directory = Environment.CurrentDirectory;   // 取得目前執行檔所在的目錄

            string root_path = Directory.GetParent(base_directory)?.Parent?.FullName;  // 回到專案根目錄 (向上一層)
            string forms_path = Path.Combine(root_path, "Forms");

            // 確保資料夾存在
            if (!Directory.Exists(forms_path))
            {
                MessageBox.Show($"路徑 {forms_path} 不存在");
                return;
            }
            
            // 讀取資料夾內的 .cs 檔案
            string[] csFiles = Directory.GetFiles(forms_path, "*.cs");

            foreach (string csFile in csFiles)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(csFile);

                if (fileNameWithoutExtension == "Setting") continue;       // 跳過 setting 檔案

                // 嘗試在目前專案中找到對應的 Form 類型
                Type formType = Assembly.GetEntryAssembly().GetTypes()
                    .FirstOrDefault(t => t.Name.Equals(fileNameWithoutExtension, StringComparison.OrdinalIgnoreCase)
                                         && t.IsSubclassOf(typeof(Form)));

                if (formType != null)
                {
                    Form form = Activator.CreateInstance(formType) as Form;

                    // 創建按鈕
                    menu_button button = new menu_button(form);

                    button.Click += (sender, e) => menu_x_Click(sender, e, form);

                    // 將按鈕加入主視窗
                    tableLayoutPanel1.Controls.Add(button); // flowLayoutPanel1 是放置按鈕的容器
                    menu_button_list.Add(button);
                }
                else
                {
                    Console.WriteLine($"找不到類型：{fileNameWithoutExtension}");
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // 於環境變數中，紀錄主視窗尺寸&位置
            Env.FormSize = Size;
            Env.FormLocation = Location;
        } 

        #region 視窗控制
        /// <summary>
        /// 視窗縮放 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFormControl_Click(object sender, EventArgs e)
        {
            if (btnFormControl.Change) WindowState = FormWindowState.Normal;
            else WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 視窗最小化 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 關閉程式 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPower_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 設定視窗可拖動
        private Point mousePoint = new Point();
        void panel_title_MouseDown(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            if (!btnFormControl.Change) btnFormControl.Change = true;
            base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void panel_title_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = MousePosition.Y - mousePoint.Y;
                this.Left = MousePosition.X - panel4.Width - mousePoint.X;
            }

            Env.FormLocation = Location;
        }
        #endregion

        #region 返回主程式
        private const int SW_NORMAL = 1;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        private IntPtr handle;

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                MsgBox.Show("現在是偵錯模式!");
                return;
            }

            this.WindowState = FormWindowState.Minimized;
            Process[] processName = Process.GetProcessesByName("iCAPS");
            var p = System.Diagnostics.Process.GetProcessesByName("iCAPS").FirstOrDefault();
            ShowWindow(p.MainWindowHandle, SW_NORMAL);
            handle = processName[0].MainWindowHandle;
            SetForegroundWindow(handle);
        }
        #endregion

        #region 菜單點擊事件
        /// <summary>
        /// Menu 點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_x_Click(object sender, EventArgs e, Form frame)
        {
            Button button = sender as Button;
            btnColor(button);

            if (!(button.Tag is Form))
            {
                frame.Dock = DockStyle.Fill;
                frame.TopLevel = false;
                frame.Parent = panel1;
                frame.FormBorderStyle = FormBorderStyle.None;

                button.Tag = frame;
            }

            Tag = button.Tag;
            (button.Tag as Form).Show();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// 按鈕選中後渲染
        /// </summary>
        /// <param name="btn"></param>
        private void btnColor(Button btn)
        {
            slidePanel.Top = btn.Top + btn.Parent.Top;
            slidePanel.Visible = true;
            foreach (var item in menu_button_list)
            {
                item.BackColor = Color.SteelBlue;
            }
            btn.BackColor = Color.DodgerBlue;
            if (Tag is Form) (Tag as Form).Hide();
        }
        #endregion 

        class menu_button : Button
        {
            public menu_button(Form formType)
            {
                Text = $"  {formType.Text}";
                Font = new Font("微軟正黑體", 14.25F, FontStyle.Bold);
                ForeColor = Color.White;

                FlatStyle = FlatStyle.Flat;
                FlatAppearance.BorderSize = 0;

                AutoSize = true;
                Padding = new Padding(20, 0, 0, 0);
                Dock = DockStyle.Fill;

                Image input_img = icon_black_to_white(formType.Icon.ToBitmap());
                // 創建一個新的 Bitmap，並使用 Graphics 類別進行縮放
                Bitmap resizedImage = new Bitmap(50, 50);
                using (Graphics g = Graphics.FromImage(resizedImage))
                {
                    g.DrawImage(input_img, 0, 0, 50, 50);  // 縮放並繪製圖片
                }
                Image = resizedImage;

                ImageAlign = ContentAlignment.MiddleLeft;
                TextImageRelation = TextImageRelation.ImageBeforeText;

                Cursor = Cursors.Hand;

                //Tag = formType;
            }

            public static Bitmap icon_black_to_white(Bitmap bitmap)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        // 獲取當前像素的顏色
                        Color pixelColor = bitmap.GetPixel(x, y);

                        // 檢查是否為黑色 (RGB = (0, 0, 0))
                        if (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0 && pixelColor.A != 0)
                        {
                            // 將黑色像素轉為白色
                            bitmap.SetPixel(x, y, Color.FromArgb(pixelColor.A, 255, 255, 255));
                        }
                    }
                }

                return bitmap;
            }
        }
    }

}

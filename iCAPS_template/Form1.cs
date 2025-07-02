using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Chump_kuka.Controls;

namespace iCAPS
{ 
    public partial class Form1 : Form
    {
        //private string _form_path = "";
        private SubBubble _sub_bubble;      // 泡泡視窗，當 Env.EnableBubble = true 時，視窗最小化會以泡泡置頂出現

        public string FormsPath 
        {
            get => INiReader.ReadINIFile(Env.ini_path, "System", "FormsPath"); 
            set => INiReader.WriteINIFile(Env.ini_path, "System", "FormsPath", value);
        }

        /// <summary>
        /// 連線狀態文字
        /// </summary>
        public string ConnectStatus
        {
            get { return connStatusLabel.Text; }
            set { connStatusLabel.Text = value; }
        }

        List<Button> menu_button_list = new List<Button>();
        SidePanel right_side_panel;

        public Form1()
        {
            InitializeComponent();

            string[] Version_parts = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');
            string icaps_version = string.Join(".", Version_parts.Take(3));
            version_no.Text = $"V{icaps_version}";

            SizeChanged += Form1_SizeChanged;
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.Site?.DesignMode ?? false) return;

            // 若設定允許開啟泡泡視窗，建立泡泡視窗實例
            if (Env.EnableBubble)
            {
                _sub_bubble = new SubBubble(this);
            }

            // 判定是否啟用右側欄
            if (enable_side.Checked)
            {
                side_trick.Visible = true;

                // 嘗試在目前專案中找到 SidePanel
                Type side_panel = Assembly.GetEntryAssembly().GetTypes()
                    .FirstOrDefault(t => t.Name.Equals("SidePanel", StringComparison.OrdinalIgnoreCase));

                if (side_panel == null)
                {
                    MessageBox.Show("請確定在專案中已建立 SidePanel.cs。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                right_side_panel = Activator.CreateInstance(side_panel) as SidePanel;
                right_side_panel.Parent = panel1;
            }

            menu_add_setting();     // 加入 menu 的 setting 設定
            LoadFormsFromFolder();  // 讀取資料夾建立 menu
            WindowState = FormWindowState.Maximized;    // 全螢幕
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
            string[] csFiles;

            if (Debugger.IsAttached)
            {
                // string root_path = Directory.GetParent(base_directory)?.Parent?.FullName;  // 回到專案根目錄 (向上一層)
                if (FormsPath == "")
                {
                    using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                    {
                        folderDialog.Description = "請選擇 Forms 所在資料夾";
                        folderDialog.ShowNewFolderButton = true;

                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            string selectedPath = folderDialog.SelectedPath;
                            FormsPath = selectedPath;
                            Console.WriteLine("你選擇的資料夾路徑是：" + selectedPath);
                        }
                        else
                        {
                            Console.WriteLine("使用者取消選擇");
                        }
                    }
                }
                // string forms_path = Path.Combine(FormsPath, "Forms");

                // 確保資料夾存在
                if (!Directory.Exists(FormsPath))
                {
                    MessageBox.Show($"路徑 {FormsPath} 不存在");
                    return;
                }

                // 讀取資料夾內的 .cs 檔案
                csFiles = Directory.GetFiles(FormsPath, "*.cs");
                
            }
            else
            {
                string forms_string = INiReader.ReadINIFile(Env.ini_path, "System", "Forms");
                csFiles = forms_string.Split(';');
            }
            

            List<string> form_cs = new List<string>();
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
                    form_cs.Add(fileNameWithoutExtension);

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
            if (Debugger.IsAttached)
            {
                string result = string.Join(";", form_cs);
                INiReader.WriteINIFile(Env.ini_path, "System", "Forms", result);
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
            if (Env.EnableBubble)
            {
                _sub_bubble.Show();
                this.Hide();
            }
            else
            {
                WindowState = FormWindowState.Minimized;
            }
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

                AutoSize = false;
                Padding = new Padding(20, 0, 0, 0);
                Dock = DockStyle.Top;
                Height = 80;

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

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            right_side_panel.Start = true;
        }
    }

}

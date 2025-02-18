using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCAPS
{
    public partial class SidePanel : UserControl
    {
        private bool isExpanded = false; // 側邊欄展開狀態
        private float MaxSidebarWidth = 200; // 側邊欄最大寬度
        private const int AnimationSpeed = 30; // 動畫速度 (越小越快)
        private int ParentWidth = 200;
        public bool Start
        {
            set 
            {
                if(!isExpanded) SidebarTimer.Start(); 
            }
        }

        public SidePanel()
        {
            InitializeComponent();
            Load += SidePanel_Load;
            Resize += SidePanel_Resize_design;
        }

        private void SidePanel_Resize_design(object sender, EventArgs e)
        {
            title.Height = (int)(this.Height * 0.05);
            close_btn.Size = new Size(title.Height, title.Height);
        }

        public void SidePanel_Resize(object sender, EventArgs e)
        {
            if (ParentWidth != Parent.Width)
            {
                ParentWidth = Parent.Width - 6;
                MaxSidebarWidth = ParentWidth * 0.3f;

                this.Location = new Point(ParentWidth, 0);
                this.Width = (int)MaxSidebarWidth;
                this.Height = Parent.Height; // 讓側邊欄高度等於視窗高度
            }
        }

        public void SidePanel_Load(object sender, EventArgs e)
        {
            if (this.Site?.DesignMode ?? false) return;

            Resize -= SidePanel_Resize_design;
            Resize += SidePanel_Resize;

            InitializeSidebar();

            this.BringToFront(); // 確保在最上層

            //SidePanelContent content = new SidePanelContent();
            //tableLayoutPanel1.Controls.Add(content, 1, 1); // 在第 1 欄、第 1 列加入按鈕
        }

        private void InitializeSidebar()
        {
            // 設定 SidePanel 初始狀態
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                // 收回動畫
                if (this.Left <= ParentWidth)
                {
                    this.Left += AnimationSpeed;
                }
                else
                {
                    SidebarTimer.Stop();
                    isExpanded = false;
                }
            }
            else
            {
                // 展開動畫
                if (this.Left > ParentWidth - (int)MaxSidebarWidth)
                {
                    int expectLeft = this.Left - AnimationSpeed;
                    if (expectLeft < ParentWidth - MaxSidebarWidth) this.Left = ParentWidth - (int)MaxSidebarWidth;
                    else this.Left = expectLeft;

                }
                else
                {
                    SidebarTimer.Stop();
                    isExpanded = true;
                }
            }

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            SidebarTimer.Start();
        }
    }
}

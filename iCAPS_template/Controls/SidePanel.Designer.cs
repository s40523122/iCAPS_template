namespace iCAPS
{
    partial class SidePanel
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SidePanel));
            this.SidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.title = new System.Windows.Forms.Panel();
            this.close_btn = new iCAPS.DoubleImg();
            this.title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // SidebarTimer
            // 
            this.SidebarTimer.Interval = 5;
            this.SidebarTimer.Tick += new System.EventHandler(this.SidebarTimer_Tick);
            // 
            // title
            // 
            this.title.Controls.Add(this.close_btn);
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Margin = new System.Windows.Forms.Padding(0);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(3);
            this.title.Size = new System.Drawing.Size(284, 35);
            this.title.TabIndex = 1;
            // 
            // close_btn
            // 
            this.close_btn.Change = false;
            this.close_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_btn.EnableCilck = false;
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.Location = new System.Drawing.Point(252, 3);
            this.close_btn.Margin = new System.Windows.Forms.Padding(5);
            this.close_btn.Name = "close_btn";
            this.close_btn.SetSquare = true;
            this.close_btn.Size = new System.Drawing.Size(29, 29);
            this.close_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close_btn.SubImg = null;
            this.close_btn.TabIndex = 0;
            this.close_btn.TabStop = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // SidePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.title);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SidePanel";
            this.Size = new System.Drawing.Size(284, 560);
            this.title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer SidebarTimer;
        private DoubleImg close_btn;
        private System.Windows.Forms.Panel title;
    }
}

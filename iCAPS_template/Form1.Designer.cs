namespace iCAPS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.slidePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.info = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMini = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btFold = new System.Windows.Forms.PictureBox();
            this.btPower = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.connStatusLabel = new System.Windows.Forms.Label();
            this.moduleTitle = new System.Windows.Forms.Label();
            this.btnFormControl = new iCAPS.DoubleImg();
            this.scaleLabel1 = new iCAPS.ScaleLabel();
            this.scaleLabel2 = new iCAPS.ScaleLabel();
            this.scaleLabel3 = new iCAPS.ScaleLabel();
            this.sidePanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btFold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFormControl)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.SteelBlue;
            this.sidePanel.Controls.Add(this.slidePanel);
            this.sidePanel.Controls.Add(this.tableLayoutPanel2);
            this.sidePanel.Controls.Add(this.tableLayoutPanel1);
            this.sidePanel.Controls.Add(this.info);
            this.sidePanel.Controls.Add(this.panel4);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(266, 720);
            this.sidePanel.TabIndex = 0;
            // 
            // slidePanel
            // 
            this.slidePanel.BackColor = System.Drawing.Color.DarkOrange;
            this.slidePanel.Location = new System.Drawing.Point(4, 39);
            this.slidePanel.Name = "slidePanel";
            this.slidePanel.Size = new System.Drawing.Size(8, 81);
            this.slidePanel.TabIndex = 2;
            this.slidePanel.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnHome, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnSetting, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 459);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(266, 261);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(3, 177);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(204, 80);
            this.btnHome.TabIndex = 4;
            this.btnHome.Text = "  返回主頁";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(3, 90);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSetting.Size = new System.Drawing.Size(204, 80);
            this.btnSetting.TabIndex = 4;
            this.btnSetting.Text = "   設定";
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetting.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 136);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(266, 464);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // info
            // 
            this.info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.info.Image = ((System.Drawing.Image)(resources.GetObject("info.Image")));
            this.info.Location = new System.Drawing.Point(3, 452);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(30, 32);
            this.info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.info.TabIndex = 2;
            this.info.TabStop = false;
            this.info.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(266, 136);
            this.panel4.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Controls.Add(this.scaleLabel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.scaleLabel2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.scaleLabel3, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(266, 136);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMini);
            this.panel2.Controls.Add(this.btnFormControl);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btFold);
            this.panel2.Controls.Add(this.btPower);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(266, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(965, 46);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_title_MouseMove);
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMini.BackgroundImage")));
            this.btnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMini.FlatAppearance.BorderSize = 0;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.Location = new System.Drawing.Point(838, 8);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(29, 29);
            this.btnMini.TabIndex = 7;
            this.btnMini.UseVisualStyleBackColor = true;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(965, 1);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(43, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "State Monitor App";
            // 
            // btFold
            // 
            this.btFold.Image = ((System.Drawing.Image)(resources.GetObject("btFold.Image")));
            this.btFold.Location = new System.Drawing.Point(17, 13);
            this.btFold.Name = "btFold";
            this.btFold.Size = new System.Drawing.Size(20, 22);
            this.btFold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btFold.TabIndex = 2;
            this.btFold.TabStop = false;
            // 
            // btPower
            // 
            this.btPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPower.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPower.FlatAppearance.BorderSize = 0;
            this.btPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPower.Image = ((System.Drawing.Image)(resources.GetObject("btPower.Image")));
            this.btPower.Location = new System.Drawing.Point(934, 13);
            this.btPower.Name = "btPower";
            this.btPower.Size = new System.Drawing.Size(20, 22);
            this.btPower.TabIndex = 0;
            this.btPower.UseVisualStyleBackColor = true;
            this.btPower.Click += new System.EventHandler(this.btPower_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(266, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 579);
            this.panel1.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(266, 140);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(965, 1);
            this.panel5.TabIndex = 44;
            // 
            // connStatusLabel
            // 
            this.connStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connStatusLabel.AutoSize = true;
            this.connStatusLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.connStatusLabel.Location = new System.Drawing.Point(988, 82);
            this.connStatusLabel.Name = "connStatusLabel";
            this.connStatusLabel.Size = new System.Drawing.Size(231, 34);
            this.connStatusLabel.TabIndex = 43;
            this.connStatusLabel.Text = "連線狀態：未連接";
            // 
            // moduleTitle
            // 
            this.moduleTitle.AutoSize = true;
            this.moduleTitle.BackColor = System.Drawing.SystemColors.Control;
            this.moduleTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.moduleTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moduleTitle.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.moduleTitle.Location = new System.Drawing.Point(266, 46);
            this.moduleTitle.Name = "moduleTitle";
            this.moduleTitle.Padding = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.moduleTitle.Size = new System.Drawing.Size(383, 94);
            this.moduleTitle.TabIndex = 42;
            this.moduleTitle.Text = "設備狀態監控App";
            this.moduleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFormControl
            // 
            this.btnFormControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFormControl.Change = false;
            this.btnFormControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFormControl.EnableCilck = true;
            this.btnFormControl.Image = ((System.Drawing.Image)(resources.GetObject("btnFormControl.Image")));
            this.btnFormControl.Location = new System.Drawing.Point(886, 10);
            this.btnFormControl.Name = "btnFormControl";
            this.btnFormControl.SetSquare = true;
            this.btnFormControl.Size = new System.Drawing.Size(27, 27);
            this.btnFormControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFormControl.SubImg = ((System.Drawing.Image)(resources.GetObject("btnFormControl.SubImg")));
            this.btnFormControl.TabIndex = 5;
            this.btnFormControl.TabStop = false;
            this.btnFormControl.Click += new System.EventHandler(this.BtnFormControl_Click);
            // 
            // scaleLabel1
            // 
            this.scaleLabel1.AutoSize = true;
            this.scaleLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.scaleLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleLabel1.Factor = 0.31F;
            this.scaleLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scaleLabel1.Font = new System.Drawing.Font("微軟正黑體", 29.45F, System.Drawing.FontStyle.Bold);
            this.scaleLabel1.ForeColor = System.Drawing.Color.White;
            this.scaleLabel1.Location = new System.Drawing.Point(0, 0);
            this.scaleLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.scaleLabel1.Name = "scaleLabel1";
            this.scaleLabel1.Size = new System.Drawing.Size(172, 95);
            this.scaleLabel1.TabIndex = 5;
            this.scaleLabel1.Text = "iCAPS";
            this.scaleLabel1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // scaleLabel2
            // 
            this.scaleLabel2.AutoSize = true;
            this.scaleLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleLabel2.Factor = 0.14F;
            this.scaleLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.3F);
            this.scaleLabel2.ForeColor = System.Drawing.Color.White;
            this.scaleLabel2.Location = new System.Drawing.Point(175, 0);
            this.scaleLabel2.Name = "scaleLabel2";
            this.scaleLabel2.Size = new System.Drawing.Size(88, 95);
            this.scaleLabel2.TabIndex = 6;
            this.scaleLabel2.Text = "V2.0.1";
            this.scaleLabel2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // scaleLabel3
            // 
            this.scaleLabel3.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.scaleLabel3, 2);
            this.scaleLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleLabel3.Factor = 0.32F;
            this.scaleLabel3.Font = new System.Drawing.Font("微軟正黑體", 13.12F, System.Drawing.FontStyle.Bold);
            this.scaleLabel3.ForeColor = System.Drawing.Color.White;
            this.scaleLabel3.Location = new System.Drawing.Point(3, 95);
            this.scaleLabel3.Name = "scaleLabel3";
            this.scaleLabel3.Size = new System.Drawing.Size(260, 41);
            this.scaleLabel3.TabIndex = 7;
            this.scaleLabel3.Text = "  智慧電腦輔助生產系統";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1231, 720);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.connStatusLabel);
            this.Controls.Add(this.moduleTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "狀態監控App";
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.info)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btFold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFormControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btFold;
        private System.Windows.Forms.Panel slidePanel;
        private System.Windows.Forms.PictureBox info;
        private System.Windows.Forms.Button btPower;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label connStatusLabel;
        private System.Windows.Forms.Label moduleTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private iCAPS.DoubleImg btnFormControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ScaleLabel scaleLabel1;
        private ScaleLabel scaleLabel2;
        private ScaleLabel scaleLabel3;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCAPS.Forms
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();

            WebView webView = new WebView();        // 建立實例，初始化網址 ( 預設為google首頁 )
            webView.Embed(this);        // 嵌入控制項中
        }
    }
}

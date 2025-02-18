using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace iCAPS
{
    public class WebView
    {
        private static CefSettings settings;
        private ChromiumWebBrowser browser;
        public WebView(string url = "https://www.google.com/")
        {
            InitializeCef();
            browser = new ChromiumWebBrowser(url);
            browser.Show();
        }

        public void Embed(Control ctrl = null)
        {
            // 若未指定嵌入控制項，開啟彈出式表單以顯示內容
            if (ctrl != null)
            {
                ctrl.Controls.Add(browser); 
                browser.Dock = DockStyle.Fill;
            }
            else
            {
                Form form = new Form();
                form.Controls.Add(browser);
                form.Show();
            }
        }

        private void InitializeCef()
        {
            // 初始化 CefSharp
            if (settings != null) return;
            settings = new CefSettings();
            Cef.Initialize(settings);
        }

        public static void main(Control ctrl = null)
        {
            WebView webView = new WebView();        // 建立實例，初始化網址 ( 預設為google首頁 )
            webView.Embed(ctrl);        // 嵌入控制項中
        }

    }
}

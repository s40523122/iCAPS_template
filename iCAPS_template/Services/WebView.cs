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
        private ChromiumWebBrowser browser;
        public void InitializeBrowser(string url = "https://www.google.com/")
        {
            browser = new ChromiumWebBrowser(url);
            browser.Show();
        }

        public void Embed(Control ctrl = null)
        {
            // 若未指定控制項，開啟新表單以顯示網頁
            if (ctrl != null)
            {
                 ctrl.Controls.Add(browser); 
            }
            else
            {
                Form form = new Form();
                form.Controls.Add(browser);
                form.Show();
            }
        }

        public static void main(Control ctrl = null)
        {
            WebView webView = new WebView();        // 建立實例
            webView.InitializeBrowser();        // 初始化網址 ( 預設為google首頁 )
            webView.Embed(ctrl);        // 嵌入控制項中
        }

    }
}

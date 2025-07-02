using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCAPS
{
    public class Env
    {
        /// <summary>
        /// 專案 Debug 路徑
        /// </summary>
        public static string debug_path = Application.StartupPath;
        public static string ini_path = Path.Combine(debug_path, "config\\layout.ini");

        public static Size FormSize { get; set; }
        public static Point FormLocation { get; set; }

        /// <summary>
        /// 允許當視窗最小化時，以泡泡形式置頂於螢幕排列
        /// </summary>
        public static bool EnableBubble { get; set; } = false;

        /// <summary>
        /// 當前視窗狀態是否為泡泡形式
        /// </summary>
        public static bool IsBubble {  get; set; } = false;
    }
}

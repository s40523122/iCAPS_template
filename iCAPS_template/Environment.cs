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
    }
}

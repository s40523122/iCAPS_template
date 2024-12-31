using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCAPS
{
    internal class Env
    {
        /// <summary>
        /// 專案 Debug 路徑
        /// </summary>
        public static string debug_path = Application.StartupPath;

        public static Size FormSize { get; set; }
        public static Point FormLocation { get; set; }
    }
}

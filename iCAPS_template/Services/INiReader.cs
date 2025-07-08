using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;


namespace iCAPS
{
    public class INiReader
    {
        // 寫入 INI 檔案的方法
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        /// <summary>
        /// 將資料寫入 INI 檔案
        /// </summary>
        /// <param name="path">INI 檔案地址</param>
        /// <param name="section">資料所在之節</param>
        /// <param name="key">資料參數名稱</param>
        /// <param name="value">資料參數之值</param>
        /// <returns>(bool) 是否寫入</returns>
        /// <remarks>
        /// 若欲使用工作位置資料夾路徑，可使用下列程式碼
        /// <code>
        /// string DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/temp.ini");
        /// </code>
        /// </remarks>
        public static bool WriteINIFile(string filePath, string section, string key, string value)
        {
            try
            {
                // 判斷資料夾是否存在
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);       // 若不存在，自動建立
                }

                // 檢查檔案是否存在
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "", Encoding.Unicode);
                }

                    // 寫入INI檔案
                WritePrivateProfileString(section, key, value, filePath);
                return true;
            }
            catch
            {
                return false;
            }

        }

        // 讀取 INI 檔案的方法
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnBuffer, int size, string filePath);

        /// <summary>
        /// 讀取 INI 檔案內資料之值
        /// </summary>
        /// <param name="path">INI 檔案地址</param>
        /// <param name="section">資料所在之節</param>
        /// <param name="key">資料參數名稱</param>
        /// <param name="bufferSize">緩衝區大小</param>
        /// <returns>(string) 讀取之資料內容</returns>
        /// <remarks>
        /// 若欲使用工作位置資料夾路徑，可使用下列程式碼
        /// <code>
        /// string DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/temp.ini");
        /// </code>
        /// </remarks>
        public static string ReadINIFile(string path, string section, string key, int bufferSize = 255)
        {
            StringBuilder buffer = new StringBuilder(bufferSize);

            GetPrivateProfileString(section, key, "", buffer, bufferSize, path);

            return buffer.ToString();
        }
    }
}

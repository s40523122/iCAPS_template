using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCAPS
{
    public class ScalePadding : TableLayoutPanel
    {
        [Description("初始化為9宮格。"), Category("自訂值")]
        public bool Init
        {
            get { return _init; }
            set
            {
                _init = value;

                SetRowStyles(20f);
                SetColumnStyles(20f);
                Refresh();
            }
        }
        private bool _init = false;

        [Description("設定上下邊界占比。"), Category("自訂值")]
        public float SetRowRatio
        {
            get { return _row_ratio; }
            set
            {
                _row_ratio = value;

                // 設定行高
                SetRowStyles(value);
            }
        }
        private float _row_ratio = 20f;

        [Description("設定左右邊界占比。"), Category("自訂值")]
        public float SetColumnRatio
        {
            get { return _column_ratio; }
            set
            {
                _column_ratio = value;

                // 設定列寬
                SetColumnStyles(value);
            }
        }
        private float _column_ratio = 20f;

        //public ScalePadding() 
        //{

        //}

        private void UpdateLayout()
        {
            SuspendLayout(); // 避免畫面閃爍


            ResumeLayout();
            PerformLayout();
        }

        private void SetRowStyles(float side)
        {
            if (RowCount != 3 || ColumnCount != 3) // 防止重設
            {
                RowCount = 3;
                ColumnCount = 3;
            }
            
            float middle = 100 - (2 * side); // 計算中間比例
            if (RowStyles.Count < 3)
            {
                RowStyles.Clear();
                RowStyles.Add(new RowStyle(SizeType.Percent, side));
                RowStyles.Add(new RowStyle(SizeType.Percent, middle));
                RowStyles.Add(new RowStyle(SizeType.Percent, side));
            }
            else
            {
                RowStyles[0].Height = side;
                RowStyles[1].Height = middle;
                RowStyles[2].Height = side;
            }
        }

        private void SetColumnStyles(float side)
        {
            if (RowCount != 3 || ColumnCount != 3) // 防止重設
            {
                RowCount = 3;
                ColumnCount = 3;
            }

            float middle = 100 - (2 * side); // 計算中間比例
            if (ColumnStyles.Count < 3)
            {
                ColumnStyles.Clear();
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, side));
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, middle));
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, side));
            }
            else
            {
                ColumnStyles[0].Width = side;
                ColumnStyles[1].Width = middle;
                ColumnStyles[2].Width = side;
            }
        }

    }
}

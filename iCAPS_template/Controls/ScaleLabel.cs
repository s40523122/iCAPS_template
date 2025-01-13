using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCAPS
{
    public class ScaleLabel : Label
    {
        [Description("縮放因子。"), Category("自訂值")]
        public float Factor
        {
            get { return _factor; }
            set 
            {
                _factor = value;
                Invalidate();
                //Font = new Font(Font.FontFamily, Height * _factor, Font.Style);
            }
        }
        private float _factor = 0.5f;

        public ScaleLabel()
        {
            AutoSize = false;
            SizeChanged += ScaleLabel_SizeChanged;
            Paint += ScaleLabel_Paint;
        }

        private void ScaleLabel_Paint(object sender, PaintEventArgs e)
        {
            Font = new Font(Font.FontFamily, Height * _factor, Font.Style);
        }

        private void ScaleLabel_SizeChanged(object sender, EventArgs e)
        {
            
            Factor = _factor;
        }
    }
}

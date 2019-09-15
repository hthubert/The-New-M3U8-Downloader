using System.Drawing;
using System.Windows.Forms;

namespace M3U8_Downloader
{
    //新建一个MyProgressBar类，它继承了ProgressBar的所有属性与方法
    class MyProgressBar : ProgressBar
    {
        public MyProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);//使控件可由用户自由重绘
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var bounds = new Rectangle(0, 0, Width, Height);
            //此处完成背景重绘，并且按照属性中的BackColor设置背景色
            e.Graphics.FillRectangle(new SolidBrush(BackColor), 1, 1, bounds.Width - 2, bounds.Height - 2);
            bounds.Height -= 4;
            //是的进度条跟着ProgressBar.Value值变化
            bounds.Width = ((int)(bounds.Width * (Value / ((double)Maximum)))) - 4;
            SolidBrush brush = new SolidBrush(ForeColor);
            //此处完成前景重绘，依旧按照Progressbar的属性设置前景色
            e.Graphics.FillRectangle(brush, 2, 2, bounds.Width, bounds.Height);
        }
    }
}
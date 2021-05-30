using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public class Trump
    {
        public int Y { get; set; }
        public int X { get; set; }
        public bool MovingLeft = true;
        public int StartPosition;
        public PictureBox CreateTrump(int x, int y)
        {
            return new PictureBox
            {
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(60, 100),
                Image = Properties.Resources.TrumpLeft,
                Location = new Point(x, y)
            };
        }
    }
}

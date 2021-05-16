using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public class Coins
    {
        public PictureBox CreateCoin(int x, int y)
        {
            return new PictureBox
            {
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(50, 50),
                Image = Properties.Resources.монетка,
                Location = new Point(x, y)
            };
        }
    }
}
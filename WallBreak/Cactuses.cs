using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WallBreak
{
    class Cactuses
    {
        public PictureBox CreateCactus(int x, int y)
        {
            return new PictureBox
            {
                BackColor = Color.BlueViolet,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(75, 100),
                Image = Properties.Resources.Cactus__1_,
                Location = new Point(x, y)
            };
        }
    }
}

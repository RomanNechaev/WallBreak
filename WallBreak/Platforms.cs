using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    class Platforms
    {
        public PictureBox CreatePlatform(int x, int y)
        {
            return new PictureBox
            {
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(250, 50),
                Image = Properties.Resources.заккк,
                Location = new Point(x, y)
            };
        }
        //PictureBox Boom = new PictureBox();
        //Boom.Name = "Boom";
        //Boom.BackColor = Color.Transparent;
        //Boom.SizeMode = PictureBoxSizeMode.StretchImage;
        //Boom.Size = new Size(200, 60);
        //Boom.Image = Properties.Resources.заккк;
        //Boom.Location = new Point(1200, 100);
        //return Boom;
    }
}

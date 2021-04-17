using System;
using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            var label = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Century Gothic", 85F, ((FontStyle) ((FontStyle.Bold | FontStyle.Italic))),
                    GraphicsUnit.Point),
                Location = new Point(470, 34),
                Name = "label1",
                Size = new Size(900, 180),
                Text = "Настройки",
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(label);
        }
        
    }
}
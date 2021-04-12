using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallBreak
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            var label = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Century Gothic", 80F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point),
                Location = new Point(460, 44),
                Name = "label1",
                Size = new Size(827, 207),
                Text = "WallBreak",
                TextAlign = ContentAlignment.MiddleCenter
            };

            var startGame = CreateButton("Начать игру", new Point(550, 288));
            var settings = CreateButton("Настройки", new Point(550, 419));
            var exit = CreateButton("Выйти из игры", new Point(550, 550));
            exit.Click += (sender, args) => Application.Exit();
            
            InitializeComponent();
            Controls.Add(label);
            Controls.Add(exit);
            Controls.Add(startGame);
            Controls.Add(settings);
        }

        private static Button CreateButton(string text, Point coords)
        {
            var button = new Button
            {
                Text = text,
                BackColor = SystemColors.Control,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Century Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point),
                Location = coords,
                Size = new Size(637, 72),
            };
            button.FlatAppearance.MouseOverBackColor = Color.Pink;
            return button;
        }
    }
}
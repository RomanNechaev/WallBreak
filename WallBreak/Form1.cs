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
using Microsoft.Win32;

namespace WallBreak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var label = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Century Gothic", 85F, ((FontStyle) ((FontStyle.Bold | FontStyle.Italic))),
                    GraphicsUnit.Point),
                Location = new Point(470, 34),
                Name = "label1",
                Size = new Size(1000, 207),
                Text = "WallBreak",
                TextAlign = ContentAlignment.MiddleCenter
            };

            var startGame = CreateButton("Начать игру", new Point(600, 330));
            var settings = CreateButton("Настройки", new Point(600, 500));
            var exit = CreateButton("Выйти из игры", new Point(600, 670));
            exit.Click += (sender, args) => Application.Exit();
            settings.DoubleClick += (sender, args) =>
            {
                
            };
                
            Music();
            InitializeComponent();
            Controls.Add(label);
            Controls.Add(exit);
            Controls.Add(startGame);
            Controls.Add(settings);
        }

        private static void Music()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream resourceStream = assembly.GetManifestResourceStream(@"WallBreak.мекс.wav");
            SoundPlayer player = new SoundPlayer(resourceStream);
            player.Play();
            
        }

        private static Button CreateButton(string text, Point coords)
        {
            var button = new Button
            {
                Text = text,
                BackColor = SystemColors.Control,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Century Gothic", 28F, FontStyle.Bold, GraphicsUnit.Point),
                Location = coords,
                Size = new Size(700, 90),
            };
            button.FlatAppearance.MouseOverBackColor = Color.Pink;
            return button;
        }
    }
}
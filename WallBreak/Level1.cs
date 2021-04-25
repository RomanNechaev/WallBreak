using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.Keys;

namespace WallBreak
{
    public partial class Level1 : Form
    {
        private Game game;
        private Player _player;
        public Level1()
        {
            CreateLevel1();
            /*
            var platform1 = CreateAngledBox(new Point(250, 850));
            var platform2 = CreateAngledBox(new Point(450, 700));
            var platform3 = CreateAngledBox(new Point(250, 550));
            var platform5 = CreateAngledBox(new Point(100, 400));
            var platform4 = CreateAngledBox(new Point(1500, 700));
            var platform6 = CreateAngledBox(new Point(250, 250));
            var platform7 = CreateSquaredBox(new Point(100, 100));
            var platform8 = CreateAngledBox(new Point(700, 250));
            var platform9 = CreateAngledBox(new Point(950, 400));
            var platform10 = CreateSquaredBox(new Point(1300, 250));
            var platform11 = CreateSquaredBox(new Point(1500, 100));
            var platform12 = CreateAngledBox(new Point(1600, 250));
            var platform13 = CreateAngledBox(new Point(1150, 550));
            */
            var coin1 = CreateCoin(new Point(175, 0));
            var coins = new Coins();
            var score = coins.Count;
            var coin2 = CreateCoin(new Point(1575, 0));
            var label = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Century Gothic", 10F, ((FontStyle) ((FontStyle.Bold | FontStyle.Italic))),
                    GraphicsUnit.Point),
                Location = new Point(12, -70),
                Name = "label1",
                Size = new Size(200, 100),
                TextAlign = ContentAlignment.BottomLeft
            };
            coin1.MouseClick += (sender, args) =>
            {
                score += 1;
                label.Text = "Грамм травы:" + score;
            };
            KeyDown+= new KeyEventHandler(OnPress);

            Controls.Add(coin2);
            Controls.Add(coin1);
            /*
            Controls.Add(platform13);
            Controls.Add(platform12);
            Controls.Add(platform11);
            Controls.Add(platform10);
            Controls.Add(platform9);
            Controls.Add(platform8);
            Controls.Add(platform7);
            Controls.Add(platform6);
            Controls.Add(platform1);
            Controls.Add(platform2);
            Controls.Add(platform3);
            Controls.Add(platform4);
            Controls.Add(platform5);
            */
            Controls.Add(label);
            InitializeComponent();
        }
        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    game.MovePlayer(0,-1);
                    break;
                case Keys.A:
                    game.MovePlayer(-1,0);
                    break;
                case Keys.D:
                    game.MovePlayer(1,0);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var image = Properties.Resources.заккк;
            var image1 = Properties.Resources._55;
            var player = Properties.Resources.player;
            var graphics = e.Graphics;
            graphics.DrawImage(image, new Point(250, 850));
            graphics.DrawImage(image, new Point(450, 700));
            graphics.DrawImage(image, new Point(250, 550));
            graphics.DrawImage(image, new Point(100, 400));
            graphics.DrawImage(image, new Point(1500, 700));
            graphics.DrawImage(image, new Point(250, 250));
            graphics.DrawImage(image1, new Point(100, 100));
            graphics.DrawImage(image, new Point(700, 250));
            graphics.DrawImage(image, new Point(950, 400));
            graphics.DrawImage(image1, new Point(1300, 250));
            graphics.DrawImage(image1, new Point(1500, 100));
            graphics.DrawImage(image, new Point(1600, 250));
            graphics.DrawImage(image, new Point(1150, 550));
            graphics.DrawImage(player,new Point(_player.posX,_player.posY));
            
        }
        

        private static PictureBox CreateCoin(Point coords)
        {
            return new PictureBox
            {
                BackColor = Color.Transparent,
                BackgroundImage = Properties.Resources.монетка,
                Location = coords,
                Size = new Size(100, 100)
            };
        }

        private static PictureBox CreateAngledBox(Point coords)
        {
            return new PictureBox
            {
                BackColor = Color.Transparent,
                BackgroundImage = Properties.Resources._3_версия_закругленной,
                Location = coords,
                Size = new Size(318, 74)
            };
        }

        private static PictureBox CreateSquaredBox(Point coords)
        {
            return new PictureBox
            {
                BackColor = Color.Transparent,
                BackgroundImage = Properties.Resources.square2,
                Location = coords,
                Size = new Size(223, 74)
            };
        }

        private void CreateLevel1()
        {
            Name = "Level1";
            Text = "Level1";
            ResumeLayout(false);
            DoubleBuffered = true;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._2x_total;
            ClientSize = new Size(1920, 1080);
            FormBorderStyle = FormBorderStyle.None;
        }
    }
}
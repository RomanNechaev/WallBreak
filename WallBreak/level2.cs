﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class level2 : Form
    {
        Platforms platforms = new Platforms();
        static Player player = new Player(100, 0);
        Coins coins = new Coins();
        private PictureBox[] WorldObjects;
        private PictureBox[] CoinsArray;

        private Label score = new Label()
        {
            BackColor = Color.Transparent,
            Font = new Font("Century Gothic", 12F, ((FontStyle) ((FontStyle.Bold | FontStyle.Italic))),
                GraphicsUnit.Point),
            Location = new Point(20, 34),
            Name = "label1",
            Size = new Size(100, 100),
            Text = "Количество монет:" + player.Score,
            TextAlign = ContentAlignment.MiddleCenter
        };

        public level2()
        {
            InitializeComponent();
            CreateLevel1();
            WorldObjects = new PictureBox[11]
            {
                platforms.CreatePlatform(155, 900),
                platforms.CreatePlatform(360, 720),
                platforms.CreatePlatform(140, 540),
                platforms.CreatePlatform(760, 775),
                platforms.CreatePlatform(640, 430),
                platforms.CreatePlatform(236, 240),
                platforms.CreatePlatform(800, 180),
                platforms.CreatePlatform(1100, 530),
                platforms.CreatePlatform(1400, 730),
                platforms.CreatePlatform(1100, 950),
                platforms.CreatePlatform(1436, 358)
            };

            CoinsArray = new PictureBox[5]
            {
                coins.CreateCoin(800, 900),
                coins.CreateCoin(190, 850),
                coins.CreateCoin(410, 670),
                coins.CreateCoin(180, 490),
                coins.CreateCoin(820, 725),
            };


            CreatePlatforms();
            CreateCoins();
            WorldFrame.Controls.Add(score);
        }

        private void CreatePlatforms()
        {
            foreach (var platform in WorldObjects)
                WorldFrame.Controls.Add(platform);
        }

        private void CreateCoins()
        {
            foreach (var coin in CoinsArray)
                WorldFrame.Controls.Add(coin);
        }

        private void CreateLevel1()
        {
            Name = "Level1";
            Text = "Level1";
            DoubleBuffered = true;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            FormBorderStyle = FormBorderStyle.None;
        }

        public Boolean InAirNoCollision(PictureBox tar)
        {
            if (!OutsideWorldFrame(tar))
            {
                foreach (PictureBox Obj in WorldObjects)
                {
                    if (!tar.Bounds.IntersectsWith(Obj.Bounds))
                    {
                        if (tar.Location.Y < WorldFrame.Width && !CollisionTop(pb_Player))
                            return true;
                    }
                }
            }

            return false;
        }

        public Boolean OutsideWorldFrame(PictureBox tar)
        {
            if (tar.Location.X < 0)
                return true;
            if (tar.Location.X > WorldFrame.Width)
                return true;
            if (tar.Location.Y + tar.Height > WorldFrame.Height - 3)
                return true;
            foreach (PictureBox Obj in WorldObjects)
            {
                if (Obj != null)
                {
                    if (tar.Bounds.IntersectsWith(Obj.Bounds))
                        return true;
                }
            }

            return false;
        }


        private void Level2KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (player.GameOn)
                        player.PlayerLeft = true;
                    break;
                case Keys.Right:
                    if (player.GameOn)
                        player.PlayerRight = true;
                    break;
                case Keys.Up:
                    if (!player.PlayerJump && !InAirNoCollision(pb_Player))
                    {
                        pb_Player.Top -= player.SpeedJump;
                        player.Force = player.Gravity;
                        player.PlayerJump = true;
                    }

                    break;
            }
        }

        private void Level2KeyUp(object sender, KeyEventArgs e)
        {
            if (player.GameOn)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        player.PlayerLeft = false;
                        break;
                    case Keys.Right:
                        player.PlayerRight = false;
                        break;
                }
            }
        }


        public bool PlayerTookCoin(PictureBox tar, PictureBox coin)
        {
            if (coin != null)
            {
                var temp = new PictureBox();
                temp.SetBounds(coin.Location.X, coin.Location.Y, coin.Width, coin.Height);
                if (!tar.Bounds.IntersectsWith(temp.Bounds))
                    return false;
            }

            return true;
        }


        public bool CollisionTop(PictureBox tar)
        {
            return Collision(tar,
                temp => temp.Location.X - 3,
                temp => temp.Location.Y - 3,
                temp => temp.Width - 1,
                _ => 1);
        }


        public bool CollisionLeft(PictureBox tar)
        {
            return Collision(tar,
                temp => temp.Location.X - 5,
                temp => temp.Location.Y + 1,
                _ => 1,
                temp => temp.Height + 1); 
        }

        public bool CollisionBottom(PictureBox tar)
        {
            return Collision(tar, temp => temp.Location.X,
                temp => temp.Location.Y + temp.Height - 5,
                temp => temp.Width - 2,
                _ => 6);
        }

        public bool CollisionRight(PictureBox tar)
        {
            return Collision(tar,
                temp => temp.Location.X + temp.Width + 1,
                temp => temp.Location.Y + 1,
                _ => 2,
                temp => temp.Height + 1);
        }
 
        private bool Collision(PictureBox tar, Func<PictureBox, int> getX, Func<PictureBox, int> getY,
            Func<PictureBox, int> getW, Func<PictureBox, int> getH)
        {
            foreach (PictureBox ob in WorldObjects)
            {
                if (ob != null)
                {
                    PictureBox temp = new PictureBox();
                    temp.Bounds = ob.Bounds;
                    temp.SetBounds(getX(temp), getY(temp), getW(temp), getH(temp));
                    if (tar.Bounds.IntersectsWith(temp.Bounds))
                        return true;
                }
            }

            return false;
        }

        private void timer_Jump_Tick(object sender, EventArgs e)
        {
            if (player.GameOn)
            {
                if (player.PlayerRight && pb_Player.Right <= WorldFrame.Width - 3 && !CollisionLeft(pb_Player))
                    pb_Player.Left += player.SpeedMovement;
                if (player.PlayerLeft && pb_Player.Left >= 3 && !CollisionRight(pb_Player))
                    pb_Player.Left -= player.SpeedMovement;
            }
            else
            {
                player.PlayerRight = false;
                player.PlayerLeft = false;
            }

            if (player.Force > 0)
            {
                if (CollisionBottom(pb_Player))
                    player.Force = 0;
                else
                {
                    player.Force--;
                    pb_Player.Top -= player.SpeedJump;
                }
            }
            else
                player.PlayerJump = false;
        }

        private void GravityTimer(object sender, EventArgs e)
        {
            if (!player.PlayerJump && pb_Player.Location.Y + pb_Player.Height < WorldFrame.Height &&
                !CollisionTop(pb_Player))
                pb_Player.Top += player.SpeedFall;

            if (!player.PlayerJump && pb_Player.Location.Y + pb_Player.Height > WorldFrame.Height)
                pb_Player.Top--;

            foreach (var coin in CoinsArray)
            {
                if (PlayerTookCoin(pb_Player, coin))
                {
                    if (coin.Visible)
                    {
                        player.Score++;
                        score.Text = "Количество монет:" + player.Score;
                        coin.Visible = false;
                    }
                }
            }
        }
    }
}
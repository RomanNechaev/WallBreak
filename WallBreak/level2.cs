using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class level2 : Form
    {
        Platforms platforms = new Platforms();
        Player player = new Player(100, 0);
        Coins coins = new Coins();
        private PictureBox[] WorldObjects;
        private PictureBox[] CoinsArray;

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
                coins.CreateCoin(190,850),
                coins.CreateCoin(410, 670),
                coins.CreateCoin(180, 490),
                coins.CreateCoin(820, 725),
            };


            CreatePlatforms();
            CreateCoins();
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
            foreach (PictureBox ob in WorldObjects)
            {
                if (ob != null)
                {
                    PictureBox temp = new PictureBox();
                    temp.Bounds = ob.Bounds;
                    temp.SetBounds(temp.Location.X - 3, temp.Location.Y - 3, temp.Width - 1, 1);
                    if (tar.Bounds.IntersectsWith(temp.Bounds))
                        return true;
                }
            }

            return false;
        }

        

        public bool CollisionLeft(PictureBox tar)
        {
            foreach (PictureBox ob in WorldObjects)
            {
                if (ob != null)
                {
                    PictureBox temp = new PictureBox();
                    temp.Bounds = ob.Bounds;
                    temp.SetBounds(temp.Location.X - 5, temp.Location.Y + 1, 1, temp.Height + 1);
                    if (tar.Bounds.IntersectsWith(temp.Bounds))
                        return true;
                }
            }

            return false;
        }

        public bool CollisionBottom(PictureBox tar)
        {
            foreach (PictureBox ob in WorldObjects)
            {
                if (ob != null)
                {
                    PictureBox temp = new PictureBox();
                    temp.Bounds = ob.Bounds;
                    temp.SetBounds(temp.Location.X, temp.Location.Y + temp.Height - 5, temp.Width - 2, 6);
                    if (tar.Bounds.IntersectsWith(temp.Bounds))
                        return true;
                }
            }

            return false;
        }

        public bool CollisionRight(PictureBox tar)
        {
            foreach (PictureBox ob in WorldObjects)
            {
                if (ob != null)
                {
                    PictureBox temp = new PictureBox();
                    temp.Bounds = ob.Bounds;
                    temp.SetBounds(temp.Location.X + temp.Width + 1, temp.Location.Y + 1, 2, temp.Height + 1);
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
                    coin.Visible = false;
            }
        }
        public bool Collision(PictureBox target, int x, int y, int width, int height)
        {
            foreach (PictureBox ob in WorldObjects)
            {
                if (ob != null)
                {
                    PictureBox temp = new PictureBox();
                    temp.Bounds = ob.Bounds;
                    temp.SetBounds(x, y, width, height);
                    if (target.Bounds.IntersectsWith(temp.Bounds))
                        return true;
                }
            }

            return false;
        }
    }
}
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class level2 : Form
    {
        Platforms platforms = new Platforms();
        Coins coins = new Coins();
        public static PictureBox[] WorldObjects;
        private PictureBox[] CoinsArray;

        private Label score = new Label()
        {
            BackColor = Color.Transparent,
            Font = new Font("Century Gothic", 12F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))),
                GraphicsUnit.Point),
            Location = new Point(20, 34),
            Name = "label1",
            Size = new Size(100, 100),
            Text = "Количество монет:" + Physics.player.Score,
            TextAlign = ContentAlignment.MiddleCenter
        };

        public level2()
        {
            InitializeComponent();
            CreateLevel1();

            WorldObjects = new PictureBox[11]
            {
                platforms.CreatePlatform(160, 900),
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

        private void Level2KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (Physics.player.GameOn)
                        Physics.SetLeftValue(true);
                    break;
                case Keys.Right:
                    if (Physics.player.GameOn)
                        Physics.setRightValue(true);
                    break;
                case Keys.Up:
                    if (!Physics.player.PlayerJump && !Physics.InAirNoCollision(pb_Player, WorldFrame, WorldObjects))
                    {
                        Physics.UpdateY(Physics.player.SpeedJump);
                        pb_Player.Top = Physics.player.Y;
                        Physics.SetForce(Physics.player.Gravity);
                        Physics.SetJump(true);
                    }
                    break;
            }
        }

        private void Level2KeyUp(object sender, KeyEventArgs e)
        {
            if (Physics.player.GameOn)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        Physics.SetLeftValue(false);
                        break;
                    case Keys.Right:
                        Physics.setRightValue(false);
                        break;
                }
            }
        }

        private void timer_Jump_Tick(object sender, EventArgs e)
        {
            if (Physics.player.GameOn)
            {
                if (Physics.CanMoveRigth(pb_Player, WorldFrame, WorldObjects))
                {
                    Physics.UpdateX(Physics.player.SpeedMovement);
                    pb_Player.Left = Physics.player.X + 200;
                }
                if (Physics.CanMoveLeft(pb_Player, WorldObjects))
                {
                    Physics.UpdateX(-Physics.player.SpeedMovement);
                    pb_Player.Left = Physics.player.X + 200;
                }
            }
            else
            {
                Physics.setRightValue(false);
                Physics.SetLeftValue(false);
            }

            if (Physics.player.Force > 0)
            {
                if (Physics.CollisionBottom(pb_Player, WorldObjects))
                    Physics.SetForce(0);
                else
                {
                    Physics.UpdateForce(-1);
                    Physics.UpdateY(Physics.player.SpeedJump);
                    pb_Player.Top = Physics.player.Y;
                }
            }
            else
                Physics.SetJump(false);
        }

        private void GravityTimer(object sender, EventArgs e)
        {
            if (Physics.PLayerIsFalling(pb_Player, WorldFrame, WorldObjects))
            {
                Physics.UpdateY(Physics.player.SpeedFall);
                pb_Player.Top = Physics.player.Y;
            }

            if (Physics.PlayeCanJump(pb_Player, WorldFrame))
            {
                Physics.UpdateY(-1);
                pb_Player.Top = Physics.player.Y;
            }

            foreach (var coin in CoinsArray)
            {
                if (Physics.PlayerTookCoin(pb_Player, coin))
                {
                    if (coin.Visible)
                    {
                        Physics.InrementScore();
                        score.Text = "Количество монет:" + Physics.player.Score;
                        coin.Visible = false;
                    }
                }
            }
        }
    }
}
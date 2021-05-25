using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class level2 : Form
    {
        Platforms platforms = new Platforms();
        Coins coins = new Coins();
        Cactuses cactuses = new Cactuses();
        Level11 leve1 = new Level11();
        public static List<PictureBox> CactusesArray;
        public static List<PictureBox> WorldObjects;
        private List<PictureBox> CoinsArray;        
        public static int time;

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

        private PictureBox Hp = new PictureBox()
        {
            BackColor = Color.Transparent,
            Location = new Point(1700, 0),
            Size = new Size(150, 70),
            Image = Properties.Resources._5_hp
        };
        private PictureBox DeadScreen = new PictureBox()
        {
            BackColor = Color.Transparent,
            Location = new Point(710, 315),
            Size = new Size(500, 400),
            Image = Properties.Resources.gameover,
            Visible = false
        };
        public level2()
        {
            InitializeComponent();
            CreateLevel1();

            WorldObjects = new List<PictureBox>
            {
                platforms.CreatePlatform(leve1.coords[0].Item1, leve1.coords[0].Item2),
                platforms.CreatePlatform(leve1.coords[1].Item1, leve1.coords[1].Item2),
                platforms.CreatePlatform(leve1.coords[2].Item1, leve1.coords[2].Item2),
                platforms.CreatePlatform(leve1.coords[3].Item1, leve1.coords[3].Item2),
                platforms.CreatePlatform(leve1.coords[4].Item1, leve1.coords[4].Item2),
                platforms.CreatePlatform(leve1.coords[5].Item1, leve1.coords[5].Item2),
                platforms.CreatePlatform(leve1.coords[6].Item1, leve1.coords[6].Item2),
                platforms.CreatePlatform(leve1.coords[7].Item1, leve1.coords[7].Item2),
                platforms.CreatePlatform(leve1.coords[8].Item1, leve1.coords[8].Item2),
                platforms.CreatePlatform(leve1.coords[9].Item1, leve1.coords[9].Item2),
                platforms.CreatePlatform(leve1.coords[10].Item1, leve1.coords[10].Item2)

            };

            CoinsArray = new List<PictureBox>
            {
                coins.CreateCoin(800, 900),
                coins.CreateCoin(190, 850),
                coins.CreateCoin(410, 670),
                coins.CreateCoin(180, 490),
                coins.CreateCoin(820, 725),
            };

            CactusesArray = new List<PictureBox>
            {
                cactuses.CreateCactus(1700,953)
            };

            CreatePlatforms();
            CreateCoins();
            CreateCactuses();
            
            WorldFrame.Controls.Add(score);
            WorldFrame.Controls.Add(Hp);
            WorldFrame.Controls.Add(DeadScreen);
        }

        private void CreatePlatforms()
        {
            foreach (var platform in WorldObjects)
            {
                WorldFrame.Controls.Add(platform);
            }
        }

        private void CreateCoins()
        {
            foreach (var coin in CoinsArray)
                WorldFrame.Controls.Add(coin);
        }

        private void CreateCactuses()
        {
            foreach (var cactus in CactusesArray)
                WorldFrame.Controls.Add(cactus);
        }


        private void RemovePlatforms()
        {
            foreach (var platform in CoinsArray)
                WorldFrame.Controls.Remove(platform);
        }

        private void RemoveCoins()
        {
            foreach (var platform in WorldObjects)
                WorldFrame.Controls.Remove(platform);
        }

        private void RemoveCactuses()
        {
            foreach (var cactus in CactusesArray)
                WorldFrame.Controls.Remove(cactus);
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
                    pb_Player.Image = Properties.Resources.sprite_23_3;
                    break;
                case Keys.Right:
                    if (Physics.player.GameOn)
                        Physics.SetRightValue(true);
                    pb_Player.Image = Properties.Resources.sprite_23_2;
                    break;
                case Keys.Up:
                    if (!Physics.player.PlayerJump
                        && Physics.player.GameOn
                        && (!Physics.InAirNoCollision(pb_Player, WorldFrame, WorldObjects)
                            || !Physics.InAirNoCollision(pb_Player, WorldFrame, CactusesArray)))
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
                        Physics.SetRightValue(false);
                        break;
                }
            }
        }

        private void timer_Jump_Tick(object sender, EventArgs e)
        {
            if (Physics.player.GameOn)
            {
                if (Physics.CanMoveRigth(pb_Player, WorldFrame, WorldObjects) && Physics.CanMoveRigth(pb_Player, WorldFrame, CactusesArray))
                {
                    Physics.UpdateX(Physics.player.SpeedMovement);
                    pb_Player.Left = Physics.player.X + 200;
                }
                if (Physics.CanMoveLeft(pb_Player, WorldObjects) && Physics.CanMoveLeft(pb_Player, CactusesArray))
                {
                    Physics.UpdateX(-Physics.player.SpeedMovement);
                    pb_Player.Left = Physics.player.X + 200;
                }
            }
            else
            {
                Physics.SetRightValue(false);
                Physics.SetLeftValue(false);
            }

            if (Physics.player.Force > 0 || Physics.CollisionTop(pb_Player, CactusesArray))
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

            ///////
            
            //////

        }

        private void GravityTimer(object sender, EventArgs e)
        {
            if (!Physics.player.GameOn)
            {
                DeadScreen.Visible = true;
                RemovePlatforms();
                RemoveCoins();
                RemoveCactuses();
            }
                
            if (Physics.PLayerIsFalling(pb_Player, WorldFrame, WorldObjects))
            {
                Physics.player.FallingTime++;
                Physics.UpdateY(Physics.player.SpeedFall);
                pb_Player.Top = Physics.player.Y;
            }
            if (!Physics.PLayerIsFalling(pb_Player, WorldFrame, WorldObjects) || !Physics.PLayerIsFalling(pb_Player, WorldFrame, CactusesArray))
            {
                Physics.ChangeHealth(Physics.player.FallingTime);
                Physics.player.FallingTime = 0;
            }

            if (Physics.PlayerCanJump(pb_Player, WorldFrame))
            {
                Physics.UpdateY(-1);
                pb_Player.Top = Physics.player.Y;
            }



            ///////
            
            

            /////////
            if (Physics.player.Health == 4)
            {
                Hp.Image = Properties.Resources._4_hp;
            }
            if (Physics.player.Health == 3)
            {
                Hp.Image = Properties.Resources._3_hp;
            }
            if (Physics.player.Health == 2)
            {
                Hp.Image = Properties.Resources._2_hp;
            }
            if (Physics.player.Health == 1)
            {
                Hp.Image = Properties.Resources._1_hp;
            }
            if (Physics.player.Health <= 0)
            {
                Hp.Image = Properties.Resources._0_hp;
                Physics.player.GameOn = false;
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
        private void CactusTimer(object sender, EventArgs e)
        {
            if (Physics.player.GameOn)
            {
                if (Physics.CollisionRight(pb_Player, CactusesArray) 
                    || Physics.CollisionLeft(pb_Player, CactusesArray)
                    || Physics.CollisionTop(pb_Player, CactusesArray))
                {
                    Physics.ChangeHealth(75);
                }

            }
        }
    }
}
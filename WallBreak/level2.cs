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
        Cactuses cactuses = new Cactuses();
        Level11 leve1 = new Level11();
        Level222 leve2 = new Level222();
        
        private List<PictureBox> WorldObjectGeneral;    
        private List<PictureBox> CactusObject;
        private List<PictureBox> CoinsObject;
        public bool GameLevel1 = true;
        public int delay;

        
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
        private PictureBox Loading = new PictureBox()
        {
            BackColor = Color.Transparent,
            Location = new Point(960, 440),
            Size = new Size(100, 100),
            Image = Properties.Resources._159,
            Visible = false
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
            ChangeLevel();
            
            

            CreatePlatforms();
            CreateCoins();
            CreateCactuses();
            
            WorldFrame.Controls.Add(score);
            WorldFrame.Controls.Add(Hp);
            WorldFrame.Controls.Add(DeadScreen);
            WorldFrame.Controls.Add(Loading);
        }
        
        private void ChangeLevel()
        {
            if (Physics.player.Score == 0)
            {
                WorldObjectGeneral = leve1.WorldObjects;
                CoinsObject = leve1.CoinsObject;
                CactusObject = leve1.CactusObject;
            }

            if (Physics.player.Score == leve1.CoinsScore)
            {
                RemoveCoins();
                RemovePlatforms(); 
                RemoveCactuses();
                WorldObjectGeneral = leve2.WorldObjects;
                CoinsObject = leve2.CoinsObject;
                CactusObject = leve2.CactusObject;
                CreatePlatforms();
                CreateCoins();
                CreateCactuses();

            }
        }

        private void CreatePlatforms()
        {
            foreach (var platform in WorldObjectGeneral)
            {
                WorldFrame.Controls.Add(platform);
            }
        }

        private void CreateCoins()
        {
            foreach (var coin in CoinsObject)
                WorldFrame.Controls.Add(coin);
        }

        private void CreateCactuses()
        {
            foreach (var cactus in CactusObject)
                WorldFrame.Controls.Add(cactus);
        }


        private void RemovePlatforms()
        {
            foreach (var platform in WorldObjectGeneral)
                WorldFrame.Controls.Remove(platform);
        }

        private void RemoveCoins()
        {
            foreach (var coins in CoinsObject)
                WorldFrame.Controls.Remove(coins);
        }

        private void RemoveCactuses()
        {
            foreach (var cactus in CactusObject)
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
                        && (!Physics.InAirNoCollision(pb_Player, WorldFrame, WorldObjectGeneral)
                            || !Physics.InAirNoCollision(pb_Player, WorldFrame, CactusObject)))
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
                if (Physics.CanMoveRigth(pb_Player, WorldFrame, WorldObjectGeneral) && Physics.CanMoveRigth(pb_Player, WorldFrame, CactusObject))
                {
                    Physics.UpdateX(Physics.player.SpeedMovement);
                    pb_Player.Left = Physics.player.X + 200;
                }
                if (Physics.CanMoveLeft(pb_Player, WorldObjectGeneral) && Physics.CanMoveLeft(pb_Player, CactusObject))
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

            if (Physics.player.Force > 0 || Physics.CollisionTop(pb_Player, CactusObject))
            {
                if (Physics.CollisionBottom(pb_Player, WorldObjectGeneral))
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
            // if (!Physics.player.GameOn)
            // {
            //     DeadScreen.Visible = true;
            //     RemovePlatforms();
            //     RemoveCoins();
            //     RemoveCactuses();
            // }
            if (Physics.player.Score == leve1.CoinsScore && GameLevel1)
            {
                Physics.player.GameOn = false;
                RemovePlatforms();
                RemoveCoins();
                RemoveCactuses();
                Loading.Visible = true;
                if (delay > 100)
                {
                    Physics.player.GameOn = true;
                    ChangeLevel();
                    GameLevel1= false;
                    Loading.Visible = false;
                }
                delay++;
            }
                
            if (Physics.PLayerIsFalling(pb_Player, WorldFrame, WorldObjectGeneral))
            {
                Physics.player.FallingTime++;
                Physics.UpdateY(Physics.player.SpeedFall);
                pb_Player.Top = Physics.player.Y;
            }
            if (!Physics.PLayerIsFalling(pb_Player, WorldFrame, WorldObjectGeneral) || !Physics.PLayerIsFalling(pb_Player, WorldFrame, CactusObject))
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
            foreach (var coin in CoinsObject)
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
                if (Physics.CollisionRight(pb_Player, CactusObject) 
                    || Physics.CollisionLeft(pb_Player, CactusObject)
                    || Physics.CollisionTop(pb_Player, CactusObject))
                {
                    Physics.ChangeHealth(75);
                }

            }
        }
    }
}
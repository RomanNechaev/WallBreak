using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class Game : Form
    {
        Level11 Level1 = new Level11();
        Level222 Level2 = new Level222();
        Level3 level3 = new Level3();
        Platforms platforms = new Platforms();
        Coins coins = new Coins();
        Cactuses cactuses = new Cactuses();
        Trump trumps = new Trump();
        
        
        public List<PictureBox> WorldObjectGeneral;    
        private List<PictureBox> CactusObject;
        private List<PictureBox> CoinsObject;
        private List<PictureBox> TrumpObject;
        private List<Trump> TrumpList;
        public bool GameLevel1 = true;
        public bool GameLevel2 = true;
        public int delayLevel1;
        public int delayLevel2;


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
        private Label DeadText = new Label()
        {
            BackColor = Color.Transparent,
            Font = new Font("Bahnschrift SemiBold", 32F, ((FontStyle)((FontStyle.Regular ))),
                GraphicsUnit.Point),
            Location = new Point(500, 100),
            Name = "label1",
            Size = new Size(1000, 100),
            Text = "Для продолжения нажмите на пробел",
            TextAlign = ContentAlignment.MiddleCenter,
            Visible = false
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
        public Game()
        {
            InitializeComponent();
            CreateLevel1();
            WorldObjectGeneral = new List<PictureBox>();
            CoinsObject = new List<PictureBox>();
            CactusObject = new List<PictureBox>();
            TrumpObject = new List<PictureBox>();
            ChangeLevel();
            WorldFrame.Controls.Add(score);
            WorldFrame.Controls.Add(Hp);
            WorldFrame.Controls.Add(DeadScreen);
            WorldFrame.Controls.Add(Loading);
            WorldFrame.Controls.Add(DeadText);
        }
        
        private void ChangeLevel()
        {
            if (Physics.player.Score == 0)
            {
                WorldObjectGeneral = CreateWorldObjects(1);
                CoinsObject = CreateCoinsObjects(1);
                CactusObject = CreateCactusObjects(1);
                TrumpObject = CreateTrumpObjects(1);
                TrumpList = Level1.trumpsList;
                CreateTrumps();
            }

            if (Physics.player.Score == Level1.CoinsScore)
            {
                CactusObject.Clear(); 
                WorldObjectGeneral.Clear();
                CoinsObject.Clear();
                TrumpList.Clear();
                TrumpObject.Clear();
                WorldObjectGeneral = CreateWorldObjects(2);
                CoinsObject = CreateCoinsObjects(2);
                CactusObject = CreateCactusObjects(2);
                TrumpList = Level2.trumpsList;
                TrumpObject = CreateTrumpObjects(2);
                CreateTrumps();

            }
        }

        private void CreateTrumps()
        {
            for (var i = 0; i < TrumpObject.Count; i++)
            {
                TrumpList.ElementAt(i).X = TrumpObject.ElementAt(i).Left;
                TrumpList.ElementAt(i).Y = TrumpObject.ElementAt(i).Top;
                TrumpList.ElementAt(i).StartPosition =
                    TrumpObject.ElementAt(i).Left + TrumpObject.ElementAt(i).Size.Width / 2 + 40;
                if (i % 2 == 0)
                    TrumpList.ElementAt(i).MovingLeft = false;
            }
        }
        public List<PictureBox> CreateWorldObjects(int levelNumber) 
        {
            switch (levelNumber)
            {
                case 1:
                    for (int i = 0; i < Level1.coordsPlatform.Length; i++)
                    {
                        WorldObjectGeneral.Add(platforms.CreatePlatform(Level1.coordsPlatform[i].Item1, Level1.coordsPlatform[i].Item2));
                        var temp = WorldObjectGeneral[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 2:
                    for (int i = 0; i < Level2.coordsPlatform.Length; i++)
                    {
                        WorldObjectGeneral.Add(platforms.CreatePlatform(Level2.coordsPlatform[i].Item1, Level2.coordsPlatform[i].Item2));
                        var temp = WorldObjectGeneral[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 3:
                    for (int i = 0; i < level3.coordsPlatform.Length; i++)
                    {
                        WorldObjectGeneral.Add(platforms.CreatePlatform(level3.coordsPlatform[i].Item1, level3.coordsPlatform[i].Item2));
                        var temp = WorldObjectGeneral[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
            }
            return WorldObjectGeneral;
        }

        public List<PictureBox> CreateCoinsObjects(int levelNumber)
        {
            switch (levelNumber)
            {
                case 1:
                    for (int i = 0; i < Level1.coordsCoins.Length; i++)
                    {
                        CoinsObject.Add(coins.CreateCoin(Level1.coordsCoins[i].Item1, Level1.coordsCoins[i].Item2));
                        var temp = CoinsObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 2:
                    for (int i = 0; i < Level2.coordsCoins.Length; i++)
                    {
                        CoinsObject.Add(coins.CreateCoin(Level2.coordsCoins[i].Item1, Level2.coordsCoins[i].Item2));
                        var temp = CoinsObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 3:
                    for (int i = 0; i < level3.coordsCoins.Length; i++)
                    {
                        CoinsObject.Add(coins.CreateCoin(level3.coordsCoins[i].Item1, level3.coordsCoins[i].Item2));
                        var temp = CoinsObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
            }
            return CoinsObject;
        }
        public List<PictureBox> CreateCactusObjects(int levelNumber)
        {
            switch (levelNumber)
            {
                case 1:
                    for (int i = 0; i < Level1.coordsCactus.Length; i++)
                    {
                        CactusObject.Add(cactuses.CreateCactus(Level1.coordsCactus[i].Item1, Level1.coordsCactus[i].Item2));
                        var temp = CactusObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 2:
                    for (int i = 0; i < Level2.coordsCactus.Length; i++)
                    {
                        CactusObject.Add(cactuses.CreateCactus(Level2.coordsCactus[i].Item1, Level2.coordsCactus[i].Item2));
                        var temp = CactusObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 3:
                    for (int i = 0; i < level3.coordsCoins.Length; i++)
                    {
                        CactusObject.Add(cactuses.CreateCactus(level3.coordsCoins[i].Item1, level3.coordsCoins[i].Item2));
                        var temp = CactusObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
            }
            return CactusObject;
        }
        public List<PictureBox> CreateTrumpObjects(int levelNumber) 
        {
            switch (levelNumber)
            {
                case 1:
                    for (int i = 0; i < Level1.TrumpCoords.Length; i++)
                    {
                        TrumpObject.Add(trumps.CreateTrump(Level1.TrumpCoords[i].Item1, Level1.TrumpCoords[i].Item2));
                        var temp = TrumpObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 2:
                    for (int i = 0; i < Level2.TrumpCoords.Length; i++)
                    {
                        TrumpObject.Add(trumps.CreateTrump(Level2.TrumpCoords[i].Item1, Level2.TrumpCoords[i].Item2));
                        var temp = TrumpObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 3:
                    for (int i = 0; i < level3.TrumpCoords.Length; i++)
                    {
                        TrumpObject.Add(trumps.CreateTrump(level3.TrumpCoords[i].Item1, level3.TrumpCoords[i].Item2));
                        var temp = TrumpObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
            }
            return TrumpObject;
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
        private void RemoveTrump()
        {
            foreach (var trump in TrumpObject)
                WorldFrame.Controls.Remove(trump);
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
                case Keys.Space:
                    if (Physics.player.Health <= 0)
                    {
                        Physics.player.GameOn = true;
                        Physics.player.Health = 5;
                        pb_Player.Visible = true;
                        DeadScreen.Visible = false;
                        DeadText.Visible = false;
                        CactusObject.Clear(); 
                        WorldObjectGeneral.Clear();
                        CoinsObject.Clear();
                        TrumpList.Clear();
                        TrumpObject.Clear();
                        WorldObjectGeneral = CreateWorldObjects(1);
                        CoinsObject = CreateCoinsObjects(1);
                        CactusObject = CreateCactusObjects(1);
                        TrumpList = Level1.trumpsList;
                        TrumpObject = CreateTrumpObjects(1);
                        CreateTrumps();
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

            if (Physics.player.Force > 0)
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

            for (var i = 0; i < TrumpObject.Count(); i++)
            {
                if (TrumpPhysics.MovingLeft(TrumpList.ElementAt(i)))
                {
                    TrumpObject.ElementAt(i).Image = Properties.Resources.TrumpLeft;
                    TrumpPhysics.UpdateTrumpX(-1, TrumpList.ElementAt(i));
                    TrumpObject.ElementAt(i).Left = TrumpList.ElementAt(i).X;
                }
                else
                {
                    TrumpObject.ElementAt(i).Image = Properties.Resources.TrumpRight;
                    TrumpPhysics.UpdateTrumpX(1, TrumpList.ElementAt(i));
                    TrumpObject.ElementAt(i).Left = TrumpList.ElementAt(i).X;
                }

                if (TrumpPhysics.TrumpGetLeftBorder(TrumpList.ElementAt(i)))
                    TrumpPhysics.ChangeDirectionToLeft(TrumpList.ElementAt(i), false);

                if (TrumpPhysics.TrumpGetRightBorder(TrumpList.ElementAt(i)))
                    TrumpPhysics.ChangeDirectionToLeft(TrumpList.ElementAt(i), true);
                if (TrumpPhysics.CollisionRightWithTrump(pb_Player, TrumpObject.ElementAt(i))
                    || TrumpPhysics.CollisionLeftWithTrump(pb_Player, TrumpObject.ElementAt(i)))
                {
                    Physics.player.GameOn = false;
                    Physics.ChangeHealth(250);
                }

                if (TrumpPhysics.CollisionTopWithTrump(pb_Player, TrumpObject.ElementAt(i)))
                {
                    Physics.SetFallingTime(0);
                    TrumpPhysics.ChangeVisible(TrumpObject.ElementAt(i));
                }
            }

        }

        


        private void GravityTimer(object sender, EventArgs e)
        {
            if (Physics.player.Health<=0)
            {
                DeadScreen.Visible = true;
                DeadText.Visible = true;
                RemovePlatforms();
                RemoveCoins();
                RemoveCactuses();
                RemoveTrump();
                TrumpObject.Clear();
                TrumpList.Clear();
                pb_Player.Visible = false;

            }

            if (Physics.player.Score == Level1.CoinsScore && GameLevel1)
            {
                Physics.player.GameOn = false;
                RemovePlatforms();
                RemoveCoins();
                RemoveCactuses();
                RemoveTrump();


                Loading.Visible = true;
                if (delayLevel1 > 100)
                {
                    Physics.player.GameOn = true;
                    ChangeLevel();
                    GameLevel1 = false;
                    Loading.Visible = false;
                }

                delayLevel1++;
            }

            if (Physics.PLayerIsFalling(pb_Player, WorldFrame, WorldObjectGeneral) && Physics.PLayerIsFalling(pb_Player,WorldFrame,CactusObject))
            {
                Physics.InrementFallingTime();
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
            if (Physics.player.Health == 5)
            {
                Hp.Image = Properties.Resources._5_hp;
            }
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

        private void RemoveAllItems()
        {
            RemovePlatforms();
            RemoveCoins();
            RemoveCactuses();
            RemoveTrump();
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
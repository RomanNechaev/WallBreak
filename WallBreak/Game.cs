using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WallBreak
{
    public partial class Game : Form
    {
        Level1 LevelOne = new Level1();
        Level2 LevelTwo = new Level2();
        Level3 LevelThree = new Level3();
        Coins Coins = new Coins();
        Trump Trumps = new Trump();
        Cactuses Cactuses = new Cactuses();
        Platforms Platforms = new Platforms();

        public List<PictureBox> WorldObjectGeneral;
        private List<PictureBox> CactusObject;
        private List<PictureBox> CoinsObject;
        private List<PictureBox> TrumpObject;
        private List<Trump> TrumpList;
        public bool GameLevel1 = true;
        public bool GameLevel2 = false;
        public bool GameLevel3 = false;
        public int delay;


        private Label score = new Label()
        {
            BackColor = Color.Transparent,
            Font = new Font("Century Gothic", 12F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))),
                GraphicsUnit.Point),
            Location = new Point(20, 34),
            Name = "label1",
            Size = new Size(110, 100),
            Text = "Количество очков:" + Physics.Player.Score,
            TextAlign = ContentAlignment.MiddleCenter
        };
        
        private Label DeadText = new Label()
        {
            BackColor = Color.Transparent,
            Font = new Font("Bahnschrift SemiBold", 32F, ((FontStyle)((FontStyle.Regular))),
                GraphicsUnit.Point),
            Location = new Point(500, 100),
            Name = "label1",
            Size = new Size(1000, 100),
            Text = "Для продолжения нажмите на пробел",
            TextAlign = ContentAlignment.MiddleCenter,
            Visible = false
        };
        private Label Magic = new Label()
        {
            BackColor = Color.Transparent,
            Font = new Font("Bahnschrift SemiBold", 32F, ((FontStyle)((FontStyle.Regular))),
                GraphicsUnit.Point),
            Location = new Point(500, 100),
            Name = "label1",
            Size = new Size(1000, 100),
            Text = "Запоминай где платформы!!!",
            TextAlign = ContentAlignment.MiddleCenter,
            Visible = false
        };
        private Label Final = new Label()
        {
            BackColor = Color.Transparent,
            Font = new Font("Bahnschrift SemiBold", 32F, ((FontStyle)((FontStyle.Regular))),
                GraphicsUnit.Point),
            Location = new Point(500, 100),
            Name = "label1",
            Size = new Size(1000, 100),
            Text = "Красавчик)))",
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
            CreateLevel();
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
            WorldFrame.Controls.Add(Final);
            WorldFrame.Controls.Add(Magic);
        }
        private void CreateLevel()
        {
            DoubleBuffered = true;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            FormBorderStyle = FormBorderStyle.None;
        }

        private void ChangeLevel()
        {
            if (Physics.Player.Score == 0)
            {
                GetNewObjects(1);
                CreateTrumps();
            }

            if (Physics.Player.Score == LevelOne.CoinsScore)
            {
                ClearEverything();
                RemoveEverything();
                GetNewObjects(2);
                CreateTrumps();
                TeleportPlayerToPosition(1000, 935);
            }

            if (Physics.Player.Score == LevelTwo.CoinsScore)
            {
                ClearEverything();
                RemoveEverything();
                GetNewObjects(3);
                CreateTrumps();
                TeleportPlayerToPosition(800, 935);
            }
        }

        private void GetNewObjects(int level)
        {
            WorldObjectGeneral = CreateWorldObjects(level);
            CoinsObject = CreateCoinsObjects(level);
            CactusObject = CreateCactusObjects(level);
            TrumpObject = CreateTrumpObjects(level);
            TrumpList = CreateTrumpList(level);
        }

        private void ClearEverything()
        {
            WorldObjectGeneral.Clear();
            CactusObject.Clear();
            CoinsObject.Clear();
            TrumpObject.Clear();
            TrumpList.Clear();
        }

        private void RemoveEverything()
        {
            RemoveCactuses();
            RemoveCoins();
            RemovePlatforms();
            RemoveTrump();
        }

        private void TeleportPlayerToPosition(int x, int y)
        {
            Physics.TeleportPlayer(x, y);
            pb_Player.Top = Physics.Player.Y;
            pb_Player.Left = Physics.Player.X + 200;
        }

        private void CreateTrumps()
        {
            if (TrumpList.Count == 0)
            {
                TrumpList = new List<Trump>
                {
                    new Trump(),
                    new Trump(),
                    new Trump(),
                    new Trump(),
                    new Trump(),
                    new Trump(),
                };
                ConnectTrumpPb();
            }
            else
            {
                ConnectTrumpPb();
            }
        }

        private void ConnectTrumpPb()
        {
            for (var i = 0; i < TrumpObject.Count; i++)
            {
                TrumpPhysics.SetTrumpPosition(TrumpList, TrumpObject, i);
            }
        }

        public List<Trump> CreateTrumpList(int levelNumber)
        {
            switch (levelNumber)
            {
                case 1:
                    return LevelOne.trumpsList;
                case 2:
                    return LevelTwo.trumpsList;
                case 3:
                    return LevelThree.trumpsList;
            }
            return new List<Trump>();
        }

        public List<PictureBox> CreateWorldObjects(int levelNumber)
        {
            switch (levelNumber)
            {
                case 1:
                    for (int i = 0; i < LevelOne.coordsPlatform.Length; i++)
                    {
                        WorldObjectGeneral.Add(Platforms.CreatePlatform(LevelOne.coordsPlatform[i].Item1, LevelOne.coordsPlatform[i].Item2));
                        var temp = WorldObjectGeneral[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 2:
                    for (int i = 0; i < LevelTwo.coordsPlatform.Length; i++)
                    {
                        WorldObjectGeneral.Add(Platforms.CreatePlatform(LevelTwo.coordsPlatform[i].Item1, LevelTwo.coordsPlatform[i].Item2));
                        var temp = WorldObjectGeneral[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 3:
                    for (int i = 0; i < LevelThree.CoordsPlatform.Length; i++)
                    {
                        WorldObjectGeneral.Add(Platforms.CreatePlatform(LevelThree.CoordsPlatform[i].Item1, LevelThree.CoordsPlatform[i].Item2));
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
                    for (int i = 0; i < LevelOne.coordsCoins.Length; i++)
                    {
                        CoinsObject.Add(Coins.CreateCoin(LevelOne.coordsCoins[i].Item1, LevelOne.coordsCoins[i].Item2));
                        var temp = CoinsObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 2:
                    for (int i = 0; i < LevelTwo.coordsCoins.Length; i++)
                    {
                        CoinsObject.Add(Coins.CreateCoin(LevelTwo.coordsCoins[i].Item1, LevelTwo.coordsCoins[i].Item2));
                        var temp = CoinsObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 3:
                    for (int i = 0; i < LevelThree.coordsCoins.Length; i++)
                    {
                        CoinsObject.Add(Coins.CreateCoin(LevelThree.coordsCoins[i].Item1, LevelThree.coordsCoins[i].Item2));
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
                    for (int i = 0; i < LevelOne.coordsCactus.Length; i++)
                    {
                        CactusObject.Add(Cactuses.CreateCactus(LevelOne.coordsCactus[i].Item1, LevelOne.coordsCactus[i].Item2));
                        var temp = CactusObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 2:
                    for (int i = 0; i < LevelTwo.coordsCactus.Length; i++)
                    {
                        CactusObject.Add(Cactuses.CreateCactus(LevelTwo.coordsCactus[i].Item1, LevelTwo.coordsCactus[i].Item2));
                        var temp = CactusObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 3:
                    for (int i = 0; i < LevelThree.CoordsCactus.Length; i++)
                    {
                        CactusObject.Add(Cactuses.CreateCactus(LevelThree.CoordsCactus[i].Item1, LevelThree.CoordsCactus[i].Item2));
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
                    for (int i = 0; i < LevelOne.TrumpCoords.Length; i++)
                    {
                        TrumpObject.Add(Trumps.CreateTrump(LevelOne.TrumpCoords[i].Item1, LevelOne.TrumpCoords[i].Item2));
                        var temp = TrumpObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 2:
                    for (int i = 0; i < LevelTwo.TrumpCoords.Length; i++)
                    {
                        TrumpObject.Add(Trumps.CreateTrump(LevelTwo.TrumpCoords[i].Item1, LevelTwo.TrumpCoords[i].Item2));
                        var temp = TrumpObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
                case 3:
                    for (int i = 0; i < LevelThree.TrumpCoords.Length; i++)
                    {
                        TrumpObject.Add(Trumps.CreateTrump(LevelThree.TrumpCoords[i].Item1, LevelThree.TrumpCoords[i].Item2));
                        var temp = TrumpObject[i];
                        WorldFrame.Controls.Add(temp);
                    }
                    break;
            }
            return TrumpObject;
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

        private void Level2KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (Physics.Player.GameOn)
                        Physics.SetLeftValue(true);
                    pb_Player.Image = Properties.Resources.sprite_23_3;
                    break;
                case Keys.Right:
                    if (Physics.Player.GameOn)
                        Physics.SetRightValue(true);
                    pb_Player.Image = Properties.Resources.sprite_23_2;
                    break;
                case Keys.Up:
                    if (!Physics.Player.PlayerJump
                        && Physics.Player.GameOn
                        && (!Physics.InAirNoCollision(pb_Player, WorldFrame, WorldObjectGeneral)
                            || !Physics.InAirNoCollision(pb_Player, WorldFrame, CactusObject)))
                    {
                        Physics.UpdateY(Physics.Player.SpeedJump);
                        pb_Player.Top = Physics.Player.Y;
                        Physics.SetForce(Physics.Player.Gravity);
                        Physics.SetJump(true);
                    }
                    break;
                case Keys.Space:
                    if (Physics.Player.Health <= 0)
                    {
                        pb_Player.Visible = true;
                        DeadScreen.Visible = false;
                        DeadText.Visible = false;
                        Final.Visible = false;
                        GameLevel1 = true;
                        GameLevel2 = false;
                        GameLevel3 = false;
                        Physics.SetHp(5);
                        Physics.SetGameOn(true);
                        Physics.SetScore(0);
                        score.Text = "Количество монет:" + Physics.Player.Score;
                        Physics.TeleportPlayer(1200, 800);
                        Physics.SetFallingTime(0);
                        pb_Player.Top = Physics.Player.Y;
                        pb_Player.Left = Physics.Player.X + 200;
                        ClearEverything();
                        TrumpList = CreateTrumpList(1);
                        ChangeLevel();
                    }
                    break;
            }
        }


        private void Level2KeyUp(object sender, KeyEventArgs e)
        {
            if (Physics.Player.GameOn)
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
            if (Physics.Player.GameOn)
            {
                if (Physics.CanMoveRigth(pb_Player, WorldFrame, WorldObjectGeneral) && Physics.CanMoveRigth(pb_Player, WorldFrame, CactusObject))
                {
                    Physics.UpdateX(Physics.Player.SpeedMovement);
                    pb_Player.Left = Physics.Player.X + 200;
                }
                if (Physics.CanMoveLeft(pb_Player, WorldObjectGeneral) && Physics.CanMoveLeft(pb_Player, CactusObject))
                {
                    Physics.UpdateX(-Physics.Player.SpeedMovement);
                    pb_Player.Left = Physics.Player.X + 200;
                }
            }
            else
            {
                Physics.SetRightValue(false);
                Physics.SetLeftValue(false);
            }

            if (Physics.Player.Force > 0)
            {
                if (Physics.CollisionBottom(pb_Player, WorldObjectGeneral))
                    Physics.SetForce(0);
                else
                {
                    Physics.UpdateForce(-1);
                    Physics.UpdateY(Physics.Player.SpeedJump);
                    pb_Player.Top = Physics.Player.Y;
                }
            }
            else
                Physics.SetJump(false);

            for (var i = 0; i < TrumpObject.Count(); i++)
            {
                if (TrumpList.Count != 0)
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
                        Physics.SetGameOn(false);
                        Physics.ChangeHealth(250);
                    }

                    if (TrumpPhysics.CollisionTopWithTrump(pb_Player, TrumpObject.ElementAt(i)))
                    {
                        Physics.SetFallingTime(0);
                        TrumpPhysics.ChangeVisible(TrumpObject.ElementAt(i));
                        Physics.InrementScore();
                        score.Text ="Количество монет:" + Physics.Player.Score; 
                    }
                }
                else
                {
                    TrumpList = new List<Trump>()
                    {
                        new Trump(),
                        new Trump(),
                        new Trump(),
                        new Trump(),
                        new Trump(),
                        new Trump(),
                    };
                }
            }
        }

        private void GravityTimer(object sender, EventArgs e)
        {
            if (Physics.Player.Health <= 0)
            {
                Physics.SetGameOn(false);
                DeadScreen.Visible = true;
                DeadText.Visible = true;
                RemoveEverything();
                ClearEverything();
                TrumpList = CreateTrumpList(1);
                pb_Player.Visible = false;
            }

            if (Physics.Player.Score == LevelOne.CoinsScore && GameLevel1)
            {
                Physics.Player.GameOn = false;
                RemoveEverything();
                Loading.Visible = true;
                if (delay > 100)
                {
                    Physics.Player.GameOn = true;
                    ChangeLevel();
                    GameLevel1 = false;
                    GameLevel2 = true;
                    Loading.Visible = false;
                    delay = 0;
                }
                delay++;
            }

            if (Physics.Player.Score == LevelTwo.CoinsScore && GameLevel2)
            {
                Physics.SetGameOn(false);
                RemoveEverything();
                Loading.Visible = true;
                if (delay > 100)
                {
                    Physics.Player.GameOn = true;
                    ChangeLevel();
                    GameLevel2 = false;
                    GameLevel3 = true;
                    Loading.Visible = false;
                    delay = 0;
                }
                delay++;
            }

            if (GameLevel3 && (Physics.Player.X > 850 || Physics.Player.X < 750))
            {
                Physics.SetGameOn(false);
                Magic.Visible = true;
                if (delay > 650)
                {
                    Physics.SetGameOn(true);
                    GameLevel3 = false;
                    Magic.Visible = false;
                    delay = 0;
                    foreach (var platform in WorldObjectGeneral)
                    {
                        platform.Visible = false;
                    }
                }
                delay++;
                
            }
            if (Physics.Player.Score == LevelThree.CoinsScore)
            {
                Physics.SetGameOn(false);
                RemoveEverything();
                Final.Visible = true;
            }


            if (Physics.PLayerIsFalling(pb_Player, WorldFrame, WorldObjectGeneral) 
                && Physics.PLayerIsFalling(pb_Player, WorldFrame, CactusObject))
            {
                Physics.InrementFallingTime();
                Physics.UpdateY(Physics.Player.SpeedFall);
                pb_Player.Top = Physics.Player.Y;
            }
            if (!Physics.PLayerIsFalling(pb_Player, WorldFrame, WorldObjectGeneral) 
                || !Physics.PLayerIsFalling(pb_Player, WorldFrame, CactusObject))
            {
                Physics.ChangeHealth(Physics.Player.FallingTime);
                Physics.SetFallingTime(0);
            }

            if (Physics.PlayerCanJump(pb_Player, WorldFrame))
            {
                Physics.UpdateY(-1);
                pb_Player.Top = Physics.Player.Y;
            }


            if (Physics.Player.Health == 5)
            {
                Hp.Image = Properties.Resources._5_hp;
            }
            if (Physics.Player.Health == 4)
            {
                Hp.Image = Properties.Resources._4_hp;
            }
            if (Physics.Player.Health == 3)
            {
                Hp.Image = Properties.Resources._3_hp;
            }
            if (Physics.Player.Health == 2)
            {
                Hp.Image = Properties.Resources._2_hp;
            }
            if (Physics.Player.Health == 1)
            {
                Hp.Image = Properties.Resources._1_hp;
            }
            if (Physics.Player.Health <= 0)
            {
                Hp.Image = Properties.Resources._0_hp;
                Physics.SetGameOn(false);
            }

            foreach (var coin in CoinsObject)
            {
                if (Physics.PlayerTookCoin(pb_Player, coin))
                {
                    if (coin.Visible)
                    {
                        Physics.InrementScore();
                        score.Text = "Количество монет:" + Physics.Player.Score;
                        coin.Visible = false;
                    }
                }
            }
        }

        private void CactusTimer(object sender, EventArgs e)
        {
            if (Physics.Player.GameOn)
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
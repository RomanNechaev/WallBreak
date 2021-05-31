using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace WallBreak
{
    class Physics
    {
        public static Player Player = new Player(5, 0, 1200, 935);
        

        public static bool CollisionTop(PictureBox tar, List<PictureBox> WorldObjects)
        {
            return Collision(tar,
                    temp => temp.Location.X - 3,
                    temp => temp.Location.Y - 3,
                    temp => temp.Width - 2,
                    temp => 1,
                    WorldObjects);
        }


        public static bool CollisionLeft(PictureBox tar, List<PictureBox> WorldObjects)
        {
            return Collision(tar,
                    temp => temp.Location.X - 5,
                    temp => temp.Location.Y + 1,
                    temp => 1,
                    temp => temp.Height + 1,
                    WorldObjects);
        }

        public static bool CollisionBottom(PictureBox tar, List<PictureBox> WorldObjects)
        {
            return Collision(tar,
                temp => temp.Location.X,
                temp => temp.Location.Y + temp.Height - 5,
                temp => temp.Width - 2,
                temp => 7,
                WorldObjects);
        }

        public static bool CollisionRight(PictureBox tar, List<PictureBox> WorldObjects)
        {
            return Collision(tar,
                    temp => temp.Location.X + temp.Width + 1,
                    temp => temp.Location.Y + 1,
                    temp => 2,
                    temp => temp.Height + 1,
                    WorldObjects);
        }

        private static bool Collision(PictureBox tar, Func<PictureBox, int> getX, Func<PictureBox, int> getY,
            Func<PictureBox, int> getW, Func<PictureBox, int> getH, List<PictureBox> WorldObjects)
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

        public static bool InAirNoCollision(PictureBox tar, Panel WorldFrame, List<PictureBox> worldobjects)
        {
            if (!OutsideWorldFrame(tar, WorldFrame, worldobjects))
            {
                foreach (PictureBox Obj in worldobjects)
                {
                    if (!tar.Bounds.IntersectsWith(Obj.Bounds))
                    {
                        if (tar.Location.Y < WorldFrame.Width && !Physics.CollisionTop(tar, worldobjects))
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool OutsideWorldFrame(PictureBox tar, Panel WorldFrame, List<PictureBox> WorldObjects)
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

        public static bool CanMoveRigth(PictureBox pb_Player, Panel worldFrame, List<PictureBox> WorldObjects)
        {
            return Player.PlayerRight && Player.X + 260 <= worldFrame.Width - 3 && !Physics.CollisionLeft(pb_Player, WorldObjects);
        }

        public static bool CanMoveLeft(PictureBox pb_Player, List<PictureBox> WorldObjects)
        {
            return Player.PlayerLeft && pb_Player.Left >= 3 && !Physics.CollisionRight(pb_Player, WorldObjects);
        }

        public static void SetLeftValue(bool value) => Player.PlayerLeft = value;
        
        public static void SetRightValue(bool value) => Player.PlayerRight = value;

        public static void SetFallingTime(int value) => Player.FallingTime = value;

        public static void SetForce(int value) => Player.Force = value;

        public static void SetJump(bool value) => Player.PlayerJump = value;

        public static void SetHp(int value) => Player.Health = value;

        public static void SetScore(int value) => Player.Score = value;

        public static void SetGameOn(bool value) => Player.GameOn = value;

        public static void UpdateY(int value) => Player.Y += value;

        public static void UpdateX(int value) => Player.X += value;

        public static void UpdateForce(int value) => Player.Force += value;

        public static void InrementScore() => Player.Score++;

        public static void InrementFallingTime() => Player.FallingTime++;

        public static void TeleportPlayer(int x, int y)
        {
            Player.X = x;
            Player.Y = y;
        }

        public static bool PLayerIsFalling(PictureBox pb_Player, Panel WorldFrame, List<PictureBox> WorldObjects)
        {
            return !Player.PlayerJump 
                   && pb_Player.Location.Y + pb_Player.Height < WorldFrame.Height 
                   && !CollisionTop(pb_Player, WorldObjects);
        }
        public static bool PlayerCanJump(PictureBox pb_Player, Panel WorldFrame)
        {
            return !Player.PlayerJump 
                   && pb_Player.Location.Y + pb_Player.Height > WorldFrame.Height;
        }
        public static bool PlayerTookCoin(PictureBox tar, PictureBox coin)
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
        public static void ChangeHealth(int fallingTime)
        {
            var SP = new SoundPlayer(Properties.Resources.ab376c2f466a3ca1);
            
            if (fallingTime > 200)
            {
                SP.Play();
                Player.Health -= 4;
            }

            else if (fallingTime > 150)
            {
                SP.Play();
                Player.Health -= 3;
            }

            else if (fallingTime > 100)
            {
                SP.Play();
                Player.Health -= 2;
            }

            else if (fallingTime > 70)
            {
                SP.Play();
                Player.Health -= 1;
            }
        }
    }
}
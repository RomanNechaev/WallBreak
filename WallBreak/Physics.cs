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
        public static Player player = new Player(5, 0, 1200, 800);

        public static bool CollisionTop(PictureBox tar, List<PictureBox> WorldObjects)
        {
            return Collision(tar,
                    temp => temp.Location.X - 3,
                    temp => temp.Location.Y - 3,
                    temp => temp.Width - 2,
                    _ => 1, WorldObjects);
        }


        public static bool CollisionLeft(PictureBox tar, List<PictureBox> WorldObjects)
        {
            return Collision(tar,
                    temp => temp.Location.X - 5,
                    temp => temp.Location.Y + 1,
                    _ => 1,
                    temp => temp.Height + 1, WorldObjects);
        }

        public static bool CollisionBottom(PictureBox tar, List<PictureBox> WorldObjects)
        {
            return Collision(tar, temp => temp.Location.X,
                    temp => temp.Location.Y + temp.Height - 5,
                    temp => temp.Width - 2,
                    _ => 7, WorldObjects);
        }

        public static bool CollisionRight(PictureBox tar, List<PictureBox> WorldObjects)
        {
            return Collision(tar,
                    temp => temp.Location.X + temp.Width + 1,
                    temp => temp.Location.Y + 1,
                    _ => 2,
                    temp => temp.Height + 1, WorldObjects);
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

        public static void SetLeftValue(bool value) => player.PlayerLeft = value;
        
        public static void SetRightValue(bool value) => player.PlayerRight = value;

        public static void UpdateY(int value) => player.Y += value;

        public static void UpdateX(int value) => player.X += value;

        public static bool CanMoveRigth(PictureBox pb_Player, Panel worldFrame, List<PictureBox> WorldObjects)
        {
            return player.PlayerRight && player.X + 300 <= worldFrame.Width - 3 && !Physics.CollisionLeft(pb_Player, WorldObjects);
        }
        public static bool CanMoveLeft(PictureBox pb_Player, List<PictureBox> WorldObjects)
        {
            return player.PlayerLeft && pb_Player.Left >= 3 && !Physics.CollisionRight(pb_Player, WorldObjects);
        }

        public static void SetForce(int value) => player.Force = value;
        
        public static void SetJump(bool value) => player.PlayerJump = value;

        public static void UpdateForce(int value) => player.Force += value;

        public static void InrementScore() => player.Score++;

        public static bool PLayerIsFalling(PictureBox pb_Player, Panel WorldFrame, List<PictureBox> WorldObjects)
        {
            return !player.PlayerJump && pb_Player.Location.Y + pb_Player.Height < WorldFrame.Height &&
                            !CollisionTop(pb_Player, WorldObjects);
        }
        public static bool PlayerCanJump(PictureBox pb_Player, Panel WorldFrame)
        {
            return !player.PlayerJump && pb_Player.Location.Y + pb_Player.Height > WorldFrame.Height;
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
                player.Health -= 4;
            }
                
            else if (fallingTime > 150)
            {
                SP.Play();
                player.Health -= 3;
            }
                
            else if (fallingTime > 100)
            {
                SP.Play();
                player.Health -= 2;
            }
                
            else if (fallingTime > 70)
            {
                SP.Play();
                player.Health -= 1;
            }
                
        }
    }
}
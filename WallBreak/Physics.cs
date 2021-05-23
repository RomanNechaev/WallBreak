﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WallBreak
{
    class Physics
    {
        public static Player player = new Player(100, 0, 1200, 800);

        public static bool CollisionTop(PictureBox tar, PictureBox[] WorldObjects)
        {
            return Collision(tar,
                    temp => temp.Location.X - 3,
                    temp => temp.Location.Y - 3,
                    temp => temp.Width - 1,
                    _ => 1, WorldObjects);
        }


        public static bool CollisionLeft(PictureBox tar, PictureBox[] WorldObjects)
        {
            return Collision(tar,
                    temp => temp.Location.X - 5,
                    temp => temp.Location.Y + 1,
                    _ => 1,
                    temp => temp.Height + 1, WorldObjects);
        }

        public static bool CollisionBottom(PictureBox tar, PictureBox[] WorldObjects)
        {
            return Collision(tar, temp => temp.Location.X,
                    temp => temp.Location.Y + temp.Height - 5,
                    temp => temp.Width - 2,
                    _ => 6, WorldObjects);
        }

        public static bool CollisionRight(PictureBox tar, PictureBox[] WorldObjects)
        {
            return Collision(tar,
                    temp => temp.Location.X + temp.Width + 1,
                    temp => temp.Location.Y + 1,
                    _ => 2,
                    temp => temp.Height + 1, WorldObjects);
        }

        public static bool Collision(PictureBox tar, Func<PictureBox, int> getX, Func<PictureBox, int> getY,
            Func<PictureBox, int> getW, Func<PictureBox, int> getH, PictureBox[] WorldObjects)
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
        public static bool InAirNoCollision(PictureBox tar, Panel WorldFrame, PictureBox[] worldobjects)
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

        public static bool OutsideWorldFrame(PictureBox tar, Panel WorldFrame, PictureBox[] WorldObjects)
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
        
        public static void setRightValue(bool value) => player.PlayerRight = value;

        public static void UpdateY(int value) => player.Y += value;

        public static void UpdateX(int value) => player.X += value;

        public static bool CanMoveRigth(PictureBox pb_Player, Panel worldFrame, PictureBox[] WorldObjects)
        {
            return player.PlayerRight && player.X <= worldFrame.Width - 3 && !Physics.CollisionLeft(pb_Player, WorldObjects);
        }
        public static bool CanMoveLeft(PictureBox pb_Player, PictureBox[] WorldObjects)
        {
            return player.PlayerLeft && pb_Player.Left >= 3 && !Physics.CollisionRight(pb_Player, WorldObjects);
        }

        public static void SetForce(int value) => player.Force = value;
        
        public static void SetJump(bool value) => player.PlayerJump = value;

        public static void UpdateForce(int value) => player.Force += value;

        public static void InrementScore() => player.Score++;

        public static bool PLayerIsFalling(PictureBox pb_Player, Panel WorldFrame, PictureBox[] WorldObjects)
        {
            return !player.PlayerJump && pb_Player.Location.Y + pb_Player.Height < WorldFrame.Height &&
                            !CollisionTop(pb_Player, WorldObjects);
        }
        public static bool PlayeCanJump(PictureBox pb_Player, Panel WorldFrame)
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
    }

}
using System;
using System.Windows.Forms;

namespace WallBreak
{
    class TrumpPhysics
    {
        public static bool CollisionLeftWithTrump(PictureBox tar, PictureBox trumpPictureBox)
        {
            return CollisionWithTrump(tar,
                temp => temp.Location.X - 5,
                temp => temp.Location.Y + 1,
                _ => 1,
                temp => temp.Height + 1, trumpPictureBox);
        }
        public static bool CollisionRightWithTrump(PictureBox tar, PictureBox trumpPictureBox)
        {
            return CollisionWithTrump(tar,
                temp => temp.Location.X + temp.Width + 1,
                temp => temp.Location.Y + 1,
                _ => 2,
                temp => temp.Height + 1, trumpPictureBox);
        }
        public static bool CollisionTopWithTrump(PictureBox tar, PictureBox trumpPictureBox)
        {
            return CollisionWithTrump(tar,
                temp => temp.Location.X - 3,
                temp => temp.Location.Y - 3,
                temp => temp.Width - 2,
                _ => 1, trumpPictureBox);
        }
        private static bool CollisionWithTrump(PictureBox tar, Func<PictureBox, int> getX, Func<PictureBox, int> getY,
            Func<PictureBox, int> getW, Func<PictureBox, int> getH, PictureBox trumpPictureBox)
        {
            if (trumpPictureBox.Visible)
            {
                PictureBox temp = new PictureBox();
                temp.Bounds = trumpPictureBox.Bounds;
                temp.SetBounds(getX(temp), getY(temp), getW(temp), getH(temp));
                if (tar.Bounds.IntersectsWith(temp.Bounds))
                    return true;
            }
            return false;
        }
        public static void UpdateTrumpX(int value, Trump trump) => trump.X += value;

        public static bool MovingLeft(Trump trump) => trump.MovingLeft;

        public static bool TrumpGetLeftBorder(Trump trump) => trump.X < trump.StartPosition - 150;

        public static bool TrumpGetRightBorder(Trump trump) => trump.X > trump.StartPosition + 50;

        public static void ChangeDirectionToLeft(Trump trump, bool direction) => trump.MovingLeft = direction;

        public static void ChangeVisible(PictureBox trumpPb) => trumpPb.Visible = false;


    }
}

using System.Drawing;

namespace WallBreak
{
    public class Player
    {
        public Player(int health, int coins, int x, int y)
        {
            Health = health;
            Coins = coins;
            X = x;
            Y = y;
        }
        public int Y { get; set; }
        public int X { get; set; }
        public int Health { get; set; }
        public int Coins { get; set; }
        public bool PlayerJump;
        public bool PlayerLeft;
        public bool PlayerRight;
        public bool GameOn = true;
        public int Gravity = 48;
        public int Anim = 0;
        public int Force = 0;
        public int SpeedMovement = 4;
        public int SpeedJump = -4;
        public int SpeedFall = 4;
        public int Score = 0;
        public int Size = 100;



    }
}
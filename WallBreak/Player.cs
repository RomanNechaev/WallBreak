using System.Drawing;

namespace WallBreak
{
    public class Player
    {
        public Player(int health, int coins)
        {
            Health = health;
            Coins = coins;
        }

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
        public int SpeedJump = 4;
        public int SpeedFall = 4;
        public int Score = 0;
        public int Size = 100;
        public int X = 1200;
        public int Y = 800;


    }
}
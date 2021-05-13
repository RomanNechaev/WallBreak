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
        public  bool PlayerJump;    
        public bool PlayerLeft;
        public  bool PlayerRight;
        public bool LastDirRight;
        public  bool GameOn; 
        public  int Gravity = 20;
        public  int Anim = 0;
        public  int Force = 0;
        public  int SpeedMovement = 3;
        public  int SpeedJump = 3;
        public  int SpeedFall = 3;
        public  int Score = 0;
    }
}
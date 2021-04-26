using System.Drawing;

namespace WallBreak
{
    public class Player
    {
        public Player(int health, int coins,int posX,int posY)
        {
            Health = health;
            Coins = coins;
            this.posX = posX;
            this.posY = posY;
        }
        public int Health { get; set; }
        public int Coins { get; set; }

        public int posX;
        public int speedY;
        public int posY;
        public int dirX;
        public int dirY;
        public bool Moving;
    }
}
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
        public int Health { get; }
        public int Coins { get; }

        public int posX;
        public int posY;
    }
}
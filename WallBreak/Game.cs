using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WallBreak
{
    public class Game
    {
        public Player player = new Player(100, 0, 100, 100);
        

        public void MovePlayer()
        {
            player.posX += player.dirX;
            player.posY += player.dirY;
        }
        
    }
}
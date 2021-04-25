using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WallBreak
{
    public class Game
    {
        Player player = new Player(100,0,100,100);

        public void MovePlayer(int dX,int dY)
        {
            player.posX += dX;
            player.posY += dY;
        }
    }
}
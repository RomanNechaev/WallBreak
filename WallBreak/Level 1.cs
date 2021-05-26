using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WallBreak
{
    public class Level11
    {
        static Coins coins = new Coins();
        static Platforms platforms = new Platforms();
        static Cactuses cactuses = new Cactuses();
        
        public List<PictureBox> CactusObject = new List<PictureBox>
        {
            cactuses.CreateCactus(1700,953)
        };
        public  List<PictureBox> WorldObjects = new List<PictureBox>
        {
            platforms.CreatePlatform(160, 900),
            platforms.CreatePlatform(360, 720),
            platforms.CreatePlatform(140, 540),
            platforms.CreatePlatform(760, 775),
            platforms.CreatePlatform(640, 430),
            platforms.CreatePlatform(236, 240),
            platforms.CreatePlatform(800, 180),
            platforms.CreatePlatform(1100, 530),
            platforms.CreatePlatform(1400, 730),
            platforms.CreatePlatform(1100, 950),
            platforms.CreatePlatform(1436, 358)
        };

        public List<PictureBox> CoinsObject = new List<PictureBox>
        {
            coins.CreateCoin(800, 900),
            coins.CreateCoin(190, 850),
            coins.CreateCoin(410, 670),
            coins.CreateCoin(180, 490),
            coins.CreateCoin(820, 725),

        };
        public readonly int CoinsScore = 1;
    }
}
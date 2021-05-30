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
        public static Trump trumps = new Trump();
        
        public Tuple<int, int>[] coordsCactus =
        {
            Tuple.Create(1700,953)
        };
        public Tuple<int, int>[] coordsPlatform =
        {
            Tuple.Create(160, 900),
            Tuple.Create(360, 720),
            Tuple.Create(140, 540),
            Tuple.Create(760, 775),
            Tuple.Create(640, 430),
            Tuple.Create(236, 240),
            Tuple.Create(800, 180),
            Tuple.Create(1100, 530),
            Tuple.Create(1400, 730),
            Tuple.Create(1100, 950),
            Tuple.Create(1436, 358)
        };
        public Tuple<int, int>[] coordsCoins =
        {
            Tuple.Create(800, 900),
            Tuple.Create(190, 850),
            Tuple.Create(410, 670),
            Tuple.Create(180, 490),
            Tuple.Create(820, 725)
        };
        
        public Tuple<int, int>[] TrumpCoords =
        {
            Tuple.Create(315,140),
            Tuple.Create(900,75),
            Tuple.Create(725,350)
        };

        public List<Trump> trumpsList = new List<Trump>
        {
            new Trump(),
            new Trump(),
            new Trump()
        };
        public readonly int CoinsScore = 1;
    }
}
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
            Tuple.Create(1702,953),
            Tuple.Create(850,700),
            Tuple.Create(278,825),
            Tuple.Create(342,165),
            Tuple.Create(1500, 280)
        };
        public Tuple<int, int>[] coordsPlatform =
        {
            Tuple.Create(162, 900),
            Tuple.Create(362, 720),
            Tuple.Create(142, 540),
            Tuple.Create(762, 775),
            Tuple.Create(642, 430),
            Tuple.Create(230, 240),
            Tuple.Create(802, 180),
            Tuple.Create(1102, 530),
            Tuple.Create(1402, 710),
            Tuple.Create(1102, 950),
            Tuple.Create(1438, 358)
        };
        public Tuple<int, int>[] coordsCoins =
        {
            Tuple.Create(1200, 900),
            Tuple.Create(200, 850),
            Tuple.Create(240, 490),
            Tuple.Create(260, 190),
            Tuple.Create(1150, 50),
            Tuple.Create(1000, 275),
            Tuple.Create(1630, 305),
            Tuple.Create(1500, 660),

        };
        
        public Tuple<int, int>[] TrumpCoords =
        {
            Tuple.Create(875,80),
            Tuple.Create(725,330),
            Tuple.Create(430,620),
            Tuple.Create(1180,430),
        };

        public List<Trump> trumpsList = new List<Trump>
        {
            new Trump(),
            new Trump(),
            new Trump(), 
            new Trump(),
        };
        public readonly int CoinsScore = 1;
    }
}
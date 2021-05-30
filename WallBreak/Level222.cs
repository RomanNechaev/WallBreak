using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WallBreak
{
    public class Level222
    {
        static Coins coins = new Coins();
        static Platforms platforms = new Platforms();
        static Cactuses cactuses = new Cactuses();
        
        public Tuple<int, int>[] coordsCactus =
        {
            Tuple.Create(1300,953)
        };
        
        public Tuple<int, int>[] coordsPlatform =
        {
            Tuple.Create(160, 900),
            Tuple.Create(360, 720),
            Tuple.Create(140, 540),
        };
        
        public Tuple<int, int>[] coordsCoins =
        {
            Tuple.Create(800, 900),
        };

        public Tuple<int, int>[] TrumpCoords =
        {
            Tuple.Create<int, int>(100, 900),
        };
        
        
        public readonly int CoinsScore = 5;
    }
}
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
            Tuple.Create(1300,953),
            Tuple.Create(650,953),
            Tuple.Create(250,300),
            Tuple.Create(994,280),
            Tuple.Create(914,730),
        };
        
        public Tuple<int, int>[] coordsPlatform =
        {
            Tuple.Create(102, 900),
            Tuple.Create(362, 720),
            Tuple.Create(630, 530),
            Tuple.Create(158,380),
            Tuple.Create(502,220),
            Tuple.Create(894,360),
            Tuple.Create(1202,600), 
            Tuple.Create(814,812),
            Tuple.Create(1458,448),
            Tuple.Create(1212,202), 
            Tuple.Create(1602,900), 
        };
        
        public Tuple<int, int>[] coordsCoins =
        {
            Tuple.Create(800, 900),
            
        };

        public Tuple<int, int>[] TrumpCoords =
        {
            Tuple.Create(182, 800),
            Tuple.Create(710, 430),
            Tuple.Create(582,120),
            Tuple.Create(1282,500),
            Tuple.Create(1292,102), 
            Tuple.Create(1682,800),
        };

        public List<Trump> trumpsList = new List<Trump>
        {
            new Trump(),
             new Trump(),
            new Trump(),
            new Trump(),
            new Trump(),
            new Trump()
        };
        
        
        public readonly int CoinsScore = 1;
    }
}
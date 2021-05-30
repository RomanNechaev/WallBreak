using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WallBreak
{
    public class Level3
    {
        public Tuple<int, int>[] coordsPlatform =
        {
            Tuple.Create(0, 875),
            Tuple.Create(1650, 900),
            Tuple.Create(350, 750),
            Tuple.Create(650, 675),
            Tuple.Create(1574, 675),
            Tuple.Create(1050, 675),
            Tuple.Create(1650, 485),
            Tuple.Create(1050, 875),
            Tuple.Create(1350, 300),
            Tuple.Create(890, 200),
            Tuple.Create(950, 400),
            Tuple.Create(450, 300),
            Tuple.Create(100, 500)

        };
        public Tuple<int, int>[] coordsCoins =
        {
            Tuple.Create(1750, 850),
            Tuple.Create(1150, 825),
            Tuple.Create(1150, 1000),
            Tuple.Create(50, 1000),
            Tuple.Create(90, 825),
            Tuple.Create(450, 400),
            Tuple.Create(1870, 550),
            Tuple.Create(1450, 250),
            Tuple.Create(550, 250),
            Tuple.Create(100, 100),
            Tuple.Create(100, 100),
            Tuple.Create(100, 100),
            Tuple.Create(100, 100),


        };

        public Tuple<int, int>[] TrumpCoords =
        {
            Tuple.Create(720, 575),
            Tuple.Create(1650, 575),
            Tuple.Create(1730, 385),
            Tuple.Create(1030, 300),
            Tuple.Create(970, 100),
            Tuple.Create(170, 400),

        };

        public List<Trump> trumpsList = new List<Trump>
        {
            new Trump(),
            new Trump(),
            new Trump(),
            new Trump(),
            new Trump(),
            new Trump(),
            new Trump(),
            new Trump(),
        };
        public readonly int CoinsScore = 2;
    }
}
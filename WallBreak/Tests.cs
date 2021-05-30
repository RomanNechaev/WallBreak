using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using System.Windows.Forms;


namespace WallBreak
{
    [TestFixture]
    public class Tests
    {
        static Cactuses cactus = new Cactuses();
        Level11 level1 = new Level11();
        public static Panel WorldFrame = new Panel()
        {
            //Dock = DockStyle.Fill,
            Location = new System.Drawing.Point(0, 0),
            Name = "WorldFloor",
            Size = new System.Drawing.Size(1920, 1080)
        };

        public List<PictureBox> worldobjectTest = new List<PictureBox>()
        {
            cactus.CreateCactus(1700,953)
        };

        public static PictureBox tar1 = new PictureBox()
        {
            Location = new Point(-5, 3)
        };
        public PictureBox tar2 = new PictureBox()
        {
            Location = new Point(WorldFrame.Width+5, 3)
        };
        public PictureBox tar3 = new PictureBox()
        {
            Size = new Size(100,100),
            Location = new Point(-5, 10)
        };
        public PictureBox tar4 = new PictureBox()
        {
            Size = new Size(100,100),
            Location = new Point(1700, 931)
        };
        public PictureBox tar5 = new PictureBox()
        {
            Size = new Size(100,100),
            Location = new Point(30, 931)
        };
        
        // [Test]
        // public void OutsideWorldFrameTest()  
        // {
        //     Assert.AreEqual(true, Physics.OutsideWorldFrame(tar1, WorldFrame, level1.WorldObjects));
        // }
        // [Test]
        // public void OutsideWorldFrameTest2()  
        // {
        //     Assert.AreEqual(true, Physics.OutsideWorldFrame(tar2, WorldFrame, level1.WorldObjects));
        // }
        // [Test]
        // public void OutsideWorldFrameTest3()  
        // {
        //     Assert.AreEqual(true, Physics.OutsideWorldFrame(tar3, WorldFrame, level1.WorldObjects));
        // }

        [Test]
        public void CollisionRightTest()
        {
            Assert.AreEqual(true,Physics.CollisionRight(tar4,worldobjectTest));
        }
        [Test]
        public void CollisionLeftTest()
        {
            Assert.AreEqual(true,Physics.CollisionRight(tar4,worldobjectTest));
        }
        [Test]
        public void CollisionBottomTest()
        {
            Assert.AreEqual(true,Physics.CollisionRight(tar4,worldobjectTest));
        }
        [Test]
        public void CollisionTopTest()
        {
            Assert.AreEqual(true,Physics.CollisionRight(tar4,worldobjectTest));
        }
        // [Test]
        // public void InAirNoCollisionTest()
        // {
        //     Assert.AreEqual(true,Physics.InAirNoCollision(tar4,WorldFrame,));
        // }
        [Test]
        public void PlayerTookCoinTest()
        {
            Assert.AreEqual(false,Physics.PlayerTookCoin(tar3,tar4));
        }
        [Test]
        public void PlayerTookCoinTest2()
        {
            Assert.AreEqual(true,Physics.PlayerTookCoin(tar3,tar3));
        }


    }
}
using System.Drawing;
using NUnit.Framework;
using System.Windows.Forms;


namespace WallBreak
{
    [TestFixture]
    public class Tests
    {
        Level11 level1 = new Level11();
        public static Panel WorldFrame = new Panel()
        {
            //Dock = DockStyle.Fill,
            Location = new System.Drawing.Point(0, 0),
            Name = "WorldFloor",
            Size = new System.Drawing.Size(1920, 1080)
        };

        public PictureBox tar1 = new PictureBox()
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
        [Test]
        public void OutsideWorldFrameTest()
        {
            Assert.AreEqual(true,Physics.OutsideWorldFrame(tar1,WorldFrame,level1.CactusObject));
        }
    }
}
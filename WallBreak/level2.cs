using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class level2 : Form
    {
        Platforms platforms = new Platforms();
        Player player = new Player(100, 0);
        private PictureBox[] WorldObjects;
        public level2()
        {
            

            InitializeComponent();
            CreateLevel1();
            WorldObjects = new PictureBox[6] {
                platforms.CreatePlatform(1000, 900),
                platforms.CreatePlatform(1500, 850),
                platforms.CreatePlatform(500, 950),
                platforms.CreatePlatform(500, 850),
                platforms.CreatePlatform(500, 700),
                platforms.CreatePlatform(500, 950)
            };
            CreatePlatforms();
        }        

        private void CreatePlatforms()
        {
            foreach (var platform in WorldObjects)
            {
                WorldFrame.Controls.Add(platform);
            }
        }
        
        private void CreateLevel1()
        {
            Name = "Level1";
            Text = "Level1";
            //ResumeLayout(false);
            DoubleBuffered = true;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            //BackgroundImage = Properties.Resources._2x_total;
            ClientSize = new Size(1920, 1080);
            FormBorderStyle = FormBorderStyle.None;
        }
        public Boolean InAirNoCollision(PictureBox tar)
        {   //Checks if the target Picturebox is Outside of the frame
            if (!OutsideWorldFrame(tar))
            {
                foreach (PictureBox Obj in WorldObjects)
                {   //Or if it's not colliding with anything
                    if (!tar.Bounds.IntersectsWith(Obj.Bounds))
                    {
                        if (tar.Location.Y < WorldFrame.Width && !Collision_Top(pb_Player))
                        {   //And it's not under ground for some reason
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public Boolean OutsideWorldFrame(PictureBox tar)
        {
            if (tar.Location.X < 0) //Is it outside of the left side?
                return true;
            if (tar.Location.X > WorldFrame.Width)  //... right side?
                return true;
            if (tar.Location.Y + tar.Height > WorldFrame.Height - 3)
                return true;                        //Or above the WorldFrame?
            foreach (PictureBox Obj in WorldObjects)
            {
                if (Obj != null)
                {   //Or, intersecting with any world object
                    if (tar.Bounds.IntersectsWith(Obj.Bounds))
                        return true;
                }
            }
            return false;
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (player.GameOn)
                    {                        
                        player.LastDirRight = false; 
                        player.PlayerLeft = true; 
                    }

                    break;
                case Keys.Right: 
                    if (player.GameOn)
                    {
                        player.LastDirRight = true;
                        player.PlayerRight = true;
                    }

                    break;
                case Keys.Up: 
                    if (!player.PlayerJump && !InAirNoCollision(pb_Player))
                    {
                        pb_Player.Top -= player.SpeedJump; 
                        player.Force = player.Gravity;
                        player.PlayerJump = true; 
                    }

                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (player.GameOn)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left: 
                        player.LastDirRight = false;
                        player.PlayerLeft = false; 
                        break;
                    case Keys.Right:
                        player.LastDirRight = true;
                        player.PlayerRight = false;
                        break;
                }
            }
        }

        private void timer_Jump_Tick(object sender, EventArgs e)
        {
            if (player.GameOn)
            {
                if (player.PlayerRight &&pb_Player.Right <= WorldFrame.Width - 3 && !Collision_Left(pb_Player))
                {
                    pb_Player.Left += player.SpeedMovement; 
                }

                if (player.PlayerLeft && pb_Player.Left >= 3 && !Collision_Right(pb_Player))
                {
                    pb_Player.Left -= player.SpeedMovement;
                }
            }
            else
            {
                player.PlayerRight = false;
                player.PlayerLeft = false;
            }

            if (player.Force > 0)
            {
                if (Collision_Bottom(pb_Player))
                {
                    player.Force = 0;

                }
                else
                {
                    player.Force--;
                    pb_Player.Top -= player.SpeedJump;
                }
            }
            else
            {
                player.PlayerJump = false;
            }
        }
        public Boolean Collision_Top(PictureBox tar)
        {
            foreach (PictureBox ob in WorldObjects)
            {
                if (ob != null)
                {
                    PictureBox temp = new PictureBox(); 
                    temp.Bounds = ob.Bounds;
                    temp.SetBounds(temp.Location.X - 3, temp.Location.Y - 3, temp.Width -1 , 1);
                    if (tar.Bounds.IntersectsWith(temp.Bounds))
                        return true;
                }
            }
            return false;
        }
        public Boolean Collision_Left(PictureBox tar)
        {
            foreach (PictureBox ob in WorldObjects)
            {
                PictureBox temp = new PictureBox();
                temp.Bounds = ob.Bounds;
                temp.SetBounds(temp.Location.X - 5, temp.Location.Y + 1, 1, temp.Height + 1);
                if (tar.Bounds.IntersectsWith(temp.Bounds))
                    return true;
            }
            return false;
        }
        public Boolean Collision_Bottom(PictureBox tar)
        {
            foreach (PictureBox ob in WorldObjects)
            {
                if (ob != null)
                {
                    PictureBox temp = new PictureBox();
                    temp.Bounds = ob.Bounds;
                    temp.SetBounds(temp.Location.X, temp.Location.Y + temp.Height - 5, temp.Width - 2, 6);
                    if (tar.Bounds.IntersectsWith(temp.Bounds))
                        return true;
                }
            }
            return false;
        }
       
        public Boolean Collision_Right(PictureBox tar)
        {
            foreach (PictureBox ob in WorldObjects)
            {
                if (ob != null)
                {
                    PictureBox temp = new PictureBox();
                    temp.Bounds = ob.Bounds;
                    temp.SetBounds(temp.Location.X + temp.Width + 1, temp.Location.Y + 1, 2, temp.Height + 1);
                    if (tar.Bounds.IntersectsWith(temp.Bounds))
                        return true;
                }
            }
            return false;
        }

        private void timer_Gravity_Tick(object sender, EventArgs e)
        {
            if (!player.PlayerJump && pb_Player.Location.Y + pb_Player.Height < WorldFrame.Height && !Collision_Top(pb_Player))  
            {
                pb_Player.Top += player.SpeedFall; //Player falls
            }

            if (!player.PlayerJump && pb_Player.Location.Y + pb_Player.Height > WorldFrame.Height) 
            {
                //under the floor
                pb_Player.Top--;
            }
        }
    }
}
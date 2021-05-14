using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class level2 : Form
    {
        Platforms platforms = new Platforms();
        public level2()
        {
            
            InitializeComponent();
            CreateLevel1();
            CreatePlatforms();
        }
        Player player = new Player(100,0);

        private void CreatePlatforms()
        {
            WorldFrame.Controls.Add(platforms.CreatePlatform(0, 0));
            WorldFrame.Controls.Add(platforms.CreatePlatform(0, 200));
            WorldFrame.Controls.Add(platforms.CreatePlatform(0, 400));
            WorldFrame.Controls.Add(platforms.CreatePlatform(0, 600));
            WorldFrame.Controls.Add(platforms.CreatePlatform(0, 800));
            WorldFrame.Controls.Add(platforms.CreatePlatform(0, 1000));
        }
        private void CreateLevel1()
        {
            Name = "Level1";
            Text = "Level1";
            ResumeLayout(false);
            DoubleBuffered = true;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            //BackgroundImage = Properties.Resources._2x_total;
            ClientSize = new Size(1920, 1080);
            FormBorderStyle = FormBorderStyle.None;
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
                case Keys.Space: 
                    if (!player.PlayerJump)
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
                if (player.PlayerRight)
                {
                    pb_Player.Left += player.SpeedMovement; 
                }

                if (player.PlayerLeft)
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
                if (false)
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

        private void timer_Gravity_Tick(object sender, EventArgs e)
        {
            if (!player.PlayerJump && pb_Player.Location.Y + pb_Player.Height < WorldFrame.Height)  
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
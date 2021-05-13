using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class level2 : Form
    {
        public level2()
        {
            InitializeComponent();
            CreateLevel1();
        }
        Player player = new Player(100,0);

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
                case Keys.Left: // On Left Keypress down
                    if (player.GameOn)
                    {                        
                        player.LastDirRight = false; //For the animation, stand right or left
                        player.PlayerLeft = true; //Walk left
                    }

                    break;
                case Keys.Right: // On Right Keypress down
                    if (player.GameOn)
                    {
                        player.LastDirRight = true;
                        player.PlayerRight = true;
                    }

                    break;
                case Keys.Space: // On Space Keypress down
                    if (!player.PlayerJump)
                    {
                        //Anti multijump - If the player doesnt jump, is in the air and not colliding with anything
                        pb_Player.Top -= player.SpeedJump; //Player moves up a bit
                        player.Force = player.Gravity; //Force to be moved up changes
                        player.PlayerJump = true; //Sets a variable that player is jumping
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
                    case Keys.Left: //On Left Key press UP
                        player.LastDirRight = false; //Last move was to the left
                        player.PlayerLeft = false; //Doesnt move left anymore
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
                    //Stops the player from moving out of screen
                    pb_Player.Left += player.SpeedMovement; //Moves right
                }

                if (player.PlayerLeft)
                {
                    //Stops the player from moving out of screen
                    pb_Player.Left -= player.SpeedMovement; //Moves left
                }
            }
            else
            {
                //If game is not on, stops the player
                player.PlayerRight = false;
                player.PlayerLeft = false;
            }

            if (player.Force > 0)
            {
                //If any force still exists
                if (false)
                {
                    //Unless players head is banging in a wall
                    player.Force = 0;
                }
                else
                {
                    //Move player up, lower force each "move"
                    player.Force--;
                    pb_Player.Top -= player.SpeedJump;
                }
            }
            else
            {
                //If no force, player is not jumping.
                player.PlayerJump = false;
            }
        }

        private void timer_Gravity_Tick(object sender, EventArgs e)
        {
            if (!player.PlayerJump&&pb_Player.Location.Y+pb_Player.Height<1062)
            {
                //If Player doesnt jump, Location is above the floor or is standing on object
                pb_Player.Top += player.SpeedFall; //Player falls
            }

            if (!player.PlayerJump && pb_Player.Location.Y + pb_Player.Height > 1062)
            {
                //If player would for some reason be under the floor, move him up
                pb_Player.Top--;
            }
        }
    }
}
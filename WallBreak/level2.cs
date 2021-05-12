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

        Boolean Player_Jump = false; //Is the player jumping
        Boolean Player_Left = false; //.. moving to the left
        Boolean Player_Right = false; //.. moving to the right
        Boolean LastDirRight = true; // Whats the last dir facing
        Boolean GameOn = true; //Is the game on?
        int Gravity = 20;
        int Anim = 0;
        int Force = 0;
        int BombSize = 16;
        int Speed_Movement = 3;
        int Speed_Jump = 3;
        int Speed_Fall = 3;
        int Score = 0;

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
                    if (GameOn)
                    {
                        LastDirRight = false; //For the animation, stand right or left
                        Player_Left = true; //Walk left
                    }

                    break;
                case Keys.Right: // On Right Keypress down
                    if (GameOn)
                    {
                        LastDirRight = true;
                        Player_Right = true;
                    }

                    break;
                case Keys.Space: // On Space Keypress down
                    if (!Player_Jump)
                    {
                        //Anti multijump - If the player doesnt jump, is in the air and not colliding with anything
                        pb_Player.Top -= Speed_Jump; //Player moves up a bit
                        Force = Gravity; //Force to be moved up changes
                        Player_Jump = true; //Sets a variable that player is jumping
                    }

                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (GameOn)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left: //On Left Key press UP
                        LastDirRight = false; //Last move was to the left
                        Player_Left = false; //Doesnt move left anymore
                        break;
                    case Keys.Right:
                        LastDirRight = true;
                        Player_Right = false;
                        break;
                }
            }
        }

        private void timer_Jump_Tick(object sender, EventArgs e)
        {
            if (GameOn)
            {
                if (Player_Right)
                {
                    //Stops the player from moving out of screen
                    pb_Player.Left += Speed_Movement; //Moves right
                }

                if (Player_Left)
                {
                    //Stops the player from moving out of screen
                    pb_Player.Left -= Speed_Movement; //Moves left
                }
            }
            else
            {
                //If game is not on, stops the player
                Player_Right = false;
                Player_Left = false;
            }

            if (Force > 0)
            {
                //If any force still exists
                if (false)
                {
                    //Unless players head is banging in a wall
                    Force = 0;
                }
                else
                {
                    //Move player up, lower force each "move"
                    Force--;
                    pb_Player.Top -= Speed_Jump;
                }
            }
            else
            {
                //If no force, player is not jumping.
                Player_Jump = false;
            }
        }

        private void timer_Gravity_Tick(object sender, EventArgs e)
        {
            if (!Player_Jump&&pb_Player.Location.Y+pb_Player.Height<1062)
            {
                //If Player doesnt jump, Location is above the floor or is standing on object
                pb_Player.Top += Speed_Fall; //Player falls
            }

            if (!Player_Jump && pb_Player.Location.Y + pb_Player.Height > 1062)
            {
                //If player would for some reason be under the floor, move him up
                pb_Player.Top--;
            }
        }
    }
}
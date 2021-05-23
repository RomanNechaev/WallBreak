using System.ComponentModel;
using System.Drawing;

namespace WallBreak
{
    partial class level2
    {
        //Player players = new Player(100, 0);
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.components = new System.ComponentModel.Container();


            this.WorldFrame = new System.Windows.Forms.Panel();
            this.pb_Player = new System.Windows.Forms.PictureBox();

            this.timer_Gravity = new System.Windows.Forms.Timer(this.components);
            this.timer_Jump = new System.Windows.Forms.Timer(this.components);
            this.WorldFloor = new System.Windows.Forms.PictureBox();


            //((System.ComponentModel.ISupportInitialize)(this.pb_Player)).BeginInit();
            //this.WorldFrame.SuspendLayout();
            //this.WorldFloor.SuspendLayout();
            //this.SuspendLayout();
            //// 
            // WorldFrame
            // 

            this.WorldFrame.Controls.Add(this.pb_Player);
            //this.WorldFrame.Controls.Add(this.back);
            //this.WorldFrame.Controls.Add(this.platform1);
            //this.WorldFrame.Controls.Add(this.platform2);
            //this.WorldFrame.Controls.Add(this.platform3);
            //this.WorldFrame.Controls.Add(this.platform4);
            //this.WorldFrame.Controls.Add(this.platform5);
            //this.WorldFrame.Controls.Add(this.platform6);
            //this.WorldFrame.Controls.Add(this.platform7);

            this.WorldFrame.BackColor = Color.SkyBlue;
            //this.WorldFrame.BackgroundImage = global::WallBreak.World.cancel;
            this.WorldFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorldFrame.Location = new System.Drawing.Point(0, 0);
            this.WorldFrame.Name = "WorldFloor";
            this.WorldFrame.Size = new System.Drawing.Size(0, 0);
            this.WorldFrame.TabIndex = 1;
            this.Controls.Add(this.WorldFrame);
            //this.WorldFrame.ResumeLayout(false);
            //this.WorldFrame.PerformLayout();
            //               
            // pb_Player
            // 
            this.pb_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Player.BackColor = Color.Transparent;
            this.pb_Player.Image = Properties.Resources.sprite_23_2;
            this.pb_Player.Location = new System.Drawing.Point(Physics.player.X, Physics.player.Y);
            this.pb_Player.Name = "pb_Player";
            this.pb_Player.Size = new System.Drawing.Size(Physics.player.Size, Physics.player.Size);
            this.pb_Player.TabIndex = 0;
            this.pb_Player.TabStop = false;
            // 
            // timer_Gravity
            //     
            this.timer_Gravity.Enabled = true;
            this.timer_Gravity.Interval = 1;
            this.timer_Gravity.Tick += new System.EventHandler(this.GravityTimer);
            // 
            // timer_Jump
            // 
            this.timer_Jump.Enabled = true;
            this.timer_Jump.Interval = 10;
            this.timer_Jump.Tick += new System.EventHandler(this.timer_Jump_Tick);
            //   
            // WorldFloor
            // 
            this.WorldFloor.BackgroundImage = Properties.Resources.floordesert;
            this.WorldFloor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WorldFloor.Location = new System.Drawing.Point(0, 900);
            this.WorldFloor.Name = "WorldFloor";
            this.WorldFloor.Size = new System.Drawing.Size(1920, 45);
            this.WorldFloor.TabIndex = 1;
            //             
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1800);
            this.Controls.Add(this.WorldFloor);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Level2KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Level2KeyUp);

            //((System.ComponentModel.ISupportInitialize)(this.pb_Player)).EndInit();
            //this.WorldFloor.ResumeLayout(false);
            //this.WorldFloor.PerformLayout();
            //this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel WorldFrame;
        //private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.PictureBox WorldFloor;
        public System.Windows.Forms.PictureBox pb_Player;
        private System.Windows.Forms.Timer timer_Gravity;
        private System.Windows.Forms.Timer timer_Jump;


    }

}
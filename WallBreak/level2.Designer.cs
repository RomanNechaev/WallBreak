using System.ComponentModel;
using System.Drawing;

namespace WallBreak
{
    partial class level2
    {
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
            this.platform1 = new System.Windows.Forms.PictureBox();
            this.platform2 = new System.Windows.Forms.PictureBox();
            this.platform3 = new System.Windows.Forms.PictureBox();
            this.platform4 = new System.Windows.Forms.PictureBox();
            this.platform5 = new System.Windows.Forms.PictureBox();
            this.platform6 = new System.Windows.Forms.PictureBox();
            this.platform7 = new System.Windows.Forms.PictureBox();
            //this.back = new System.Windows.Forms.PictureBox();

            this.timer_Gravity = new System.Windows.Forms.Timer(this.components);
            this.timer_Jump = new System.Windows.Forms.Timer(this.components);
            this.WorldFloor = new System.Windows.Forms.PictureBox();
            //this.pb_Block2 = new System.Windows.Forms.PictureBox();///

            this.WorldFrame.SuspendLayout();            
            ((System.ComponentModel.ISupportInitialize)(this.pb_Player)).BeginInit();
            this.WorldFloor.SuspendLayout();
            this.SuspendLayout();
            // 
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
            this.WorldFrame.Size = new System.Drawing.Size(960, 1035);
            this.WorldFrame.TabIndex = 1;
            this.Controls.Add(this.WorldFrame);
            this.WorldFrame.ResumeLayout(false);
            this.WorldFrame.PerformLayout();
            //    

            //this.back.BackgroundImage = Properties.Resources._2;
            //this.back.Location = new System.Drawing.Point(0, 0);
            //this.back.Size = new System.Drawing.Size(500, 500);

            this.platform1.BackColor = System.Drawing.Color.Transparent;
            this.platform1.Image = Properties.Resources.заккк;
            this.platform1.Location = new System.Drawing.Point(0, 800);
            this.platform1.Size = new System.Drawing.Size(100, 100);

            this.platform2.BackColor = System.Drawing.Color.Transparent;
            this.platform2.Image = Properties.Resources.заккк;
            this.platform2.Location = new System.Drawing.Point(100, 800);
            this.platform2.Size = new System.Drawing.Size(100, 100);

            this.platform3.BackColor = System.Drawing.Color.Transparent;
            this.platform3.Image = Properties.Resources.заккк;
            this.platform3.Location = new System.Drawing.Point(200, 800);
            this.platform3.Size = new System.Drawing.Size(100, 100);

            this.platform4.BackColor = System.Drawing.Color.Transparent;
            this.platform4.Image = Properties.Resources.заккк;
            this.platform4.Location = new System.Drawing.Point(300, 800);
            this.platform4.Size = new System.Drawing.Size(100, 100);

            this.platform5.BackColor = System.Drawing.Color.Transparent;
            this.platform5.Image = Properties.Resources.заккк;
            this.platform5.Location = new System.Drawing.Point(400, 800);
            this.platform5.Size = new System.Drawing.Size(100, 100);

            this.platform6.BackColor = System.Drawing.Color.Transparent;
            this.platform6.Image = Properties.Resources.заккк;
            this.platform6.Location = new System.Drawing.Point(500, 800);
            this.platform6.Size = new System.Drawing.Size(100, 100);

            this.platform7.BackColor = System.Drawing.Color.Transparent;
            this.platform7.Image = Properties.Resources.заккк;
            this.platform7.Location = new System.Drawing.Point(600, 800);
            this.platform7.Size = new System.Drawing.Size(100, 100);

            // pb_Player
            // 
            this.pb_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Player.BackColor = Color.Transparent;
            this.pb_Player.Image = Properties.Resources.sprite_23_2;
            this.pb_Player.Location = new System.Drawing.Point(1000, 800);
            this.pb_Player.Name = "pb_Player";
            this.pb_Player.Size = new System.Drawing.Size(100, 100);
            this.pb_Player.TabIndex = 0;
            this.pb_Player.TabStop = false;
            // 
            // timer_Gravity
            // 
            this.timer_Gravity.Enabled = true;
            this.timer_Gravity.Interval = 10;
            this.timer_Gravity.Tick += new System.EventHandler(this.timer_Gravity_Tick);
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
            this.WorldFloor.Location = new System.Drawing.Point(0, 1035);
            this.WorldFloor.Name = "WorldFloor";
            this.WorldFloor.Size = new System.Drawing.Size(1920, 45);
            this.WorldFloor.TabIndex = 1;
            //             
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.WorldFloor);
            
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            
            ((System.ComponentModel.ISupportInitialize)(this.pb_Player)).EndInit();
            this.WorldFloor.ResumeLayout(false);
            this.WorldFloor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel WorldFrame;
        //private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.PictureBox WorldFloor;
        private System.Windows.Forms.PictureBox pb_Player;
        private System.Windows.Forms.PictureBox platform1;
        private System.Windows.Forms.PictureBox platform7;
        private System.Windows.Forms.PictureBox platform6;
        private System.Windows.Forms.PictureBox platform5;
        private System.Windows.Forms.PictureBox platform4;
        private System.Windows.Forms.PictureBox platform3;
        private System.Windows.Forms.PictureBox platform2;
        private System.Windows.Forms.Timer timer_Gravity;
        private System.Windows.Forms.Timer timer_Jump;


    }

    }
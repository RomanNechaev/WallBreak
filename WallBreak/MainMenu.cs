using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WallBreak
{
    public interface IScreen
    {
        void Draw(Form form);

        void Clear(Form form);
    }


    public class Form1 : Form
    {
        public Form1()
        {
            var mainMenu = new MainScreen();
            var levelMenu = new LevelChooseScreen();
            var settinsMenu = new SettingsScreen();
            mainMenu.Draw(this);
            var label = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Century Gothic", 85F, ((FontStyle) ((FontStyle.Bold | FontStyle.Italic))),
                    GraphicsUnit.Point),
                Location = new Point(470, 34),
                Name = "label1",
                Size = new Size(1000, 207),
                Text = "WallBreak",
                TextAlign = ContentAlignment.MiddleCenter
            };
            mainMenu.exit.Click += (sender, args) => Application.Exit();
            mainMenu.settings.Click += (sender, args) =>
            {
                mainMenu.Clear(this);
                settinsMenu.Draw(this);
            };
            mainMenu.startGame.Click += (sender, args) =>
            {
                mainMenu.Clear(this);
                levelMenu.Draw(this);
            };
            settinsMenu.enterMenu.Click += (sender, args) =>
            {
                settinsMenu.Clear(this);
                mainMenu.Draw(this);
            };
            settinsMenu.offMusic.Click += (sender, args) => { Music().Stop(); };
            settinsMenu.onMusic.Click += (sender, args) => { Music().Play(); };
            levelMenu.firstLevel.Click += (sender, args) =>
            {
            };
            levelMenu.backTomenu.Click += (sender, args) =>
            {
                levelMenu.Clear(this);
                mainMenu.Draw(this);
            };
            mainMenu.startGame.Click += (sender, args) =>
            {
                var game = new Game();
                Program.Forms.Hide();
                game.Show();

            };
            
            Music();
            CreateMenu();
            Controls.Add(label);
        }

        private void CreateMenu()
        {
            DoubleBuffered = true;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_for_game;
            ClientSize = new Size(1920, 1080);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }
        

        public static SoundPlayer Music()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream resourceStream = assembly.GetManifestResourceStream(@"WallBreak.мекс.wav");
            SoundPlayer player = new SoundPlayer(resourceStream);
            return player;
        }
    }
}
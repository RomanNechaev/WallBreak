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
        // void Draw(Form form);
        //
        // void Clear(Form form);
        //
        // void MoveTo(Form form, IScreen screen)
        // {
        //     Clear(form);
        //     screen.Draw(form);
        // }
    }

    /*
    class MainScreen : IScreen
    {
        private Button _button;
        public void Draw(Form form)
        {
            _button = new Button()
            {

            };
            
            form.Controls.Add(_button);
        }

        public void Clear(Form form)
        {
            form.Controls.Remove(_button);
        }
    }
    */

    public partial class Form1 : Form, IScreen
    {
        public Form1()
        {
            //var mainMenu = new MainScreen();
            //mainMenu.Draw(this);
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
            var startGame = CreateButton("Начать игру", new Point(600, 330));
            var settings = CreateButton("Настройки", new Point(600, 500));
            var exit = CreateButton("Выйти из игры", new Point(600, 670));
            var settingsForm= new Settings();
            var levelChooseForm  = new LevelChoose();
            exit.Click += (sender, args) => Application.Exit();
            settings.Click += (sender, args) =>
            {
                Draw(settingsForm);                
            };
            startGame.Click += (sender, args) =>
            {
                Draw(levelChooseForm);
            };
            Music();
            CreateMenu();
            Controls.Add(label);
            Controls.Add(exit);
            Controls.Add(startGame);
            Controls.Add(settings);
        }
        public void Draw(Form form)
        {
            form.Show();
        }

        public void Clear(Form form)
        {
            form.Hide();
        }

        // public void MoveTo(Form form, IScreen screen)
        // {
        //     Clear(form);
        //     screen.Draw(form);
        // }

        private void CreateMenu()
        {
            DoubleBuffered = true;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            AutoScaleDimensions = new SizeF(8F, 20F);
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

        private static Button CreateButton(string text, Point coords)
        {
            var button = new Button
            {
                Text = text,
                BackColor = SystemColors.Control,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Century Gothic", 28F, FontStyle.Bold, GraphicsUnit.Point),
                Location = coords,
                Size = new Size(700, 90),
            };
            button.FlatAppearance.MouseOverBackColor = Color.Pink;
            return button;
        }

        
        
    }
}

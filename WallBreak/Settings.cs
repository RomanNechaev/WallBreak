﻿using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class Settings : Form,IScreen
    {
        public Settings()
        {
            var label = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Century Gothic", 80F, ((FontStyle) ((FontStyle.Bold | FontStyle.Italic))),
                    GraphicsUnit.Point),
                Location = new Point(430, 34),
                Name = "label1",
                Size = new Size(1100, 207),
                Text = "Настройки",
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(label);
            var offMusic = CreateButton("Выключить музыку", new Point(600, 330));
            var onMusic = CreateButton("Включить музыку", new Point(600, 500));
            var enterMenu = CreateButton("Назад", new Point(600, 670));
            CreateSettings();
            Controls.Add(enterMenu);
            Controls.Add(offMusic);
            Controls.Add(onMusic);
            enterMenu.Click += (sender, args) =>
            {
                Hide();
                Program.menu.Show();
            };
            offMusic.Click += (sender, args) =>
            {
                Form1.Music().Stop();
            };
            onMusic.Click += (sender, args) =>
            {
                Form1.Music().Play();
            };


        }
        private void CreateSettings()
        {
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Settings";
            Text = "Form1";
            ResumeLayout(false);
            BackgroundImage = Properties.Resources.background_for_game;
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
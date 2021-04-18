using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WallBreak
{
    public partial class LevelChoose : Form
    {
        public LevelChoose()
        {

            var label = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Century Gothic", 85F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))),
                    GraphicsUnit.Point),
                Location = new Point(500, 34),
                Name = "label1",
                Size = new Size(1000, 207),
                Text = "Выбор уровня",
                TextAlign = ContentAlignment.TopLeft
            };
            var firstLevel = CreateButton("Первый уровень", new Point(600, 330));
            var secondLevel = CreateButton("Второй Уровень", new Point(600, 500));
            var thirdLevel = CreateButton("Третий Уровень", new Point(600, 670));
            var backTomenu = CreateButton("Назад", new Point(600, 840));
            firstLevel.Click += (sender, args) =>
            {
                Hide();
                var level1 = new Level1();
                level1.Show();
            };
            backTomenu.Click += (sender, args) =>
            {
                Hide();
                var menu = new Form1();
                menu.Show();
            };
            CreateLevelChoose();
            Controls.Add(label);
            Controls.Add(thirdLevel);
            Controls.Add(firstLevel);
            Controls.Add(secondLevel);
            Controls.Add(backTomenu);
            InitializeComponent();
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
        private void CreateLevelChoose()
        {
            FormBorderStyle = FormBorderStyle.None;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_for_game;
            ClientSize = new System.Drawing.Size(1920, 1080);
            Name = "Level1";
            Text = "Level1";
            ResumeLayout(false);
        }
    }
}

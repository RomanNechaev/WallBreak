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
                Location = new Point(470, 34),
                Name = "label1",
                Size = new Size(1000, 207),
                Text = "WallBreak",
                TextAlign = ContentAlignment.MiddleCenter
            };
            var firstLevel = CreateButton("Первый уровень", new Point(600, 330));
            var secondLevel = CreateButton("Второй Уровень", new Point(600, 500));
            var thirdLevel = CreateButton("Третий Уровень", new Point(600, 670));
            var backTomenu = CreateButton("Назад", new Point(600, 840));
            //firstLevel.Click
            //thirdLevel.Click += (sender, args) => Application.Exit();
            //secondLevel.Click += (sender, args) =>
            //{
            //    Hide();
            //    var settings = new Settings();
            //    settings.Show();
            //};
            //firstLevel.Click += (sender, args) =>
            //{
            //    Hide();
            //    var level1 = new Level1();
            //    level1.Show();
            //};
            //Music().Play();
            //InitializeComponent();
            Controls.Add(label);
            Controls.Add(thirdLevel);
            Controls.Add(firstLevel);
            Controls.Add(secondLevel);
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
    }
}

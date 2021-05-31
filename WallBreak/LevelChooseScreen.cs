using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public class LevelChooseScreen
    {
        public Button firstLevel = CreateButton("Первый уровень", new Point(600, 330));
        public Button secondLevel = CreateButton("Второй Уровень", new Point(600, 500));
        public Button thirdLevel = CreateButton("Третий Уровень", new Point(600, 670));
        public Button backTomenu = CreateButton("Назад", new Point(600, 840));
        public Label label = new Label
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

        public void Draw(Form form)
        {
            form.Controls.Add(label);
            form.Controls.Add(thirdLevel);
            form.Controls.Add(firstLevel);
            form.Controls.Add(secondLevel);
            form.Controls.Add(backTomenu);
        }

        public void Clear(Form form)
        {
            form.Controls.Remove(label);
            form.Controls.Remove(thirdLevel);
            form.Controls.Remove(firstLevel);
            form.Controls.Remove(secondLevel);
            form.Controls.Remove(backTomenu);
        }
    }
}
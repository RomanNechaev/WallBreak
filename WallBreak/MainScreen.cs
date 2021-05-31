using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public class MainScreen:IScreen
    {
        public Button startGame = CreateButton("Начать игру", new Point(600, 330));
        public Button settings = CreateButton("Настройки", new Point(600, 500));
        public Button exit = CreateButton("Выйти из игры", new Point(600, 670));

        public static Button CreateButton(string text, Point coords)
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
            form.Controls.Add(startGame);
            form.Controls.Add(settings);
            form.Controls.Add(exit);
        }

        public void Clear(Form form)
        {
            form.Controls.Remove(startGame);
            form.Controls.Remove(settings);
            form.Controls.Remove(exit);
        }
    }
}
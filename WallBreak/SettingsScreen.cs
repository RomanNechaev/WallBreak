using System.Drawing;
using System.Windows.Forms;

namespace WallBreak
{
    public class SettingsScreen:IScreen
    {
        public Button offMusic = CreateButton("Выключить музыку", new Point(600, 330));
        public Button onMusic = CreateButton("Включить музыку", new Point(600, 500));
        public Button enterMenu = CreateButton("Назад", new Point(600, 670));

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
            form.Controls.Add(offMusic);
            form.Controls.Add(onMusic);
            form.Controls.Add(enterMenu);
        }

        public void Clear(Form form)
        {
            form.Controls.Remove(offMusic);
            form.Controls.Remove(onMusic);
            form.Controls.Remove(enterMenu);
            
        }
    }
}
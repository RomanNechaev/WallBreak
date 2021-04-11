using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace WallBreak
{

    public partial class Form1 : Form
    {
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            WMP.URL = @"C:\Users\79123\Documents\GitHub\WallBreak\.mp3"; // файл музыкальный
            WMP.settings.volume = 100; // меняя значение можно регулировать громкость
            WMP.controls.play(); // Старт
        }
    }
}
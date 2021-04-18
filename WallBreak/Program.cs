using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WallBreak
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MenuInit());
            Application.Run(new Settings());
        }
        
        public static Form menu;
        public static Form setting;
        
        public static Form MenuInit()
        {
            return menu = new Form1();
        }

        public static Form SettingInit()
        {
            return setting = new Settings();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FBMCE_Configuration_Tool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tool());
        }
    }
}

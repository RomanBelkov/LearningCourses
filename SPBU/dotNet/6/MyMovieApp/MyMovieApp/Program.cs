using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyMovieApp.Controllers;

namespace MyMovieApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var db = new DataModelContainer())
            {
                var appController = new AppController(db);
                Application.Run(appController.RenderMainView());
            }
        }
    }
}

using System;
using System.Windows.Forms;
using Exam.Controllers;
using Exam.Views;

namespace Exam
{
    internal static class Exam
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new ExamForm();
            var controller = new ExamController(view);
            Application.Run(view);
        }
    }
}

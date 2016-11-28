using System;
using System.ComponentModel;
using System.Windows.Forms;
using Exam.Models;
using Exam.Properties;

namespace Exam.Views
{
    internal partial class ExamForm : Form, IExamView
    {
        public event EventHandler ExamStarted;

        public ExamForm()
        {
            InitializeComponent();
            AdjustListViewColumnsWidth();
            progressBar.Step = 1;
            startButton.Click += OnButtonStartClick;
        }

        public void SetProgressBarMaxValue(int max)
        {
            progressBar.Maximum = max; //progress presenter
        }

        public void InformAboutFinish()
        {
            InvokeIfRequired(() =>
            {
                startButton.Enabled = true;
                MessageBox.Show(Resources.ExamIsOver, Resources.ExamIsOverCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }, this);
        }

        public void DisplayStudentName(Student student, int studentId)
        {
            if (string.IsNullOrEmpty(student?.Name))
            {
                throw new ArgumentNullException();
            }
            InvokeIfRequired(() =>
            {
                studentsListView.Items.Add(new ListViewItem(new[] { (studentId + 1).ToString(), student.Name, "" }));
            }, studentsListView);
        }

        public void DisplayStudentMark(int studentMark, int studentId)
        {
            InvokeIfRequired(() =>
            {
                progressBar.PerformStep();
                studentsListView.Items[studentId].SubItems[2].Text = studentMark.ToString();
            }, studentsListView);
        }

        private void InvokeIfRequired(Action action, ISynchronizeInvoke control)
        {
            if (control.InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void OnButtonStartClick(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            ResetResultListView();
            ExamStarted?.Invoke(this, EventArgs.Empty);
        }

        private void ResetResultListView()
        {
            progressBar.Value = 0;
            studentsListView.Items.Clear();
            studentsListView.Refresh();
        }

        private void AdjustListViewColumnsWidth()
        {
            var allWidth = studentsListView.Size.Width;
            var idWidth = allWidth / 10 * 2 - 1;
            var nameWidth = allWidth / 10 * 6 - 1;
            var markWidth = allWidth / 10 * 2 - 1;

            studentsListView.Columns[0].Width = idWidth;
            studentsListView.Columns[1].Width = nameWidth;
            studentsListView.Columns[2].Width = markWidth;
        }
    }
}
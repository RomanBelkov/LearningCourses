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
        private int _amountStudentsPassed;

        public ExamForm()
        {
            InitializeComponent();
            AdjustListViewColumnsWidth();
            progressBar.Step = 1;
            SizeChanged += OnFormSizeChanges;
            startButton.Click += OnButtonStartClick;
        }

        public void SetProgressBarMaxValue(int max)
        {
            progressBar.Maximum = max;
        }

        public void InformAboutFinish()
        {
            InvokeIfRequired(() =>
            {
                startButton.Enabled = true;
            }, startButton);
            MessageBox.Show(Resources.ExamIsOver);
        }

        public void DisplayStudentName(Student student)
        {
            if (string.IsNullOrEmpty(student?.Name))
            {
                throw new ArgumentNullException();
            }
            InvokeIfRequired(() =>
            {
                studentsListView.Items.Add(new ListViewItem(new[] { (++_amountStudentsPassed).ToString(), student.Name, "" }));
            }, studentsListView);
        }

        public void DisplayStudentMark(Student student)
        {
            if (student == null || student.Mark < 2 || student.Mark > 5)
            {
                throw new ArgumentOutOfRangeException();
            }
            InvokeIfRequired(() =>
            {
                progressBar.PerformStep();
                studentsListView.Items[_amountStudentsPassed - 1].SubItems[2].Text = student.Mark.ToString();
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

        private void OnFormSizeChanges(object sender, EventArgs e)
        {
            AdjustListViewColumnsWidth();
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
            _amountStudentsPassed = 0;
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
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Exam.Helpers;
using Exam.Models;
using Exam.Views;

namespace Exam.Controllers
{
    public sealed class ExamController : IDeanStudentCommunicator
    {
        private readonly IExamView _view;
        private DeanOffice _deanOffice;
        private int _amountStudents;
        private int _amountStudentsPassed;
        private bool _isPaused;
        private readonly object _pauseLock = new object();

        public ExamController(IExamView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException();
            }
            _view = view;
            _view.ExamStarted += OnExamStarted;
            _view.ExamPaused += OnExamPaused;
            _view.ExamResumed += OnExamResumed;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void CallStudent(Student student)
        {
            lock (_pauseLock)
            {
                if (_isPaused) Monitor.Wait(_pauseLock);
            }

            if (string.IsNullOrEmpty(student.Name))
            {
                throw new ArgumentNullException();
            }
            _view.DisplayStudentName(student, _amountStudentsPassed);

            Thread.Sleep(Randomizer.GetStudentExaminationTime());

            var mark = Randomizer.GetStudentMark();

            _view.DisplayStudentMark(mark, _amountStudentsPassed);
            _amountStudentsPassed++;
            _view.SetProgress(_amountStudentsPassed * 100 / _amountStudents);

            if (_amountStudents == _amountStudentsPassed)
            {
                _view.InformAboutFinish();
            }
        }

        internal void PauseExam()
        {
            _isPaused = true;
        }

        internal void ResumeExam()
        {
            lock (_pauseLock)
            {
                _isPaused = false;
                Monitor.PulseAll(_pauseLock);
            }
        }

        private void OnExamStarted(object sender, EventArgs e)
        {
            _isPaused = false;
            _amountStudentsPassed = 0;
            _amountStudents = Randomizer.GetAmountStudents();
            if (_amountStudents == 0)
            {
                _view.InformAboutFinish();
                return;
            }
            _deanOffice = new DeanOffice(this);
            for (var i = 0; i < _amountStudents; i++)
            {
                new Thread(new Student(_deanOffice).AttemptToPassExam).Start();
            }
            _deanOffice.StartExamination();
        }

        private void OnExamPaused(object sender, EventArgs e)
        {
            PauseExam();
        }

        private void OnExamResumed(object sender, EventArgs e)
        {
            ResumeExam();
        }
    }
}

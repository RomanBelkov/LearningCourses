using System;
using System.Threading;
using Exam.Helpers;
using Exam.Models;
using Exam.Views;

namespace Exam.Controllers
{
    public sealed class ExamController : IDeanInformer
    {
        private readonly IExamView _view;
        private DeanOffice _deanOffice;
        private int _amountStudents;
        private int _amountStudentsPassed;

        public ExamController(IExamView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException();
            }
            _view = view;
            _view.ExamStarted += OnExamStarted;
        }

        public void InformStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
            {
                throw new ArgumentNullException();
            }
            _view.DisplayStudentName(student);
        }

        public void InformStudentMark(Student student)
        {
            if (student.Mark < 2 || student.Mark > 5)
            {
                throw new ArgumentOutOfRangeException();
            }
            _view.DisplayStudentMark(student);
            if (_amountStudents == ++_amountStudentsPassed)
            {
                _view.InformAboutFinish();
            }
        }

        private void OnExamStarted(object sender, EventArgs e)
        {
            _amountStudentsPassed = 0;
            _amountStudents = Randomizer.GetAmountStudents();
            _view.SetProgressBarMaxValue(_amountStudents);
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
    }
}

using System;
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

        public ExamController(IExamView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException();
            }
            _view = view;
            _view.ExamStarted += OnExamStarted;
        }

        public void CallStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
            {
                throw new ArgumentNullException();
            }
            _view.DisplayStudentName(student, _amountStudentsPassed);

            Thread.Sleep(Randomizer.GetStudentExaminationTime());

            var mark = Randomizer.GetStudentMark();

            _view.DisplayStudentMark(mark, _amountStudentsPassed);
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

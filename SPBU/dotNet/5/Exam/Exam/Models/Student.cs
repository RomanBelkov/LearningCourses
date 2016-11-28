using System;
using System.Threading;
using Exam.Helpers;

namespace Exam.Models
{
    public sealed class Student
    {
        public string Name { get; }
        public int Mark { get; internal set; }
        private readonly DeanOffice _deanOffice;

        public Student(DeanOffice deanOffice)
        {
            if (deanOffice == null)
            {
                throw new ArgumentNullException();
            }
            Name = Randomizer.GetStudentName();
            _deanOffice = deanOffice;
        }

        public void AttemptToPassExam()
        {
            _deanOffice.ExamStartedEvent.WaitOne();
            Thread.Sleep(Randomizer.GetSleepTime());
            _deanOffice.ExamineStudent(this);
        }
    }
}

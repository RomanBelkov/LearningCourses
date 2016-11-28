using System;
using System.Threading;
using Exam.Helpers;

namespace Exam.Models
{
    public sealed class DeanOffice
    {
        public ManualResetEvent ExamStartedEvent { get; }
        private readonly object _lock = new object();
        private readonly IDeanInformer _informer;

        public DeanOffice(IDeanInformer informer)
        {
            if (informer == null)
            {
                throw new ArgumentNullException();
            }
            _informer = informer;
            ExamStartedEvent = new ManualResetEvent(false);
        }

        public void StartExamination()
        {
            ExamStartedEvent.Set();
        }

        public void ExamineStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException();
            }
            lock (_lock)
            {
                _informer.InformStudent(student);
                Thread.Sleep(Randomizer.GetStudentExaminationTime());
                student.Mark = Randomizer.GetStudentMark();
                _informer.InformStudentMark(student);
                //return Randomizer.GetStudentMark();
            }
        }
    }
}

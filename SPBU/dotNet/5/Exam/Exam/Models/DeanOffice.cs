using System;
using System.Threading;

namespace Exam.Models
{
    public sealed class DeanOffice
    {
        public ManualResetEvent ExamStartedEvent { get; }
        private readonly object _lock = new object();
        private readonly IDeanStudentCommunicator _communicator;

        public DeanOffice(IDeanStudentCommunicator communicator)
        {
            if (communicator == null)
            {
                throw new ArgumentNullException();
            }
            _communicator = communicator;
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

           _communicator.CallStudent(student);
        }
    }
}

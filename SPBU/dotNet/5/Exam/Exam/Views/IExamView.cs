using System;
using Exam.Models;

namespace Exam.Views
{
    public interface IExamView
    {
        event EventHandler ExamStarted;
        void DisplayStudentName(Student student);
        void DisplayStudentMark(Student student);
        void InformAboutFinish();
        void SetProgressBarMaxValue(int max);
    }
}

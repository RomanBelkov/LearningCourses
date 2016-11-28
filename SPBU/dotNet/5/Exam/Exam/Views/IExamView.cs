using System;
using Exam.Models;

namespace Exam.Views
{
    public interface IExamView
    {
        event EventHandler ExamStarted;
        void DisplayStudentName(Student student, int studentId);
        void DisplayStudentMark(int studentMark, int studentId);
        void InformAboutFinish();
        void SetProgressBarMaxValue(int max); //separate progress from viewS
    }
}

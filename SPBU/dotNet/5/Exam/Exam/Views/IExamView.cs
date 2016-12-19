using System;
using Exam.Models;

namespace Exam.Views
{
    public interface IExamView
    {
        event EventHandler ExamStarted;
        event EventHandler ExamPaused;
        event EventHandler ExamResumed;

        void DisplayStudentName(Student student, int studentId);
        void DisplayStudentMark(int studentMark, int studentId);
        void InformAboutFinish();

        void SetProgress(int percent);
    }
}

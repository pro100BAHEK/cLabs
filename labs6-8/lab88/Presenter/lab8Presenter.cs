using lab88.View;
using lab88.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab88.Presenter
{
    public class lab8Presenter
    {
        private readonly lab8View view;
        private readonly StudentModel model;

        public lab8Presenter(lab8View view, StudentModel model)
        {
            this.view = view;
            this.model = model;

            view.AddStudent += OnAddStudent;
            view.UpdateStudent += OnUpdateStudent;
            view.DeleteStudent += OnDeleteStudent;
            view.ViewStudents += OnViewStudents;
        }

        private void OnAddStudent(object sender, EventArgs e)
        {
            model.CreateStudent(view.StudentName, view.RecordBook, view.Department, view.Specification, view.DateOfAdmission, view.Group);
            OnViewStudents(sender, e);
        }

        private void OnUpdateStudent(object sender, EventArgs e)
        {
            model.UpdateStudent(view.Id, view.StudentName, view.RecordBook, view.Department, view.Specification, view.DateOfAdmission, view.Group);
            OnViewStudents(sender, e);
        }

        private void OnDeleteStudent(object sender, EventArgs e)
        {
            model.DeleteStudent(view.Id);
            OnViewStudents(sender, e);
        }

        private void OnViewStudents(object sender, EventArgs e)
        {
            Debug.WriteLine("Просмотр студентов...");
            view.DisplayStudents(model.ReadStudents());
        }
    }
}

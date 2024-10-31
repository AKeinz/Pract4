using Model;
using pract4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class StudentPresenter
    {
        private IModel<Student> model;

        public StudentPresenter(IView view, IModel<Student> model)
        {
            this.model = model;
            model.DataChanged += view.RedrawForm;
            view.AddDataEvent += OnAddData;
            view.DeleteDataEvent += model.Delete;
            model.InvokeDataChanged();
        }

        private void OnAddData(List<object> newStudent)
        {
            Student student = new Student();
            student.Name = (string)newStudent[0];
            student.Specialty = (string)newStudent[1];
            student.Group = (string)newStudent[2];
            model.Insert(student);
        }
    }
}

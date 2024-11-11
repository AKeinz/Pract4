using Model;
using pract4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //model.InvokeDataChanged();
        }

        private void OnAddData(List<object> newStudent)
        {
            Student student = new Student();
            student.Id = (int)newStudent[0];
            student.Name = (string)newStudent[1];
            student.Specialty = (string)newStudent[2];
            student.Group = (string)newStudent[3];
            model.Insert(student);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BusinessLogic : IModel<Student>
    {
        private List<Student> students = new List<Student>();
        public event DataChangedDelegate DataChanged;

        public void Delete(int index)
        {
            students.RemoveAt(index);
            InvokeDataChanged();
        }

        public void Insert(Student item)
        {
            students.Add(item);
            InvokeDataChanged();
        }

        public void InvokeDataChanged()
        {
            List<List<object>> newStudents = new List<List<object>>();
            for (int i=0; i<students.Count; i++)
            {
                Student student = students[i];
                newStudents.Add(new List<object>()
                {
                    student.Name,
                    student.Specialty,
                    student.Group
                });
            }
            DataChanged?.Invoke(newStudents);
        }
    }
}

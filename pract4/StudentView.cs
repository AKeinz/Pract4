using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract4
{
    public partial class StudentView : Form, IView
    {
        public StudentView()
        {
            InitializeComponent();
            studentsListView.Columns.Add("Номер");
            studentsListView.Columns[0].Width = 60;
            studentsListView.Columns.Add("Имя");
            studentsListView.Columns[1].Width = 200;
            studentsListView.Columns.Add("Специальность");
            studentsListView.Columns[2].Width = 170;
            studentsListView.Columns.Add("Группа");
            studentsListView.Columns[3].Width = 130;
        }

        public event AddDataDelegate AddDataEvent;
        public event DeleteDataDelegate DeleteDataEvent;

        public void RedrawForm(IEnumerable<IEnumerable<object>> students)
        {
            studentsListView.Items.Clear();
            int k = 1;
            foreach (var student in students)
            {
                List<object> studentData = new List<object>(student);
                ListViewItem studentItem = new ListViewItem(k.ToString());
                studentItem.SubItems.Add(studentData[0].ToString());
                studentItem.SubItems.Add(studentData[1].ToString());
                studentItem.SubItems.Add(studentData[2].ToString());
                studentsListView.Items.Add(studentItem);
                k++;
            }
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            List<object> newStudent = new List<object>()
            {
                nameTextBox.Text,
                specialtyTextBox.Text,
                groupTextBox.Text
            };
            AddDataEvent?.Invoke(newStudent);
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            int index = studentsListView.SelectedItems[0].Index;
            DeleteDataEvent?.Invoke(index);
        }
    }
}

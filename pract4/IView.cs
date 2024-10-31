using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract4
{
    public delegate void AddDataDelegate(List<object> newStudent);
    public delegate void DeleteDataDelegate(int index);
    public interface IView
    {
        event AddDataDelegate AddDataEvent;
        event DeleteDataDelegate DeleteDataEvent;

        void RedrawForm(IEnumerable<IEnumerable<object>> students);
    }
}

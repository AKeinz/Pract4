using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public delegate void DataChangedDelegate(IEnumerable<IEnumerable<object>> students);
    public interface IModel<T>
    {
        event DataChangedDelegate DataChanged;
        void Delete(int index);
        void Insert(T item);
        void InvokeDataChanged();
    }
}

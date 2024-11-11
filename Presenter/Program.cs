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
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentView view = new StudentView();
            new StudentPresenter(view, new BusinessLogic());
            Application.Run(view);
            
        }
    }
}

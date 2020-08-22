using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Wpf1
{
    class MainCommand
    {
        private Action execute;

        public MainCommand(Action execute)
        {
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object p)
        {
            return true;
        }

        public void Execute(object p)
        {
            execute.Invoke();
        }
    }
}

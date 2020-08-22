using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Subject : ISubject
    {
        private List<IObserver> Observers = new List<IObserver>();

        public void Attach(IObserver observerObject)
        {
            Observers.Add(observerObject);
        }

        public void Notify()
        {
            foreach (IObserver index in Observers)
            {
                index.Update();
            }
        }
    }
}

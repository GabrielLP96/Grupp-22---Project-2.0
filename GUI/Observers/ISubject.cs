namespace GUI
{
    interface ISubject
    {
        void Attach(IObserver observerObject);
        void Notify();
    }
}
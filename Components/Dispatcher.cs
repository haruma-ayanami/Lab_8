using Lab8_PrintSystem.Mediator;
using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem.Components
{
    public class Dispatcher : Colleague
    {
        public void AddDocument(Document document)
        {
            document.SetMediator(Mediator);
            document.AddToQueue();
        }

        public void CommandProcessQueue()
        {
            Mediator.Notify(this, "ProcessQueue");
        }
    }
}
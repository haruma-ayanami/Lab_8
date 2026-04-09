using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem.Mediator
{
    public interface IMediator
    {
        void Notify(Colleague sender, string ev, Document document = null);
    }
}
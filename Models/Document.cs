using System;
using Lab8_PrintSystem.Mediator;
using Lab8_PrintSystem.States;

namespace Lab8_PrintSystem.Models
{
    public class Document : Colleague
    {
        public string Title { get; }
        private IDocumentState State { get; set; }

        public Document(string title)
        {
            Title = title;
            State = new NewState();
        }

        public void SetState(IDocumentState state)
        {
            State = state;
        }

        public void Print() => State.Print(this);
        public void AddToQueue() => State.AddToQueue(this);
        public void CompletePrinting() => State.CompletePrinting(this);
        public void FailPrinting() => State.FailPrinting(this);
        public void Reset() => State.Reset(this);

        public string GetStateName()
        {
            return State.GetType().Name.Replace("State", "");
        }

        public void MediatorNotify(string ev, Document document = null)
        {
            if (Mediator == null)
            {
                Console.WriteLine("[Document] Посредник не установлен.");
                return;
            }

            Mediator.Notify(this, ev, document);
        }
    }
}
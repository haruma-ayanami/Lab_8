using System;
using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem.States
{
    public class DoneState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Done] Документ '{document.Title}' уже напечатан.");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: Done] Документ '{document.Title}' уже в финальном состоянии и не может быть добавлен повторно.");
        }

        public void CompletePrinting(Document document)
        {
            Console.WriteLine("[FSM: Done] Печать уже завершена.");
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine("[FSM: Done] Нельзя перевести напечатанный документ в состояние ошибки.");
        }

        public void Reset(Document document)
        {
            Console.WriteLine("[FSM: Done] Финальное состояние. Сброс не предусмотрен.");
        }
    }
}
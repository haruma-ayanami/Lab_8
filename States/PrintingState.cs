using System;
using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem.States
{
    public class PrintingState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Printing] Документ '{document.Title}' уже печатается.");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: Printing] Нельзя повторно добавить '{document.Title}' в очередь.");
        }

        public void CompletePrinting(Document document)
        {
            document.SetState(new DoneState());
            Console.WriteLine($"[FSM: Printing -> Done] Документ '{document.Title}' успешно напечатан.");
        }

        public void FailPrinting(Document document)
        {
            document.SetState(new ErrorState());
            Console.WriteLine($"[FSM: Printing -> Error] Во время печати '{document.Title}' произошла ошибка.");
        }

        public void Reset(Document document)
        {
            Console.WriteLine("[FSM: Printing] Нельзя сбросить документ во время печати.");
        }
    }
}
using System;
using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem.States
{
    public class ErrorState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Error] Печать '{document.Title}' невозможна. Сначала выполните Reset.");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: Error] Нельзя добавить '{document.Title}' в очередь из состояния ошибки. Сначала Reset.");
        }

        public void CompletePrinting(Document document)
        {
            Console.WriteLine("[FSM: Error] Ошибка не устранена.");
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine("[FSM: Error] Документ уже находится в состоянии ошибки.");
        }

        public void Reset(Document document)
        {
            document.SetState(new NewState());
            Console.WriteLine($"[FSM: Error -> New] Документ '{document.Title}' сброшен и снова готов к печати.");
        }
    }
}
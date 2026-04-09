using System;
using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem.States
{
    public class NewState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: New] Документ '{document.Title}' готов к печати.");
            document.MediatorNotify("RequestPrint", document);
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: New] Документ '{document.Title}' отправляется в очередь.");
            document.MediatorNotify("AddToQueue", document);
        }

        public void CompletePrinting(Document document)
        {
            Console.WriteLine("[FSM: New] Нельзя завершить печать: печать еще не начиналась.");
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine("[FSM: New] Нельзя зафиксировать ошибку: печать еще не начиналась.");
        }

        public void Reset(Document document)
        {
            Console.WriteLine("[FSM: New] Документ уже находится в исходном состоянии.");
        }
    }
}
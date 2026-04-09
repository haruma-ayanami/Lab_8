using System;
using Lab8_PrintSystem.Mediator;
using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem.Components
{
    public class Printer : Colleague
    {
        public bool SimulateFailure { get; set; }

        public void StartPrint(Document document)
        {
            Console.WriteLine($"[Принтер] Физическая печать документа '{document.Title}'...");

            if (SimulateFailure)
            {
                SimulateFailure = false;
                Mediator.Notify(this, "PrintFailed", document);
            }
            else
            {
                Mediator.Notify(this, "PrintSuccess", document);
            }
        }
    }
}
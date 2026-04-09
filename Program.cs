using System;
using Lab8_PrintSystem.Components;
using Lab8_PrintSystem.Mediator;
using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var printer = new Printer();
            var queue = new PrintQueue();
            var logger = new Logger();
            var dispatcher = new Dispatcher();

            var mediator = new PrintSystemMediator(printer, queue, logger, dispatcher);

            var doc1 = new Document("Отчет_2026");
            var doc2 = new Document("Диплом");
            var doc3 = new Document("Заявление");

            Console.WriteLine("=== ДОБАВЛЕНИЕ ДОКУМЕНТОВ В ОЧЕРЕДЬ ===");

            dispatcher.AddDocument(doc1);
            dispatcher.AddDocument(doc2);
            dispatcher.AddDocument(doc3);

            Console.WriteLine();

            Console.WriteLine("=== СЦЕНАРИЙ 1: УСПЕШНАЯ ПЕЧАТЬ ===");

            dispatcher.CommandProcessQueue();

            Console.WriteLine();

            Console.WriteLine("=== СЦЕНАРИЙ 2: ОШИБКА ПРИНТЕРА И ВОССТАНОВЛЕНИЕ ===");

            printer.SimulateFailure = true;
            dispatcher.CommandProcessQueue();

            Console.WriteLine();
            Console.WriteLine("Повторная подготовка документа после ошибки...");
            doc2.Reset();

            Console.WriteLine("Повторное добавление документа в очередь...");
            dispatcher.AddDocument(doc2);

            Console.WriteLine("Повторная печать документа...");
            dispatcher.CommandProcessQueue();
            dispatcher.CommandProcessQueue();

            Console.WriteLine();

            Console.WriteLine("=== СЦЕНАРИЙ 3: ПРОВЕРКА ФИНАЛЬНОГО СОСТОЯНИЯ ===");

            Console.WriteLine($"Документ '{doc1.Title}' -> состояние: {doc1.GetStateName()}");
            Console.WriteLine($"Документ '{doc2.Title}' -> состояние: {doc2.GetStateName()}");
            Console.WriteLine($"Документ '{doc3.Title}' -> состояние: {doc3.GetStateName()}");

            Console.WriteLine();
            Console.WriteLine("Попытка повторно добавить напечатанный документ:");
            doc1.SetMediator(mediator);
            doc1.AddToQueue();

            Console.WriteLine();
            Console.WriteLine("Попытка напечатать уже напечатанный документ:");
            doc1.Print();

            Console.WriteLine();
            Console.WriteLine("=== РАБОТА ЗАВЕРШЕНА ===");
        }
    }
}
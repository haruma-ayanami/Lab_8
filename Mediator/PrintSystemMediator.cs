using Lab8_PrintSystem.Components;
using Lab8_PrintSystem.Models;
using Lab8_PrintSystem.States;

namespace Lab8_PrintSystem.Mediator
{
    public class PrintSystemMediator : IMediator
    {
        private readonly Printer _printer;
        private readonly PrintQueue _queue;
        private readonly Logger _logger;
        private readonly Dispatcher _dispatcher;

        public PrintSystemMediator(
            Printer printer,
            PrintQueue queue,
            Logger logger,
            Dispatcher dispatcher)
        {
            _printer = printer;
            _queue = queue;
            _logger = logger;
            _dispatcher = dispatcher;

            _printer.SetMediator(this);
            _queue.SetMediator(this);
            _logger.SetMediator(this);
            _dispatcher.SetMediator(this);
        }

        public void Notify(Colleague sender, string ev, Document document = null)
        {
            switch (ev)
            {
                case "AddToQueue":
                    _queue.EnqueueItem(document);
                    break;

                case "Enqueued":
                    _logger.WriteMessage($"Документ '{document.Title}' помещен в очередь.");
                    break;

                case "RequestPrint":
                    document.SetState(new PrintingState());
                    _logger.WriteMessage($"Начата печать документа '{document.Title}'.");
                    _printer.StartPrint(document);
                    break;

                case "ProcessQueue":
                    if (_queue.IsEmpty)
                    {
                        _logger.WriteMessage("Очередь пуста.");
                        return;
                    }

                    var nextDoc = _queue.DequeueItem();
                    nextDoc.SetMediator(this);
                    _logger.WriteMessage($"Из очереди извлечен документ '{nextDoc.Title}'.");
                    nextDoc.Print();
                    break;

                case "PrintSuccess":
                    document.CompletePrinting();
                    _logger.WriteMessage($"Успешно напечатан документ '{document.Title}'.");
                    break;

                case "PrintFailed":
                    document.FailPrinting();
                    _logger.WriteMessage($"ОШИБКА печати документа '{document.Title}'.");
                    break;

                default:
                    _logger.WriteMessage($"Неизвестное событие: {ev}");
                    break;
            }
        }
    }
}
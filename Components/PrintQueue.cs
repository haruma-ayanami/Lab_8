using System.Collections.Generic;
using Lab8_PrintSystem.Mediator;
using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem.Components
{
    public class PrintQueue : Colleague
    {
        private readonly Queue<Document> _documents = new Queue<Document>();

        public void EnqueueItem(Document document)
        {
            _documents.Enqueue(document);
            Mediator.Notify(this, "Enqueued", document);
        }

        public Document DequeueItem()
        {
            return _documents.Dequeue();
        }

        public bool IsEmpty => _documents.Count == 0;

        public int Count => _documents.Count;
    }
}
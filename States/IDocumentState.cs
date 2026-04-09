using Lab8_PrintSystem.Models;

namespace Lab8_PrintSystem.States
{
    public interface IDocumentState
    {
        void Print(Document document);
        void AddToQueue(Document document);
        void CompletePrinting(Document document);
        void FailPrinting(Document document);
        void Reset(Document document);
    }
}
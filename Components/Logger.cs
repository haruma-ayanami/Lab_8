using System;
using Lab8_PrintSystem.Mediator;

namespace Lab8_PrintSystem.Components
{
    public class Logger : Colleague
    {
        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[LOG] {message}");
            Console.ResetColor();
        }
    }
}
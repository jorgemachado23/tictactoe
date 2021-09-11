using System;
using TictactToe.Domain.Interfaces;

namespace Presentation
{
    /// <summary>
    /// This is just a Wrapper so we can verify and test this behavior
    /// </summary>
    public class CustomConsole : IConsole
    {
        public void Print(string format, params object[] args)
        {
            Write(format, args);
        }

        public void PrintLine(string format, params object[] args)
        {
            WriteLine(format, args);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string ReadLine => Console.ReadLine()!;

        private static void Write(string format, params object[] args) => Console.Write(format, args);

        private static void WriteLine(string format, params object[] args) => Console.WriteLine(format, args);

    }
}

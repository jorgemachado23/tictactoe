namespace TictactToe.Domain.Interfaces
{
    public interface IConsole
    {
        void Print(string format, params object[] args);
        void PrintLine(string format, params object[] args);
        void Clear();
        string ReadLine { get; }
    }
}

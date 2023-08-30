using ClassLib;

namespace MutexMechanism;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Without Lock statement result: {WithoutLockMechanism.Execute()}");
        Console.WriteLine($"Lock statement result: {MutexMechanism.Execute()}");
    }
}

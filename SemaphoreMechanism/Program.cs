using ClassLib;

namespace SemaphoreMechanism;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Without Lock statement result: {WithoutLockMechanism.Execute()}");
        Console.WriteLine($"Semaphore Execution result: {SemaphoreMechanism.Execute()}");
    }
}

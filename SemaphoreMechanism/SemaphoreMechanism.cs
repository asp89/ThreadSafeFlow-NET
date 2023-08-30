
namespace SemaphoreMechanism;

public class SemaphoreMechanism
{
    private static int _counter = 0;
    private static readonly int countLimit = 100000;
    private static Semaphore _semaphore = new Semaphore(1, 1); // Only one thread can enter at a time

    public static int Execute()
    {
        Task[] tasks = new Task[3];

        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() => IncrementCounter());
        }

        Task.WaitAll(tasks);
        return _counter;
    }

    private static void IncrementCounter()
    {
        _semaphore.WaitOne(); // Wait until the semaphore is available
        try
        {
            for (int cnt = 0; cnt < countLimit; cnt++)
                _counter++;
        }
        finally
        {
            _semaphore.Release(); // Release the semaphore
        }
    }

}
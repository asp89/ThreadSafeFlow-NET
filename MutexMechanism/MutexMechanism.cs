
namespace MutexMechanism;

public class MutexMechanism
{
    private static int _counter = 0;
    private static readonly int countLimit = 100000;
    private static Mutex mutex = new();

    public static int Execute()
    {
        Task[] tasks = new Task[3];

        for (int i = 0; i < tasks.Length; i++)
            tasks[i] = Task.Run(() => IncrementCounter());

        Task.WaitAll(tasks);
        return _counter;
    }

    private static void IncrementCounter()
    {
        try
        {
            if (mutex.WaitOne(1000))
            {
                for (int i = 0; i < countLimit; i++)
                    _counter++;
            }
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
}

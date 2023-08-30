namespace LockMechanism;

public static class LockStatement
{
    private static int _counter = 0;
    private static readonly int countLimit = 100000;
    private static readonly object _lockObject = new object();

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
        lock (_lockObject)
        {
            for (int cnt = 0; cnt < countLimit; cnt++)
                _counter++;
        }
    }
}

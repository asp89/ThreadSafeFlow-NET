namespace ClassLib;

public class WithoutLockMechanism
{
    private static int _counter = 0;
    private static readonly int countLimit = 100000;

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
        for (int cnt = 0; cnt < countLimit; cnt++)
            _counter++;
    }
}



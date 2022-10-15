using ThreadPoolApp;
var workerThreads = 100;
var asyncThreadMax = 1000;

ThreadPool.SetMaxThreads(workerThreads,  asyncThreadMax);
var messages = Enumerable.Range(1, 1000).Select(i => $"ind: {i}");
using var customThread = new MythreadPools(50);
    foreach (var message in messages)
    {
        customThread.start(message);
    }

    Console.ReadLine();

Console.ReadLine();
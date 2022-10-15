using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolApp
{
    public class MythreadPools : IDisposable
    {
        private readonly ConcurrentBag<Thread> _threads;
        private static readonly Semaphore threadOgran = new Semaphore(1, 1);
        private static readonly Queue<string> Queue = new();
        private static volatile bool _canWork = true;

        public MythreadPools(int threadCount)
        {
            
            _threads = new ConcurrentBag<Thread>();
            for (int i = 0; i < threadCount; i++)
            {

                var thread = Initialize();
                //checked
                //var workerThreads = 0;
                //var asyncThreadMax = 0;

                //ThreadPool.GetAvailableThreads(out workerThreads,out asyncThreadMax);
                _threads.Add(thread);
            }
        }

        private Thread Initialize()
        {
            var thread = new Thread(createThread)
            {
                Name = $"Thread_{Environment.CurrentManagedThreadId}",
                IsBackground = true,
                Priority = ThreadPriority.Normal,
                
            };

            thread.Start();

            return thread;
        }

        private static void createThread()
        {
            Console.WriteLine($"Поток {Environment.CurrentManagedThreadId} запущен");
            try
            {
                while (_canWork)
                {
                    try
                    {
                        threadOgran.WaitOne();
                        if (!_canWork)
                            break;
                        var timer = Stopwatch.StartNew();
                        Debug.WriteLine($"wait: {Environment.CurrentManagedThreadId}");
                        if (Queue.Count > 0)
                        {
                            Thread.Sleep(1000);
                            Queue.Dequeue();

                        }
                        timer.Stop();
                        Debug.WriteLine($"Поток {Environment.CurrentManagedThreadId} завершился  {timer.ElapsedMilliseconds}");
                    }
                    finally
                    {
                        threadOgran.Release();
                    }
                  
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void start(string message)
        {
            Queue.Enqueue(message);
        }

        public void Dispose()
        {
            _canWork = false;
            try
            {
                foreach (var thread in _threads.Where(thread => !thread.Join(1000)))
                {
                    thread?.Interrupt(); //Вызывает исключение в потоке
                }
            }
            finally 
            {
                Console.WriteLine("Пул потоков завершен");
                threadOgran?.Dispose(); 
            }
        }
    }
}
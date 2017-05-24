using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwaitConsole
{
    class Program
    {
        static void Main()
        {
            var task = SlowOperationAsync();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            // If task hasnt completed .Result, will block program until it completes.
            Console.WriteLine($"Slow operation result {task.Result}");
            Console.WriteLine($"Main completed on thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        /// <summary>
        /// An example Async method, of type Task, as Async always return
        /// a type of Task
        /// </summary>
        /// <returns></returns>
        private static async Task<int> SlowOperationAsync()
        {
            Console.WriteLine($"Slow operation started on: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(3000);
            Console.WriteLine($"Slow operation completed on: {Thread.CurrentThread.ManagedThreadId}");
            return 42;
        }
    }
}

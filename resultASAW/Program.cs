using System;
using System.Threading;
using System.Threading.Tasks;

namespace resultASAW
{
    class Program
    {
        static void Main(string[] args)
        {
            //Result Task<TResult>
            //GeTResult() => TaskAwaiter<TResult>
            //await

            int syncResult = Addition("Синхронно", 1537, 256);
     
            int asyncResult = AdditionAsync("acинхронно", 1537, 256).Result;

            Console.WriteLine($"Результат синхронных вычислений: {syncResult}");
            Console.WriteLine($"Результат асинхронных вычислений: {asyncResult}");

        }

        private static int Addition(string mask, int a, int b)
        {
            Console.WriteLine($"Метод вызван в {mask} режиме, в потоке {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1500);
            return a + b;
        }

        private static async Task<int> AdditionAsync(string mask, int a, int b)
        {
            return await Task.Run(() => Addition(mask, a, b));
        }
    }
}

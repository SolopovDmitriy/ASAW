using System;
using System.Collections.Concurrent;

namespace Concurrentcollectionexample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ConcurrentQueue<int> ts = new ConcurrentQueue<int>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                ts.Enqueue(random.Next(0, 10));
            }
            Console.WriteLine($"количество элементов: {ts.Count}");
            foreach (var item in ts)
            {
                Console.WriteLine(item);
            }

            bool successPeek = ts.TryPeek(out int peekResult);                      //попытка вернуть первый элемент без его удаления
            bool successDequeue = ts.TryDequeue(out int dequeueResult);              //попытка вернуть первый элемент c удалением из коллекции
            Console.WriteLine($"Получили результат: Статус - {successPeek}; Результат - {peekResult}");
            Console.WriteLine($"Получили результат: Статус - {successDequeue}; Результат - {dequeueResult}");
            Console.WriteLine($"количество элементов: {ts.Count}");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            */

            Random random = new Random();
            ConcurrentStack<int> vs = new ConcurrentStack<int>();
            for (int i = 0; i < 10; i++)
            {
                vs.Push(random.Next(0, 10));
            }
            Console.WriteLine($"количество элементов: {vs.Count}");
            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }
            bool successPeek = vs.TryPeek(out int peekResult);                      //попытка вернуть первый элемент без его удаления
            bool successDequeue = vs.TryPop(out int dequeueResult);                 //попытка вернуть первый элемент c удалением из коллекции
            Console.WriteLine($"Получили результат: Статус - {successPeek}; Результат - {peekResult}");
            Console.WriteLine($"Получили результат: Статус - {successDequeue}; Результат - {dequeueResult}");
            Console.WriteLine($"количество элементов: {vs.Count}");
        }
    }
}

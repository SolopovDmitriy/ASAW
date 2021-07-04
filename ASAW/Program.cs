using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ASAW
{
    class Program
    {

        static async void ReadWriteAsync()
        {
            string s = "Hello world! One step at a time";
            // hello.txt - файл, который будет записываться и считываться
            using (StreamWriter writer = new StreamWriter("hello.txt", false))
            {
                Console.WriteLine($"Запуск WriteLineAsync. поток: {Thread.CurrentThread.ManagedThreadId }");
                await writer.WriteLineAsync(s);  // асинхронная запись в файл
                Console.WriteLine($"Запуск WriteLineAsync поток: {Thread.CurrentThread.ManagedThreadId }");
            }
            using (StreamReader reader = new StreamReader("hello.txt"))
            {
                Console.WriteLine($"Запуск ReadToEndAsync. поток: {Thread.CurrentThread.ManagedThreadId }");
                string result = await reader.ReadToEndAsync();  // асинхронное чтение из файла
                Console.WriteLine(result);
                Console.WriteLine($"Запуск ReadToEndAsync. поток: {Thread.CurrentThread.ManagedThreadId }");
            }
        }


        //static void Main(string[] args)
        //{
        //    // ReadWriteAsync();
        //    Parallel();
        //    Console.WriteLine("Некоторая работа");
        //    Console.Read();
        //}




        static async Task Parallel()
        {
            Console.WriteLine($"before : {Thread.CurrentThread.ManagedThreadId }");
            Task t1 = Task.Run(() => WriteChar('*'));
            Task t2 = Task.Run(() => WriteChar('$'));
            Task t3 = Task.Run(() => WriteChar('_'));
            await Task.WhenAll(new[] { t1, t2, t3 });
            Console.WriteLine($"after {Thread.CurrentThread.ManagedThreadId }");
        }


        static async Task Inseries()
        {
            Console.WriteLine($"before : {Thread.CurrentThread.ManagedThreadId }");
            await Task.Run(() => WriteChar('*'));
            await Task.Run(() => WriteChar('$'));
            await Task.Run(() => WriteChar('_'));

            //lock (plates)
            //{
            //    take(plate)
            //}
            //wash(plate)

            Console.WriteLine($"after {Thread.CurrentThread.ManagedThreadId }");
        }





        static async Task Main(string[] args)
        {
            //async
            //await
            await Parallel();




            //Console.WriteLine($"Запуск основного потока: {Thread.CurrentThread.ManagedThreadId }");
            /////WriteCharAsync('#'); //запуск метода в аснх режиме...
            //await WriteCharAsync('#'); //запуск метода в аснх режиме...
            //await WriteCharAsync('2'); //запуск метода в аснх режиме...
            //Console.WriteLine($"after WriteCharAsync: {Thread.CurrentThread.ManagedThreadId }");
            //WriteChar('*');      //запуск метода синхронно...
            //Console.WriteLine($"after WriteChar: {Thread.CurrentThread.ManagedThreadId }");
        }



        private static async Task WriteCharAsync(char symbol)
        {
            Console.WriteLine($"WriteCharAsync запущен в потоке: {Thread.CurrentThread.ManagedThreadId }");
            await Task.Run(() => { WriteChar(symbol);});
            Console.WriteLine($"WriteCharAsync выполнил свою заботу в потоке: {Thread.CurrentThread.ManagedThreadId }");


        }


        //void Function1 ()  { 
        //    WriteChar('*');
        //}



    private static void WriteChar(char symbol)
        {
            Console.WriteLine($"ID потока: {Thread.CurrentThread.ManagedThreadId }, ID Task {Task.CurrentId} ");
            for (int i = 0; i < 50; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
    }
}

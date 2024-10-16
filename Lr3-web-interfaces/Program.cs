using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        // Демонстрація роботи з Thread
        Thread thread1 = new Thread(Method1);
        thread1.Start();

        // Асинхронні виклики з await
        Task task2 = Method2Async();
        Task task3 = Method3Async();

        // Очікуємо завершення всіх завдань
        Task.WaitAll(task2, task3);

        Console.WriteLine("Main метод завершено.");
    }

    // Метод, що працює у звичайному потоці за допомогою класу Thread
    static void Method1()
    {
        Console.WriteLine($"Method 1 початок роботи у потоці {Thread.CurrentThread.ManagedThreadId}");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Method 1 виконується: {i + 1}");
            Thread.Sleep(500); // Симуляція довгого виконання
        }
        Console.WriteLine($"Method 1 завершено у потоці {Thread.CurrentThread.ManagedThreadId}");
    }

    // Асинхронний метод з використанням async-await
    static async Task Method2Async()
    {
        Console.WriteLine($"Method 2 початок роботи у потоці {Thread.CurrentThread.ManagedThreadId}");
        await Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Method 2 виконується: {i + 1}");
                Thread.Sleep(300); // Симуляція довгого виконання
            }
        });
        Console.WriteLine($"Method 2 завершено у потоці {Thread.CurrentThread.ManagedThreadId}");
    }

    //  асинхронний метод з Task і await
    static async Task Method3Async()
    {
        Console.WriteLine($"Method 3 початок роботи у потоці {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(1000); // Затримка як симуляція довгої операції
        Console.WriteLine($"Method 3 завершено у потоці {Thread.CurrentThread.ManagedThreadId}");
    }
}

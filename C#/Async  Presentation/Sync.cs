using AsyncPresentation;
using System.Diagnostics;

class Sync
{
    static async Task Main(string[] args)
    {
        Maid maid1 = new("Felix", new("cleaning dishes", 750));
        Maid maid2 = new("Janus", new("vacuumming the carpet", 500));
        Maid maid3 = new("Cheryll", new("puttting clothes in the washer", 300));
        Maid maid4 = new("Amy", new("feeding the dog", 400));
        Maid maid5 = new("Jarin", new("preparing dinner", 1000));
        Stopwatch timer = Stopwatch.StartNew();

        Console.WriteLine(PerformTask(maid1, timer));
        Console.WriteLine(PerformTask(maid2, timer));
        Console.WriteLine(PerformTask(maid3, timer));
        Console.WriteLine(PerformTask(maid4, timer));
        Console.WriteLine(PerformTask(maid5, timer));

        Console.WriteLine($"The maids cleaned the house in {timer.ElapsedMilliseconds / 1000f:0.00} seconds\n");
        Console.WriteLine("Press F7 to continue...\n");
        while (Console.ReadKey().Key != ConsoleKey.F7) { }

        timer.Restart();

        List<Task<string>> tasks = new()
        {
            PerformTaskAsync(maid1, timer),
            PerformTaskAsync(maid2, timer),
            PerformTaskAsync(maid3, timer),
            PerformTaskAsync(maid4, timer),
            PerformTaskAsync(maid5, timer)
        };

        while (tasks.Count > 0)
        {
            var finished_task = await Task.WhenAny(tasks);

            if (tasks.Contains(finished_task))
            {
                Console.WriteLine(tasks.Find(x => x == finished_task).Result);
                tasks.Remove(finished_task);
            }
        }
        Console.WriteLine($"The maids cleaned the house in {timer.ElapsedMilliseconds / 1000f:0.00} seconds");
        timer.Stop();
    }

    static string PerformTask(Maid maid, Stopwatch timer)
    {
        Task.Delay(maid.Task.Time).Wait();
        Console.WriteLine($"{maid.Name} finished their task at {timer.ElapsedMilliseconds / 1000f:0.00}");
        return maid.ToString();
    }

    static async Task<string> PerformTaskAsync(Maid maid, Stopwatch timer)
    {
        await Task.Delay(maid.Task.Time);
        Console.WriteLine($"{maid.Name} finished their task at {timer.ElapsedMilliseconds / 1000f:0.00}");
        return maid.ToString();
    }
}
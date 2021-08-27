using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DinnerPhilosophers
{
    class Program
    {
        // we have 5 philosophers, in this function I put them at the table and handed out rice sticks
        public static List<Philosophers> DecomposeStick()
        {
            List<Philosophers> philosophers = new List<Philosophers>()
            {
            new Philosophers(),
            new Philosophers(),
            new Philosophers(),
            new Philosophers(),
            new Philosophers()
            };

            philosophers[0].Right = new Stick();
            philosophers[0].Left = new Stick();
            philosophers[0].Name = "philosop 0";
            for (int i = 1; i < philosophers.Count - 1; i++)
            {
                philosophers[i].Left = philosophers[i - 1].Right;
                philosophers[i].Right = new Stick();
                philosophers[i].Name = $"philosop {i}";
            }
            philosophers[philosophers.Count - 1].Left = philosophers[philosophers.Count - 2].Right;
            philosophers[philosophers.Count - 1].Right = philosophers[0].Left;
            philosophers[philosophers.Count - 1].Name = "philosop 4";

            return philosophers;
        }

        public static async void StartAsync(CancellationToken token, List<Philosophers> philosophers)
        {
            Task t1 = Task.Run(() => philosophers[0].Eatting(token));
            Task t2 = Task.Run(() => philosophers[1].Eatting(token));
            Task t3 = Task.Run(() => philosophers[2].Eatting(token));
            Task t4 = Task.Run(() => philosophers[3].Eatting(token));
            Task t5 = Task.Run(() => philosophers[4].Eatting(token));

            await Task.WhenAll(new[] { t1, t2, t3, t4, t5 });
        }

        static void Main(string[] args)
        {
            var cancelTokenSource = new CancellationTokenSource();
            var cancelToken = cancelTokenSource.Token;
            var philosophers = DecomposeStick();

            StartAsync(cancelToken, philosophers);

            Console.ReadKey();

            cancelTokenSource.Cancel();

            Thread.Sleep(2000);
            Console.WriteLine("______________________");
            foreach (var i in philosophers)
            {
                Console.WriteLine($"{i.Name}, ate {i.Ate} times");
            }

            Console.ReadKey();
        }
    }
}
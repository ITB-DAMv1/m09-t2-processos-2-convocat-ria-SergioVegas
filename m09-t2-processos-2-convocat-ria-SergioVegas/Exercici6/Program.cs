using System.Diagnostics;

namespace Exercici6
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            BakeSequential();
            await BakeParalel();
        }
        public static void BakeSequential()
        {
            var sw = Stopwatch.StartNew();
            MixDough();
            PreheatOven();
            Bake();
            Cool();
            PrepareGanache();
            Glaze();
            Decorate();
            sw.Stop();
            Console.WriteLine($"Temps total (Seqüencial): {sw.Elapsed.TotalSeconds}s");
        }
        public static async Task BakeParalel()
        {
            var sw = Stopwatch.StartNew();

            var mixing = Task.Run(MixDoughP);
            var preheat = Task.Run(PreheatOvenP);
            
            await Task.WhenAll(mixing, preheat);

            var bake = Task.Run(BakeP);
            var prepareGanache = Task.Run(PrepareGanacheP);

            await bake;

            var cool = Task.Run(CoolP);

            await Task.WhenAll(cool, prepareGanache);

            var glaze = Task.Run(GlazeP);

            await glaze;

            var decorate = Task.Run(DecorateP);


            Console.WriteLine($"Temps total (Paral·lel): {sw.Elapsed.TotalSeconds}s");
        }
        //Sequencial
        public static void MixDough() => Task.Delay(8000).Wait();
        public static void PreheatOven() => Task.Delay(10000).Wait();
        public static void Bake() => Task.Delay(15000).Wait();
        public static  void PrepareGanache() => Task.Delay(5000).Wait();
        public static void Cool() => Task.Delay(4000).Wait();
        public static void Glaze() => Task.Delay(3000).Wait();
        public static void Decorate() => Task.Delay(2000).Wait();
        //Paral·lel
        public static async Task MixDoughP() => await Task.Delay(8000);
        public static async Task PreheatOvenP() => await Task.Delay(10000);
        public static async Task BakeP() => await Task.Delay(15000);
        public static async Task PrepareGanacheP() => await Task.Delay(5000);
        public static async Task CoolP() => await Task.Delay(4000);
        public static async Task GlazeP() => await Task.Delay(3000);
        public static async Task DecorateP() => await Task.Delay(2000);
    }
}

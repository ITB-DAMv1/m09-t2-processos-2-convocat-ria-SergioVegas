namespace Exercici5
{
    public class Program
    {
        static void Main(string[] args)
        {
            /* Apartat a)
             
            int initialBaterry = 100000;
            Batery newBattery = new Batery(initialBaterry);
            var threads = new List<Thread>();
            List<Device> devices = new List<Device> {
                new Device { Id = 0, Capacity = 30000, ConsumtionSeconds = 10000 },
                new Device { Id = 1, Capacity = 20000, ConsumtionSeconds = 12000 },
                new Device { Id = 2, Capacity = 5000, ConsumtionSeconds = 1000 }
                };
            foreach (var device in devices)
            {
                var thread = new Thread(() => device.Recharge(newBattery));
                threads.Add(thread);
            }
            threads.ForEach(t=>t.Start());
            threads.ForEach(t=>t.Join());
            Console.WriteLine($"\nEscenari (bateria {initialBaterry} mAh)");
            foreach (var d in devices)
                Console.WriteLine($"Device {d.Id}: càrregues = {d.ChargesCompleted}, temps = {d.ElapsedTime}");*/
            // Apartat b)

            int initialBaterry = 100000;
            Batery newBattery = new Batery(initialBaterry);
            var threads = new List<Thread>();
            List<Device> devices = new List<Device> {
                new Device (1,25000,23000),
                new Device (2,20000,12000),
                new Device (3,8000,1000),
                new Device (4,10000,1000)
                };
            foreach (var device in devices)
            {
                var thread = new Thread(() => device.Recharge(newBattery));
                threads.Add(thread);
            }
            threads.ForEach(t => t.Start());
            threads.ForEach(t => t.Join());
            Console.WriteLine($"\nEscenari (bateria {initialBaterry} mAh)");
            foreach (var d in devices)
                Console.WriteLine($"Device {d.Id}: càrregues = {d.ChargesCompleted}, temps = {d.ElapsedTime}");
        }
    }
}

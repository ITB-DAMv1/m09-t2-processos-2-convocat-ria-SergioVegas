using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercici5
{
    public class Device
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int ConsumtionSeconds { get; set; }
        public int ChargesCompleted { get; private set; }
        public TimeSpan ElapsedTime { get; private set; }

        public Device() { }
        public Device(int id, int capacity, int consumtionseconds)
        {
            Id = id;
            Capacity = capacity;
            ConsumtionSeconds = consumtionseconds;
        }

        public void Recharge(Batery battery)
        {
            var sw = Stopwatch.StartNew();

            bool batteryAvailable = true;

            while (batteryAvailable)
            {
                // Intentar consumir la carga completa del dispositiu
                if (!battery.TryConsum(Capacity))
                {
                    batteryAvailable = false;
                    break;
                }

                ChargesCompleted++;

                // Calcular temps en ms segons N mAh y X mAh/s
                int msDelay = (int)Math.Ceiling((double)Capacity / ConsumtionSeconds) * 1000;
                Console.WriteLine($"Device {Id}: Carrega completada");
                Thread.Sleep(msDelay);
            }
            sw.Stop();
            ElapsedTime = sw.Elapsed;
        }
    }
}

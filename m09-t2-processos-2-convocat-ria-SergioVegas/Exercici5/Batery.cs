using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercici5
{
    public class Batery
    {
        public int Capacity { get; set; }
        private readonly object _locker = new object();

        public Batery(int capacity) { Capacity = capacity; }
        public bool TryConsum(int amount)
        {
            lock (_locker)
            {
                if (amount > Capacity) return false;
                else
                {
                    Capacity -= amount;
                    return true;
                }
            }
            
        }

    }
}

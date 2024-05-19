using System.Collections.Generic;
using System.Linq;

namespace d06.Models
{
    public class Store
    {
        public List<Register> Registers { get; }
        public Storage Storage { get; }

        public bool IsOpen => !Storage.IsEmpty;

        public Store(int registerCount,
            int storageCapacity, int registerSwitchDelayInSeconds, int registerProductScanInSeconds)
        {
            Storage = new Storage(storageCapacity);
            Registers = Enumerable.Range(1, registerCount)
                .Select(i => new Register(i, registerProductScanInSeconds, registerSwitchDelayInSeconds))
                .ToList();
        }
    }
}
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace d06.Models
{
    public class Register
    {
        public int No { get; }
        public ConcurrentQueue<Customer> QueuedCustomers { get; }
        private readonly float _timePerItem;
        private readonly float _timePerCustomer;
        public TimeSpan TotalBusyTime { get; private set; } = TimeSpan.Zero;
        public int servedCustomersCount;
        
        public Register(int number, float productScanInSeconds, float switchDelayInSeconds)
        {
            No = number;
            QueuedCustomers = new ConcurrentQueue<Customer>();
            _timePerItem = productScanInSeconds;
            _timePerCustomer = switchDelayInSeconds;
        }

        public void Process()
        {
            if (QueuedCustomers.TryDequeue(out var customer))
            {
                var random = new Random();
                var itemsDuration = 0.0f;
                for (int i = 0; i < customer.ItemsInCart; i++)
                {
                    itemsDuration += random.Next(10, (int)(_timePerItem * 10)) / 10.0f;
                }
                var amountDuration = TimeSpan.FromSeconds(itemsDuration + random.Next(10, (int)_timePerCustomer * 10) / 10.0f);
                Thread.Sleep(amountDuration);
                TotalBusyTime = TotalBusyTime.Add(amountDuration);
                servedCustomersCount++;
            }
            else
            {
                Console.WriteLine($"Register#{No} has no customers in line");
            }
        }
        
        public override string ToString()
            => $"Register#{No} ({QueuedCustomers.Count} customers in line)";
    }
}
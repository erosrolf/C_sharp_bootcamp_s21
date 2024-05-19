using System;
using System.Collections.Generic;

namespace d06.Models
{
    public class Register
    {
        public int No { get; }
        public Queue<Customer> QueuedCustomers { get; }
        public TimeSpan ProductScanDuration { get; }
        public TimeSpan CustomerSwitchDelay { get; }
        
        public Register(int number, int productScanInSeconds, int switchDelayInSeconds)
        {
            No = number;
            QueuedCustomers = new Queue<Customer>();
            ProductScanDuration = TimeSpan.FromSeconds(productScanInSeconds);
            CustomerSwitchDelay = TimeSpan.FromSeconds(switchDelayInSeconds);
        }

        public override string ToString()
            => $"Register#{No} ({QueuedCustomers.Count} customers in line)";
    }
}
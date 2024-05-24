using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using d06.Extensions;

namespace d06.Models
{
    public class Store
    {
        public List<Register> Registers { get; }
        public Storage Storage { get; }

        public bool IsOpen => !Storage.IsEmpty;

        public Store(int registerCount,
            int storageCapacity, float registerSwitchDelayInSeconds, float registerProductScanInSeconds)
        {
            Storage = new Storage(storageCapacity);
            Registers = Enumerable.Range(1, registerCount)
                .Select(i => new Register(i, registerProductScanInSeconds, registerSwitchDelayInSeconds))
                .ToList();
        }
        
        public async Task OpenRegistersAsync()
        {
            var tasks = Registers.Select(register =>
                Task.Run(() =>
                {
                    while (IsOpen || Registers.Any(register => register.QueuedCustomers.Count > 0))
                    {
                        if (register.QueuedCustomers.Count > 0)
                        {
                            if (register.QueuedCustomers.TryPeek(out var customer))
                            {
                                register.Process();
                                Console.WriteLine($"{register}, {customer}, {customer.ItemsInCart}, {register.QueuedCustomers.Count}");
                            }
                        }
                    }
                }));
            await Task.WhenAll(tasks);
        }

        public async Task SimulationAsync(int customerCount, int cartCapacity,
            Func<Customer, IEnumerable<Register>, Register> strategy)
        {
            var customers = Enumerable.Range(1, customerCount)
                .Select(x => new Customer(x))
                .ToArray();

            Parallel.ForEach(customers, customer =>
            {
                if (Storage.TryTakeItems(customer.ItemsInCart))
                {
                    customer.FillCart(cartCapacity);
                    if (Storage.TryTakeItems(customer.ItemsInCart))
                    {
                        Register register;
                        lock (Registers)
                        {
                            register = strategy(customer, Registers);
                            register.QueuedCustomers.Enqueue(customer);
                            Console.WriteLine($"{customer} in line at {register}");
                        }
                    }
                }
            });
            
            var addCustomerTask = Task.Run(async () =>
            {
                int newCustomerNo = customerCount + 1;
                while (IsOpen)
                {
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    var newCustomer = new Customer(newCustomerNo++);
                    newCustomer.FillCart(cartCapacity);
                    if (Storage.TryTakeItems(newCustomer.ItemsInCart))
                    {
                        var register = strategy(newCustomer, Registers);
                        Console.WriteLine($"New {newCustomer} in line at {register}");
                    }
                }
            });
            
            await OpenRegistersAsync();
        }
    }
}
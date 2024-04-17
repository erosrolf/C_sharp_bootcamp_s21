public class Store
{
    public delegate CashRegister Strategy(Customer customer, List<CashRegister> cashRegisters);
    public Storage Storage { get; }
    public List<CashRegister> CashRegisters { get; }
    public int CartCapacity { get; }

    public Store(int storageCapacity, int numberOfCashRegisters, int cartCapacity)
    {
        Storage = new Storage(storageCapacity);
        CashRegisters = new List<CashRegister>();
        CartCapacity = cartCapacity;

        for (int i = 1; i <= numberOfCashRegisters; i++)
        {
            CashRegisters.Add(new CashRegister($"Register #{i}"));
        }
    }

    public void StoreCycle(List<Customer> customers, Strategy strat)
    {
        while (IsOpen && customers.Count > 0)
        {
            foreach (var customer in customers.ToList())
            {
                if (IsOpen)
                {
                    customer.FillCart(CartCapacity, Storage);
                    var register = strat(customer, CashRegisters);
                    Console.WriteLine($"{customer} - {register} ({register.CountOfCustomers} people with {register.TotalCountOfGoods} items behind)");
                    register.AddCustomer(customer);
                }
                customers.Remove(customer);
            }
        }
    }

    public bool IsOpen => !Storage.IsEmpty;
}

public class CashRegister
{
    public string Name { get; }
    private Queue<Customer> _customers;
    public int CountOfCustomers => _customers.Count;
    public int TotalCountOfGoods
    {
        get
        {
            int totalCount = 0;
            foreach (var customer in _customers)
            {
                totalCount += customer.CountOfItemsInCart;
            }
            return totalCount;
        }
    }

    public CashRegister(string name)
    {
        Name = name;
        _customers = new Queue<Customer>();
    }

    public void AddCustomer(Customer customer) => _customers.Enqueue(customer);

    public Customer ServeCustomer() => _customers.Dequeue();

    public override string ToString() => $"Register #{Name}";

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType != obj.GetType)
        {
            return false;
        }
        var otherCashRegister = (CashRegister)obj;
        return Name == otherCashRegister.Name;
    }

    public override int GetHashCode() => Name.GetHashCode();

    public static bool operator ==(CashRegister first, CashRegister second)
    {
        if (ReferenceEquals(first, null))
            return ReferenceEquals(second, null);
        return first.Equals(second);
    }

    public static bool operator !=(CashRegister first, CashRegister second)
    {
        return !(first == second);
    }
}
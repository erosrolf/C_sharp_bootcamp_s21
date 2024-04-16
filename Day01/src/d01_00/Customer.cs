using System.Reflection.Metadata.Ecma335;

class Customer
{
    public string Name { get; }
    public uint Id { get; }
    private int _itemsInCart;
    private static Random _random = new Random();

    public Customer(string name, uint id)
    {
        Name = name;
        Id = id;
        _itemsInCart = 0;
    }

    public override string ToString()
    {
        return $"{Name}, customer #{Id} ({_itemsInCart} items in cart)";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        var otherCustomer = (Customer)obj;
        return Name == otherCustomer.Name && Id == otherCustomer.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Id);
    }

    public static bool operator ==(Customer first, Customer second)
    {
        if (ReferenceEquals(first, null))
            return ReferenceEquals(second, null);
        return first.Equals(second);
    }

    public static bool operator !=(Customer first, Customer second)
    {
        return !(first == second);
    }

    public void FillCart(int maxCapacity)
    {
        _itemsInCart = _random.Next(1, maxCapacity + 1);
    }
}
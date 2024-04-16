class Storage
{
    private int _capacity;
    private int _goods;

    public Storage(int capacity)
    {
        _capacity = capacity;
        _goods = 0;
    }

    public bool IsEmpty() => _goods == 0;

    public void AddGoods(int amount)
    {
        if (_goods + amount > _capacity)
        {
            throw new Exception("Not enough capacity to add more goods.");
        }
        _goods += amount;
    }

    public void RemoveGoods(int amount)
    {
        if (_goods - amount < 0)
        {
            throw new Exception("Not enough goods to remove.");
        }
        _goods -= amount;
    }
}
public class Store
{
    public Storage Storage { get; }
    public List<CashRegister> CashRegisters { get; }

    public Store(int storageCapacity, int numberOfCashRegisters)
    {
        Storage = new Storage(storageCapacity);
        CashRegisters = new List<CashRegister>();

        for (int i = 1; i <= numberOfCashRegisters; i++)
        {
            CashRegisters.Add(new CashRegister($"Register #{i}"));
        }
    }

    public bool IsOpen => !Storage.IsEmpty;
}

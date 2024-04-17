public static class CustomerExtensions
{
    public static CashRegister ChooseRegisterWithLeastCustomers(this Customer customer, List<CashRegister> cashRegisters)
    {
        return cashRegisters.OrderBy(register => register.CountOfCustomers).First();
    }

    public static CashRegister ChooseRegisterWithLeastGoods(this Customer customer, List<CashRegister> cashRegisters)
    {
        return cashRegisters.OrderBy(register => register.TotalCountOfGoods).First();
    }
}

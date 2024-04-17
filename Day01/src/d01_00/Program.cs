var store = new Store(40, 3, 7);
var customers = new List<Customer>
{
    new Customer("Dionissiy", 1),
    new Customer("Svyatoslav", 2),
    new Customer("Panteleimon", 3),
    new Customer("Erosrolf", 4),
    new Customer("Agaphonika", 5),
    new Customer("Evlampiya", 6),
    new Customer("Kallispheniya", 7),
    new Customer("Mstislava", 8),
    new Customer("Mstislava", 9),
    new Customer("Protoleon", 10)
};

store.Storage.AddGoods(40);
store.StoreCycle(customers.ToList(), CustomerExtensions.ChooseRegisterWithLeastCustomers);
Console.WriteLine();
store.Storage.AddGoods(40 - store.Storage.CountOfGoods);
store.StoreCycle(customers.ToList(), CustomerExtensions.ChooseRegisterWithLeastGoods);

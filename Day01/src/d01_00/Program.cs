//00
Storage d = new(0);
Console.WriteLine(d.IsEmpty);

//01
Customer customer1 = new Customer("Andrew", 1);
Customer customer2 = new Customer("Andrew", 1);
Console.WriteLine(customer1);
Console.WriteLine(customer1 == customer2);

//02
customer1 = new Customer("Dionissiy", 1);
customer2 = new Customer("Svyatoslav", 2);
Customer customer3 = new Customer("Panteleimon", 3);

customer1.FillCart(15);
customer2.FillCart(15);
customer3.FillCart(15);

Console.WriteLine(customer1);
Console.WriteLine(customer2);
Console.WriteLine(customer3);
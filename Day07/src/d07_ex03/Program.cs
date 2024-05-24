using d07_ex03.Models;
using d07_ex03;

var user1 = TypeFactory.CreateWithConstructor<IdentityUser>();
var user2 = TypeFactory.CreateWithActivator<IdentityUser>();
Console.WriteLine(user1.GetType().FullName);
Console.WriteLine(user1 == user2 ? "user1 == user2" : "user1 != user2");

var role1 = TypeFactory.CreateWithConstructor<IdentityRole>();
var role2 = TypeFactory.CreateWithActivator<IdentityRole>();
Console.WriteLine(user1.GetType().FullName);
Console.WriteLine(role1 == role2 ? "role1 == role2" : "role1 != role2");

// bonus part
Console.WriteLine();
Console.WriteLine(typeof(IdentityUser).FullName);
Console.Write("Set name:\n");
string? userName = Console.ReadLine();
var activatedUser = TypeFactory.CreateWithParameters<IdentityUser>(userName ?? "");
        
Console.WriteLine($"Username set: {activatedUser?.UserName ?? "null"}");
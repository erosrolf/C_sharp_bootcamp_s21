using d07_ex02.ConsoleSetter;
using d07_ex02.Models;

var identity = new IdentityUser();
// var identity = new IdentityRole();
ConsoleSetter.SetValues(identity);
Console.WriteLine(identity);
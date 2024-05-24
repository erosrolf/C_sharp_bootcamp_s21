using System;
using System.IO;
using Newtonsoft.Json.Linq;
using d06.Extensions;
using d06.Models;

const int registerCount = 3;
const int storageCapacity = 50;
const int cartCapacity = 7;
const int customerCount = 10;

var json = File.ReadAllText("appsettings.json");
var jsonObj = JObject.Parse(json);

float timePerCustomer = (float?)jsonObj["TimePerCustomer"] ?? throw new Exception("CustomerSwitchTime not found");
float timePerItem = (float?)jsonObj["TimePerItem"] ?? throw new Exception("ProductScanDuration not found");
timePerItem = Math.Max(timePerItem, 1);
timePerCustomer = Math.Max(timePerCustomer, 1);



var shop = new Store(registerCount,
     storageCapacity, timePerCustomer, timePerItem);
await shop.SimulationAsync(customerCount, cartCapacity, CustomerExtensions.GetInLineByPeople);
// await shop.SimulationAsync(customerCount, cartCapacity, CustomerExtensions.GetInLineByPeople);

foreach (var register in shop.Registers)
{
     Console.WriteLine($"{register}. Average time for service customer = {register.TotalBusyTime / register.servedCustomersCount}");
}
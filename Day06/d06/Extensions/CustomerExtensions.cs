using System.Collections.Generic;
using System.Linq;
using d06.Models;

namespace d06.Extensions
{
    public static class CustomerExtensions
    {
        public static Register GetInLineByPeople(this Customer customer,
            IEnumerable<Register> registers)
        {
            var register = registers.MinBy(x => x.QueuedCustomers.Count);

            register?.QueuedCustomers
                .Enqueue(customer);

            return register;
        }

        public static Register GetInLineByItems(this Customer customer,
            IEnumerable<Register> registers)
        {
            var register = registers.MinBy(x => x.QueuedCustomers.Sum(c => c.ItemsInCart));

            register?.QueuedCustomers
                .Enqueue(customer);
         
            return register;
        }
    }
}
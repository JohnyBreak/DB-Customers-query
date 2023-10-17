
namespace Query_MSSQL2.Scripts
{
    public class DBFiller
    {
        public void FillDB() 
        {
            using (var context = new MyDBContext())
            {
                var manager = new Manager()
                {
                    Name = "Bill"
                };

                var manager2 = new Manager()
                {
                    Name = "May"
                };

                context.managers.Add(manager);
                context.SaveChanges();

                var customer = new Customer()
                {
                    Name = "Frank",
                    Manager = manager,
                    ManagerID = manager.ID
                };

                var customer2 = new Customer()
                {
                    Name = "Paul",
                    Manager = manager,
                    ManagerID = manager.ID
                };

                var customer3 = new Customer()
                {
                    Name = "Tom",
                    Manager = manager2,
                    ManagerID = manager2.ID
                };

                context.customers.Add(customer);
                context.customers.Add(customer2);
                context.SaveChanges();


                var orders = new List<Order>()
                {
                    new Order() { Date = new DateTime(2023,9,9), Amount = 500, Customer = customer, CustomerID = customer.ID },
                    new Order() { Date = new DateTime(2023,9,16), Amount = 501, Customer = customer, CustomerID = customer.ID },

                    new Order() { Date = new DateTime(2023,10,1), Amount = 900, Customer = customer2, CustomerID = customer2.ID },
                    new Order() { Date = new DateTime(2023,1,1), Amount = 9000, Customer = customer2, CustomerID = customer2.ID },

                    new Order() { Date = new DateTime(2023,9,9), Amount = 222, Customer = customer3, CustomerID = customer3.ID },
                    new Order() { Date = new DateTime(2023,9,16), Amount = 33, Customer = customer3, CustomerID = customer3.ID },
                };

                context.orders.AddRange(orders);
                context.SaveChanges();

                Console.WriteLine($"database filled");
            }
        }
    }
}

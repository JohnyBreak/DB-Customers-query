
namespace Query_MSSQL2.Scripts
{
    public class DBQueryManager
    {
        private MyDBContext _dBContext;

        public DBQueryManager(MyDBContext dBContext) 
        {
            _dBContext = dBContext;
        }

        public List<CustomerViewModel> GetCustomers(DateTime beginDate, decimal sumAmount)
        {
            List<CustomerViewModel> viewList = new List<CustomerViewModel>();

            foreach (var customer in _dBContext.customers)
            {
                List<Order> allCustomerOrders = customer.Orders.Select(o => o).Where(o => o.CustomerID == customer.ID).ToList();

                decimal total = 0;
                foreach (var order in allCustomerOrders)
                {
                    if (order.Date > beginDate) total += order.Amount;
                }
                if (total > sumAmount)
                {
                    viewList.Add(new CustomerViewModel() 
                    { 
                        Amount = total, 
                        CustomerName = customer.Name,
                        ManagerName = GetManagerName(customer.ManagerID)
                    });
                
                } 
            }
            return viewList;
        }

        private string GetManagerName(int managerID) 
        {
            return _dBContext.managers.Select(m => m).Where(m => m.ID == managerID).First().Name;
        }
    }
}

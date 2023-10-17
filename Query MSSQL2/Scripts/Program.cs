
namespace Query_MSSQL2.Scripts
{

    // я использовал SQLEXPRESS и MSSQLSERVER для бд, настройки подключения находятся в файле App.config,
    // ниже в коде в комментариях написано как создать и заполнить бдбд

    public static class Program
    {
        static void Main(string[] args)
        {
            MyDBContext context = new MyDBContext();
            
            
            //context.ReCreateDB(); // чтобы создать новую бд
            
            //DBFiller filler = new DBFiller(); // чтобы заполнить бд стартовой информацией для теста
            //filler.FillDB();


            Console.WriteLine("Connecting to DB");

            DBQueryManager dBQueryManager = new(context);
            Console.WriteLine("Sending query to DB");

            var result = dBQueryManager.GetCustomers(new DateTime(2022,9,2), 1000);// сам метод, который нужно было реализовать
            Console.WriteLine("Result: \n");

            foreach (var item in result) 
            {
                Console.WriteLine($"Customer name: {item.CustomerName}, Manager name: {item.ManagerName}, Amount: {item.Amount}");
            }
        }
    }
}


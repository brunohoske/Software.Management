using SystemManagement.DAO;

namespace SystemManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Store Store { get; set; }
        public Table Table { get; set; }

        public OrderDao dao = new OrderDao();


        public void CreateOrder()
        {
            dao.CreateOrder(this);
        }

        public List<Order> GetOrders()
        {
            return dao.GetOrders(Store);
        }

        public int GetOrderNumber()
        {
            return dao.GetOrderNumber(Store);
        }
        public List<Order> GetOrdersInTable()
        {
            return dao.GetOrdersInTable(Store, Table);
        }

        

    }
}

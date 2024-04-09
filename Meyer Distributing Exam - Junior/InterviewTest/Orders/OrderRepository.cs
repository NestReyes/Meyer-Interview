using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Orders
{
    public class OrderRepository
    {
        private List<IOrder> orders;
        public OrderRepository()
        {
            orders = new List<IOrder>();
        }

        public void Add(IOrder newOrder)
        {
            orders.Add(newOrder);
        }

        public void Remove(IOrder removedOrder)
        {
            orders = orders.Where(o => !string.Equals(removedOrder.OrderNumber, o.OrderNumber)).ToList();
        }

        // Added a function to clear List<IOrder> orders from any content.
        public void Clear()
        {
            orders.Clear();
        }

        public List<IOrder> Get()
        {
            return orders;
        }
    }
}

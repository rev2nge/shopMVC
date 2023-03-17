using shopProject.Models;
using shopProject.Interface;

namespace shopProject.SQLRepository
{
    public class OrdersSQLRepository : IOrderRepository
    {
        private readonly ApplicationContext context;
        public OrdersSQLRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public Order Create(Order order)
        {
            context.Order.Add(order);
            context.SaveChanges();
            return order;
        }

        public Order Update(Order order)
        {
            var orders = context.Order.Attach(order);
            orders.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return order;
        }

        public Order Delete(int Id)
        {
            Order order = context.Order.Find(Id);
            if (order != null)
            {
                context.Order.Remove(order);
                context.SaveChanges();
            }
            return order;
        }

        public IEnumerable<Order> GetOrder()
        {
            return context.Order;
        }

        public Order GetOrderByID(int? Id)
        {
            return context.Order.Find(Id);
        }
    }
}

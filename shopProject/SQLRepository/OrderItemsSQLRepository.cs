using shopProject.Models;
using shopProject.Interface;

namespace shopProject.SQLRepository
{
    public class OrderItemsSQLRepository : IOrderItemRepository
    {
        private readonly ApplicationContext context;
        public OrderItemsSQLRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public OrderItem Create(OrderItem orderItem)
        {
            context.OrderItem.Add(orderItem);
            context.SaveChanges();
            return orderItem;
        }

        public OrderItem Update(OrderItem orderItem)
        {
            var orderItems = context.OrderItem.Attach(orderItem);
            orderItems.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return orderItem;
        }

        public OrderItem Delete(int Id)
        {
            OrderItem orderItem = context.OrderItem.Find(Id);
            if (orderItem != null)
            {
                context.OrderItem.Remove(orderItem);
                context.SaveChanges();
            }
            return orderItem;
        }

        public IEnumerable<OrderItem> GetOrderItem()
        {
            return context.OrderItem;
        }

        public OrderItem GetOrderItemByID(int? Id)
        {
            return context.OrderItem.Find(Id);
        }
    }
}

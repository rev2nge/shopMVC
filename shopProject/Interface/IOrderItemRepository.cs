using shopProject.Models;

namespace shopProject.Interface
{
    public interface IOrderItemRepository 
    {
        IEnumerable<OrderItem> GetOrderItem(); // получение всех объектов
        OrderItem GetOrderItemByID(int? Id); // получение id
        OrderItem Create(OrderItem orderItem); // создание объекта
        OrderItem Update(OrderItem orderItem); // обновление объекта
        OrderItem Delete(int Id); // удаление объекта по id
    }
}
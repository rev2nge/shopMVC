using shopProject.Models;

namespace shopProject.Interface
{
    public interface IOrderRepository 
    {
        IEnumerable<Order> GetOrder(); // получение всех объектов
        Order GetOrderByID(int? Id); // получение id
        Order Create(Order order); // создание объекта
        Order Update(Order order); // обновление объекта
        Order Delete(int Id); // удаление объекта по id
    }
}
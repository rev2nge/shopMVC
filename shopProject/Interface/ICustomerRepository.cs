using shopProject.Models;

namespace shopProject.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomer(); // получение всех объектов
        Customer GetCustomerByID(int? Id); // получение id
        Customer Create(Customer customer); // создание объекта
        Customer Update(Customer customer); // обновление объекта
        Customer Delete(int Id); // удаление объекта по id
    }
}

using shopProject.Models;

namespace shopProject.Interface
{
    public interface IProductRepository 
    {
        IEnumerable<Product> GetProduct(); // получение всех объектов
        Product GetProductByID(int? Id); // получение id
        Product Create(Product product); // создание объекта
        Product Update(Product product); // обновление объекта
        Product Delete(int Id); // удаление объекта по id
    }
}

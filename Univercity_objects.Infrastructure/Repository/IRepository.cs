namespace Univercity_objects.Infrastructure;

interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(); // получение всех объектов
    T Getobj(int id); // получение объекта по id
    void Create(T item); // создание объекта
    void Update(T item); // обновление объекта
    void Delete(int id); // удаление объекта по id
    void Save();  // сохранение изменений
}

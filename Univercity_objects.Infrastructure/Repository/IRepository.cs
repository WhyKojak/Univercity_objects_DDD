namespace Univercity_objects.Infrastructure;

interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(); // получение всех объектов
    T Get(Guid guid); // получение объекта по id
    void Create(T item); // создание объекта
    void Update(T item); // обновление объекта
    void Delete(Guid guid); // удаление объекта по id
    void Save();  // сохранение изменений
}

using System.Collections.Generic;

namespace ModelLib
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// добавление
        /// </summary>
        /// <param name="объект"></param>
        void Add(T obj);
        /// <summary>
        /// удаление
        /// </summary>
        /// <param name="объект"></param>
        void Delete(T obj);
        /// <summary>
        /// выводит все данные
        /// </summary>
        /// <returns>список данных</returns>
        IEnumerable<T> ReadAll();
        /// <summary>
        /// поиск по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns>объект </returns>
        T ReadById(int id);
        /// <summary>
        /// обновление данных
        /// </summary>
        void Update(T obj);
        /// <summary>
        /// обновляем рейтинг
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rating"></param>
        void UpdateRating(int id, int rating);
    }
}

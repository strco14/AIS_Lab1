using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace аис_лаба_1
{
    public class Logic
    {
        private List<Wine> wines = new List<Wine>()
        {
            new Wine("Шардоне", "Белое", "Сухое", "Франция"),
            new Wine("Каберне Совиньон", "Красное", "Сухое", "Франция"),
            new Wine("Мерло", "Красное", "Полусухое", "Италия"),
            new Wine("Совиньон Блан", "Белое", "Сухое", "Испания"),
            new Wine("Пино Нуар", "Красное", "Сухое", "Франция"),
            new Wine("Рислинг", "Белое", "Полусладкое", "Россия"),
            new Wine("Мадера", "Красное", "Сладкое", "Аргентина"),
            new Wine("Мускат", "Белое", "Сладкое", "Италия"),
            new Wine("Изабелла", "Красное", "Полусладкое", "Россия"),
            new Wine("Токай", "Белое", "Сладкое", "Аргентина")
        };
        /// <summary>
        /// возвращает список вин
        /// </summary>
        /// <returns></returns>
        public List<Wine> GetWines()
        {
            return wines;
        }

        /// <summary>
        /// Добавление нового вина в список
        /// </summary>
        /// <param name="wine"></param>
        public void AddWine(Wine wine)
        {
            wines.Add(wine);
        }
        /// <summary>
        /// Проверка, было ли уже такое вино добавлено
        /// </summary>
        /// <param name="wine"></param>
        /// <returns></returns>
        public bool CheckWineInList(Wine wine)
        {
            bool isIn = true;
            foreach (Wine w in wines)
            {
                if (w.Name == wine.Name && w.Homeland == wine.Homeland &&
                    w.Sugar == wine.Sugar && w.Type == wine.Type) isIn = false;
            }
            return isIn;
        }
        /// <summary>
        /// Удаляет вино из списка
        /// </summary>
        /// <param name="wine"></param>
        public void RemoveWine(Wine wine)
        {
            wines.Remove(wine);
        }
        /// <summary>
        /// Изменяем вино в списке по индексу
        /// </summary>
        /// <param name="newWine"></param>
        /// <param name="index"></param>
        public void ChangeWine(Wine newWine, int index)
        {
            wines[index] = newWine;
        }
        /// <summary>
        /// Поиск вина по параметрам (могут быть нулевыми)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="sweetness"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public List<Wine> SearchWines(string name = null,
            string color = null,
            string sweetness = null,
            string country = null)
        {
            var query = wines.AsQueryable(); //Отличие от IEnumerable в том, что список создается
                                             //не при каждом Where, а только после ToList

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(w => w.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(color))
                query = query.Where(w => w.Type == color);

            if (!string.IsNullOrWhiteSpace(sweetness))
                query = query.Where(w => w.Sugar == sweetness);

            if (!string.IsNullOrWhiteSpace(country))
                query = query.Where(w => w.Homeland == country);

            return query.ToList();
        }
        /// <summary>
        /// Возвращает список вин, отсортированных по рейтингу
        /// </summary>
        /// <returns></returns>
        public List<Wine> BestWines()
        {
            return wines
                .OrderByDescending(w => w.Rating)
                .ThenBy(w => w.Name)
                .ToList();

        }
        /// <summary>
        /// Задаем\меняем параметр рейтинга у вина
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="wine"></param>
        public void GetMark(int mark, Wine wine)
        {
            wine.Rating = mark;
        }
    }
}

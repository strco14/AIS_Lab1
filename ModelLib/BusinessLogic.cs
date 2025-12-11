using System;
using System.Linq;
using DAL;
using ModelLib;
namespace аис_лаба_1
{
    public class BusinessLogic : IWineBusinessService
    {
        private IRepository<Wine> repos;
        public BusinessLogic(IRepository<Wine> rep)
        {
            repos = rep;
        }
        /// <summary>
        /// Поиск вина по параметрам (могут быть нулевыми)
        /// </summary>
        /// <param name="name">название вина</param>
        /// <param name="color">цвет вина</param>
        /// <param name="sweetness">сладость вина</param>
        /// <param name="country">страна производства</param>
        /// <returns>таблицу вин по параметрам</returns>
        public string[,] SearchWines(string name = null,
        string color = null,
        string sweetness = null,
        string country = null)
        {
            var query = repos.ReadAll().AsQueryable(); //Отличие от IEnumerable в том, что список создается
                                                       //не при каждом Where, а только после ToList

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(w => w.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(color))
                query = query.Where(w => w.Type == color);

            if (!string.IsNullOrWhiteSpace(sweetness))
                query = query.Where(w => w.Sugar == sweetness);

            if (!string.IsNullOrWhiteSpace(country))
                query = query.Where(w => w.Homeland == country);

            var list = query.ToList();
            string[,] Out = new string[list.Count, 6];
            for (int i = 0; i < list.Count; i++)
            {
                Out[i, 0] = list[i].Id.ToString();
                Out[i, 1] = list[i].Name.ToString();
                Out[i, 2] = list[i].Type.ToString();
                Out[i, 3] = list[i].Sugar.ToString();
                Out[i, 4] = list[i].Homeland.ToString();
                Out[i, 5] = list[i].Rating.ToString();
            }
            return Out;
        }
        /// <summary>
        /// Возвращает таблицу вин, отсортированных по рейтингу
        /// </summary>
        /// <returns>таблица вин, отсортированных по рейтингу</returns>
        public string[,] BestWines()
        {
            var list = repos.ReadAll()
                .OrderByDescending(w => w.Rating)
                .ThenBy(w => w.Name)
                .ToList();
            string[,] Out = new string[list.Count, 6];
            for (int i = 0; i < list.Count; i++)
            {
                Out[i, 0] = list[i].Id.ToString();
                Out[i, 1] = list[i].Name.ToString();
                Out[i, 2] = list[i].Type.ToString();
                Out[i, 3] = list[i].Sugar.ToString();
                Out[i, 4] = list[i].Homeland.ToString();
                Out[i, 5] = list[i].Rating.ToString();
            }
            return Out;
        }
        /// <summary>
        /// Задаем, меняем параметр рейтинга у вина
        /// </summary>
        /// <param name="mark">оценка</param>
        /// <param name="wine">вино</param>
        public void GetMark(int mark, int id)
        {
            repos.UpdateRating(id, mark);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using ModelLib;
using DAL;
namespace аис_лаба_1
{
    public class WineService : IWineService
    {
        private IRepository<Wine> repos;
        private IWineBusinessService businessService;
        public WineService(IRepository<Wine> _wines, IWineBusinessService businessService)
        {
            repos = _wines;
            this.businessService = businessService;
            //repos.Add(new Wine("Шардоне", "Белое", "Сухое", "Франция"));
            //repos.Add(new Wine("Каберне Совиньон", "Красное", "Сухое", "Франция"));
            //repos.Add(new Wine("Мерло", "Красное", "Полусухое", "Италия"));
            //repos.Add(new Wine("Совиньон Блан", "Белое", "Сухое", "Испания"));
            //repos.Add(new Wine("Пино Нуар", "Красное", "Сухое", "Франция"));
            //repos.Add(new Wine("Рислинг", "Белое", "Полусладкое", "Россия"));
            //repos.Add(new Wine("Мадера", "Красное", "Сладкое", "Аргентина"));
            //repos.Add(new Wine("Мускат", "Белое", "Сладкое", "Италия"));
            //repos.Add(new Wine("Изабелла", "Красное", "Полусладкое", "Россия"));
            //repos.Add(new Wine("Токай", "Белое", "Сладкое", "Аргентина"));
        }
        public event EventHandler<WineEventArgs> WineAdded;
        public event EventHandler<WineChangedEventArgs> WineChanged;
        public event EventHandler<WineDeletedEventArgs> WineDeleted;
        public event EventHandler<WineRatedEventArgs> WineRated;
        /// <summary>
        /// возвращает таблицу вин
        /// </summary>
        /// <returns>таблица всех вин</returns>
        public string[,] GetWines()
        {
            List<Wine> wines = new List<Wine>(repos.ReadAll());
            string[,] Out = new string[wines.Count, 6];
            for (int i = 0; i < wines.Count; i++)
            {
                Out[i, 0] = wines[i].Id.ToString();
                Out[i, 1] = wines[i].Name.ToString();
                Out[i, 2] = wines[i].Type.ToString();
                Out[i, 3] = wines[i].Sugar.ToString();
                Out[i, 4] = wines[i].Homeland.ToString();
                Out[i, 5] = wines[i].Rating.ToString();
            }
            return Out;
        }
        /// <summary>
        /// поиск по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns> свойства вина</returns>
        public string[] GetWine(int id)
        {
            Wine wine = repos.ReadById(id);
            if (wine != null) return new string[6] {wine.Id.ToString(), wine.Name,
                wine.Type, wine.Sugar, wine.Homeland, wine.Rating.ToString()};
            return new string[6];
        }

        /// <summary>
        /// Добавление нового вина в список
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="type">тип</param>
        /// <param name="sugar">сладость</param>
        /// <param name="homeland">родина</param>
        public void AddWine(string name, string type, string sugar, string homeland)
        {
            Wine wine = new Wine(name, type, sugar, homeland);
            repos.Add(wine);
            repos.Update(wine);
            WineAdded?.Invoke(this, new WineEventArgs(wine));
        }
        /// <summary>
        /// Проверка, было ли уже такое вино добавлено
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="type">тип</param>
        /// <param name="sugar">сладость</param>
        /// <param name="homeland">родина</param>
        /// <returns> возвращает есть ли введеное вино в списке(проверка на повтор)</returns>
        public bool CheckWineInList(string name, string type, string sugar, string homeland)
        {
            Wine newWine = new Wine(name, type, sugar, homeland);
            var allWines = repos.ReadAll();

            // Используем LINQ и Equals() (который мы реализовали в Wine)
            bool isDuplicate = allWines.Any(w => w.Equals(newWine));

            // Сохраняем вашу оригинальную логику: true если вино НЕ найдено
            return !isDuplicate;
        }
        /// <summary>
        /// Удаляет вино
        /// </summary>
        /// <param name="id">id удаляемого вина</param>
        public void RemoveWine(int id)
        {
            var wine = repos.ReadById(id);
            if (wine != null)
            {
                repos.Delete(wine);
                WineDeleted?.Invoke(this, new WineDeletedEventArgs(id));
            }
            else
            {
                throw new ArgumentException($"Wine with ID {id} not found");
            }
        }
        /// <summary>
        /// Изменяем параметры вина
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="type">тип</param>
        /// <param name="sugar">сладость</param>
        /// <param name="homeland">родина</param>
        /// <param name="index"> индекс</param>
        public void ChangeWine(string name, string type, string sugar, string homeland, int index)
        {
            var wine = repos.ReadById(index);

            if (wine == null)
                throw new ArgumentException("Вино с таким ID не найдено.", nameof(index));


            wine.Name = name;
            wine.Type = type;
            wine.Sugar = sugar;
            wine.Homeland = homeland;


            repos.Update(wine);
            WineChanged?.Invoke(this, new WineChangedEventArgs(index, name, type, sugar, homeland));
        }

        public string[,] SearchWines(string name = null, string color = null, string sweetness = null, string country = null)
        {
            return businessService.SearchWines(name, color, sweetness, country);
        }

        public string[,] BestWines()
        {
            return businessService.BestWines();
        }

        public void GetMark(int mark, int id)
        {
            businessService.GetMark(mark, id);
            WineRated?.Invoke(this, new WineRatedEventArgs(id, mark));
        }
    }
}
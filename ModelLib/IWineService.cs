using System;
using ModelLib;

namespace аис_лаба_1
{
    public interface IWineService : IWineBusinessService
    {
        event EventHandler<WineEventArgs> WineAdded;
        event EventHandler<WineChangedEventArgs> WineChanged;
        event EventHandler<WineDeletedEventArgs> WineDeleted;
        event EventHandler<WineRatedEventArgs> WineRated;
        /// <summary>
        /// возвращает таблицу вин
        /// </summary>
        /// <returns>таблица всех вин</returns>
        string[,] GetWines();
        /// <summary>
        /// поиск по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns> свойства вина</returns>
        string[] GetWine(int id);
        /// <summary>
        /// Добавление нового вина в список
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="type">тип</param>
        /// <param name="sugar">сладость</param>
        /// <param name="homeland">родина</param>
        void AddWine(string name, string type, string sugar, string homeland);
        /// <summary>
        /// Проверка, было ли уже такое вино добавлено
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="type">тип</param>
        /// <param name="sugar">сладость</param>
        /// <param name="homeland">родина</param>
        /// <returns> возвращает есть ли введеное вино в списке(проверка на повтор)</returns>
        bool CheckWineInList(string name, string type, string sugar, string homeland);
        /// <summary>
        /// Удаляет вино
        /// </summary>
        /// <param name="id">id удаляемого вина</param>
        void RemoveWine(int id);
        /// <summary>
        /// Изменяет параметры вина
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="type">тип</param>
        /// <param name="sugar">сладость</param>
        /// <param name="homeland">родина</param>
        /// <param name="index">индекс</param>
        void ChangeWine(string name, string type, string sugar, string homeland, int index);
    }
    public class WineEventArgs : EventArgs
    {
        public Wine Wine { get; }
        public WineEventArgs(Wine wine) => Wine = wine;
    }

    public class WineChangedEventArgs : EventArgs
    {
        public int WineId { get; }
        public string NewName { get; }
        public string NewType { get; }
        public string NewSugar { get; }
        public string NewHomeland { get; }

        public WineChangedEventArgs(int wineId, string name, string type, string sugar, string homeland)
        {
            WineId = wineId;
            NewName = name;
            NewType = type;
            NewSugar = sugar;
            NewHomeland = homeland;
        }
    }

    public class WineDeletedEventArgs : EventArgs
    {
        public int WineId { get; }
        public WineDeletedEventArgs(int wineId) => WineId = wineId;
    }

    public class WineRatedEventArgs : EventArgs
    {
        public int WineId { get; }
        public int NewRating { get; }
        public WineRatedEventArgs(int wineId, int newRating)
        {
            WineId = wineId;
            NewRating = newRating;
        }
    }
}


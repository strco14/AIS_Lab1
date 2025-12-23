namespace ModelLib
{
    public interface IWineBusinessService
    {
        /// <summary>
        /// Поиск вина по параметрам (могут быть нулевыми)
        /// </summary>
        /// <param name="name">название вина</param>
        /// <param name="color">цвет вина</param>
        /// <param name="sweetness">сладость вина</param>
        /// <param name="country">страна производства</param>
        /// <returns>таблицу вин по параметрам</returns>
        string[,] SearchWines(string name = null, string color = null,
                             string sweetness = null, string country = null);
        /// <summary>
        /// Возвращает таблицу вин, отсортированных по рейтингу
        /// </summary>
        /// <returns>таблица вин, отсортированных по рейтингу</returns>
        string[,] BestWines();
        /// <summary>
        /// Задаем, меняем параметр рейтинга у вина
        /// </summary>
        /// <param name="mark">оценка</param>
        /// <param name="wine">вино</param>
        void GetMark(int mark, int id);
    }
}


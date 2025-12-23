using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.WineDTO;

namespace Shared
{
    public interface IWineView
    {
        // События, на которые подписывается Presenter
        event EventHandler LoadWinesRequested;
        event EventHandler<WineEventArgs> AddWineRequested;
        event EventHandler<WineEventArgs> EditWineRequested;
        event EventHandler<DeleteWineEventArgs> DeleteWineRequested;
        event EventHandler<SearchWineEventArgs> SearchWinesRequested;
        event EventHandler<RateWineEventArgs> RateWineRequested;
        event EventHandler ShowBestWinesRequested;

        /// <summary>
        /// Отображение вин
        /// </summary>
        /// <param name="wines"></param>
        void DisplayWines(IEnumerable<WineDTO> wines);
        /// <summary>
        /// Уведомления
        /// </summary>
        /// <param name="wines"></param>
        void DisplayMessage(string message, MessageType type);
        /// <summary>
        /// Очистка
        /// </summary>
        void ClearWinesDisplay();

        WineDTO SelectedWine { get; }
        WineDTO WineToAdd { get; }
        WineDTO WineToEdit { get; }
        SearchCriteriaDto SearchCriteria { get; }
        RatingInfo RatingInfo { get; }
    }
    //    public class WineDto
    //    {
    //        public string Id { get; set; }
    //        public string Name { get; set; }
    //        public string Type { get; set; }
    //        public string Sugar { get; set; }
    //        public string Homeland { get; set; }
    //        public string Rating { get; set; } = "0";
    //        public WineDto(string id, string name, string type, string sugar, string homeland, string rating)
    //        {
    //            Id = id;
    //            Name = name;
    //            Type = type;
    //            Sugar = sugar;
    //            Homeland = homeland;
    //            Rating = rating;
    //        }
    //        public WineDto(string name, string type, string sugar, string homeland)
    //        {
    //            Name = name;
    //            Type = type;
    //            Sugar = sugar;
    //            Homeland = homeland;
    //        }
    //    }
    //    public class SearchCriteria
    //    {
    //        public string Name { get; set; }
    //        public string Type { get; set; }
    //        public string Sugar { get; set; }
    //        public string Homeland { get; set; }
    //    }

    public class RatingInfo
    {
        public string WineId { get; set; }
        public int Rating { get; set; }
    }

    public enum MessageType
    {
        Info,
        Warning,
        Error,
        Success
    }




    public class DeleteWineEventArgs : EventArgs
    {
        public string WineId { get; }
        public DeleteWineEventArgs(string wineId) => WineId = wineId;
    }

    public class SearchWineEventArgs : EventArgs
    {
        public SearchCriteriaDto Criteria { get; }
        public SearchWineEventArgs(SearchCriteriaDto criteria) => Criteria = criteria;
    }

    public class RateWineEventArgs : EventArgs
    {
        public string WineId { get; }
        public int Rating { get; }
        public RateWineEventArgs(string wineId, int rating)
        {
            WineId = wineId;
            Rating = rating;
        }
    }
}

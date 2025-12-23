using System;
using System.Collections.ObjectModel;

namespace ViewModel
{
    /// <summary>
    /// ViewModel для поиска вин.
    /// </summary>
    public class SearchViewModel : ViewModelBase
    {
        private readonly IWineService _wineService;
        private SearchCriteriaDto _criteria;

        /// <summary>
        /// Событие запроса закрытия окна.
        /// </summary>
        public event Action CloseRequested;

        /// <summary>
        /// Событие запроса поиска.
        /// </summary>
        public event Action<string, string, string, string> SearchRequested;

        /// <summary>
        /// Критерии поиска.
        /// </summary>
        public SearchCriteriaDto Criteria
        {
            get => _criteria;
            set => SetField(ref _criteria, value);
        }

        /// <summary>
        /// Списки для ComboBox.
        /// </summary>
        public ObservableCollection<string> WineTypes { get; }
        public ObservableCollection<string> SugarTypes { get; }
        public ObservableCollection<string> Countries { get; }

        /// <summary>
        /// Команды.
        /// </summary>
        public Command SearchCommand { get; }
        public Command CancelCommand { get; }

        public SearchViewModel(IWineService wineService)
        {
            _wineService = wineService ?? throw new ArgumentNullException(nameof(wineService));
            Criteria = new SearchCriteriaDto();

            // Инициализация списков
            WineTypes = new ObservableCollection<string> { "", "Белое", "Красное" };
            SugarTypes = new ObservableCollection<string> { "", "Сладкое", "Полусладкое", "Полусухое", "Сухое" };
            Countries = new ObservableCollection<string> { "", "Франция", "Италия", "Испания", "Россия", "Аргентина" };

            // Команды
            SearchCommand = new Command(_ => PerformSearch());
            CancelCommand = new Command(_ => Cancel());
        }

        private void PerformSearch()
        {
            SearchRequested?.Invoke(
                string.IsNullOrWhiteSpace(Criteria.Name) ? null : Criteria.Name,
                string.IsNullOrWhiteSpace(Criteria.Type) ? null : Criteria.Type,
                string.IsNullOrWhiteSpace(Criteria.Sugar) ? null : Criteria.Sugar,
                string.IsNullOrWhiteSpace(Criteria.Country) ? null : Criteria.Country);

            CloseRequested?.Invoke();
        }

        private void Cancel()
        {
            CloseRequested?.Invoke();
        }
    }
}
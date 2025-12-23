using System;
using System.Collections.ObjectModel;



namespace ViewModel
{
    public class WineViewModel : ViewModelBase
    {
        private readonly IWineService _wineService;
        private WineDTO _wine;

        public WineDTO Wine
        {
            get => _wine;
            set => SetField(ref _wine, value);
        }

        public ObservableCollection<string> WineTypes { get; }
        public ObservableCollection<string> SugarTypes { get; }
        public ObservableCollection<string> Countries { get; }

        public WineViewModel(IWineService wineService, WineDTO existingWine = null)
        {
            _wineService = wineService;

            WineTypes = new ObservableCollection<string> { "Белое", "Красное" };
            SugarTypes = new ObservableCollection<string> { "Сладкое", "Полусладкое", "Полусухое", "Сухое" };
            Countries = new ObservableCollection<string> { "Франция", "Италия", "Испания", "Россия", "Аргентина" };

            Wine = existingWine ?? new WineDTO();
        }
    }
}
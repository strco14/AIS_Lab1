using System;
using System.Collections.ObjectModel;
using System.Linq;
using Shared;
using ModelLib;

namespace ViewModel
{
    /// <summary>
    /// Главная ViewModel приложения.
    /// Содержит бизнес-логику управления винным каталогом,
    /// команды пользовательского интерфейса и события взаимодействия с View.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IWineService _wineService;
        private ObservableCollection<WineDTO> _wines;
        private WineDTO _selectedWine;
        private string _statusMessage;

        /// <summary>
        /// Событие запроса открытия нового окна (ViewModel).
        /// </summary>
        public event Action<ViewModelBase> OpenRequested;

        /// <summary>
        /// Событие запроса отображения сообщения пользователю.
        /// </summary>
        public event Action<string> ShowMessageRequested;

        /// <summary>
        /// Коллекция вин для отображения.
        /// </summary>
        public ObservableCollection<WineDTO> Wines
        {
            get => _wines;
            set => SetField(ref _wines, value);
        }

        private WineDTO _selectedWine;

        /// <summary>
        /// Выбранное вино в таблице.
        /// Используется для операций редактирования и удаления.
        /// При изменении обновляет доступность соответствующих команд.
        /// </summary>
        public WineDTO SelectedWine
        {
            get => _selectedWine;
            set
            {
                _selectedWine = value;
                RaisePropertyChanged();
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
                RateWineCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Сообщение статуса для отображения в интерфейсе.
        /// </summary>
        public string StatusMessage
        {
            get => _statusMessage;
            set => SetField(ref _statusMessage, value);
        }

        /// <summary>
        /// Команды пользовательского интерфейса.
        /// </summary>
        public Command RefreshCommand { get; }
        public Command AddCommand { get; }
        public Command EditCommand { get; }
        public Command DeleteCommand { get; }
        public Command SearchCommand { get; }
        public Command ShowBestWinesCommand { get; }
        public Command RateWineCommand { get; }

        /// <summary>
        /// Создаёт главную ViewModel приложения
        /// и инициализирует команды пользовательского интерфейса.
        /// </summary>
        public MainViewModel(IWineService wineService)
        {
            _wineService = wineService ?? throw new ArgumentNullException(nameof(wineService));
            Wines = new ObservableCollection<WineDTO>();

            // Инициализация команд
            RefreshCommand = new Command(_ => LoadWines());
            AddCommand = new Command(_ => AddWine());
            EditCommand = new Command(_ => EditWine(), _ => SelectedWine != null);
            DeleteCommand = new Command(_ => DeleteWine(), _ => SelectedWine != null);
            SearchCommand = new Command(_ => SearchWines());
            ShowBestWinesCommand = new Command(_ => ShowBestWines());
            RateWineCommand = new Command(param => RateWine(param), _ => SelectedWine != null);

            // Подписка на события сервиса
            SubscribeToServiceEvents();
        }

        /// <summary>
        /// Метод инициализации ViewModel.
        /// Вызывается менеджером ViewModel после создания.
        /// </summary>
        public override void Init()
        {
            LoadWines();
        }

        private void SubscribeToServiceEvents()
        {
            _wineService.WineAdded += OnWineAdded;
            _wineService.WineChanged += OnWineChanged;
            _wineService.WineDeleted += OnWineDeleted;
            _wineService.WineRated += OnWineRated;
        }

        /// <summary>
        /// Загружает список вин из слоя бизнес-логики.
        /// </summary>
        private void LoadWines()
        {
            try
            {
                var wineData = _wineService.GetWines();
                Wines.Clear();

                for (int i = 0; i < wineData.GetLength(0); i++)
                {
                    Wines.Add(new WineDTO
                    {
                        Id = int.Parse(wineData[i, 0]),
                        Name = wineData[i, 1],
                        Type = wineData[i, 2],
                        Sugar = wineData[i, 3],
                        Homeland = wineData[i, 4],
                        Rating = int.Parse(wineData[i, 5])
                    });
                }

                StatusMessage = $"Загружено {Wines.Count} вин";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Ошибка загрузки: {ex.Message}";
                ShowMessageRequested?.Invoke($"Ошибка загрузки: {ex.Message}");
            }
        }

        /// <summary>
        /// Инициирует добавление нового вина.
        /// </summary>
        private void AddWine()
        {
            try
            {
                var editorVm = VMWanager.Instance.CreateWineEditorViewModel(_wineService);

                editorVm.WineSaved += wine =>
                {
                    Wines.Add(wine);
                    StatusMessage = $"Вино '{wine.Name}' добавлено";
                };

                editorVm.CloseRequested += () =>
                {
                    // Окно закроется через ViewManager
                };

                OpenRequested?.Invoke(editorVm);
                StatusMessage = "Добавление нового вина...";
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
                ShowMessageRequested?.Invoke(ex.Message);
            }
        }

        /// <summary>
        /// Инициирует редактирование выбранного вина.
        /// </summary>
        private void EditWine()
        {
            if (SelectedWine == null) return;

            try
            {
                var editorVm = VMWanager.Instance.CreateWineEditorViewModel(_wineService, SelectedWine);

                editorVm.WineSaved += editedWine =>
                {
                    var index = Wines.IndexOf(SelectedWine);
                    if (index >= 0)
                    {
                        Wines[index] = editedWine;
                        StatusMessage = $"Вино '{editedWine.Name}' обновлено";
                    }
                };

                OpenRequested?.Invoke(editorVm);
                StatusMessage = $"Редактирование: {SelectedWine.Name}";
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
                ShowMessageRequested?.Invoke(ex.Message);
            }
        }

        /// <summary>
        /// Удаляет выбранное вино.
        /// </summary>
        private void DeleteWine()
        {
            if (SelectedWine == null) return;

            try
            {
                _wineService.RemoveWine(SelectedWine.Id);
                StatusMessage = $"Вино '{SelectedWine.Name}' удалено";

                // Обновляем список
                LoadWines();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Ошибка удаления: {ex.Message}";
                ShowMessageRequested?.Invoke($"Ошибка удаления: {ex.Message}");
            }
        }

        /// <summary>
        /// Инициирует поиск вин.
        /// </summary>
        private void SearchWines()
        {
            try
            {
                var searchVm = VMWanager.Instance.CreateSearchViewModel(_wineService);

                searchVm.SearchRequested += (name, type, sugar, country) =>
                {
                    PerformSearch(name, type, sugar, country);
                };

                OpenRequested?.Invoke(searchVm);
                StatusMessage = "Открытие формы поиска...";
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
                ShowMessageRequested?.Invoke(ex.Message);
            }
        }

        /// <summary>
        /// Выполняет поиск вин.
        /// </summary>
        private void PerformSearch(string name = null, string type = null, string sugar = null, string country = null)
        {
            try
            {
                var searchResults = _wineService.SearchWines(name, type, sugar, country);
                Wines.Clear();

                for (int i = 0; i < searchResults.GetLength(0); i++)
                {
                    Wines.Add(new WineDTO
                    {
                        Id = int.Parse(searchResults[i, 0]),
                        Name = searchResults[i, 1],
                        Type = searchResults[i, 2],
                        Sugar = searchResults[i, 3],
                        Homeland = searchResults[i, 4],
                        Rating = int.Parse(searchResults[i, 5])
                    });
                }

                StatusMessage = $"Найдено {Wines.Count} вин";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Ошибка поиска: {ex.Message}";
                ShowMessageRequested?.Invoke($"Ошибка поиска: {ex.Message}");
            }
        }

        /// <summary>
        /// Показывает лучшие вина по рейтингу.
        /// </summary>
        private void ShowBestWines()
        {
            try
            {
                var bestWinesData = _wineService.BestWines();
                Wines.Clear();

                for (int i = 0; i < bestWinesData.GetLength(0); i++)
                {
                    Wines.Add(new WineDTO
                    {
                        Id = int.Parse(bestWinesData[i, 0]),
                        Name = bestWinesData[i, 1],
                        Type = bestWinesData[i, 2],
                        Sugar = bestWinesData[i, 3],
                        Homeland = bestWinesData[i, 4],
                        Rating = int.Parse(bestWinesData[i, 5])
                    });
                }

                StatusMessage = $"Показаны {Wines.Count} лучших вин";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Ошибка: {ex.Message}";
                ShowMessageRequested?.Invoke($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Оценивает выбранное вино.
        /// </summary>
        private void RateWine(object parameter)
        {
            if (SelectedWine == null || parameter == null) return;

            if (int.TryParse(parameter.ToString(), out int rating) && rating >= 1 && rating <= 5)
            {
                try
                {
                    _wineService.GetMark(rating, SelectedWine.Id);
                    SelectedWine.Rating = rating;
                    StatusMessage = $"Вино '{SelectedWine.Name}' оценено на {rating}";
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Ошибка оценки: {ex.Message}";
                    ShowMessageRequested?.Invoke($"Ошибка оценки: {ex.Message}");
                }
            }
        }

        // Обработчики событий сервиса
        private void OnWineAdded(object sender, WineEventArgs e)
        {
            // Обновляем список
            LoadWines();
        }

        private void OnWineChanged(object sender, WineChangedEventArgs e)
        {
            var wine = Wines.FirstOrDefault(w => w.Id == e.WineId);
            if (wine != null)
            {
                wine.Name = e.NewName;
                wine.Type = e.NewType;
                wine.Sugar = e.NewSugar;
                wine.Homeland = e.NewHomeland;
            }
        }

        private void OnWineDeleted(object sender, WineDeletedEventArgs e)
        {
            var wine = Wines.FirstOrDefault(w => w.Id == e.WineId);
            if (wine != null)
            {
                Wines.Remove(wine);
            }
        }

        private void OnWineRated(object sender, WineRatedEventArgs e)
        {
            var wine = Wines.FirstOrDefault(w => w.Id == e.WineId);
            if (wine != null)
            {
                wine.Rating = e.NewRating;
            }
        }
    }
}
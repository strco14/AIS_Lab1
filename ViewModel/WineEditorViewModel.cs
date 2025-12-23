using System;
using System.Collections.ObjectModel;
using Shared;
using ModelLib;

namespace ViewModel
{
    /// <summary>
    /// ViewModel для добавления/редактирования вина.
    /// </summary>
    public class WineEditorViewModel : ViewModelBase
    {
        private readonly IWineService _wineService;
        private WineDTO _wine;
        private bool _isEditMode;

        /// <summary>
        /// Событие запроса закрытия окна.
        /// </summary>
        public event Action CloseRequested;

        /// <summary>
        /// Событие сохранения вина.
        /// </summary>
        public event Action<WineDTO> WineSaved;

        /// <summary>
        /// Событие отображения сообщения.
        /// </summary>
        public event Action<string> ShowMessageRequested;

        /// <summary>
        /// Вино для редактирования.
        /// </summary>
        public WineDTO Wine
        {
            get => _wine;
            set => SetField(ref _wine, value);
        }

        /// <summary>
        /// Режим редактирования (true) или добавления (false).
        /// </summary>
        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetField(ref _isEditMode, value);
        }

        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title => IsEditMode ? "Редактировать вино" : "Добавить вино";

        /// <summary>
        /// Списки для ComboBox.
        /// </summary>
        public ObservableCollection<string> WineTypes { get; }
        public ObservableCollection<string> SugarTypes { get; }
        public ObservableCollection<string> Countries { get; }

        /// <summary>
        /// Команды.
        /// </summary>
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public WineEditorViewModel(IWineService wineService, WineDTO wineToEdit = null)
        {
            _wineService = wineService ?? throw new ArgumentNullException(nameof(wineService));

            // Инициализация списков
            WineTypes = new ObservableCollection<string> { "Белое", "Красное" };
            SugarTypes = new ObservableCollection<string> { "Сладкое", "Полусладкое", "Полусухое", "Сухое" };
            Countries = new ObservableCollection<string> { "Франция", "Италия", "Испания", "Россия", "Аргентина" };

            if (wineToEdit != null)
            {
                Wine = wineToEdit;
                IsEditMode = true;
            }
            else
            {
                Wine = new WineDTO();
                IsEditMode = false;
            }

            // Команды
            SaveCommand = new Command(_ => SaveWine(), _ => CanSave());
            CancelCommand = new Command(_ => Cancel());
        }

        private bool CanSave()
        {
            return Wine != null &&
                   !string.IsNullOrWhiteSpace(Wine.Name) &&
                   !string.IsNullOrWhiteSpace(Wine.Type) &&
                   !string.IsNullOrWhiteSpace(Wine.Sugar) &&
                   !string.IsNullOrWhiteSpace(Wine.Homeland);
        }

        private void SaveWine()
        {
            try
            {
                if (IsEditMode)
                {
                    _wineService.ChangeWine(
                        Wine.Name,
                        Wine.Type,
                        Wine.Sugar,
                        Wine.Homeland,
                        Wine.Id);
                }
                else
                {
                    // Проверка на дубликат
                    if (!_wineService.CheckWineInList(
                        Wine.Name,
                        Wine.Type,
                        Wine.Sugar,
                        Wine.Homeland))
                    {
                        ShowMessageRequested?.Invoke("Такое вино уже существует");
                        return;
                    }

                    _wineService.AddWine(
                        Wine.Name,
                        Wine.Type,
                        Wine.Sugar,
                        Wine.Homeland);
                }

                WineSaved?.Invoke(Wine);
                CloseRequested?.Invoke();
            }
            catch (Exception ex)
            {
                ShowMessageRequested?.Invoke($"Ошибка: {ex.Message}");
            }
        }

        private void Cancel()
        {
            CloseRequested?.Invoke();
        }
    }
}
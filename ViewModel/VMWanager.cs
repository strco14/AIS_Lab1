using System;
using System.Collections.Generic;
using DAL;
using ModelLib;
using Shared;

namespace   ViewModel
{
    /// <summary>
    /// Отвечает за создание, инициализацию и показ ViewModel
    /// </summary>
    public class VMWanager : IDisposable
    {
        private static VMWanager _instance;
        private readonly Dictionary<ViewModelBase, object> _viewModels;
        private static readonly object _lock = new object();

        /// <summary>
        /// Событие запроса отображения ViewModel.
        /// </summary>
        public event Action<ViewModelBase> ShowRequested;

        public static VMWanager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new VMWanager();
                    }
                    return _instance;
                }
            }
        }

        private VMWanager()
        {
            _viewModels = new Dictionary<ViewModelBase, object>();
        }

        /// <summary>
        /// Запускает приложение, создавая и инициализируя главную ViewModel.
        /// </summary>
        public void Run()
        {
            // Создаем сервисы
            var repository = new EntityRepository<Wine>();
            var businessLogic = new BusinessLogic(repository);
            var wineService = new WineService(repository, businessLogic);

            // Создаем главную ViewModel
            var mainVm = new MainViewModel(wineService);
            mainVm.Init();

            // Подписываемся на события
            mainVm.OpenRequested += vm => ShowRequested?.Invoke(vm);

            // Показываем главную ViewModel
            ShowRequested?.Invoke(mainVm);
        }

        /// <summary>
        /// Создает ViewModel для редактирования вина
        /// </summary>
        public WineEditorViewModel CreateWineEditorViewModel(IWineService wineService, WineDTO wineToEdit = null)
        {
            return new WineEditorViewModel(wineService, wineToEdit);
        }

        /// <summary>
        /// Создает ViewModel для поиска вин
        /// </summary>
        public SearchViewModel CreateSearchViewModel(IWineService wineService)
        {
            return new SearchViewModel(wineService);
        }

        public void Dispose()
        {
            foreach (var vm in _viewModels.Keys)
            {
                if (vm is IDisposable disposable)
                    disposable.Dispose();
            }
            _viewModels.Clear();
        }
    }
}
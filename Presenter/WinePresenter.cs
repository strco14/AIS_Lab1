using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Shared;
using DAL;
using аис_лаба_1;


namespace Presenter
{
    public class WinePresenter
    {
            private readonly IWineService _wineService;
            private IWineView _view;

            public WinePresenter(IWineService wineService)
            {
                _wineService = wineService ?? throw new ArgumentNullException(nameof(wineService));

            //СОБЫТИЯ ОТ MODEL
                _wineService.WineAdded += OnWineAdded;
                _wineService.WineChanged += OnWineChanged;
                _wineService.WineDeleted += OnWineDeleted;
                _wineService.WineRated += OnWineRated;  
            }

            public void Initialize(IWineView view)
            {
                _view = view ?? throw new ArgumentNullException(nameof(view));

                //СОБЫТИЯ ОТ VIEW
                _view.LoadWinesRequested += OnLoadWinesRequested;
                _view.AddWineRequested += OnAddWineRequested;
                _view.EditWineRequested += OnEditWineRequested;
                _view.DeleteWineRequested += OnDeleteWineRequested;
                _view.SearchWinesRequested += OnSearchWinesRequested;
                _view.RateWineRequested += OnRateWineRequested;
                _view.ShowBestWinesRequested += OnShowBestWinesRequested;
                


                LoadAllWines();
            }

            //СОБЫТИЯ ОТ VIEW
            /// <summary>
            /// загружаем вина
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnLoadWinesRequested(object sender, EventArgs e)
            {
                LoadAllWines();
            }
            /// <summary>
            /// Добавление вина
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnAddWineRequested(object sender, Shared.WineEventArgs e)
            {
                try
                {
                    var wineDto = e.Wine;

                    if (_wineService.CheckWineInList(
                        wineDto.Name,
                        wineDto.Type,
                        wineDto.Sugar,
                        wineDto.Homeland))
                    {
                        _wineService.AddWine(
                            wineDto.Name,
                            wineDto.Type,
                            wineDto.Sugar,
                            wineDto.Homeland);
                    }
                    else
                    {
                        _view.DisplayMessage("Такое вино уже есть в списке", MessageType.Warning);
                    }
                }
                catch (Exception ex)
                {
                    _view.DisplayMessage($"Ошибка добавления: {ex.Message}", MessageType.Error);
                }
            }
            /// <summary>
            /// Изменение вина
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnEditWineRequested(object sender, Shared.WineEventArgs e)
            {
            try
            {
                var wineDto = e.Wine;

                if (!int.TryParse(wineDto.Id, out int wineId))
                {
                    _view.DisplayMessage("Неверный формат ID", MessageType.Error);
                    return;
                }

 
                var existingWine = _wineService.GetWine(wineId);
                if (existingWine[0] == null)
                {
                    _view.DisplayMessage("Вино не найдено", MessageType.Error);
                    return;
                }

                if (_wineService.CheckWineInList(
                    wineDto.Name,
                    wineDto.Type,
                    wineDto.Sugar,
                    wineDto.Homeland))
                {

                    _wineService.ChangeWine(
                        wineDto.Name,
                        wineDto.Type,
                        wineDto.Sugar,
                        wineDto.Homeland,
                        wineId);
                }
                else
                {
                    _view.DisplayMessage("Вино с такими параметрами уже существует", MessageType.Warning);
                }
            }
            catch (Exception ex)
            {
                _view.DisplayMessage($"Ошибка редактирования: {ex.Message}", MessageType.Error);
            }
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            private void OnDeleteWineRequested(object sender, DeleteWineEventArgs e)
            {
            try
            {
                if (!int.TryParse(e.WineId, out int wineId))
                {
                    _view.DisplayMessage("Неверный формат ID", MessageType.Error);
                    return;
                }

                _wineService.RemoveWine(wineId);
            }
            catch (Exception ex)
            {
                _view.DisplayMessage($"Ошибка удаления: {ex.Message}", MessageType.Error);
            }
        }
        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            private void OnSearchWinesRequested(object sender, SearchWineEventArgs e)
            {
                try
                {
                    var criteria = e.Criteria;
                    var result = _wineService.SearchWines(
                        criteria.Name,
                        criteria.Type,
                        criteria.Sugar,
                        criteria.Homeland);

                    DisplayWineArray(result);
                }
                catch (Exception ex)
                {
                    _view.DisplayMessage($"Ошибка поиска: {ex.Message}", MessageType.Error);
                }
            }

            /// <summary>
            /// Оценивание вина
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnRateWineRequested(object sender, RateWineEventArgs e)
            {
            try
            {
                // Парсим ID из строки в int
                if (!int.TryParse(e.WineId, out int wineId))
                {
                    _view.DisplayMessage("Неверный формат ID", MessageType.Error);
                    return;
                }

                _wineService.GetMark(e.Rating, wineId);
            }
            catch (Exception ex)
            {
                _view.DisplayMessage($"Ошибка оценки: {ex.Message}", MessageType.Error);
            }
        }
        /// <summary>
        /// Лучшие вина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            private void OnShowBestWinesRequested(object sender, EventArgs e)
            {
                try
                {
                    var result = _wineService.BestWines();
                    DisplayWineArray(result);
                }
                catch (Exception ex)
                {
                    _view.DisplayMessage($"Ошибка: {ex.Message}", MessageType.Error);
                }
            }

            //ОБРАБОТЧИКИ СОБЫТИЙ ОТ MODEL
            /// <summary>
            /// Добавление
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnWineAdded(object sender, аис_лаба_1.WineEventArgs e)
            {
                _view.DisplayMessage($"Вино '{e.Wine.Name}' успешно добавлено", MessageType.Success);
                LoadAllWines();
            }
        /// <summary>
        /// Изменение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            private void OnWineChanged(object sender, WineChangedEventArgs e)
            {
                _view.DisplayMessage($"Вино #{e.WineId} успешно изменено", MessageType.Success);
                LoadAllWines();
            }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            private void OnWineDeleted(object sender, WineDeletedEventArgs e)
            {
                _view.DisplayMessage($"Вино #{e.WineId} успешно удалено", MessageType.Success);
                LoadAllWines();
            }
        /// <summary>
        /// Оценка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            private void OnWineRated(object sender, WineRatedEventArgs e)
            {
                _view.DisplayMessage($"Вино #{e.WineId} оценено на {e.NewRating}", MessageType.Success);
                LoadAllWines();
            }

        /// <summary>
        /// загрузка всех вин
        /// </summary>
            private void LoadAllWines()
            {
                try
                {
                    var result = _wineService.GetWines();
                    DisplayWineArray(result);
                }
                catch (Exception ex)
                {
                    _view.DisplayMessage($"Ошибка загрузки: {ex.Message}", MessageType.Error);
                }
            }

            private void DisplayWineArray(string[,] wineArray)
            {
                var wineDtos = new List<WineDto>();

                for (int i = 0; i < wineArray.GetLength(0); i++)
                {
                    wineDtos.Add(new WineDto
                    (
                        wineArray[i, 0],
                        wineArray[i, 1],
                        wineArray[i, 2],
                        wineArray[i, 3],
                        wineArray[i, 4],
                        wineArray[i, 5]
                    ));
                }

                _view.DisplayWines(wineDtos);
            }

            // Дополнительный метод для получения View (если нужно)
            public IWineView GetView()
            {
                return _view;
            }
        }
    }

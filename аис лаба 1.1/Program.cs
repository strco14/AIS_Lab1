using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using Ninject;
using Shared;
using static Shared.WineDTO;

namespace аис_лаба_1._1
{
    public class Program : IWineView
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            program.Start();
        }
        private List<WineDTO> _currentWines = new List<WineDTO>();
        private bool _isRunning = true;
        public WineDTO SelectedWine { get; private set; }
        public WineDTO WineToAdd { get; private set; }
        public WineDTO WineToEdit { get; private set; }
        public SearchCriteriaDto SearchCriteria { get; private set; }
        public RatingInfo RatingInfo { get; private set; }

        public event EventHandler LoadWinesRequested;
        public event EventHandler<WineEventArgs> AddWineRequested;
        public event EventHandler<WineEventArgs> EditWineRequested;
        public event EventHandler<DeleteWineEventArgs> DeleteWineRequested;
        public event EventHandler<SearchWineEventArgs> SearchWinesRequested;
        public event EventHandler<RateWineEventArgs> RateWineRequested;
        public event EventHandler ShowBestWinesRequested;
        /// <summary>
        /// запуск консоли
        /// </summary>
        public void Start()
        {
            
            Console.Clear();
            Console.WriteLine("=== КОНСОЛЬНЫЙ ИНТЕРФЕЙС ВИННОГО КАТАЛОГА ===");
            Console.WriteLine("Введите 'help' для списка команд");
            Console.WriteLine();

            while (_isRunning)
            {
                Console.Write("команда> ");
                var command = Console.ReadLine()?.Trim().ToLower();

                ProcessCommand(command);
            }
        }

        private void ProcessCommand(string command)
        {
            switch (command)
            {
                case "help":
                    ShowHelp();
                    break;
                case "list":
                case "l":
                    LoadWinesRequested?.Invoke(this, EventArgs.Empty);
                    break;
                case "add":
                case "a":
                    AddWine();
                    break;
                case "edit":
                case "e":
                    EditWine();
                    break;
                case "delete":
                case "d":
                case "del":
                    DeleteWine();
                    break;
                case "search":
                case "s":
                case "find":
                    SearchWines();
                    break;
                case "rate":
                case "r":
                case "mark":
                    RateWine();
                    break;
                case "best":
                case "b":
                case "top":
                    ShowBestWinesRequested?.Invoke(this, EventArgs.Empty);
                    break;
                default:
                    if (!string.IsNullOrEmpty(command))
                    {
                        DisplayMessage($"Неизвестная команда: '{command}'. Введите 'help'", MessageType.Warning);
                    }
                    break;
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("\n════════════════════ ДОСТУПНЫЕ КОМАНДЫ ════════════════════");
            Console.WriteLine("  list (l)     - Показать все вина");
            Console.WriteLine("  add (a)      - Добавить новое вино");
            Console.WriteLine("  edit (e)     - Редактировать вино");
            Console.WriteLine("  delete (d)   - Удалить вино");
            Console.WriteLine("  search (s)   - Поиск вин по параметрам");
            Console.WriteLine("  rate (r)     - Оценить вино (1-5)");
            Console.WriteLine("  best (b)     - Показать лучшие вина по рейтингу");
            Console.WriteLine("  help         - Показать эту справку");
            Console.WriteLine("═══════════════════════════════════════════════════════════\n");
        }

        private void AddWine()
        {
            Console.WriteLine("\n────────── ДОБАВЛЕНИЕ НОВОГО ВИНА ──────────");

            Console.Write("Название: ");
            string name = Console.ReadLine();

            Console.Write("Тип (Красное/Белое): ");
            string type = Console.ReadLine();

            Console.Write("Сладость (Сладкое/Полусладкое/Полусухое/Сухое): ");
            string sugar = Console.ReadLine();

            Console.Write("Страна: ");
            string country = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(type) &&
                !string.IsNullOrWhiteSpace(sugar) &&
                !string.IsNullOrWhiteSpace(country))
            {
                WineToAdd = new WineDTO
                (
                    name: name,
                    type: type,
                    sugar: sugar,
                    homeland: country
                );

                AddWineRequested?.Invoke(this, new WineEventArgs(WineToAdd));
            }
            else
            {
                DisplayMessage("Все поля должны быть заполнены!", MessageType.Warning);
            }
        }

        private void EditWine()
        {
            Console.Write("\nВведите ID вина для редактирования: ");
            string idInput = Console.ReadLine(); // Получаем как строку

            // Ищем вино по строковому ID
            var wineToEdit = _currentWines.FirstOrDefault(w => w.Id == idInput);

            if (wineToEdit == null)
            {
                DisplayMessage($"Вино с ID {idInput} не найдено", MessageType.Warning);
                return;
            }

            Console.WriteLine($"\nРедактирование вина: {wineToEdit.Name} (ID: {wineToEdit.Id})");
            Console.WriteLine("Оставьте поле пустым, чтобы оставить текущее значение\n");

            Console.Write($"Название [{wineToEdit.Name}]: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                wineToEdit.Name = name;

            Console.Write($"Тип [{wineToEdit.Type}]: ");
            string type = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(type))
                wineToEdit.Type = type;

            Console.Write($"Сладость [{wineToEdit.Sugar}]: ");
            string sugar = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(sugar))
                wineToEdit.Sugar = sugar;

            Console.Write($"Страна [{wineToEdit.Homeland}]: ");
            string country = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(country))
                wineToEdit.Homeland = country;

            WineToEdit = wineToEdit;
            EditWineRequested?.Invoke(this, new WineEventArgs(WineToEdit));
        }

        private void DeleteWine()
        {
            Console.Write("\nВведите ID вина для удаления: ");
            string id = Console.ReadLine(); // Получаем как строку

            if (string.IsNullOrWhiteSpace(id))
            {
                DisplayMessage("Неверный формат ID", MessageType.Error);
                return;
            }

            Console.Write($"Вы уверены, что хотите удалить вино с ID {id}? (y/n): ");
            string confirm = Console.ReadLine()?.ToLower();

            if (confirm == "y" || confirm == "yes")
            {
                DeleteWineRequested?.Invoke(this, new DeleteWineEventArgs(id)); // Передаем строку
            }
            else
            {
                DisplayMessage("Удаление отменено", MessageType.Info);
            }
        }

        private void SearchWines()
        {
            Console.WriteLine("\n────────── ПОИСК ВИН ──────────");
            Console.WriteLine("Оставьте поле пустым, чтобы пропустить критерий\n");

            Console.Write("Название: ");
            string name = Console.ReadLine();

            Console.Write("Тип: ");
            string type = Console.ReadLine();

            Console.Write("Сладость: ");
            string sugar = Console.ReadLine();

            Console.Write("Страна: ");
            string country = Console.ReadLine();

            SearchCriteria = new   SearchCriteriaDto
            {
                Name = string.IsNullOrWhiteSpace(name) ? null : name,
                Type = string.IsNullOrWhiteSpace(type) ? null : type,
                Sugar = string.IsNullOrWhiteSpace(sugar) ? null : sugar,
                Country = string.IsNullOrWhiteSpace(country) ? null : country
            };

            SearchWinesRequested?.Invoke(this, new SearchWineEventArgs(SearchCriteria));
        }

        private void RateWine()
        {
            Console.WriteLine("\n────────── ОЦЕНКА ВИНА ──────────");

            // 1. Сначала показываем список вин
            DisplayWines(_currentWines);

            // 2. Просим выбрать ID вина
            Console.Write("\nВведите ID вина для оценки: ");
            string id = Console.ReadLine(); // Получаем как строку

            // 3. Ищем вино
            var wineToRate = _currentWines.FirstOrDefault(w => w.Id == id); // Сравниваем строки
            if (wineToRate == null)
            {
                DisplayMessage($"Вино с ID {id} не найдено", MessageType.Warning);
                return;
            }

            Console.WriteLine($"\nВы выбрали: {wineToRate.Name} ({wineToRate.Type}, {wineToRate.Homeland})");
            Console.WriteLine($"Текущая оценка: {wineToRate.Rating}/5");

            // 4. Просим ввести новую оценку
            Console.Write("\nВведите новую оценку (1-5): ");
            if (!int.TryParse(Console.ReadLine(), out int rating) || rating < 1 || rating > 5)
            {
                DisplayMessage("Оценка должна быть от 1 до 5", MessageType.Error);
                return;
            }

            // 5. Подтверждение
            Console.Write($"\nПоставить оценку {rating} вину '{wineToRate.Name}'? (y/n): ");
            string confirm = Console.ReadLine()?.ToLower();

            if (confirm == "y" || confirm == "yes")
            {
                // 6. Создаем RatingInfo и вызываем событие
                RatingInfo = new RatingInfo
                {
                    WineId = id, // Используем строковый ID
                    Rating = rating
                };

                RateWineRequested?.Invoke(this, new RateWineEventArgs(RatingInfo.WineId, RatingInfo.Rating));
                DisplayMessage($"Вино '{wineToRate.Name}' оценено на {rating}", MessageType.Success);
            }
            else
            {
                DisplayMessage("Оценка отменена", MessageType.Info);
            }
        }

        // ========== МЕТОДЫ IWineView ==========
        public void DisplayWines(IEnumerable<WineDTO> wines)
        {
            _currentWines = wines.ToList();

            //Console.Clear();
            Console.WriteLine("=== СПИСОК ВИН ===\n");

            foreach (var wine in _currentWines)
            {
                // Максимально просто
                Console.WriteLine($"ID: {wine.Id} | {wine.Name} | {wine.Type} | {wine.Sugar} | {wine.Homeland} | Оценка: {wine.Rating}/5");
            }

            Console.WriteLine($"\nВсего: {_currentWines.Count} вин");
            Console.WriteLine("Для оценки вина используйте команду: rate");
        }

        public void DisplayMessage(string message, MessageType type)
        {
            ConsoleColor color;

            // Обычный switch вместо switch expression
            switch (type)
            {
                case MessageType.Success:
                    color = ConsoleColor.Green;
                    break;
                case MessageType.Warning:
                    color = ConsoleColor.Yellow;
                    break;
                case MessageType.Error:
                    color = ConsoleColor.Red;
                    break;
                default:
                    color = ConsoleColor.White;
                    break;
            }

            Console.ForegroundColor = color;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        public void ClearWinesDisplay()
        {
            _currentWines.Clear();
            Console.Clear();
        }
    }
}



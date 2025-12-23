//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using BL;
//using DAL;
//using ModelLib;
//using Ninject;
//using Shared;
//using аис_лаба_1;

//namespace Presenter
//{
//    class Program
//    {
//        [STAThread]
//        public static void Main(string[] args)
//        {
//            try
//            {
//                Console.WriteLine("=== НАЧАЛО Main ===");
//                Console.WriteLine("ВЫБЕРИТЕ ИНТЕРФЕЙС ДЛЯ ЗАПУСКА:");
//                Console.WriteLine("1. Windows Forms (графический интерфейс)");
//                Console.WriteLine("2. Консольный интерфейс");
//                var choice = Console.ReadLine();
//                Console.WriteLine($"Выбрано: {choice}");

//                // Шаг 2: Создание Ninject
//                Console.WriteLine("Шаг 2: Создание Ninject Kernel");
//                IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
//                Console.WriteLine("Ninject Kernel создан");

//                // Шаг 3: Запуск выбранного интерфейса
//                Console.WriteLine("Шаг 3: Запуск выбранного интерфейса");
//                if (choice == "1")
//                {
//                    Console.WriteLine("Запуск Windows Forms...");
//                    LaunchWinForms(ninjectKernel);
//                }
//                else
//                {
//                    Console.WriteLine("Запуск консольного интерфейса...");
//                    Console.WriteLine("Перед вызовом LaunchConsole");
//                    Console.WriteLine($"Kernel is null: {ninjectKernel == null}");

//                    try
//                    {
//                        LaunchConsole(ninjectKernel);
//                        Console.WriteLine("После вызова LaunchConsole");
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine($"Исключение при вызове LaunchConsole: {ex}");
//                        Console.WriteLine($"StackTrace: {ex.StackTrace}");
//                        Console.ReadLine();
//                    }

//                    Console.WriteLine("=== КОНЕЦ Main ===");
//                    Console.ReadLine();
//                    //LaunchConsole(ninjectKernel);
//                }

//                Console.WriteLine("=== КОНЕЦ Main ===");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"КРИТИЧЕСКАЯ ОШИБКА: {ex}");
//                Console.WriteLine($"StackTrace: {ex.StackTrace}");
//                Console.ReadKey();
//            }

//        }
//        /// <summary>
//        /// подключение к винформам
//        /// </summary>
//        /// <param name="kernel"></param>
//        static void LaunchWinForms(IKernel kernel)
//        {
//            try
//            {
//                Console.WriteLine("LaunchWinForms: Начало");
//                kernel.Bind<IWineView>().To<Form1>().InSingletonScope();

//                var wineService = kernel.Get<IWineService>();
//                var view = kernel.Get<IWineView>();


//                var presenter = new WinePresenter(wineService);
//                presenter.Initialize(view);

//                System.Windows.Forms.Application.Run((Form1)view);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"ОШИБКА В LaunchWinForms: {ex}");
//                throw;
//            }
//        }
//        /// <summary>
//        /// подключение к консоли
//        /// </summary>
//        /// <param name="kernel"></param>
//        static void LaunchConsole(IKernel kernel)
//        {
//            Console.WriteLine("\n=== LaunchConsole НАЧАЛО ===");

//            try
//            {
//                Console.WriteLine("1. Регистрация IWineView...");
//                kernel.Bind<IWineView>().To<аис_лаба_1._1.Program>().InSingletonScope();
//                Console.WriteLine("   IWineView зарегистрирован");

//                Console.WriteLine("2. Получение WineService...");
//                var wineService = kernel.Get<IWineService>();
//                Console.WriteLine($"   WineService получен, тип: {wineService.GetType().Name}");

//                Console.WriteLine("3. Получение View...");
//                var view = kernel.Get<IWineView>();
//                Console.WriteLine($"   View получен, тип: {view.GetType().Name}");

//                Console.WriteLine("4. Создание Presenter...");
//                var presenter = new WinePresenter(wineService);
//                Console.WriteLine("   Presenter создан");

//                Console.WriteLine("5. Инициализация Presenter...");
//                presenter.Initialize(view);
//                Console.WriteLine("   Presenter инициализирован");

//                Console.WriteLine("6. Запуск View.Start()...");
//                ((аис_лаба_1._1.Program)view).Start();

//                Console.WriteLine("7. Возврат из View.Start()");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"\n!!! ОШИБКА В LaunchConsole: {ex.GetType().Name}: {ex.Message}");
//                Console.WriteLine($"StackTrace:\n{ex.StackTrace}");

//                if (ex.InnerException != null)
//                {
//                    Console.WriteLine($"\nInner Exception: {ex.InnerException.GetType().Name}: {ex.InnerException.Message}");
//                    Console.WriteLine($"Inner StackTrace:\n{ex.InnerException.StackTrace}");
//                }

//                Console.WriteLine("\nНажмите Enter для выхода...");
//                Console.ReadLine();
//                throw;
//            }

//            Console.WriteLine("=== LaunchConsole КОНЕЦ ===\n");
//            Console.WriteLine("Нажмите Enter для выхода...");
//            Console.ReadLine();
//        }
//    }
//    }

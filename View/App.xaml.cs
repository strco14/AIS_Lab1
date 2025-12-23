using System.Windows;
using ViewModel;
using ModelLib;
using DAL;
using Shared;

namespace View
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаем VMManager и подписываемся на события
            var vmManager = VMWanager.Instance;
            vmManager.ShowRequested += vm => ViewManager.Instance.Show(vm);

            // Запускаем приложение
            vmManager.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            VMWanager.Instance?.Dispose();
            base.OnExit(e);
        }
    }
}
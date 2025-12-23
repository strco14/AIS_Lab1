using System.Windows;
using ViewModel;
using ModelLib;
using DAL;
using Shared;

namespace View
{
    /// <summary>
    /// Базовое окно для всех View.
    /// </summary>
    public partial class BaseView : Window
    {
        public BaseView()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
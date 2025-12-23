using System.Windows;
using ViewModel;
using ModelLib;
using DAL;
using Shared;

namespace View
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            // ТОЛЬКО инициализация DataContext
            DataContext = new MainViewModel();
        }
    }
}
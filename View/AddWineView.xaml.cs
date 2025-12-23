using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel;
using ModelLib;
using DAL;
using Shared;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для AddWineView.xaml
    /// </summary>
    public partial class AddWineView : BaseView
    {
        public AddWineView()
        {
            InitializeComponent();
            if (DataContext is WineEditorViewModel viewModel)
            {
                viewModel.ShowError = (message, title) =>
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);

                viewModel.RequestClose += (s, e) => this.Close();
            }
        }
    }
}

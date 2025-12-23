using System;
using System.Collections.Generic;
using System.Windows;
using ViewModel;
using ModelLib;
using DAL;
using Shared;

namespace View
{
    /// <summary>
    /// Менеджер представлений (View).
    /// Реализует логику сопоставления ViewModel и соответствующих окон (Window)
    /// Отвечает за создание, показ и повторную активацию окон.
    /// </summary>
    public class ViewManager
    {
        private static ViewManager _instance;

        /// <summary>
        /// Словарь сопоставления ViewModel и окон View.
        /// </summary>
        private static readonly Dictionary<ViewModelBase, Window> V_VM_Comparator
            = new Dictionary<ViewModelBase, Window>(new VMComparer());

        public static ViewManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewManager();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Отображает View для переданной ViewModel.
        /// Если окно для данной ViewModel уже существует — активирует его,
        /// иначе создаёт новое и связывает с ViewModel.
        /// </summary>
        public void Show(ViewModelBase vm)
        {
            if (V_VM_Comparator.ContainsKey(vm))
            {
                V_VM_Comparator[vm].Activate();
                return;
            }

            Window view = CreateView(vm);

            view.DataContext = vm;
            V_VM_Comparator[vm] = view;

            HookEvents(vm, view);
            view.Show();
        }

        /// <summary>
        /// Создаёт соответствующее окно View для переданной ViewModel.
        /// </summary>
        private Window CreateView(ViewModelBase vm)
        {
            if (vm is MainViewModel)
                return new MainView();

            if (vm is WineEditorViewModel)
                return new AddWineView();

            if (vm is SearchViewModel)
                return new SearchWineView();

            throw new Exception($"Нет View для {vm.GetType().Name}");
        }

        /// <summary>
        /// Подписывает окно на события ViewModel
        /// </summary>
        private void HookEvents(ViewModelBase vm, Window view)
        {
            if (vm is MainViewModel mainVm)
            {
                mainVm.ShowMessageRequested += msg =>
                    MessageBox.Show(msg, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (vm is WineEditorViewModel editorVm)
            {
                editorVm.CloseRequested += () =>
                {
                    view.Close();
                    V_VM_Comparator.Remove(editorVm);
                };

                editorVm.ShowMessageRequested += msg =>
                    MessageBox.Show(msg, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (vm is SearchViewModel searchVm)
            {
                searchVm.CloseRequested += () =>
                {
                    view.Close();
                    V_VM_Comparator.Remove(searchVm);
                };
            }
        }
    }
}
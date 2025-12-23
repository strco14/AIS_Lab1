using System;
using System.Windows.Input;

namespace ViewModel
{
    /// <summary>
    /// Реализация паттерна «Команда».
    /// Используется для связывания действий интерфейса
    /// с логикой ViewModel в WPF.
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Создаёт новую команду.
        /// </summary>
        /// <param name="execute">Действие команды.</param>
        /// <param name="canExecute">Условие доступности команды.</param>
        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Проверяет, можно ли выполнить команду.
        /// </summary>
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        public void Execute(object parameter) => _execute(parameter);

        /// <summary>
        /// Уведомляет интерфейс об изменении состояния команды.
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
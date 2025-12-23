using System;
using System.Collections.Generic;

namespace ViewModel
{
    /// <summary>
    /// Используется для сравнения ViewModel по их типу,
    /// обеспечивая правило "одно окно на один тип ViewModel".
    /// </summary>
    public class VMComparer : IEqualityComparer<ViewModelBase>
    {
        /// <summary>
        /// Сравнивает два ViewModel по типу.
        /// </summary>
        public bool Equals(ViewModelBase x, ViewModelBase y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.GetType() == y.GetType();
        }

        /// <summary>
        /// Возвращает хэш-код типа ViewModel.
        /// </summary>
        public int GetHashCode(ViewModelBase obj)
        {
            if (obj is null) return 0;
            return obj.GetType().GetHashCode();
        }
    }
}
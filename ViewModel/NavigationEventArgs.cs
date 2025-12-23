using System;

namespace ViewModel
{
    public class NavigationEventArgs : EventArgs
    {
        public NavigationTarget Target { get; }

        public NavigationEventArgs(NavigationTarget target)
        {
            Target = target;
        }
    }

    public enum NavigationTarget
    {
        AddWine,
        EditWine,
        Search,
        BestWines
    }
}
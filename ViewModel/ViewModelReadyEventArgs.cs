using System;

namespace ViewModel
{
    public class ViewModelReadyEventArgs : EventArgs
    {
        public ViewModelBase ViewModel { get; }

        public ViewModelReadyEventArgs(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
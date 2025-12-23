using System;

namespace ViewModel
{
    public class StatusChangedEventArgs : EventArgs
    {
        public string Message { get; }
        public bool IsError { get; }

        public StatusChangedEventArgs(string message, bool isError)
        {
            Message = message;
            IsError = isError;
        }
    }
}
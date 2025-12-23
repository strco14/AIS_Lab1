using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    public class WineDTO : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _type;
        private string _sugar;
        private string _homeland;
        private int _rating;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Sugar
        {
            get => _sugar;
            set
            {
                if (_sugar != value)
                {
                    _sugar = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Homeland
        {
            get => _homeland;
            set
            {
                if (_homeland != value)
                {
                    _homeland = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Rating
        {
            get => _rating;
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    OnPropertyChanged();
                }
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // Переопределение ToString для удобства отладки
        public override string ToString()
        {
            return $"{Name} ({Type}, {Sugar}, {Homeland}) - Оценка: {Rating}";
        }
    }
    public class WineEventArgs : EventArgs
    {
        public WineDTO Wine { get; }
        public WineEventArgs(WineDTO wine) => Wine = wine;
    }
    public class SearchCriteriaDto : INotifyPropertyChanged
        {
            private string _name;
            private string _type;
            private string _sugar;
            private string _country;

            public event PropertyChangedEventHandler PropertyChanged;

            public string Name
            {
                get => _name;
                set
                {
                    if (_name != value)
                    {
                        _name = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Type
            {
                get => _type;
                set
                {
                    if (_type != value)
                    {
                        _type = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Sugar
            {
                get => _sugar;
                set
                {
                    if (_sugar != value)
                    {
                        _sugar = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Country
            {
                get => _country;
                set
                {
                    if (_country != value)
                    {
                        _country = value;
                        OnPropertyChanged();
                    }
                }
            }

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
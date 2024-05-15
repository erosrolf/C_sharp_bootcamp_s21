using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace rush00.App.DataModel
{
    public class HabitCheck : INotifyPropertyChanged
    {
        private bool _isChecked;
        public DateTimeOffset Date { get; set; }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (value != _isChecked)
                {
                    _isChecked = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
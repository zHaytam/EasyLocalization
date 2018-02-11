using System.ComponentModel;
using System.Runtime.CompilerServices;
using EasyLocalization.Annotations;

namespace EasyLocalization.Demo
{
    public class MainViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Fields

        private string _key = "Key22";
        private int _value = 0;

        #endregion

        #region Properties

        public string Key
        {
            get => _key;
            set
            {
                if (_key == value)
                    return;

                _key = value;
                OnPropertyChanged();
            }
        }

        public int Value
        {
            get => _value;
            set
            {
                if (_value == value)
                    return;

                _value = value;
                OnPropertyChanged();
            }
        }

        #endregion

    }
}

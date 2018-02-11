using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using EasyLocalization.Annotations;
using EasyLocalization.Readers;

namespace EasyLocalization.Localization
{
    public class LocalizationManager : INotifyPropertyChanged
    {

        #region Singleton

        private static LocalizationManager _instance;

        public static LocalizationManager Instance => _instance ?? (_instance = new LocalizationManager());

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Fields

        private readonly Dictionary<CultureInfo, List<LocalizationEntry>> _languageEntries = new Dictionary<CultureInfo, List<LocalizationEntry>>();
        private CultureInfo _currentCulture;

        #endregion

        #region Properties

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture.Equals(value))
                    return;

                _currentCulture = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Public Methods

        public void AddCulture(CultureInfo culture, FileReader reader, bool choose)
        {
            if (_languageEntries.ContainsKey(culture))
            {
                // If the culture is already registered, re-set its value
                _languageEntries[culture] = reader.GetEntries();
            }
            else
            {
                _languageEntries.Add(culture, reader.GetEntries());
            }

            if (choose)
            {
                CurrentCulture = culture;
            }
        }

        

        #endregion

        
    }
}

using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace EasyLocalization.Localization
{
    public class LocalizationConverter : IMultiValueConverter
    {

        #region Fields

        private string _key;
        private string _alternativeKey;

        #endregion

        public LocalizationConverter(string key, string alternativeKey)
        {
            _key = key;
            _alternativeKey = alternativeKey;
        }

        #region Public Methods

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object key;
            int count;

            switch (values.Length)
            {
                default:
                    // (1) CultureInfo
                    return LocalizationManager.Instance.GetValue(_key) ?? LocalizationManager.Instance.GetValue(_alternativeKey, false);
                case 2:
                    // (2) CultureInfo + KeySource or CultureInfo + CountSource
                    key = values.FirstOrDefault(v => v is string);

                    if (key == null)
                    {
                        // CultureInfo + CountSource
                        count = System.Convert.ToInt32(values.First(v => !(v is CultureInfo)));
                        return LocalizationManager.Instance.GetValue(_key, count) ?? LocalizationManager.Instance.GetValue(_alternativeKey, count, false);
                    }
                    else
                    {
                        // CultureInfo + KeySource
                        return LocalizationManager.Instance.GetValue(key.ToString()) ?? LocalizationManager.Instance.GetValue(_alternativeKey, false);
                    }
                case 3:
                    // (3) CultureInfo + KeySource + CountSource
                    key = values.First(v => v is string);
                    count = System.Convert.ToInt32(values.First(v => v != key && !(v is CultureInfo)));
                    return LocalizationManager.Instance.GetValue(key.ToString(), count) ?? LocalizationManager.Instance.GetValue(_alternativeKey, count, false);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

namespace EasyLocalization.Localization
{
    public class LocalizationEntry
    {

        #region Properties

        public string Key { get; internal set; }
        
        public string Value { get; }

        public string ZeroValue { get; }

        public string PluralValue { get; }

        #endregion

        public LocalizationEntry(string key, string value, string zeroValue = null, string pluralValue = null)
        {
            Key = key;
            Value = value;
            ZeroValue = zeroValue;
            PluralValue = pluralValue;
        }

    }
}

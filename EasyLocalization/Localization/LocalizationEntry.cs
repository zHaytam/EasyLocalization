namespace EasyLocalization.Localization
{
    public class LocalizationEntry
    {

        #region Properties
        
        public string Value { get; }

        public string ZeroValue { get; }

        public string PluralValue { get; }

        #endregion

        public LocalizationEntry(string value, string zeroValue = null, string pluralValue = null)
        {
            Value = value;
            ZeroValue = zeroValue;
            PluralValue = pluralValue;
        }

    }
}

using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace EasyLocalization.Localization
{
    public class LocalizeExtension : MarkupExtension
    {

        #region Properties

        public string Key { get; set; }

        public Binding KeySource { get; set; }

        public Binding CountSource { get; set; }

        #endregion

        public LocalizeExtension() { }

        public LocalizeExtension(string key, Binding countSource)
        {
            Key = key;
            CountSource = countSource;
        }

        public LocalizeExtension(Binding keySource, Binding countSource)
        {
            KeySource = keySource;
            CountSource = countSource;
        }

        #region Public Methods

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return null;
        }

        #endregion

    }
}
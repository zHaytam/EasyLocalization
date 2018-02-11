using System;
using System.Windows;
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

        public LocalizeExtension(string key)
        {
            Key = key;
        }

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
            var provideValueTarget = serviceProvider as IProvideValueTarget;
            var targetObject = provideValueTarget?.TargetObject as FrameworkElement;
            var targetProperty = provideValueTarget?.TargetProperty as DependencyProperty;
            string alternativeKey = $"{targetObject?.Name}_{targetProperty?.Name}";

            var multiBinding = new MultiBinding
            {
                Converter = new LocalizationConverter(Key, alternativeKey),
                NotifyOnSourceUpdated = true
            };

            multiBinding.Bindings.Add(new Binding
            {
                Source = LocalizationManager.Instance,
                Path = new PropertyPath("CurrentCulture")
            });

            if (KeySource != null)
            {
                multiBinding.Bindings.Add(KeySource);
            }

            if (CountSource != null)
            {
                multiBinding.Bindings.Add(CountSource);
            }

            return multiBinding.ProvideValue(serviceProvider);
        }

        #endregion

    }
}
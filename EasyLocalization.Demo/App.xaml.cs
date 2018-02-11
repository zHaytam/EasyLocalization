using System.Globalization;
using System.Windows;
using EasyLocalization.Localization;
using EasyLocalization.Readers;

namespace EasyLocalization.Demo
{
    public partial class App
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LocalizationManager.Instance.AddCulture(CultureInfo.GetCultureInfo("en-US"), new CharSeperatedFileReader("Resources/en-US.txt"), true);
            LocalizationManager.Instance.AddCulture(CultureInfo.GetCultureInfo("es-ES"), new XmlFileReader("Resources/es-ES.xml"));
            LocalizationManager.Instance.AddCulture(CultureInfo.GetCultureInfo("fr"), new JsonFileReader("Resources/fr.json"));
        }

    }
}

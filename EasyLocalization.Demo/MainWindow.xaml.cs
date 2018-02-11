using System.Windows;
using EasyLocalization.Localization;

namespace EasyLocalization.Demo
{
    public partial class MainWindow
    {

        private int _index;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var availableCultures = LocalizationManager.Instance.AvailableCultures;
            _index++;

            if (_index == availableCultures.Count)
                _index = 0;

            LocalizationManager.Instance.CurrentCulture = availableCultures[_index];
        }

    }
}

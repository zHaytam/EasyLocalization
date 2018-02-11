using System.Windows;
using EasyLocalization.Readers;

namespace EasyLocalization.Demo
{
    public partial class App
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //var x = new CharSeperatedFileReader("Resources/CharSeperatedFile.txt");
            //x.GetEntries();

            var x = new JsonFileReader("Resources/JsonFile.json");
            x.GetEntries();
        }

    }
}

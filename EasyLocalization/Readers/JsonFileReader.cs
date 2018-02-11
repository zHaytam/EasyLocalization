using System.Collections.Generic;
using System.IO;
using EasyLocalization.Localization;
using Newtonsoft.Json;

namespace EasyLocalization.Readers
{
    public class JsonFileReader : FileReader
    {

        public JsonFileReader(string path) : base(path) { }

        #region Public Methods

        internal override Dictionary<string, LocalizationEntry> GetEntries()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, LocalizationEntry>>(File.ReadAllText(Path));
        }

        #endregion

    }
}

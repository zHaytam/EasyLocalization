using System.Collections.Generic;
using System.IO;
using EasyLocalization.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyLocalization.Readers
{
    public class JsonFileReader : FileReader
    {

        public JsonFileReader(string path) : base(path) { }

        #region Public Methods

        public override List<LocalizationEntry> GetEntries()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(File.ReadAllText(Path));
            var entries = new List<LocalizationEntry>();

            foreach (var kvp in dict)
            {
                var entry = kvp.Value.ToObject<LocalizationEntry>();
                entry.Key = kvp.Key;
                entries.Add(entry);
            }

            return entries;
        }

        #endregion

    }
}

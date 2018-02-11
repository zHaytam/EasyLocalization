using System.Collections.Generic;
using System.IO;
using System.Xml;
using EasyLocalization.Localization;

namespace EasyLocalization.Readers
{
    public class XmlFileReader : FileReader
    {

        public XmlFileReader(string path) : base(path) { }

        #region Public Methods

        internal override List<LocalizationEntry> GetEntries()
        {
            var entries = new List<LocalizationEntry>();
            var doc = new XmlDocument();
            doc.Load(Path);

            var entryNodes = doc.SelectNodes("//Entry");
            if (entryNodes == null)
                throw new FileFormatException("Invalid xml file.");

            foreach (XmlNode entry in entryNodes)
            {
                var keyAttr = entry.Attributes?["key"];
                if (keyAttr == null)
                    throw new FileFormatException("All entries must have a 'key' attribute.");

                string key = keyAttr.Value;
                var valueNode = entry.SelectSingleNode("Value");

                if (valueNode == null)
                {
                    // If theere is no Value node, we'll take the InnerText instead
                    entries.Add(new LocalizationEntry(key, entry.InnerText.Trim()));
                }
                else
                {
                    var zeroValueNode = entry.SelectSingleNode("ZeroValue");
                    var pluralValueNode = entry.SelectSingleNode("PluralValue");
                    entries.Add(new LocalizationEntry(key, valueNode.InnerText, zeroValueNode?.InnerText, pluralValueNode?.InnerText));
                }

            }

            return entries;
        }

        #endregion

    }
}

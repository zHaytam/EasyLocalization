using System.Collections.Generic;
using System.IO;
using EasyLocalization.Localization;

namespace EasyLocalization.Readers
{
    public class CharSeperatedFileReader : FileReader
    {

        #region Fields

        private readonly char _separator;

        #endregion

        public CharSeperatedFileReader(string path, char separator = ';') : base(path)
        {
            _separator = separator;
        }

        #region Public Methods

        internal override Dictionary<string, LocalizationEntry> GetEntries()
        {
            var entries = new Dictionary<string, LocalizationEntry>();

            using (StreamReader sr = File.OpenText(Path))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var splitted = line.Split(_separator);

                    // Each line needs to have at least 2 values (key, value)
                    if (splitted.Length == 1)
                        throw new FileFormatException($"Each line needs to have at least 2 values (line: {line})");

                    switch (splitted.Length)
                    {
                        default:
                            entries.Add(splitted[0], new LocalizationEntry(splitted[1]));
                            break;
                        case 3:
                            entries.Add(splitted[0], new LocalizationEntry(splitted[1], splitted[2]));
                            break;
                        case 4:
                            entries.Add(splitted[0], new LocalizationEntry(splitted[1], splitted[2], splitted[3]));
                            break;
                    }
                }
            }

            return entries;
        }

        #endregion

    }
}
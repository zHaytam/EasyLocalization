using System.Collections.Generic;
using System.IO;
using EasyLocalization.Localization;

namespace EasyLocalization.Readers
{
    public abstract class FileReader
    {

        #region Fields

        protected string Path;

        #endregion

        protected FileReader(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File '{path}' not found.", path);

            Path = path;
        }

        #region Abstract Methods

        internal abstract Dictionary<string, LocalizationEntry> GetEntries();

        #endregion

    }
}

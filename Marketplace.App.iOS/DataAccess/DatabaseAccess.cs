using System;
using System.IO;
using Marketplace.App.Runtime;
using Marketplace.App.Runtime.Interface;

namespace Marketplace.App.iOS
{
    public class DatabaseAccess: IDataBaseAccess
    {
        public string DatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            string finalPath = "";

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            finalPath = Path.Combine(libFolder, "Markeplacet.db");

            return finalPath;
        }
    }
}

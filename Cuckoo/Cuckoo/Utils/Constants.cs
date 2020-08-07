using Cuckoo.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cuckoo.Utils
{
    public class Constants
    {
        public const string DatabaseFilename = "Cuckoo.db3";

        public const SQLite.SQLiteOpenFlags DatabaseFlags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        public const string LoginBannerPngFileName = "login_banner.png";
    }
}

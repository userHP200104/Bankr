using System;
namespace Bankr.Services
{
	public class FileAccessHelper
	{
        // helper function get our local file path: (db related)

        public static string GetLocalFielPath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }

        public FileAccessHelper()
        {
        }
    }
}


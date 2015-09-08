using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DataHelper.Helpers
{
    public sealed class StorageHelper
    {
        //and we can user Roaming;
        
        //Local Operate to Folder or File      
        static StorageFolder LocalStorageFolder = ApplicationData.Current.LocalFolder;

        //Local Setting for Save or Get Setting Value
        static ApplicationDataContainer LocalStorageSettiings = ApplicationData.Current.LocalSettings;
        
        //Set Settings with key/value to Settings
        public static void SetValueWithKey(string key, object value)
        {
            if (LocalStorageSettiings.Values.ContainsKey(key))
            {
                LocalStorageSettiings.Values[key] = value;
            }
            else
            {
                LocalStorageSettiings.Values.Add(key, value);
            }
        }

        //Get Value from settings
        public static object GetValueWithKey(string key)
        {
            if (LocalStorageSettiings.Values.ContainsKey(key))
            {
                var value = LocalStorageSettiings.Values[key];
                if (value != null)
                    return value;
                else
                    return null;
            }
            else
                return null;
        }

        //public static async IEnumerable<StorageFile> GetAllFiles()
        //{ 
        //    var folders = await LocalStorageFolder.GetFoldersAsync();
        //    if (folders != null)
        //    {
        //        foreach (var folder in folders)
        //        {
        //            var files = await folder.GetFilesAsync();
        //            if (files != null)
        //            {
        //                foreach (var file in files)
        //                {
        //                    yield return file;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace DataHelperLib.Helpers
{
    public sealed class StorageHelper
    {
        //and we can user Roaming;

        //Local Operate to Folder or File      
        static StorageFolder LocalStorageFolder = ApplicationData.Current.LocalFolder;
        
        //Local Setting for Save or Get Setting Value
        static ApplicationDataContainer LocalStorageSettiings = ApplicationData.Current.LocalSettings;

        #region ------ Some Static Method About LocalSetting for Read Value form Key / Set Value With Key -----
        
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

        #endregion

        #region -------------序列化ViewModel等进行保存 

        #endregion

        public static async void SaveViewModel(string viewModelName, object value)
        {
            StorageFile file = await LocalStorageFolder.CreateFileAsync(viewModelName,
                CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(file, CommonHelper.XmlSerializer(value));
        }

        public static async Task<T> GetViewModel<T>(string viewmodelName)
        {
            try
            {
                StorageFile file = await LocalStorageFolder.GetFileAsync(viewmodelName);
                String result = await FileIO.ReadTextAsync(file);
                return CommonHelper.XmlDeserializer<T>(result);
            }
            catch (FileNotFoundException e)
            {
                return default(T);
            }
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

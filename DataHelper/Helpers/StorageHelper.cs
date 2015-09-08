using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DataHelper.Helpers
{
    public class StorageHelper
    {
        static StorageFolder LocalStorageFolder = ApplicationData.Current.LocalFolder;
        static ApplicationDataContainer LocalStorageSettiings = ApplicationData.Current.LocalSettings;

        public static void SetValue()
        {
           
        }
    }
}

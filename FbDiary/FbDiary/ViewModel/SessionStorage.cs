using FbDiary.Model;
using FbDiary.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbDiary.ViewModel
{
    class SessionStorage
    {
        List<UserStatusInfo> statusList = new List<UserStatusInfo>();
        /// <summary>
        /// Save status in Isolated Storage
        /// </summary>
        public static void SaveStatus(List<Datum> list, String listFileName)
        {
            using (IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!myStore.DirectoryExists(AppConstants.DiaryDB))
                    myStore.CreateDirectory(AppConstants.DiaryDB);

                string fileName = AppConstants.DiaryDB + "\\" + listFileName;

                if (myStore.FileExists(fileName))
                    myStore.DeleteFile(fileName);

                if (!myStore.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream myStream = new IsolatedStorageFileStream(fileName, FileMode.Create, myStore))
                    {
                        using(StreamWriter writer = new StreamWriter(myStream))
                        {
                            writer.Write(list);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Load status from Isolated Storage
        /// </summary>
        public static List<Datum> LoadStatus(List<Datum> list, String listFileName)
        {
            List<Datum> listFinal = new List<Datum>();

            using (IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!myStore.DirectoryExists(AppConstants.DiaryDB))
                    myStore.CreateDirectory(AppConstants.DiaryDB);

                string fileName = AppConstants.DiaryDB + "\\" + listFileName;

                if (myStore.FileExists(fileName))
                    myStore.DeleteFile(fileName);

                if (!myStore.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream myStream = new IsolatedStorageFileStream(fileName, FileMode.OpenOrCreate,myStore))
                    {
                        using (StreamReader reader = new StreamReader(myStream))
                        {
                            listFinal = list;
                        }
                    }
                }
            }
            return listFinal;
        }
    }
}

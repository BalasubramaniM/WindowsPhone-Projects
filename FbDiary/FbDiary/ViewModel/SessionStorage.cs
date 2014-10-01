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
        public static void SaveStatus(UserStatusInfo data)
        {
            using (IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!myStore.DirectoryExists(AppConstants.DiaryDB))
                    myStore.CreateDirectory(AppConstants.DiaryDB);

                string fileName = AppConstants.DiaryDB + "\\" + AppConstants.DiaryStatusFolder;

                if (myStore.FileExists(fileName))
                    myStore.DeleteFile(fileName);

                if (!myStore.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream myStream = new IsolatedStorageFileStream(fileName, FileMode.Create, myStore))
                    {

                    }
                }
            }
        }
    }
    class SessionStorage
    {
    }
}

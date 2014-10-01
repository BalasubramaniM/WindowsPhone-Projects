using FbDiary.Model;
using FbDiary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbDiary.ViewModel
{
    class ReadStatusViewModel
    {
        public static List<Datum> VeryHappyList, HappyList, OkList, SadList, VerySadList, NoCategoryList;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReadStatusViewModel()
        {
            VeryHappyList = new List<Datum>();
            HappyList = new List<Datum>();
            OkList = new List<Datum>();
            SadList = new List<Datum>();
            VerySadList = new List<Datum>();
            NoCategoryList = new List<Datum>();
        }

        /// <summary>
        /// Read status from Facebook and separate them into list
        /// </summary>
        public void ReadStatus(UserStatusInfo Data)
        {
            int dataCount = Data.Feed.Data.Count();

            for (int i = 0; i < dataCount; i++)
            {
                string statusMessage = Data.Feed.Data[i].Message;
                if (statusMessage != null)
                {
                    try
                    {
                        if (statusMessage.Contains("#fb5"))
                            StatusMessage(i, Data, VeryHappyList);

                        else if (statusMessage.Contains("#fb4"))
                            StatusMessage(i, Data, HappyList);

                        else if (statusMessage.Contains("#fb3"))
                            StatusMessage(i, Data, OkList);

                        else if (statusMessage.Contains("#fb2"))
                            StatusMessage(i, Data, SadList);

                        else if (statusMessage.Contains("#fb1"))
                            StatusMessage(i, Data, VerySadList);

                        else
                            StatusMessage(i, Data, NoCategoryList);
                    }
                    catch(Exception)
                    {

                    }
                }
            }
            /// <summary>
            /// Save all types of list in Isolated Storage
            /// </summary>
            SessionStorage.SaveStatus(VeryHappyList, AppConstants.VeryHappyStatusListName);
            SessionStorage.SaveStatus(HappyList, AppConstants.HappyStatusListName);
            SessionStorage.SaveStatus(OkList, AppConstants.OkStatusListName);
            SessionStorage.SaveStatus(SadList, AppConstants.SadStatusListName);
            SessionStorage.SaveStatus(VerySadList, AppConstants.VerySadStatusListName);
            SessionStorage.SaveStatus(NoCategoryList, AppConstants.NoCateogryStatusListName);

            /// <summary>
            /// Load saved list from Isolated Storage
            /// </summary>
            var s = SessionStorage.LoadStatus(VeryHappyList, AppConstants.VeryHappyStatusListName);
        }

        /// <summary>
        /// Status Handling Function, adds particular feed in particular list
        /// </summary>
        public List<Datum> StatusMessage(int i, UserStatusInfo Data, List<Datum> list)
        {
            var result = Data.Feed.Data[i];
            list.Add(new Datum()
            {
                Caption = result.Caption,
                Message = result.Message,
                FullPicture = result.FullPicture,
                Privacy = result.Privacy,
                Description = result.Description,
                Id = result.Id,
                CreatedTime = result.CreatedTime,
                Likes = result.Likes,
                Comments = result.Comments
            });
            return list;
        }
    }
}

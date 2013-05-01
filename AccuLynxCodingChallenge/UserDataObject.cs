using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccuLynxCodingChallenge
{
    public class UserDataObject
    {
        private int user_id;

        private string display_name;

        private int reputation;

        private string user_type;

        private string profile_image;

        private string link;

        public void Set_User_Id(int userID)
        {
            user_id = userID;
        }

        public int Get_User_Id()
        {
            return user_id;
        }

        public void Set_Display_Name(string name)
        {
            display_name = name;
        }

        public string Get_Display_Name()
        {
            return display_name;
        }

        public void Set_Profile_Image(string imageURI)
        {
            profile_image = imageURI;
        }

        public string Get_Profile_Image()
        {
            return profile_image;
        }
    }
}
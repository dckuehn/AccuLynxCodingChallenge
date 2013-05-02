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
        public string link;

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

        public void Set_Reputation(int userReputation)
        {
            reputation = userReputation;
        }

        public int Get_Repuation()
        {
            return reputation;
        }

        public void Set_User_TYpe(string userType)
        {
            user_type = userType;
        }

        public string Get_User_Type()
        {
            return user_type;
        }

        public void Set_User_Image(string profileImageURI)
        {
            profile_image = profileImageURI;
        }

        public string Get_User_Image()
        {
            return profile_image;
        }

        public void Set_User_Link(string userURI)
        {
            link = userURI;
        }

        public string Get_User_Link()
        {
            return link;
        }
    }
}
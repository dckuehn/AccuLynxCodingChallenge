using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccuLynxCodingChallenge
{



    public class QuestionDataObject
    {

        private int question_id;

        private int last_edit_date;
        private int creation_date;
        private int last_activity_date;

        private int score;

        private int answer_count;

        private string title;

        //private string[] tags;

        private int view_count;

        private UserDataObject user;

        private string link;

        private Boolean is_answered;


        public void Set_Question_Id(int id)
        {
            question_id = id;
        }

        public int Get_Question_ID()
        {
            return question_id;
        }

        public void Set_Title(string questionTitle)
        {
            title = questionTitle;
        }

        public string Get_Title()
        {
            return title;
        }

        public void Set_Link(string questionLink)
        {
            link = questionLink;
        }

        public void Set_Answer_Count(int numberOfAnswers)
        {
            answer_count = numberOfAnswers;
        }

        public int Get_Answer_Count()
        {
            if (is_answered != null)
            {
                if (is_answered == false)
                    return 0;
                else
                    return answer_count;
            }
            else
                return answer_count;
        }

        public void Set_User(UserDataObject questionAsker)
        {
            user = questionAsker;
        }

        public UserDataObject Get_User()
        {
            return user;
        }

        public void Set_Score(int questionScore)
        {
            score = questionScore;
        }

        public int Get_Score()
        {
            return score;
        }
    }
}
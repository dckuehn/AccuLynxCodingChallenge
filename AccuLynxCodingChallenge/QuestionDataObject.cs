using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccuLynxCodingChallenge
{


    /* QuestionDataObject matches objects contained in
     * the json Object array "items".  All fields are named
     * after their asscoiated json attributes.
     */
    public class QuestionDataObject
    {

        private int question_id;

        // Not going to worry about these right now. Or ever. :(
        /*
        private int last_edit_date;
        private int creation_date;
        private int last_activity_date { get; set; }
        */

        private int score;
        private int answer_count;
        public string title;

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

        public void Set_View_Count(int count)
        {
            view_count = count;
        }

        public int Get_View_Count()
        {
            return view_count;
        }

        public void Set_Link(string questionLink)
        {
            link = questionLink;
        }

        public string Get_Link()
        {
            return link;
        }

        public void Set_Answer_Count(int numberOfAnswers)
        {
            answer_count = numberOfAnswers;
        }

        public int Get_Answer_Count()
        {
            if (is_answered == false)
                return 0;
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

        public void Set_Is_Answered(Boolean answered)
        {
            is_answered = answered;
        }

        public Boolean Get_Is_Answered()
        {
            return is_answered;
        }
    }
}
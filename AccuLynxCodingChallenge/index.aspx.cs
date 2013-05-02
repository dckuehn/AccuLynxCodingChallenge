using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.IO.Compression;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace AccuLynxCodingChallenge
{
    public partial class index : System.Web.UI.Page
    {
        List<QuestionDataObject> questionList = new List<QuestionDataObject>();


        protected void Page_Load(object sender, EventArgs e)
        {

            string jsonURL;
            jsonURL = "https://api.stackexchange.com/2.1/questions?order=desc&sort=activity&site=stackoverflow";
            
            string jsonString = Do_Web_Request(jsonURL);

            Parse_JSON(jsonString);

        }

        /*
         * This method creates the web request, and returns the entire json String for parsing.
         * 
         */
        protected string Do_Web_Request(string jsonURL)
        {

            //Create a Request
            WebRequest jsonRequest = WebRequest.Create(jsonURL) as WebRequest;

            jsonRequest.Method = WebRequestMethods.Http.Get;
            jsonRequest.ContentType = "application/json; charset=UTF8";
            
            //Get the Response
            HttpWebResponse jsonResponse = (HttpWebResponse)jsonRequest.GetResponse();

            string jsonString = ExtractJsonResponse(jsonResponse);

            return jsonString;
        }

        /* This method unzips the the json provided the by WebRequest
         * 
         */
        private string ExtractJsonResponse(WebResponse response)
        {
            string json;

            var outStream = new MemoryStream();
            var zipStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);

            zipStream.CopyTo(outStream);
            outStream.Seek(0, SeekOrigin.Begin);

            using (var reader = new StreamReader(outStream, System.Text.Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }

            return json;

        }

        /* This method parses the Json and creates Question/User objects.
         *  It also keeps track of certain information regarding highest scores
         *  and highest reputation.
         *  
         *  I choose to leave a lot of the unrequired attributes unimplemented, but
         *  the logic exists in the objects to easily implement these if necessary.
         */
        protected void Parse_JSON(string jsonString)
        {
            JsonTextReader jsonReader = new JsonTextReader(new StringReader(jsonString));

            int numberOfQuestions = 0;
            int highestScore = 0;
            int highestScoreId = 0;
            int totalReputation = 0;
            int highestReputation = 0;
            int highestReputationId = 0;

            while (jsonReader.Read())
            {
                if (jsonReader.Value == null)
                    continue;

                if (jsonReader.Value.ToString() == "question_id")
                {

                    QuestionDataObject newQuestion = new QuestionDataObject();
                    UserDataObject newUser = new UserDataObject();

                    bool finishedQuestion = false;
                    bool skippedUserLink = false;

                    while (jsonReader.Read())
                    {

                        //Parse Question
                        if (jsonReader.Value == null)
                            continue;

                        string switchable = jsonReader.Value.ToString();
                        switch (switchable)
                        {
                            case "last_edit_date":
                                break;
                            case "create_date":
                                break;
                            case "last_activity_date":
                                break;
                                //required
                            case "score":
                                jsonReader.Read();
                                int score = int.Parse(jsonReader.Value.ToString());
                                newQuestion.Set_Score(score);
                                if (score > highestScore)
                                {
                                    highestScore = score;
                                    highestScoreId = numberOfQuestions;
                                }
                                break;
                                //required
                            case "answer_count":
                                jsonReader.Read();
                                int answer_count = int.Parse(jsonReader.Value.ToString());
                                newQuestion.Set_Answer_Count(answer_count);
                                break;
                                //required
                            case "title":
                                jsonReader.Read();
                                string title = jsonReader.Value.ToString();
                                newQuestion.Set_Title(title);
                                break;
                            case "tags":
                                break;
                            case "view_count":
                                break;
                            case "owner":
                                break;
                            case "user_id":
                                break;
                            case "display_name":
                                jsonReader.Read();
                                string name = jsonReader.Value.ToString();
                                newUser.Set_Display_Name(name);
                                break;
                            case "reputation":
                                jsonReader.Read();
                                int reputation = int.Parse(jsonReader.Value.ToString());
                                totalReputation += reputation;

                                if (reputation > highestReputation)
                                {
                                    highestReputation = reputation;
                                    highestReputationId = numberOfQuestions;
                                }
                                break;
                            case "user_type":
                                break;
                                //required
                            case "profile_image":
                                jsonReader.Read();
                                string url = jsonReader.Value.ToString();
                                newUser.Set_Profile_Image(url);
                                break;
                                //Skipping this link to because it will miss the other link
                            //case "link":
                              //  break;
                            case "accept_rate":
                                break;
                                //required, two items named link, first will skip, set skipped to true
                                // second link will be taken as question's individual link
                            case "link":
                                if (skippedUserLink)
                                {
                                    jsonReader.Read();
                                    string link = jsonReader.Value.ToString();
                                    newQuestion.Set_Link(link);
                                    finishedQuestion = true;
                                }
                                skippedUserLink = true;
                                break;
                        }
                        if (finishedQuestion)
                            break;
                    }

                    // Connect User and Question
                    newQuestion.Set_User(newUser);
                    // Add Question to List
                    questionList.Add(newQuestion);

                    numberOfQuestions++;
                }
            }

            Set_Question(questionList.ElementAt(highestScoreId).Get_Title(), highestScore);
            Set_Total_Reputation(totalReputation);
            Set_User(questionList.ElementAt(highestReputationId).Get_User().Get_Display_Name(), highestReputation);


            //Add each question to form
            foreach (QuestionDataObject question in questionList){
                Add_Question_To_List(question);
            }
            //Done!!
        }

        /* Sets the user label with the username of the user with the most reputation.
         * Also outputs the reputation number
         */ 
        protected void Set_User(string username, int highestReputation)
        {
            userLabel.Text = username;
            jsonLabel.Text = highestReputation.ToString();

        }

        /* Sets the question label with the title of the question with the highest score
        * Also outputs the score
        */ 
        protected void Set_Question(string question, int score)
        {
           questionLabel.Text = question;
           questionScore.Text = score.ToString();
        }

        // Set's the total reputation label
        protected void Set_Total_Reputation(int reputation)
        {
            reputationSumLabel.Text = reputation.ToString();
        }

        /*
         * This method takes a QuestionDataObject and addes the necessary
         * information to the page.  Also adds some extra styling and
         * formatting.
         */
        protected void Add_Question_To_List(QuestionDataObject question)
        {
            //Gravater image
            Image gravatar = new Image();
            gravatar.ImageUrl = question.Get_User().Get_Profile_Image();
            gravatar.Attributes.Add("style", "float:left; padding:5px; height:80px; width:80px;");

            //Question title
            Label titleLabel = new Label();
            string title = "Question: " + question.Get_Title() + "<br/>";
            titleLabel.Text = title;

            //link
            Label linkLabel = new Label();
            string url = question.Get_Link();
            linkLabel.Text = "<a href=" + url + ">  " + url + "</a><br/>";

            //number of answers
            Label answersLabel = new Label();
            answersLabel.Text = "Number of Answers: " + question.Get_Answer_Count().ToString() + "<br/>";

            //total score
            Label scoreLabel = new Label();
            scoreLabel.Text = "Score: " + question.Get_Score().ToString() + "<br/>";

            //Horizontal row for formatting
            Label horizontalRow = new Label();
            horizontalRow.Text = "<hr>";

            form1.Controls.Add(gravatar);
            form1.Controls.Add(titleLabel);
            form1.Controls.Add(linkLabel);
            form1.Controls.Add(answersLabel);
            form1.Controls.Add(scoreLabel);
            form1.Controls.Add(horizontalRow);

        }
    }
}
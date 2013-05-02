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


            Set_User("dckuehn");

            Set_Question("How to write a simple ASP.NET page in C#?");

            Set_Total_Repuation(300);

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

        protected void Parse_JSON(string jsonString)
        {
            JsonTextReader jsonReader = new JsonTextReader(new StringReader(jsonString));

            int numberOfQuestions = 0;
            int highestScore = 0;
            int highestScoreId = 0;
            int totalReputation = 0;

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
                                Set_Question(title);
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
                                break;
                            case "reputation":
                                break;
                            case "user_type":
                                break;
                                //required
                            case "profile_image":
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

        //    Set_Question(questionList.ElementAt(highestScoreId--).Get_Title());
        //    Set_Total_Repuation(totalReputation);
            jsonLabel.Text = numberOfQuestions.ToString();  
        }



        protected void Set_User(string username)
        {
            userLabel.Text = username;
        }

        protected void Set_Question(string question)
        {
           
           questionLabel.Text = question;
        }

        protected void Set_Total_Repuation(int reputation)
        {
            reputationSumLabel.Text = reputation.ToString();
        }
    }
}
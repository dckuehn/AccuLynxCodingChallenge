using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;

using System.Runtime.Serialization.Json;

namespace AccuLynxCodingChallenge
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string jsonURL;
            jsonURL = "https://api.stackexchange.com/2.1/questions?order=desc&sort=activity&site=stackoverflow";
            
            string jsonString = Do_Web_Request(jsonURL);

            Parse_JSON(jsonString);

            Set_User("dckuehn");

            Set_Question("How to write a simple ASP.NET page in C#?");

            Set_Total_Repuation(300);
        }

        /*
         * This method creates the web request, and returns the entire json String for parsing.
         * 
         */
        protected string Do_Web_Request(string jsonURL)
        {
            WebRequest jsonRequest;

            jsonRequest = WebRequest.Create(jsonURL);

            jsonRequest.ContentType = "application/json; charset=utf-8";

            Stream jsonStream;

            jsonStream = jsonRequest.GetResponse().GetResponseStream();

            StreamReader jsonReader = new StreamReader(jsonStream);

            string jsonString = jsonReader.ReadToEnd();

            jsonLabel.Text = jsonString.ToString();

            return jsonString;
        }

        protected void Parse_JSON(string jsonString)
        {

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
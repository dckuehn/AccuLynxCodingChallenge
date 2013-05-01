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

            Boolean foundItems = false;
            while (jsonReader.Read())
            {
                if (jsonReader.Value == null)
                    continue;

                if (foundItems == true)
                {
                    jsonReader.Read();
                    jsonLabel.Text = jsonReader.Value.ToString();
                    foundItems = false;
                }
                if (jsonReader.Value.ToString() == "items")
                {
                    foundItems = true;
                }

               // jsonLabel.Text = jsonReader.Value.ToString();

            }
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
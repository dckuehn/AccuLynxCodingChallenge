using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccuLynxCodingChallenge
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            question.Text = "How do I write a basic ASP.Net page in C#?";
            user.Text = "dckuehn";
            reputationSum.Text = "3000";
        }
    }
}
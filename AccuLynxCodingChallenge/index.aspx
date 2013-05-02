<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AccuLynxCodingChallenge.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AccuLynx Junior Developer Coding Challenge</title>
</head>
<body>
        <form id="form1" runat="server">

            <h1>Junior Developer Challenge</h1>
            <p>
            This web page was written in Visual C# on Visual Studio 2012.  It makes a webrequest to to StackOverflow.com, unzips, and parses the returned JSON, keeping track of specific information.  It then displays certain information, including a list of all recent questions, with the most recently asked questions displayed first.
            </p><br />
            <br />
            The Question with the highest score:
            <asp:Label ID="questionLabel" runat="server" Text="Question"></asp:Label>
            &nbsp;with a score of 
             <asp:Label ID="questionScore" runat="server" Text="score"></asp:Label>
            <br />
            The sum of all the repuations is :
            <asp:Label ID="reputationSumLabel" runat="server" Text="Reputation"></asp:Label>
            <br />
            The user with the most repuation is : <asp:Label ID="userLabel" runat="server" Text="User"></asp:Label>
            &nbsp;with an astounding* 
             <asp:Label ID="jsonLabel" runat="server" Text="json"></asp:Label>
                &nbsp;reputation!<br />
            <br />
            <br />
            <br />
            *- actual reputation may or may not be astounding.<br />
            <br />
            <br />
            <br />
            <p>A list of all the most recent questions:
                </p>

        </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AccuLynxCodingChallenge.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AccuLynx Junior Developer Coding Challenge</title>
</head>
<body>
        AccuLynx Junior Developer Coding Challenge!<br />
        <br />
        <br />
        The Question with the highest score:
        <asp:Label ID="questionLabel" runat="server" Text="Question"></asp:Label>
        <br />
        <br />
        The user with the most repuation is : <asp:Label ID="userLabel" runat="server" Text="User"></asp:Label>
        <br />
        <br />
        The sum of all the repuations is :
        <asp:Label ID="reputationSumLabel" runat="server" Text="Reputation"></asp:Label>
        <br />
        <br />
        <br />
        Here goes the list of the most recent questions.<br />
        <br />
        And here is all the JSON?: 
         <asp:Label ID="jsonLabel" runat="server" Text="json"></asp:Label>
</body>
</html>

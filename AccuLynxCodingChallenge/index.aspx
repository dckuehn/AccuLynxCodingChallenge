<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AccuLynxCodingChallenge.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AccuLynx Junior Developer Coding Challenge</title>
</head>
<body>
        <form id="form1" runat="server">
        AccuLynx Junior Developer Coding Challenge!<br />
        <br />
        <br />
        The Question with the highest score:
        <asp:Label ID="questionLabel" runat="server" Text="Question"></asp:Label>
        &nbsp;with a score of 
         <asp:Label ID="questionScore" runat="server" Text="score"></asp:Label>
        <br />
        <br />
        The user with the most repuation is : <asp:Label ID="userLabel" runat="server" Text="User"></asp:Label>
        &nbsp;with an astounding* 
         <asp:Label ID="jsonLabel" runat="server" Text="json"></asp:Label>
            &nbsp;reputation!<br />
        <br />
        The sum of all the repuations is :
        <asp:Label ID="reputationSumLabel" runat="server" Text="Reputation"></asp:Label>
        <br />
        <br />
            *- actual reputation may or may not be astounding.<br />
            <br />
            <br />
            <br />
&nbsp;<p>A list of all the most recent questions:
                &nbsp;</p>

        </form>
</body>
</html>

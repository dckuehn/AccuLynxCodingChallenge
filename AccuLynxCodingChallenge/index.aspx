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
        <asp:Label ID="question" runat="server" Text="Question"></asp:Label>
        <br />
        <br />
        The user with the most repuation is : <asp:Label ID="user" runat="server" Text="User"></asp:Label>
        <br />
        <br />
        The sum of all the repuations is :
        <asp:Label ID="reputationSum" runat="server" Text="Reputation"></asp:Label>
        <br />
        <br />
        <br />
        Here goes the list of the most recent questions.</form>
</body>
</html>

<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Application.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="H2" runat="server">My name.</h2>
    <h3>Your application description page.</h3>
    <p>
        <asp:TextBox ID="UserInput" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="OnButtonClicked" />
    </p>
    <p id="URLDisplayMessage" runat="server"></p>
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
</asp:Content>

<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Application.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2 id="H2" runat="server">My name.</h2>
    <h3>Your application description page.</h3>
    <p>
        <p>
            Email:
            <asp:TextBox ID="LoginEmailAddress" runat="server"  OnPreRender="FillEmailField" OnTextChanged="IsValidEmailAddress"/>
        </p>

        <p>
            Password:
            <asp:TextBox ID="LoginPassword" runat="server"
                OnPreRender="FillPasswordField"
                OnTextChanged="ValidatePassword" />
        </p>
        
        <p>
            Url:
            <asp:TextBox ID="URLAddress" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Go"
                OnPreRender="FillURLField"
                OnClick="GoToURL" />
        </p>

    </p>
    <p></p>
    
    <p id="URLDisplayMessage" runat="server"></p>
    <p id="EmailDisplayMessage" runat="server"></p>
    <p id="PasswordDisplayMessage" runat="server"></p>
    <p id="Redirecting" runat="server"></p>
    <p id="ResponseStatusDescription" runat="server"></p>
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
</asp:Content>

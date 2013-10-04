<%@ Page Title="" Language="C#" MasterPageFile="~/Plain.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ConnectGadget.Security.Login2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="requestCredentialsPanel">
        <table>
            <tr>
                <td>User ID:</td>
                <td><asp:TextBox runat="server" ID="userIdTextBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Button runat="server" ID="LoginButton" Text="Login" OnClick="LoginButton_Click" /></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label runat="server" ID="Feedback" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

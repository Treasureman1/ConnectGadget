<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ConnectGadget._Default" %>

<%@ Register src="Controls/ScreenShow.ascx" tagname="ScreenShow" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <uc1:ScreenShow ID="ScreenShow1" runat="server" />
    </p>
</asp:Content>

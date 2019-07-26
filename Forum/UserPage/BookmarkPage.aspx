<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UserPageMaster.Master" AutoEventWireup="true" CodeBehind="BookmarkPage.aspx.cs" Inherits="Forum.UserPage.BookmarkPage" %>

<%@ Register Src="~/UserControl/PostPreview.ascx" TagPrefix="uc1" TagName="PostPreview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PostPreview runat="server" id="PostPreview" />
</asp:Content>

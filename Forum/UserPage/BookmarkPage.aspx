<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UserPageMaster.Master" AutoEventWireup="true" CodeBehind="BookmarkPage.aspx.cs" Inherits="Forum.UserPage.BookmarkPage" %>

<%@ Register Src="~/UserControl/BookmarkControl.ascx" TagPrefix="uc1" TagName="BookmarkControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="posts scrollbar">
           <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div> 
</asp:Content>
